using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilitaire;

namespace SaisieCompta
{
    public class SaisiePlanVM
    {
        public string Compte { get; set; }
        public string Intitule { get; set; }
        public string CompteResultat { get; set; }
        public string Niveau { get; set; }
        public string AnouveauDebit { get; set; }
        public string AnouveauCredit { get; set; }

        public string MouvementDebit { get; set; }
        public string MouvementCredit { get; set; }
        public string SoldDebit { get; set; }
        public string SoldCredit { get; set; }

        public bool Ok;

        public Dictionary<string, string> validate_key()
        {
            Ok = true;
            Dictionary<string, string> Errors = new Dictionary<string, string>();
            if (Validator.valide_N(Compte) == false)
            {
                Ok = false;
                Errors.Add("Compte", "Le Format du compte doit etre numerique");
            }

            else Errors.Add("Compte", "");

            return Errors;


        }

        public Dictionary<string, string> validate()
        {
            Ok = true;


            Dictionary<string, string> Errors = new Dictionary<string, string>();

          
            if (Validator.valide_N(Compte) == false)
            {
                Ok = false;
                Errors.Add("Compte", "Le Format du compte doit etre numerique");
            }
            else Errors.Add("Compte", "");



            if (CompteResultat != "")
            {
                if (Validator.valide_N(CompteResultat) == false)
                {
                    Ok = false;
                    Errors.Add("CompteResultat", "Le Format du compte doit etre numerique");
                }
                else Errors.Add("CompteResultat", "");
            }
            else Errors.Add("CompteResultat", "");



            if ((Niveau != "1") && (Niveau != "2"))
            {
                Ok = false;
                Errors.Add("Niveau", "Le niveau du compte devrait avoir pour valeur 1 ou 2");
            }
            else Errors.Add("Niveau", "");



            if (AnouveauDebit == "") AnouveauDebit = "0,00";
            if (Validator.valide_F(AnouveauDebit) == false)
            {
                Ok = false;
                Errors.Add("AnouveauDebit", "Format A nouveau invalide");
            }
            else Errors.Add("AnouveauDebit", "");



            if (AnouveauCredit == "") AnouveauCredit = "0,00";
            if (Validator.valide_F(AnouveauCredit) == false)
            {
                Ok = false;
                Errors.Add("AnouveauCredit", "Format A nouveau invalide");
            }
            else Errors.Add("AnouveauCredit", "");


            return Errors;


        }




    }
}
