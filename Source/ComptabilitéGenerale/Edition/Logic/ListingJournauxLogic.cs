using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoucheAcceeDonnees;


namespace EditionCompta
{
    class ListingJournauxLogic
    {
      
        Journaux journaux;

        public ListingJournauxLogic(CAD db)
        {
            
            db.Fill_Journaux();
          
            journaux = new Journaux(db);

            JournalModel JourAnv = new JournalModel();
            JourAnv.Code = "9000";
            JourAnv.Intitule = "A NOUVEAU";

            journaux.Add(JourAnv);



           
        }

        public ListingJournauxVM get_journaux(string select, string tri)
        {
            ListingJournauxVM view_model = new ListingJournauxVM();

            IList<JournalModel> jours = journaux.Consulter(select, tri);


            for (int i = 0; i < jours.Count; i++ )
            {
                LigneJournalAuxiliaire Ligne = new LigneJournalAuxiliaire();
                Ligne.Code = jours[i].Code.PadLeft(4, '0'); ;
                Ligne.Intitule = jours[i].Intitule.ToString();

                view_model.Lignes.Add(Ligne);

            }

            return view_model;


        }
    }
}
