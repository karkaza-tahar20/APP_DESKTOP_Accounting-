using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Utilitaire
{
    public static class Fonctions
    {
        public static string format1(string number)
        {
            double val = double.Parse(number.Replace('.', ','));
            NumberFormatInfo nbf = new NumberFormatInfo();
            nbf.NumberDecimalDigits = 2;
            nbf.NumberDecimalSeparator = ",";
            nbf.NumberNegativePattern = 1;
            string fnum = val.ToString("F", nbf);
            return fnum;
        }

        public static string format03(string number)
        {
            double val = double.Parse(number);
            NumberFormatInfo nbf = new NumberFormatInfo();

            nbf.CurrencySymbol = "";
            nbf.CurrencyDecimalSeparator = ",";
            nbf.CurrencyGroupSeparator = " ";
            string number1 = val.ToString("C", nbf);
            return number1;
        }
        public static string format04(string number)
        {
            double val = double.Parse(number);
            NumberFormatInfo nbf = new NumberFormatInfo();

            nbf.CurrencySymbol = "";
            nbf.CurrencyDecimalSeparator = ",";
            nbf.CurrencyGroupSeparator = ".";
            nbf.CurrencyNegativePattern = 5;
            string number1 = val.ToString("C", nbf);
            if (number1 == "0,00") number1 = ""; 
            return number1;
        }
        public static float formatm(float m)
        {
            if ((float)Math.Ceiling((m * 100)) - (m * 100) > 0.5) m = (float)Math.Ceiling((m * 100)) - 1;
            else m = (float)Math.Ceiling((m * 100));
            m = m / 100;
            return m;
        }
        public static double formatm(double m)
        {
            if ((double)Math.Ceiling((m * 100)) - (m * 100) > 0.5) m = (double)Math.Ceiling((m * 100)) - 1;
            else m = (double)Math.Ceiling((m * 100));
            m = m / 100;
            return m;
        }

        public static int DateToInt(string Date)
        {
            char sep = '/';
            string[] subDate = Date.Split(sep);
            int iDate = int.Parse(subDate[0]) + (int.Parse(subDate[1]) * 100) ;
            return iDate;
        }


    }
}

