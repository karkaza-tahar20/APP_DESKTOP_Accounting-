using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Utilitaire;
using CoucheAcceeDonnees;

namespace SaisieCompta
{
    public class SaisieLibellesAutomatiquesLogic
    {
        LibellesAutomatiques Libelles; 

        public SaisieLibellesAutomatiquesLogic(CAD db)
        {
            
            db.Fill_LibellesAutomatiques();
            
            Libelles = new LibellesAutomatiques(db);

        }


        public int Enregistrer(SaisieLibellesAutomatiquesVM view_model)
        {
            
            LibelleAutomatiqueModel model = new LibelleAutomatiqueModel();

            model.Code = view_model.Code;
            model.Intitule = view_model.Intitule;

            return Libelles.Enregistrer(model);

        }

        public int Consulter(ref SaisieLibellesAutomatiquesVM view_model)
        {
            
            LibelleAutomatiqueModel model = new LibelleAutomatiqueModel();

            model.Code = view_model.Code;

            int ret = Libelles.Consulter(ref model);
            if (ret == 0)
            {
                view_model.Code = model.Code;
                view_model.Intitule = model.Intitule;

            }

            return ret;

        }

        public int Modifier(SaisieLibellesAutomatiquesVM view_model)
        {

            
            LibelleAutomatiqueModel model = new LibelleAutomatiqueModel();

            model.Code = view_model.Code;
            model.Intitule = view_model.Intitule;

            return Libelles.Modifier(model);
          
        }

        public int Supprimer(SaisieLibellesAutomatiquesVM view_model)
        {
                        
            LibelleAutomatiqueModel model = new LibelleAutomatiqueModel();

            model.Code = view_model.Code;
            return Libelles.Supprimer(model);

        }

       


       

    }
}
