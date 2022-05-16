using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using CoucheAcceeDonnees;
using Utilitaire;

namespace LivresCompta
{
    public class AffichageJournauxLogic
    {
        
        Ecritures ecritures;
        Comptes comptes;
        Journaux journaux;
     
        private string dDate;
               
               
        public AffichageJournauxLogic(CAD db, string dDate0)
        {
             
            dDate = dDate0;
               
            db.Fill_Ecritures();
            db.Fill_Journaux();
            db.Fill_Comptes();

            ecritures = new Ecritures(db);
            comptes = new Comptes(db);
            journaux = new Journaux(db);

            Anouv2Jour(dDate);
       }

       
        void Anouv2Jour(string dDate)
        {

            JournalModel jmodel = new JournalModel();
            jmodel.Code = "9000";
            jmodel.Intitule = "Journal A nouveau";

            journaux.Add(jmodel);

            IList<CompteModel> cmodels = comptes.Consulter("", "Compte");
           
            for(int i = 0; i < cmodels.Count;  i++)
            {
                string cmpt = cmodels[i].Compte;
                double mvd = double.Parse(cmodels[i].AnouveauDebit);
                double mvc = double.Parse(cmodels[i].AnouveauCredit);

                EcritureModel ecriture = new EcritureModel();
                ecriture.iDate = Fonctions.DateToInt(dDate).ToString();
                ecriture.Compte = cmpt;
                ecriture.Libelle = "A nouveau au " + dDate;
                ecriture.CodeJournal = "9000";
                ecriture.ContrePartie = "0";
                ecriture.N_Ordre = "0";
                if ((mvd - mvc) > 0)
                {
                    ecriture.Montant = (mvd - mvc).ToString();
                    ecriture.Debit = true;
                    ecritures.Add(ecriture, false);
                }
                if ((mvc - mvd) > 0)
                {
                    ecriture.Montant = (mvc - mvd).ToString();
                    ecriture.Debit = false;
                    ecritures.Add(ecriture, false);
                }

            }
        }

        void Totaux(string code, string ddebut, string dfin, ref JournalVM vm)
        {
                       
            IList<EcritureModel> mecrts;
            if (code == "")
            {
                mecrts = ecritures.Consulter("iDate <=" + dfin + "and iDate >=" + ddebut, "iDate,CodeJournal,N_Ordre");
            }
            else
            {
                mecrts = ecritures.Consulter("CodeJournal = " + code + "and iDate <=" + dfin + "and iDate >=" + ddebut, "iDate,CodeJournal,N_Ordre");
            }

            for (int i = 0; i < mecrts.Count; i++)
            {
                bool deb = mecrts[i].Debit;
                double mnt = double.Parse(mecrts[i].Montant);
                if (deb == true) vm.total_debit += mnt;
                else vm.total_credit += mnt;
                  

            }
            vm.total_debit = vm.total_debit + vm.report_debit;
            vm.total_credit = vm.total_credit + vm.report_credit;


        }


        public JournalVM get_journal(string code, string ddebut, string dfin)
        {
            JournalVM view_model = new JournalVM();

            view_model.code_journal = code;
            view_model.intitule_journal = get_journal_intitule(code);

            Totaux(code, ddebut, dfin, ref view_model);

            IList<EcritureModel> emodels = ecritures.Consulter("CodeJournal = " + code + "and iDate <=" + dfin + "and iDate >=" + ddebut, "iDate,CodeJournal,N_Ordre");

            for (int i = 0; i < emodels.Count; i++ )
            {
                LigneJournal Ligne = new LigneJournal();
                int idjour = int.Parse(emodels[i].CodeJournal);
                if (code != "9000")
                {
                    string exer = emodels[i].Annee;
                    string hdate = emodels[i].JourMois;
                    string[] subs = hdate.Split(new char[] { '/' });
                    long mois = long.Parse(subs[1]);
                    long ordre = long.Parse(emodels[i].N_Ordre);
                    long piece = (idjour * 100 + mois) * 10000 + ordre;
                    Ligne.Piece = piece.ToString().PadLeft(10, '0');
                    Ligne.Contre_Partie = emodels[i].ContrePartie.PadLeft(8, '0');
                    Ligne.Date = hdate + "/" + exer;
                }
                else
                {
                    Ligne.Piece = "";
                    Ligne.Contre_Partie = "";
                    Ligne.Date = dDate;
                }
                Ligne.Compte = emodels[i].Compte.PadLeft(8, '0');
                Ligne.Libelle = emodels[i].Libelle;
                bool deb = emodels[i].Debit;
                if (deb == true)
                {
                    Ligne.Debit = Fonctions.format04(emodels[i].Montant);
                    Ligne.Credit = "";
                }
                else
                {
                    Ligne.Credit = Fonctions.format04(emodels[i].Montant);
                    Ligne.Debit = "";
                }
                view_model.Lignes.Add(Ligne);
            }

            return view_model;

        }

        public JournalVM get_journal_global(string ddebut, string dfin)
        {

            JournalVM view_model = new JournalVM();

            Totaux("", ddebut, dfin, ref view_model);

            view_model.code_journal = "";
            view_model.intitule_journal = "Global";

            IList<EcritureModel> emodels = ecritures.Consulter("CodeJournal = 9000 And " + "iDate <=" + dfin + "and iDate >=" + ddebut, "iDate,CodeJournal,N_Ordre");

            for (int i = 0; i < emodels.Count; i++ )
            {
                LigneJournal Ligne = new LigneJournal();
                int idjour = int.Parse(emodels[i].CodeJournal);
                Ligne.Piece = "";
                Ligne.Contre_Partie = "";
                Ligne.Date = dDate;
                Ligne.Compte = emodels[i].Compte;
                Ligne.Libelle = emodels[i].Libelle;
                bool deb = emodels[i].Debit;
                if (deb == true)
                {
                    Ligne.Debit = Fonctions.format04(emodels[i].Montant);
                    Ligne.Credit = "";
                }
                else
                {
                    Ligne.Credit = Fonctions.format04(emodels[i].Montant);
                    Ligne.Debit = "";
                }
                view_model.Lignes.Add(Ligne);
            }

            IList<EcritureModel> emodels1 = ecritures.Consulter("CodeJournal <> 9000 " + "and iDate <=" + dfin + "and iDate >=" + ddebut, "iDate,CodeJournal,N_Ordre");

            for (int i = 0; i < emodels1.Count; i++ )
            {
                LigneJournal Ligne = new LigneJournal();
                int idjour = int.Parse(emodels1[i].CodeJournal);

                string exer = emodels1[i].Annee;
                string hdate = emodels1[i].JourMois;
                string[] subs = hdate.Split(new char[] { '/' });
                long mois = long.Parse(subs[1]);
                long ordre = long.Parse(emodels1[i].N_Ordre);
                long piece = (idjour * 100 + mois) * 10000 + ordre;
                Ligne.Piece = piece.ToString().PadLeft(10, '0');
                Ligne.Contre_Partie = emodels1[i].ContrePartie.PadLeft(8, '0');
                Ligne.Date = hdate + "/" + exer;

                Ligne.Compte = emodels1[i].Compte.PadLeft(8, '0'); 
                Ligne.Libelle = emodels1[i].Libelle;
                bool deb = emodels1[i].Debit;
                if (deb == true)
                {
                    Ligne.Debit = Fonctions.format04(emodels1[i].Montant);
                    Ligne.Credit = "";
                }
                else
                {
                    Ligne.Credit = Fonctions.format04(emodels1[i].Montant);
                    Ligne.Debit = "";
                }
                view_model.Lignes.Add(Ligne);
            }

            return view_model;

        }

        public string[] get_codes_journaux()
        {
            IList<JournalModel> jours = journaux.Consulter("", "Code");
            string[] codes = new string[jours.Count];

            for (int i = 0; i < codes.Length; i++ )
            {
                codes[i] = jours[i].Code;


            }

            return codes;

        }

        public string[] get_codes_journaux(string code_debut, string code_fin)
        {
            string req = " Code >= " + code_debut + " AND Code <= " + code_fin;
            IList<JournalModel> jours = journaux.Consulter(req, "Code");
            string[] codes = new string[jours.Count];

            for (int i = 0; i < codes.Length; i++)
            {
                codes[i] = jours[i].Code;


            }

            return codes;

        }

        public string get_journal_intitule(string idj)
        {
            JournalModel jmodel = new JournalModel();
            jmodel.Code = idj;

            journaux.Consulter(ref jmodel);

            return jmodel.Intitule;
        }

        

	
    }


}
