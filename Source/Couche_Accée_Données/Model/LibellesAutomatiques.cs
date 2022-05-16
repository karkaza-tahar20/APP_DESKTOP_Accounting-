using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Utilitaire;

namespace CoucheAcceeDonnees
{
    public class LibellesAutomatiques
    {
        private CAD db;

        public LibellesAutomatiques(CAD db1)
        {
            db = db1;
        }

        public int Enregistrer(LibelleAutomatiqueModel model)
        {

            DataTable dt = db.Ds.Tables["LibellesAutomatiques"];
            DataRow[] drs = dt.Select("Code =" + model.Code);
            if (drs.Length != 0) return 1;

            DataRow dr = dt.NewRow();
            dr["Code"] = model.Code;
            dr["Intitule"] = model.Intitule;
            dt.Rows.Add(dr);
            db.Update_LibellesAutomatiques();
            db.Ds.AcceptChanges();
         
            return 0;

        }

        public int Consulter(ref LibelleAutomatiqueModel model)
        {


            DataTable dt = db.Ds.Tables["LibellesAutomatiques"];
            DataRow[] drs = dt.Select("Code =" + model.Code);
            if (drs.Length > 0)
            {
                model.Code = drs[0]["Code"].ToString();
                model.Intitule = drs[0]["Intitule"].ToString();
                return 0;

            }
            else return 1;

        }

        public int Modifier(LibelleAutomatiqueModel model)
        {

            DataTable dt = db.Ds.Tables["LibellesAutomatiques"];
            DataRow[] drs = dt.Select("Code =" + model.Code);
            if (drs.Length > 0)
            {

                drs[0]["Code"] = model.Code;
                drs[0]["Intitule"] = model.Intitule;
                db.Update_LibellesAutomatiques();
                db.Ds.AcceptChanges();
                
                return 0;
            }
            else return 1;


        }

        public int Supprimer(LibelleAutomatiqueModel model)
        {

            DataTable dt = db.Ds.Tables["LibellesAutomatiques"];
            DataRow[] drs = dt.Select("Code =" + model.Code);
            if (drs.Length > 0)
            {
                drs[0].Delete();
                db.Update_LibellesAutomatiques();
                db.Ds.AcceptChanges();
                return 0;
            }
            else return 1;

        }

        public IList<LibelleAutomatiqueModel> Consulter(string selection, string tri)
        {
            DataRow[] drs = db.Ds.Tables["LibellesAutomatiques"].Select(selection, tri);
            IList<LibelleAutomatiqueModel> libelles = new List<LibelleAutomatiqueModel>();
            
            foreach (DataRow dr in drs)
            {
                LibelleAutomatiqueModel libelle_model = new LibelleAutomatiqueModel();
                libelle_model.Code = dr["Code"].ToString();
                libelle_model.Intitule = dr["Intitule"].ToString();
                libelles.Add(libelle_model);
                
            }
            return libelles;

        }

    }
}
