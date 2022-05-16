using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Export.Commun;

namespace EditionCompta
{
    public class LigneJournalAuxiliaire : ExportBase
    {
        
        public string Code { get; set; }
        public string Intitule { get; set; }

        public LigneJournalAuxiliaire()
        {
            pops_num = 2;
        }

        public override string get_prop(string prop)
        {
            switch (prop)
            {
                case "Code":
                    return Code;
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
                    return Code;
                case 1:
                    return Intitule;
               
                default: return "";
            }
        }

    }
}
