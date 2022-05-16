using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Utilitaire;
using CoucheAcceeDonnees;

namespace LivresCompta
{
    public class AffichageGrandLivreLogic
    {
       

        Ecritures ecritures;
        Comptes comptes;
        
        private string dDate;

        public AffichageGrandLivreLogic(CAD db, string dDate0)
        {
           
            dDate = dDate0;
            

            db.Fill_Ecritures();
            db.Fill_Comptes();

            ecritures = new Ecritures(db);
            comptes = new Comptes(db);
        }

        public GrandLivreVM get_grand_livre(string cmpt, string ddt, string fdt)
        {
            double anouvcred, anouvdeb;
            anouvcred = anouvdeb = 0;

            double report_debit = 0;
            double report_credit = 0;
            double mvts_debit = 0;
            double mvts_credit = 0;
            double total_debit = 0;
            double total_credit = 0;
            double solde_debit = 0;
            double solde_credit = 0;
            double anouveau = 0;

            GrandLivreVM view_model = new GrandLivreVM();

            view_model.date_debut = ddt;
            view_model.date_fin = fdt;

            CompteModel model = new CompteModel();
            model.Compte = cmpt;

            int ret = comptes.Consulter(ref model);
            if (ret != 0) throw (new Exception("Compte inexistant !"));

            view_model.compte = cmpt;
            view_model.intitule = model.Intitule;

            int ddebut = Fonctions.DateToInt(ddt);
            int dfin = Fonctions.DateToInt(fdt);

            if (model.AnouveauCredit != "") anouvcred += double.Parse(model.AnouveauCredit);
            if (model.AnouveauDebit != "") anouvdeb += double.Parse(model.AnouveauDebit);

            anouveau = anouvdeb - anouvcred;

            if (ddt == dDate)
            {
                LigneGrandLivre Ligne = new LigneGrandLivre();

                Ligne.Date = dDate;
                Ligne.Code_Journal = "9000";
                Ligne.Contre_Partie = "";
                Ligne.Piece = "";
                Ligne.Libelle = "A nouveau au " + dDate;

                if (anouvdeb - anouvcred >= 0)
                {
                    Ligne.Debit = Fonctions.format04((anouvdeb - anouvcred).ToString());
                    Ligne.Credit = "";
                    mvts_debit += anouvdeb - anouvcred;

                }
                else
                {
                    Ligne.Debit = "";
                    Ligne.Credit = Fonctions.format04((anouvcred - anouvdeb).ToString());
                    mvts_credit += anouvcred - anouvdeb;
                }

                view_model.Lignes.Add(Ligne);
            }
            else
            {
                if (anouvdeb > anouvcred) report_debit += anouvdeb - anouvcred;
                if (anouvcred > anouvdeb) report_credit += anouvcred - anouvdeb;

            }

            string req = "Compte = " + cmpt + "and iDate <" + ddebut.ToString();
            string tri = "";

            IList<EcritureModel> ecrts = ecritures.Consulter(req, tri);

            for (int i = 0; i < ecrts.Count; i ++ )
            {
                bool deb = ecrts[i].Debit;
                double mnt = double.Parse(ecrts[i].Montant);
                if (deb == true) report_debit += mnt;
                else report_credit += mnt;
            }

            req = "Compte = " + cmpt + "and iDate <=" + dfin.ToString() + "and iDate >=" + ddebut.ToString();
            tri = "iDate,CodeJournal,N_Ordre,ContrePartie";

            IList<EcritureModel> ecrts1 = ecritures.Consulter(req, tri);
               
            #region affichage grid

            for (int i = 0; i < ecrts1.Count; i++)
            {
                LigneGrandLivre Ligne = new LigneGrandLivre();

                string exer = ecrts1[i].Annee;
                string hdate = ecrts1[i].JourMois;
                int idjour = int.Parse(ecrts1[i].CodeJournal);
                string[] subs = hdate.Split(new char[] { '/' });
                long mois = long.Parse(subs[1]);
                long ordre = long.Parse(ecrts1[i].N_Ordre);
                long piece = (idjour * 100 + mois) * 10000 + ordre;

                Ligne.Date = hdate + "/" + exer;
                Ligne.Piece = piece.ToString().PadLeft(10, '0');
                Ligne.Code_Journal = ecrts1[i].CodeJournal.PadLeft(4, '0');
                Ligne.Contre_Partie = ecrts1[i].ContrePartie.PadLeft(8, '0');
                Ligne.Libelle = ecrts1[i].Libelle;
                bool deb = ecrts1[i].Debit;
                double mnt = double.Parse(ecrts1[i].Montant);
                if (deb == true)
                {
                    Ligne.Debit = Fonctions.format04(mnt.ToString());
                    Ligne.Credit = "";
                    mvts_debit += mnt;
                }
                else
                {
                    Ligne.Credit = Fonctions.format04(mnt.ToString());
                    Ligne.Debit = "";
                    mvts_credit += mnt;
                }

                view_model.Lignes.Add(Ligne);

            }
            #endregion ( dro.Length > 0 )

            total_debit = mvts_debit + report_debit;
            total_credit = mvts_credit + report_credit;

            if ((mvts_debit + report_debit) > (mvts_credit + report_credit))
            {
                solde_debit = mvts_debit + report_debit - mvts_credit - report_credit;
                view_model.solde = "Solde Débiteur";
            }
            if ((mvts_debit + report_debit) < (mvts_credit + report_credit))
            {
                solde_credit = mvts_credit + report_credit - mvts_debit - report_debit;
                view_model.solde = "Solde Créditeur";
            }

            if ((anouvdeb - anouvcred) >= 0)
            {
                if (ddt == dDate) mvts_debit = mvts_debit - (anouvdeb - anouvcred);

            }
            else
            {
                if (ddt == dDate) mvts_credit = mvts_credit - (anouvcred - anouvdeb);

            }

            view_model.report_debit = report_debit;
            view_model.report_credit = report_credit;
            view_model.mvts_debit = mvts_debit;
            view_model.mvts_credit = mvts_credit;
            view_model.total_debit = total_debit;
            view_model.total_credit = total_credit;
            view_model.solde_debit = solde_debit;
            view_model.solde_credit = solde_credit;
            view_model.anouveau = anouveau;

            if (view_model.Lignes.Count == 0)
            if ((view_model.anouveau != 0) || (view_model.report_debit != 0) || (view_model.report_credit != 0))
            {
               view_model.Lignes.Add(new LigneGrandLivre());
            }



            return view_model;

        }

        public bool grand_livre_exists(string cmpt, string ddt, string fdt)
        {
            bool b = false;

            int iddt = Fonctions.DateToInt(ddt);
            int ifdt = Fonctions.DateToInt(fdt);

            double anouvcred, anouvdeb;
            anouvcred = anouvdeb = 0;

            CompteModel model = new CompteModel();
            model.Compte = cmpt;

            int ret = comptes.Consulter(ref model);
            if (ret != 0) throw (new Exception("Compte inexistant !"));
            
            if (model.AnouveauCredit != "") anouvcred += double.Parse(model.AnouveauCredit);
            if (model.AnouveauDebit != "") anouvdeb += double.Parse(model.AnouveauDebit);

            double anouv = anouvdeb - anouvcred;

            IList<EcritureModel> recrts = ecritures.Consulter("Compte = " + cmpt + "and iDate <" + iddt.ToString(), "");
            IList<EcritureModel> mecrts = ecritures.Consulter("Compte = " + cmpt + "and iDate <=" + ifdt.ToString() + "and iDate >=" + iddt.ToString(), "");
            if ((anouv != 0) || (recrts.Count != 0) || (mecrts.Count != 0))
                b = true; 
            
            return b;

        }

        public string get_compte_intitule(string Cmpt)
        {
            CompteModel model = new CompteModel();
            model.Compte = Cmpt;

            int ret = comptes.Consulter(ref model);
            if (ret != 0) throw (new Exception("Compte inexistant !"));

            return model.Intitule;
        }

        public string[] get_comptes()
        {

            IList<CompteModel> cmptmodels = comptes.Consulter("", "Compte");
            string[] scmpts = new string[cmptmodels.Count];

            for (int i = 0; i < scmpts.Length; i++ )
            {
                scmpts[i] = cmptmodels[i].Compte;
               
            }

            return scmpts;
        }

        public string[] get_comptes(string cmptd, string cmptf)
        {

            string req = " Compte >= " + cmptd + " AND Compte <= " + cmptf;
            IList<CompteModel> cmptmodels = comptes.Consulter(req, "Compte");
            string[] scmpts = new string[cmptmodels.Count];

            for (int i = 0; i < scmpts.Length; i++)
            {
                scmpts[i] = cmptmodels[i].Compte;

            }

            return scmpts;
        }

        
	

    }
}
