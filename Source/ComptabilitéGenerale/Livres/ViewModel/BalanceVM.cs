using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace LivresCompta
{
    class BalanceVM
    {
        public string compte_debut { get; set; }
        public string compte_fin { get; set; }

        public string date { get; set; }

        public double total_anvouveau {get; set;}
        public double total_mvts_debit {get; set;}
        public double total_mvts_credit {get; set;}
        public double total_solde_debit { get; set; }
        public double total_solde_credit { get; set; }

        public ArrayList Lignes { get; set; }

        public BalanceVM()
        {
            Lignes = new ArrayList();
        }


    }
}
