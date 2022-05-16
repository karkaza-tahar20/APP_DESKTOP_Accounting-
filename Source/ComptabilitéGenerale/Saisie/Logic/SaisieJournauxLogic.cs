using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CoucheAcceeDonnees;
using Utilitaire;

namespace SaisieCompta
{
    class SaisieJournauxLogic
    {

        Journaux journaux; 

        public SaisieJournauxLogic(CAD db)
        {
            
            db.Fill_Journaux();
            db.Fill_Comptes();

            journaux = new Journaux(db);
     
        }


        public int Enregistrer(SaisieJournauxVM view_model)
        {
            
            JournalModel model = new JournalModel();

            model.Code = view_model.Code;
            model.Intitule = view_model.Intitule;
            model.ContrePartieAutomatique = view_model.ContrePartieAutomatique;
            model.Compte = view_model.Compte;

            return journaux.Enregistrer(model);



        }

        public int Consulter(ref SaisieJournauxVM view_model)
        {
            
            JournalModel model = new JournalModel();

            model.Code = view_model.Code;

            int ret = journaux.Consulter(ref model);
            if (ret == 0)
            {
                view_model.Code = model.Code;
                view_model.Intitule = model.Intitule;
                view_model.Compte = model.Compte;
                view_model.ContrePartieAutomatique = model.ContrePartieAutomatique;

            }

            return ret;
           
        }

        public int Modifier(SaisieJournauxVM view_model)
        {

            
            JournalModel model = new JournalModel();

            model.Code = view_model.Code;
            model.Intitule = view_model.Intitule;
            model.ContrePartieAutomatique = view_model.ContrePartieAutomatique;
            model.Compte = view_model.Compte;

            return journaux.Modifier(model);


        }

        public int Supprimer(SaisieJournauxVM view_model)
        {
            
            JournalModel model = new JournalModel();

            model.Code = view_model.Code;

            return journaux.Supprimer(model);

        }

        


    }
}
