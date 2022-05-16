using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilitaire;

namespace SaisieCompta
{
    public class SaisieJournauxVM
    {
        
        public string Code { get; set; }
        public string Intitule { get; set; }
        public string Compte { get; set; }
        public bool ContrePartieAutomatique { get; set; }
        
        public bool Ok;

        public Dictionary<string, string> valide_key()
        {
            Ok = true;
            Dictionary<string, string> Errors = new Dictionary<string, string>();
            if (Validator.valide_N(Code) == false)
            {
                Ok = false;
                Errors.Add("Code", "Le Format du code journal doit etre numerique");
            }
            else if (Code == "9000")
            {
                Ok = false;
                Errors.Add("Code", "Le Code 9000 est reservé au journal A nouveau");
            }

            else Errors.Add("Code", "");

            return Errors;


        }

        public Dictionary<string, string> validate()
        {
            Ok = true;
            Dictionary<string, string> Errors = new Dictionary<string, string>();
            if (Validator.valide_N(Code) == false)
            {
                Ok = false;
                Errors.Add("Code", "Le Format du code journal doit etre numerique");
            }
            else if (Code == "9000")
            {
                Ok = false;
                Errors.Add("Code", "Le Code est 9000 est reservé au journal A nouveau");
            }
            else Errors.Add("Code", "");


            if (Validator.valide_N(Compte) == false)
            {
                Ok = false;
                Errors.Add("Compte", "Le Format du compte doit etre numerique");
            }

            else Errors.Add("Compte", "");
           
            return Errors;


        }
    }
}
