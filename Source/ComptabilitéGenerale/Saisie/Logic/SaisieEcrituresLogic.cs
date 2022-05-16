using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows;
using System.Windows.Forms;
using Utilitaire;
using CoucheAcceeDonnees;

namespace SaisieCompta
{
    class SaisieEcrituresLogic
    {
       
        Ecritures ecritures;
        Comptes comptes;
        Journaux journaux;
        LibellesAutomatiques libelles;


        public SaisieEcrituresLogic(CAD db)
        {
          
            db.Fill_Comptes();
            db.Fill_Ecritures();
            db.Fill_LibellesAutomatiques();
            db.Fill_Journaux();

            ecritures = new Ecritures(db);
            comptes = new Comptes(db);
            libelles = new LibellesAutomatiques(db);
            journaux = new Journaux(db);

       }

        

        public int Enregister(ref SaisieEcrituresVM view_model, EcritureModel ecriture, bool cpa)
        {
           
            int ret = ecritures.Enregister(ecriture, cpa);
            // datagrid
            if (ret == 0)
            {
                
                LigneEcriture Ligne = new LigneEcriture();
                Ligne.JourMois = ecriture.JourMois;
                Ligne.Compte = ecriture.Compte;
                Ligne.CPartie = ecriture.ContrePartie;
                Ligne.N_Ordre = ecriture.N_Ordre;
                //Ligne.La = ecriture.CodeLibelleAutomatique;
                Ligne.Libelle = ecriture.Libelle;
                Ligne.Libelle2 = ecriture.Libelle2;

                double mnt = double.Parse(ecriture.Montant);
                if (ecriture.Debit == true)
                {
                    Ligne.DC = "D";
                    view_model.mouvements_debit += mnt;
                    view_model.cumul_debit += mnt;
                }
                else
                {
                    Ligne.DC = "C";
                    view_model.mouvements_credit += mnt;
                    view_model.cumul_credit += mnt;
                }
                Ligne.Montant = Fonctions.format1(mnt.ToString());
                view_model.Lignes.Add(Ligne);
                Console.WriteLine(" Ligne 1");
                if (cpa == true)
                {
                    LigneEcriture Ligne1 = new LigneEcriture();
                    Ligne1.JourMois = ecriture.JourMois;
                    Ligne1.Compte = ecriture.Compte;
                    Ligne1.CPartie = ecriture.ContrePartie;
                    Ligne1.N_Ordre = ecriture.N_Ordre;
                    //Ligne1.La = ecriture.CodeLibelleAutomatique;
                    Ligne1.Libelle = ecriture.Libelle;
                    Ligne1.Libelle2 = ecriture.Libelle2;
                    mnt = double.Parse(ecriture.Montant);;
                    if (ecriture.Debit == true)
                    {
                        Ligne1.DC = "C";
                        view_model.mouvements_credit += mnt;
                        view_model.cumul_credit += mnt;
                    }
                    else
                    {
                        Ligne1.DC = "D";
                        view_model.mouvements_debit += mnt;
                        view_model.cumul_debit += mnt;
                    }
                    Ligne1.Montant = Fonctions.format1(mnt.ToString());
                    view_model.Lignes.Add(Ligne1);

                }
                Console.WriteLine(" Ligne 2");
            }
            else {
                Console.WriteLine("13");
            }

            return ret;

                
          
        }

        public int get_compte_intitule(ref SaisieEcrituresVM view_model, string Compte)
        {
            CompteModel model = new CompteModel();
            model.Compte = Compte;

            int ret = comptes.Consulter(ref model);

            if ( ret == 0 ) view_model.compte_intitule = model.Intitule;

            return ret;
        }

        public int get_journal(ref SaisieEcrituresVM view_model, string Code)
        {
            JournalModel model = new JournalModel();
            model.Code = Code;

            int ret = journaux.Consulter(ref model);

            if (ret == 0)
            {
                view_model.journal_intitule = model.Intitule;
                view_model.contre_partie = model.Compte;
                view_model.cpa = model.ContrePartieAutomatique;
            }

            return ret;

           
        }

        public int get_libelle_intitule(ref SaisieEcrituresVM view_model, string code)
        {
            //LibelleAutomatiqueModel model = new LibelleAutomatiqueModel();
            CompteModel model = new CompteModel();
            model.Compte = code;

            //int ret = libelles.Consulter(ref model);
            int ret = comptes.Consulter(ref model);
            if (ret == 0) view_model.libelle_intitule = model.Intitule;

            return ret;
        }

        public void Afficher_Mouvements(ref SaisieEcrituresVM view_model,string idj, string idate1, string idate2)
        {
            view_model.Lignes.Clear();
            view_model.mouvements_debit = 0;
            view_model.mouvements_credit = 0;

            string req = "CodeJournal =" + idj + " and iDate <=" + idate2 + "and iDate >=" + idate1;
            string tri = "N_Ordre";

            IList<EcritureModel> ecrts = ecritures.Consulter(req, tri);

            for (int i = 0; i < ecrts.Count; i++ )
            {
                LigneEcriture Ligne = new LigneEcriture();
                Ligne.JourMois = ecrts[i].JourMois;
                Ligne.Compte = ecrts[i].Compte;
                Ligne.CPartie = ecrts[i].ContrePartie;
                Ligne.N_Ordre = ecrts[i].N_Ordre;
               // Ligne.La = ecrts[i].CodeLibelleAutomatique;
                Ligne.Libelle = ecrts[i].Libelle;
                Ligne.Libelle2 = ecrts[i].Libelle2;
                bool st = ecrts[i].Debit;
                double mnt = double.Parse(ecrts[i].Montant);
                if (st == true)
                {
                    Ligne.DC = "D";
                    view_model.mouvements_debit += mnt;
                }
                else
                {
                    Ligne.DC = "C";
                    view_model.mouvements_credit += mnt;
                }
                Ligne.Montant = Fonctions.format1(mnt.ToString());
                view_model.Lignes.Add(Ligne);

            }

            return ;


            
        }

        public void Afficher_Mouvements_Mois(ref SaisieEcrituresVM view_model, string idj, string mois, string an)
        {
            view_model.Lignes.Clear();
            view_model.mouvements_debit = 0;
            view_model.mouvements_credit = 0;
            string ddate = "0/" + mois + "/" + an;
            string fdate = "31/" + mois + "/" + an;
            int idate1 = Fonctions.DateToInt(ddate);
            int idate2 = Fonctions.DateToInt(fdate);

            string req = "CodeJournal =" + idj + " and iDate <=" + idate2 + "and iDate >=" + idate1;
            string tri = "N_Ordre";

            IList<EcritureModel> ecrts = ecritures.Consulter(req, tri);

            for (int i = 0; i < ecrts.Count; i++)
            {
                LigneEcriture Ligne = new LigneEcriture();
                Ligne.JourMois = ecrts[i].JourMois;
                Ligne.Compte = ecrts[i].Compte;
                Ligne.CPartie = ecrts[i].ContrePartie;
                Ligne.N_Ordre = ecrts[i].N_Ordre;
                //Ligne.La = ecrts[i].CodeLibelleAutomatique;
                Ligne.Libelle = ecrts[i].Libelle;
                Ligne.Libelle2 = ecrts[i].Libelle2;
                bool st = ecrts[i].Debit;
                double mnt = double.Parse(ecrts[i].Montant);
                if (st == true)
                {
                    Ligne.DC = "D";
                    view_model.mouvements_debit += mnt;
                }
                else
                {
                    Ligne.DC = "C";
                    view_model.mouvements_credit += mnt;
                }
                Ligne.Montant = Fonctions.format1(mnt.ToString());
                view_model.Lignes.Add(Ligne);

            }


            return;

        }

        public void Afficher_Cumuls(ref SaisieEcrituresVM view_model, string idj)
        {
            view_model.cumul_debit = 0;
            view_model.cumul_credit = 0;

            string req = "CodeJournal =" + idj;
            string tri = "N_Ordre";

            IList<EcritureModel> ecrts = ecritures.Consulter(req, tri);

            for (int i = 0; i < ecrts.Count; i++ )
            {
                bool st = ecrts[i].Debit;
                double mnt = double.Parse(ecrts[i].Montant);
                if (st == true) view_model.cumul_debit += mnt;
                else view_model.cumul_credit += mnt;

            }

        }



    }
}
