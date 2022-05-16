using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivresCompta
{
    public class SelectionJournauxVM
    {
        public bool valid { get; set; }
        public string[] idjs { get; set; }
        public string njd { get; set; }
        public string njf { get; set; }
        public string date1 { get; set; }
        public string date2 { get; set; }
        public string idate1 { get; set; }
        public string idate2 { get; set; }
    }
}
