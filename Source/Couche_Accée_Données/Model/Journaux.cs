using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CoucheAcceeDonnees
{
    public class Journaux
    {
        private CAD db;

        public Journaux(CAD db1)
        {
            db = db1;
        }
        public int Enregistrer(JournalModel model)
        {
            DataTable dt = db.Ds.Tables["Journaux"];
            DataRow[] drs = dt.Select("Code =" + model.Code);
            if (drs.Length != 0) return 1;

            DataRow dr = dt.NewRow();
            dr["Code"] = model.Code;
            dr["Intitule"] = model.Intitule;
            dr["Compte"] = model.Compte;
            dr["Cpa"] = model.ContrePartieAutomatique;

            dt.Rows.Add(dr);
            db.Update_Journaux();
            db.Ds.AcceptChanges();
            
            return 0;

        }

        public int Consulter(ref JournalModel model)
        {

            DataTable dt = db.Ds.Tables["Journaux"];
            DataRow[] drs = dt.Select("Code =" + model.Code);
            if (drs.Length > 0)
            {
                model.Code = drs[0]["Code"].ToString();
                model.Intitule = drs[0]["Intitule"].ToString();
                model.Compte = drs[0]["Compte"].ToString();
                model.ContrePartieAutomatique = (bool)drs[0]["Cpa"];

                return 0;

            }
            else return 1;

        }
        

      

        public int Modifier(JournalModel model)
        {

            DataTable dt = db.Ds.Tables["Journaux"];
            DataRow[] drs = dt.Select("Code =" + model.Code);
            if (drs.Length > 0)
            {

                drs[0]["Code"] = model.Code;
                drs[0]["Intitule"] = model.Intitule;
                drs[0]["Compte"] = model.Compte;
                drs[0]["Cpa"] = model.ContrePartieAutomatique;

                db.Update_Journaux();
                db.Ds.AcceptChanges();
                
                return 0;
            }
            else return 1;


        }

        public int Supprimer(JournalModel model)
        {
            DataTable dt = db.Ds.Tables["Journaux"];
            DataRow[] drs = dt.Select("Code =" + model.Code);
            if (drs.Length > 0)
            {
                drs[0].Delete();
                db.Update_Journaux();
                db.Ds.AcceptChanges();
                
                return 0;


            }
            else return 1;

        } 
        
        public IList<JournalModel> Consulter(string selection, string tri)
        {
            DataRow[] drs = db.Ds.Tables["Journaux"].Select(selection, tri);
            IList<JournalModel> journaux = new List<JournalModel>();

            
            foreach (DataRow dr in drs)
            {
                JournalModel journal_model = new JournalModel();
                journal_model.Code = dr["Code"].ToString();
                journal_model.Intitule = dr["Intitule"].ToString();
                journal_model.Compte = dr["Compte"].ToString();
                journal_model.ContrePartieAutomatique = (bool)dr["Cpa"];

                journaux.Add(journal_model);
            }
            return journaux;

        }

        public int Add(JournalModel model)
        {
            DataTable dt = db.Ds.Tables["Journaux"];
            DataRow[] drs = dt.Select("Code =" + model.Code);
            if (drs.Length != 0) return 1;

            DataRow dr = dt.NewRow();
            dr["Code"] = model.Code;
            dr["Intitule"] = model.Intitule;
            dr["Compte"] = "0";
            dr["Cpa"] = model.ContrePartieAutomatique;

            dt.Rows.Add(dr);
            db.Ds.AcceptChanges();

            return 0;

        }


    }
}
