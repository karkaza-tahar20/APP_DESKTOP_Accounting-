using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Utilitaire
{
    public class Validator
    {
        private static GregorianCalendar gcalend = new GregorianCalendar(); 
        
        public  static int valide_cmptTxt(string cmpt)
        {
            if (cmpt == "") return 2;
            else
            {
                if (valide_N(cmpt) == false) return 1;
                else return 0;
               
            }
        }
        
        public static bool valide_N(string s)
        {
            bool b = true;
            char[] chrs = s.ToCharArray();
            for (int i = 0; i < chrs.Length; i++)
            {
                if (!Char.IsDigit(chrs[i])) b = false;
            }
            if (s == "") b = false;
            return b;
        }

        public static bool valide_NN(string s)
        {
            bool b1 = true;
            bool b2 = true;
            char[] chrs = s.ToCharArray();
            for (int i = 0; i < chrs.Length; i++)
            {
                if (i == 0)
                {
                    b1 = (Char.IsDigit(chrs[i])) | (chrs[i] == '-');
                }
                else b2 &= Char.IsDigit(chrs[i]);

            }
            return b1 & b2;
        }
        public static bool valide_F(string s)
        {

            string[] sarr = s.Split(',');
            if (sarr.Length != 2) return false;
            if (sarr[1].Length != 2) return false;
            else
            {
                bool b1 = valide_NN(sarr[0]);
                bool b2 = valide_N(sarr[1]);
                return b1 & b2;
            }

        }
        public static int valide_DT(string s,string year)
        {
            int ret = 0;
            if (s.Length == 10)
            {
                char[] chrs = s.ToCharArray();
                if ((chrs[2] != '/') || (chrs[5] != '/')) ret = 1;
                else
                {
                    char sep = '/';
                    string[] subs = s.Split(sep);
                    for (int i = 0; i < subs.Length; i++)
                    {
                        if (valide_N(subs[i]) == false) ret = 1;
                    }
                    if (ret == 0)
                    {
                        int day = Int32.Parse(subs[0]);
                        int month = Int32.Parse(subs[1]);
                        int ryear = Int32.Parse(subs[2]);
                        if (year != ryear.ToString()) ret = 2;
                        if ((month > 12) || (month < 1)) ret = 3;
                        if ((month == 1) || (month == 3) || (month == 5) || (month == 7) || (month == 8) || (month == 10) || (month == 12))
                        {
                            if ((day > 31) || (day < 1)) ret = 4;
                        }
                        else if (month == 2)
                        {
                            if (gcalend.IsLeapYear(ryear, GregorianCalendar.ADEra))
                            {
                                if ((day > 29) || (day < 1)) ret = 4;
                            }
                            else
                            {
                                if ((day > 28) || (day < 1)) ret = 4;
                            }
                        }
                        else
                        {
                            if ((day > 30) || (day < 1)) ret = 4;
                        }
                    }
                }
            }
            else ret = 1;

            return ret;
        }

        public static bool valide_DT_OP(string s)
        {
            bool b = true;
            if (s.Length == 5)
            {
                char[] chrs = s.ToCharArray();
                if (chrs[2] != '/') b = false;
                else
                {
                    char sep = '/';
                    string[] subs = s.Split(sep);
                    for (int i = 0; i < subs.Length; i++)
                    {
                        if (valide_N(subs[i]) == false) b = false;
                    }
                }
            }
            else b = false;

            return b;
        }
	
    }
  
}
