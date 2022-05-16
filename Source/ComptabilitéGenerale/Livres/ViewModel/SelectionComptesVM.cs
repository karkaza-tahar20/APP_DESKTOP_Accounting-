using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivresCompta
{
    public class SelectionComptesVM
    {
        public bool valid { get; set; }
        public string[] cmpts { get; set; }
        public string intld { get; set; }
        public string intlf { get; set; }
        public string date1 { get; set; }
        public string date2 { get; set; }
        public string idate1 { get; set; }
        public string idate2 { get; set; }
    }
}
