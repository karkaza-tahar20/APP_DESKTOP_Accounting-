using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CoucheAcceeDonnees;

namespace EditionCompta
{
    class ListingLibellesAutLogic
    {
        
        
        LibellesAutomatiques Libelles;

        public ListingLibellesAutLogic(CAD db)
        {
           
            db.Fill_LibellesAutomatiques();

            Libelles = new LibellesAutomatiques(db);
                      

        }

        public ListingLibelleAutVM get_libelles(string select, string tri)
        {
            ListingLibelleAutVM view_model = new ListingLibelleAutVM();

            IList<LibelleAutomatiqueModel> lib_aut = Libelles.Consulter("", "Code,Intitule");


            for (int i = 0; i < lib_aut.Count; i++ )
            {
                LigneLibelleAutomatique Ligne = new LigneLibelleAutomatique();

                Ligne.Code = lib_aut[i].Code;
                Ligne.Intitule = lib_aut[i].Intitule;

                view_model.Lignes.Add(Ligne);

            }

            return view_model;
        }

    }
}
