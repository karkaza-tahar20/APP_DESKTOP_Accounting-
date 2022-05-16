using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace EditionCompta
{
    public class ListingPlanComptableVM
    {

        public string title1 { get; set; }
        public string title2 { get; set; }
 
        public ArrayList Lignes { get; set; }

        public ListingPlanComptableVM()
        {
            Lignes = new ArrayList();
        }

    }
}
