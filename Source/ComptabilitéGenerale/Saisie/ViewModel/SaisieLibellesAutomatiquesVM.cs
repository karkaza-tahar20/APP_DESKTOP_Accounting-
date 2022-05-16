using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilitaire;


namespace SaisieCompta
{
    public class SaisieLibellesAutomatiquesVM
    {
        public string Code { get; set; }
        public string Intitule { get; set; }

        public bool Ok;

        public Dictionary<string, string> validate()
        {
            Ok = true;
            Dictionary<string, string> Errors = new Dictionary<string, string>();
            if (Validator.valide_N(Code) == false)
            {
                Ok = false;
                Errors.Add("Code", "Le Format du code libelle doit etre numerique");
            }
       
            else Errors.Add("Code", "");
           
            return Errors;


        }


    }
}
