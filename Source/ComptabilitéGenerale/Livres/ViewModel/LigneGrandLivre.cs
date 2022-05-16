using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Export.Commun;

namespace LivresCompta
{
    public class LigneGrandLivre : ExportBase
    {
        public String Date {get; set;}
        public String Code_Journal {get; set;}
        public String Contre_Partie { get; set; }
        public String Piece {get; set;}
        public String Libelle { get; set; }
        public String Debit {get; set;}
        public String Credit {get; set;}
       
        public LigneGrandLivre()
        {
            pops_num = 7;

            Date = "";
            Code_Journal = "";
            Contre_Partie = "";
            Piece = "";
            Libelle = "";
            Debit = "";
            Credit = "";
        }

        public override string get_prop(string prop)
        {
            switch (prop)
            {
                case "Date":
                    return Date;
                case "Code_Journal":
                    return Code_Journal;
                case "Contre_Partie":
                    return Contre_Partie;
                case "Piece":
                    return Piece;
                case "Libelle":
                    return Libelle;
                case "Debit":
                    return Debit;
                case "Credit":
                    return Credit;
                default: return "";
            }
        }

        public override string get_prop(int index)
        {
            switch (index)
            {
                case 0 :
                    return Date;
                case 1 :
                    return Code_Journal;
                case 2 :
                    return Contre_Partie;
                case 3 :
                    return Piece;
                case 4 :
                    return Libelle;
                case 5 :
                    return Debit;
                case 6 :
                    return Credit;
                default: return "";
            }
        }


    }
}
