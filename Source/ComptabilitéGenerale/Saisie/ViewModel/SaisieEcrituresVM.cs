using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaisieCompta
{
    class SaisieEcrituresVM
    {
        public List<LigneEcriture> Lignes { get; set; }

        public string journal_intitule { get; set; }
        public string contre_partie { get; set; }
        public bool cpa { get; set; }


        public string compte_intitule { get; set; }
        public string libelle_intitule { get; set; }
        //public string libelle2_intitule { get; set; }

        public double mouvements_debit { get; set; }
        public double mouvements_credit { get; set; }
        public double cumul_debit { get; set; }
        public double cumul_credit { get; set; }

        public SaisieEcrituresVM()
        {
            Lignes = new List<LigneEcriture>();

        }

    }
}
