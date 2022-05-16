using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Export.Commun;

namespace EditionCompta
{
    public class LignePlanComptable : ExportBase
    {
        public string Compte { get; set; }
        public string Intitule { get; set; }

        public LignePlanComptable()
        {
            pops_num = 2;
        }

        public override string get_prop(string prop)
        {
            switch (prop)
            {
                case "Compte":
                    return Compte;
                case "Intitule":
                    return Intitule;
              
                default: return "";
            }
        }

        public override string get_prop(int index)
        {
            switch (index)
            {
                case 0:
                    return Compte;
                case 1:
                    return Intitule;
               
                default: return "";
            }
        }

    }

}
