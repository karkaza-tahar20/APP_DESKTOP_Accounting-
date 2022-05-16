using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Export.Commun;

namespace LivresCompta
{
    public class LigneBalance : ExportBase
    {
       
        public String Compte {get; set;}
        public String Designation {get; set;}
        public String Anouv {get; set;}
        public String Mvtdeb {get; set;}
        public String Mvtcred {get; set;}
        public String Sldeb {get; set;}
        public String Sldcred {get; set;}
        public String Niv {get; set;}

        public LigneBalance()
        {
            pops_num = 8;
        }

        public override string get_prop(string prop)
        {
            switch (prop)
            {
                case "Compte":
                    return Compte;
                case "Designation":
                    return Designation;
                case "Anouv":
                    return Anouv;
                case "Mvtdeb":
                    return Mvtdeb;
                case "Mvtcred":
                    return Mvtcred;
                case "Sldeb":
                    return Sldeb;
                case "Sldcred":
                    return Sldcred;
                case "Niv":
                    return Niv;
                default: return "";
            }
        }

        public override string get_prop(int index)
        {
            switch (index)
            {
                case 0 :
                    return Compte;
                case 1 :
                    return Designation;
                case 2 :
                    return Anouv;
                case 3 :
                    return Mvtdeb;
                case 4 :
                    return Mvtcred;
                case 5 :
                    return Sldeb;
                case 6 :
                    return Sldcred;
                case 7 :
                    return Niv;
                default: return "";
            }
        }


      
    }
}
