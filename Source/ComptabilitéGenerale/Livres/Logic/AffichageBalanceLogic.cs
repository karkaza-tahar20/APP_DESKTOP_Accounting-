using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections;
using Utilitaire;
using CoucheAcceeDonnees;

namespace LivresCompta
{
    class AffichageBalanceLogic
    {
        
        Ecritures ecritures;
        Comptes comptes;

        private string dDate;
        private string fDate;

        struct donneesTable
        {
            public string compte ;
            public string intl ;
            public string niv ;
            public double anouv;
            public double mdeb;
            public double mcred;
            public double sdeb;
            public double scred;
        }

      
        public AffichageBalanceLogic(CAD db, string dDate0)
        {
            dDate = dDate0;
           
            db.Fill_Ecritures();
            db.Fill_Comptes();

            ecritures = new Ecritures(db);
            comptes = new Comptes(db);
        }
        
        public BalanceVM Balance_General(string compted, string comptef, string fdt)
        {
            fDate = fdt;
            int ifDate = Fonctions.DateToInt(fDate);

            BalanceVM view_model = new BalanceVM();
            view_model.compte_debut = compted;
            view_model.compte_fin = comptef;
            view_model.date = fdt;



            /* ........ Construction du dictionnaire et le tableau structure données ........ */

            Dictionary<string, int> dictio = new Dictionary<string, int>();

            string req_cmpt = "Compte >=" + compted + "and Compte <=" + comptef;
            string tri_cmpt = "Compte";

            IList<CompteModel> cmpts = comptes.Consulter(req_cmpt,tri_cmpt);

            donneesTable[] dn_tables = new donneesTable[cmpts.Count];

            for (int i = 0; i < cmpts.Count; i++ )
            {
                double anv = 0;

                if (cmpts[i].AnouveauCredit != "") anv -= double.Parse(cmpts[i].AnouveauCredit);
                if (cmpts[i].AnouveauDebit != "") anv += double.Parse(cmpts[i].AnouveauDebit);

                donneesTable dn_table = new donneesTable();

                dn_table.compte = cmpts[i].Compte;
                dn_table.intl = cmpts[i].Intitule;
                dn_table.niv = cmpts[i].Niveau;
                dn_table.anouv = anv;
                dn_table.mdeb = 0;
                dn_table.mcred = 0;

                dn_tables[i] = dn_table;
                dictio.Add(dn_table.compte, i);
                
            } 

           
            /*........... calcul mouvements ....................*/

            string req_ecrt = "iDate <=" + ifDate.ToString() + " AND Compte >=" + compted + "and Compte <=" + comptef;
           
            string tri_ecrt = "";

            IList<EcritureModel> ecrts = ecritures.Consulter(req_ecrt, tri_ecrt);
            
            for (int i = 0; i < ecrts.Count; i++ )
            {

                string cmpt = ecrts[i].Compte;
                if (dictio.ContainsKey(cmpt) == true)
                {
                    bool debit = ecrts[i].Debit;
                    double mnt = double.Parse(ecrts[i].Montant);
                    int index = dictio[cmpt];
                    if (debit == true) dn_tables[index].mdeb += mnt;
                    else dn_tables[index].mcred += mnt;
                }
            }

            /*........... calcul soldes et totaux niveau 2 ....................*/
            double tanouv, tdebit, tcredit, sdebit, scredit;
            tanouv = tdebit = tcredit = sdebit = scredit = 0;

            for (int j = 0; j < dn_tables.Length; j++)
            {
                if (dn_tables[j].niv == "2")
                {
                    dn_tables[j].anouv = tanouv;
                    dn_tables[j].mdeb = tdebit;
                    dn_tables[j].mcred = tcredit;
                    dn_tables[j].sdeb = sdebit;
                    dn_tables[j].scred = scredit;
                    tanouv = tdebit = tcredit = sdebit = scredit = 0; 
                }
                if (dn_tables[j].niv == "1")
                {
                    if (dn_tables[j].anouv >= 0)
                    {
                        if (dn_tables[j].anouv + dn_tables[j].mdeb >= dn_tables[j].mcred)
                        {
                            dn_tables[j].sdeb = dn_tables[j].anouv + dn_tables[j].mdeb - dn_tables[j].mcred;
                            dn_tables[j].scred = 0;
                        }
                        else
                        {
                            dn_tables[j].sdeb = 0;
                            dn_tables[j].scred = dn_tables[j].mcred - dn_tables[j].anouv - dn_tables[j].mdeb;
                        }

                    }
                    if (dn_tables[j].anouv < 0)
                    {
                        if (dn_tables[j].mcred - dn_tables[j].anouv >= dn_tables[j].mdeb)
                        {
                            dn_tables[j].sdeb = 0;
                            dn_tables[j].scred = dn_tables[j].mcred - dn_tables[j].anouv - dn_tables[j].mdeb;
                        }
                        else
                        {
                            dn_tables[j].sdeb = dn_tables[j].mdeb - dn_tables[j].mcred + dn_tables[j].anouv;
                            dn_tables[j].scred = 0;
                        }

                        
                    }

                    tanouv += dn_tables[j].anouv;
                    tdebit += dn_tables[j].mdeb;
                    tcredit += dn_tables[j].mcred;
                    sdebit += dn_tables[j].sdeb;
                    scredit += dn_tables[j].scred;

                    view_model.total_anvouveau += dn_tables[j].anouv; view_model.total_mvts_debit += dn_tables[j].mdeb;
                    view_model.total_mvts_credit += dn_tables[j].mcred; view_model.total_solde_debit += dn_tables[j].sdeb; view_model.total_solde_credit += dn_tables[j].scred;
                }

                
                if ((dn_tables[j].anouv != 0) || (dn_tables[j].mdeb != 0) || (dn_tables[j].mcred != 0))
                {
                    LigneBalance Ligne = new LigneBalance();

                    Ligne.Compte = dn_tables[j].compte;
                    Ligne.Designation = dn_tables[j].intl;
                    Ligne.Anouv = Fonctions.format04(dn_tables[j].anouv.ToString());
                    Ligne.Niv = dn_tables[j].niv;
                    Ligne.Mvtdeb = Fonctions.format04(dn_tables[j].mdeb.ToString());
                    Ligne.Mvtcred = Fonctions.format04(dn_tables[j].mcred.ToString());
                  
                    double scd = dn_tables[j].sdeb - dn_tables[j].scred;
                    if (scd > 0)
                    {
                        Ligne.Sldeb = Fonctions.format04(scd.ToString());
                        Ligne.Sldcred = "";
                      
                    }
                    else
                    {
                        Ligne.Sldeb = "";
                        Ligne.Sldcred = Fonctions.format04((0 - scd).ToString());
                        
                    }

                    view_model.Lignes.Add(Ligne);
                    

                   
                }


             }
            
            return view_model;

            /*....................................................*/


        }

        public BalanceVM Balance_Resume(string compted, string comptef, string fdt)
        {
            fDate = fdt;
            int ifDate = Fonctions.DateToInt(fDate);

            BalanceVM view_model = new BalanceVM();
            view_model.compte_debut = compted;
            view_model.compte_fin = comptef;
            view_model.date = fdt;

            /* ........ Construction du dictionnaire et le tableau structure données ........ */
           
            Dictionary<string, int> dictio = new Dictionary<string, int>();

            string req_cmpt = "Compte >=" + compted + "and Compte <=" + comptef;
            string tri_cmpt = "Compte";

            IList<CompteModel> cmpts = comptes.Consulter(req_cmpt, tri_cmpt);

            donneesTable[] dn_tables = new donneesTable[cmpts.Count];

            for (int i = 0; i < cmpts.Count; i++)
            {
                double anv = 0;

                if (cmpts[i].AnouveauCredit != "") anv -= double.Parse(cmpts[i].AnouveauCredit);
                if (cmpts[i].AnouveauDebit != "") anv += double.Parse(cmpts[i].AnouveauDebit);

                donneesTable dn_table = new donneesTable();

                dn_table.compte = cmpts[i].Compte;
                dn_table.intl = cmpts[i].Intitule;
                dn_table.niv = cmpts[i].Niveau;
                dn_table.anouv = anv;
                dn_table.mdeb = 0;
                dn_table.mcred = 0;

                dn_tables[i] = dn_table;
                dictio.Add(dn_table.compte, i);

            } 


            /*........... calcul mouvements ....................*/

            string req_ecrt = "iDate <=" + ifDate.ToString() + " AND Compte >=" + compted + "and Compte <=" + comptef;
            string tri_ecrt = "";

            IList<EcritureModel> ecrts = ecritures.Consulter(req_ecrt, tri_ecrt);


            for (int i = 0; i < ecrts.Count; i++ )
            {

                string cmpt = ecrts[i].Compte;
                if (dictio.ContainsKey(cmpt) == true)
                {
                    bool debit = ecrts[i].Debit;
                    double mnt = double.Parse(ecrts[i].Montant);
                    int index = dictio[cmpt];
                    if (debit == true) dn_tables[index].mdeb += mnt;
                    else dn_tables[index].mcred += mnt;
                }
            }


            /*........... calcul soldes et totaux niveau 2 ....................*/
            double tanouv, tdebit, tcredit, sdebit, scredit;
            tanouv = tdebit = tcredit = sdebit = scredit = 0;

            for (int j = 0; j < dn_tables.Length; j++)
            {
                if (dn_tables[j].niv == "2")
                {
                    dn_tables[j].anouv = tanouv;
                    dn_tables[j].mdeb = tdebit;
                    dn_tables[j].mcred = tcredit;
                    dn_tables[j].sdeb = sdebit;
                    dn_tables[j].scred = scredit;
                    
                    LigneBalance Ligne = new LigneBalance();

                    Ligne.Compte = dn_tables[j].compte;
                    Ligne.Designation = dn_tables[j].intl;
                    Ligne.Anouv = Fonctions.format04(dn_tables[j].anouv.ToString());
                    Ligne.Niv = dn_tables[j].niv;
                    Ligne.Mvtdeb = Fonctions.format04(dn_tables[j].mdeb.ToString());
                    Ligne.Mvtcred = Fonctions.format04(dn_tables[j].mcred.ToString());
                    Ligne.Sldeb = Fonctions.format04(dn_tables[j].sdeb.ToString());
                    Ligne.Sldcred = Fonctions.format04(dn_tables[j].scred.ToString());

                    view_model.Lignes.Add(Ligne);
                    
                    tanouv = tdebit = tcredit = sdebit = scredit = 0;
                }

                if (dn_tables[j].niv == "1")
                {
                    if (dn_tables[j].anouv >= 0)
                    {
                        if (dn_tables[j].anouv + dn_tables[j].mdeb >= dn_tables[j].mcred)
                        {
                            dn_tables[j].sdeb = dn_tables[j].anouv + dn_tables[j].mdeb - dn_tables[j].mcred;
                            dn_tables[j].scred = 0;
                        }
                        else
                        {
                            dn_tables[j].sdeb = 0;
                            dn_tables[j].scred = dn_tables[j].mcred - dn_tables[j].anouv - dn_tables[j].mdeb;
                        }

                    }
                    if (dn_tables[j].anouv < 0)
                    {
                        if (dn_tables[j].mcred - dn_tables[j].anouv >= dn_tables[j].mdeb)
                        {
                            dn_tables[j].sdeb = 0;
                            dn_tables[j].scred = dn_tables[j].mcred - dn_tables[j].anouv - dn_tables[j].mdeb;
                        }
                        else
                        {
                            dn_tables[j].sdeb = dn_tables[j].mdeb - dn_tables[j].mcred + dn_tables[j].anouv;
                            dn_tables[j].scred = 0;
                        }


                    }
                    tanouv += dn_tables[j].anouv;
                    tdebit += dn_tables[j].mdeb;
                    tcredit += dn_tables[j].mcred;
                    sdebit += dn_tables[j].sdeb;
                    scredit += dn_tables[j].scred;

                    view_model.total_anvouveau += dn_tables[j].anouv; view_model.total_mvts_debit += dn_tables[j].mdeb;
                    view_model.total_mvts_credit += dn_tables[j].mcred; view_model.total_solde_debit += dn_tables[j].sdeb;
                    view_model.total_solde_credit += dn_tables[j].scred;

                }





            }

            return view_model;

            /*....................................................*/


        }




       
 
       

      

       

    }


}
