using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComptabiliteGenerale.Saisie.ViewModel
{
    public class LigneBilan
    {
        public string CompteActif { get; set; }
        public string LibelleActif { get; set; }
        public string SoldeActif { get; set; }
        public string ComptePassif { get; set; }
       
        public string LibellePassif { get; set; }
        public string SoldePassif { get; set; }
        
    }
}
