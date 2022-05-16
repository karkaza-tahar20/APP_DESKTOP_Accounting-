using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Utilitaire;
using CoucheAcceeDonnees;

namespace CoucheAcceeDonnees
{
    public class DossierLogic
    {
        Dossier Doss;

        public DossierLogic(CAD db)
        {
            Console.WriteLine("8-1");
            db.Fill_Dossier();
            Console.WriteLine("8-2");
            Doss = new Dossier(db);
            Console.WriteLine("8-3");
        }
        public DossierLogic() { }
        public int Modifier(DossierModel model)
        {
            return Doss.Modifier(model);

        }

        public int Consulter(ref DossierModel model)
        {
            return Doss.Consulter(ref model);

        }


         


    }
}
