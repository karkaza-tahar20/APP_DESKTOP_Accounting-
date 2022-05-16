using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace EditionCompta
{
    public class ListingJournauxVM
    {
        public ArrayList Lignes { get; set; }

        public ListingJournauxVM()
        {
            Lignes = new ArrayList();
        }
    }
}
