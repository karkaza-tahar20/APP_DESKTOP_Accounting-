using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CoucheAcceeDonnees;

namespace EditionCompta
{
    public class ListingPlanComptableLogic
    {
        Comptes comptes; 
        
        public ListingPlanComptableLogic(CAD db)
        {
            
            db.Fill_Comptes();
            
            comptes = new Comptes(db);
  
        }

        public ListingPlanComptableVM get_plan(string select, string tri)
        {
            ListingPlanComptableVM view_model = new ListingPlanComptableVM();

            
            IList<CompteModel> models = comptes.Consulter(select, tri);


            for (int i = 0; i < models.Count; i++ )
            {
                LignePlanComptable Ligne = new LignePlanComptable();

                Ligne.Compte = models[i].Compte.PadLeft(8, '0');
                Ligne.Intitule = models[i].Intitule;

                view_model.Lignes.Add(Ligne);

            }

            return view_model;
        }



    }
}
