using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Utilitaire;

namespace CoucheAcceeDonnees
{
    public class Comptes
    {
        private CAD db;
        
        public Comptes(CAD db1)
        {
            db = db1;
        }

        public int Enregistrer(CompteModel model)
        {

            DataTable dt = db.Ds.Tables["Comptes"];
            DataRow[] drs = dt.Select("Compte =" + model.Compte);
            if (drs.Length != 0) return 1;

            DataRow dr = dt.NewRow();
            dr["Compte"] = model.Compte;
            dr["Intitule"] = model.Intitule;
            dr["Niveau"] = model.Niveau;
            dr["MouvementDebit"] = model.AnouveauDebit;
            dr["MouvementCredit"] = model.AnouveauCredit;
            dr["CompteResultat"] = model.CompteResultat;

            dt.Rows.Add(dr);
            db.Update_Comptes();
            db.Ds.AcceptChanges();
            
            return 0;

        }

        public int Consulter(ref CompteModel model)
        {

            DataTable dt = db.Ds.Tables["Comptes"];
            DataRow[] drs = dt.Select("Compte =" + model.Compte);
            if (drs.Length > 0)
            {
                model.Compte = drs[0]["Compte"].ToString();
                model.Intitule = drs[0]["Intitule"].ToString();
                model.Niveau = drs[0]["Niveau"].ToString();
                model.AnouveauDebit = Fonctions.format1(drs[0]["MouvementDebit"].ToString());
                model.AnouveauCredit = Fonctions.format1(drs[0]["MouvementCredit"].ToString());
                model.CompteResultat = drs[0]["CompteResultat"].ToString();
                if (model.CompteResultat == "0") model.CompteResultat = "";

                return 0;

            }
            else {
                Console.WriteLine(" Eroor Consulter Comptes.cs !!!!");
                return 1;
            } 

        }

        public IList<CompteModel> Consulter(string selection, string tri)
        {
            DataRow[] drs = db.Ds.Tables["Comptes"].Select(selection, tri);
            IList<CompteModel> comptes = new List<CompteModel>();
                     
            foreach (DataRow dr in drs)
            {
                CompteModel compte_model = new CompteModel();
                compte_model.Compte = dr["Compte"].ToString();
                compte_model.Intitule = dr["Intitule"].ToString();
                compte_model.Niveau = dr["Niveau"].ToString();
                compte_model.AnouveauDebit = Fonctions.format1(dr["MouvementDebit"].ToString());
                compte_model.AnouveauCredit = Fonctions.format1(dr["MouvementCredit"].ToString());
                compte_model.CompteResultat = dr["CompteResultat"].ToString();
                if (compte_model.CompteResultat == "0") compte_model.CompteResultat = "";
                comptes.Add(compte_model);
                
            }
            return comptes;

        }

        public int Modifier(CompteModel model)
        {

            DataTable dt = db.Ds.Tables["Comptes"];
            DataRow[] drs = dt.Select("Compte =" + model.Compte);
            if (drs.Length > 0)
            {

                drs[0]["Compte"] = model.Compte;
                drs[0]["Intitule"] = model.Intitule;
                drs[0]["Niveau"] = model.Niveau;
                //drs[0]["Niveau"] = "1";
                Console.WriteLine(drs[0]["MouvementDebit"]);
                Console.WriteLine(drs[0]["MouvementCredit"]);
           
                drs[0]["MouvementCredit"] = double.Parse(Fonctions.format1(drs[0]["MouvementCredit"].ToString()))+ double.Parse( Fonctions.format1( model.AnouveauCredit));
                drs[0]["MouvementDebit"] = double.Parse(Fonctions.format1(drs[0]["MouvementDebit"].ToString())) + double.Parse(Fonctions.format1(model.AnouveauDebit));
                Console.WriteLine(drs[0]["MouvementDebit"]);
                Console.WriteLine(drs[0]["MouvementCredit"]);
                drs[0]["CompteResultat"] = model.CompteResultat;

                db.Update_Comptes();
                db.Ds.AcceptChanges();
               
                return 0;
            }
            else return 1;


        }

        public int Supprimer(CompteModel model)
        {

            DataTable dt = db.Ds.Tables["Comptes"];
            DataRow[] drs = dt.Select("Compte =" + model.Compte);
            if (drs.Length > 0)
            {
                               
                drs[0].Delete();
                db.Update_Comptes();
                db.Ds.AcceptChanges();
                return 0;


            }
            else return 2;

        }

   

    }
}
