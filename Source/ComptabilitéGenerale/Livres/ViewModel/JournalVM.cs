using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace LivresCompta
{
    public class JournalVM
    {
        
        public string code_journal;
        public string intitule_journal;

        public string date_debut { get; set; }
        public string date_fin { get; set; }
        
        public double report_debit {get; set;}
        public double report_credit { get; set; }

        public double total_debit { get; set; }
        public double total_credit { get; set; }

        public ArrayList Lignes { get; set; }

        public JournalVM()
        {
            Lignes = new ArrayList();
        }

    }
}
