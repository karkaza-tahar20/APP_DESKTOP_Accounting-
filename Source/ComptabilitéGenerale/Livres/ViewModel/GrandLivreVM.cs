using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;


namespace LivresCompta
{
    public class GrandLivreVM
    {
        public string date_debut { get; set; }
        public string date_fin { get; set; }
 

        public string compte  { get; set; }
        public string intitule { get; set; }
        

        public double report_debit { get; set; }
        public double report_credit { get; set; }
        public double mvts_debit { get; set; }
        public double mvts_credit { get; set; }
        public double total_debit { get; set; }
        public double total_credit { get; set; }
        public double solde_debit { get; set; }
        public double solde_credit { get; set; }
        public double anouveau { get; set; }

        public string solde { get; set; }

        public ArrayList Lignes { get; set; }

        public GrandLivreVM()
        {
            Lignes = new ArrayList();
        }

      
    }
}
