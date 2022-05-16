using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CoucheAcceeDonnees;
using Utilitaire;
using System.Windows.Forms;


namespace SaisieCompta
{
    public class SaisiePlanLogic
    {

        Comptes comptes;
        Ecritures ecritures;
      
        public SaisiePlanLogic(CAD db)
        {
            
            db.Fill_Comptes();
            db.Fill_Ecritures();

            comptes = new Comptes(db);
            ecritures = new Ecritures(db);
 
        }



        public int Enregistrer(SaisiePlanVM view_model)
        {
           
            CompteModel model = new CompteModel();

            model.Compte = view_model.Compte;
            model.Intitule = view_model.Intitule;
            model.Niveau = view_model.Niveau; 
            model.CompteResultat = view_model.CompteResultat;
            model.AnouveauCredit = view_model.AnouveauCredit;
            model.AnouveauDebit = view_model.AnouveauDebit;

            return comptes.Enregistrer(model);
           

        }

        public int Consulter(ref SaisiePlanVM view_model)
        {
            
            CompteModel model = new CompteModel();

            model.Compte = view_model.Compte;

            int ret = comptes.Consulter(ref model);
            if (ret == 0)
            {
                view_model.Compte = model.Compte;
                view_model.Intitule = model.Intitule;
                view_model.Niveau = model.Niveau;
                view_model.AnouveauDebit = model.AnouveauDebit;
                view_model.AnouveauCredit = model.AnouveauCredit;
                view_model.CompteResultat = model.CompteResultat;
                if (view_model.CompteResultat == "0") view_model.CompteResultat = "";

                double credit = 0;
                double debit = 0;
                Mvts(view_model.Compte, ref  debit, ref  credit);
                if (debit == 0) view_model.MouvementDebit = "0,00";
                else view_model.MouvementDebit = Fonctions.format1(debit.ToString());
                if (credit == 0) view_model.MouvementCredit = "0,00";
                else view_model.MouvementCredit = Fonctions.format1(credit.ToString());
                double avd = 0;
                if (view_model.AnouveauDebit != "") avd = double.Parse(view_model.AnouveauDebit.Replace('.', ','));
                else view_model.AnouveauDebit = "0,00";
                double avc = 0;
                if (view_model.AnouveauCredit != "") avc = double.Parse(view_model.AnouveauCredit.Replace('.', ','));
                else view_model.AnouveauCredit = "0,00";
                Solde(view_model, avc, avd);

            }

            return ret;



            
          

        }

        public int Modifier(SaisiePlanVM view_model)
        {

            
            CompteModel model = new CompteModel();

            model.Compte = view_model.Compte;
            model.Intitule = view_model.Intitule;
            model.Niveau = view_model.Niveau;
            model.CompteResultat = view_model.CompteResultat;
            model.AnouveauCredit = view_model.AnouveauCredit;
            model.AnouveauDebit = view_model.AnouveauDebit;

            return comptes.Modifier(model);


        }

        public int Supprimer(SaisiePlanVM view_model)
        {
            double anv = double.Parse(view_model.AnouveauDebit) - double.Parse(view_model.AnouveauCredit);
            bool rmv = removable(view_model.Compte, anv);
            if (rmv == false) return 1;
            else
            {
                
                CompteModel model = new CompteModel();

                model.Compte = view_model.Compte;
                return comptes.Supprimer(model);
            }

           

        }

     

        void Mvts(string code, ref double debit, ref double credit)
        {

            debit = credit = 0;

            string req = "Compte =" + "'" + code + "'";
            string tri = "";

            IList<EcritureModel> ecrts = ecritures.Consulter(req, tri);


            for ( int i = 0; i < ecrts.Count; i++ )
            {
                bool b = ecrts[i].Debit;
                double mnt = double.Parse(ecrts[i].Montant);
                if (b == true) debit += mnt;
                else credit += mnt;
            }


        }
        void Solde(SaisiePlanVM model, double avc, double avd)
        {
            double mvc = 0;
            double mvd = 0;
            if (model.MouvementDebit != "") mvd = double.Parse(model.MouvementDebit);
            if (model.MouvementCredit != "") mvc = double.Parse(model.MouvementCredit);

            double solde = Fonctions.formatm(avd + mvd - avc - mvc);
            double msolde = Fonctions.formatm(avc + mvc - avd - mvd);
            if (avd >= avc)
            {
                model.SoldDebit = Fonctions.format1(solde.ToString());
                model.SoldCredit = "0,00";
            }
            if (avd <= avc)
            {
                model.SoldCredit = Fonctions.format1(msolde.ToString());
                model.SoldDebit = "0,00";
            }

        }

        private bool removable(string cmpt, double anv)
        {
            bool b = true;
            double deb = 0;
            double cred = 0;
            Mvts(cmpt, ref deb, ref cred);
            if ((anv != 0) || (deb != 0) || (cred != 0)) b = false;
            return b;
        }

    }
}
