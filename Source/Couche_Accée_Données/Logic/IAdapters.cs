using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace CoucheAcceeDonnees
{
    public interface IAdapters
    {
        void Get_Adapters(ref DbDataAdapter Dossier_Adapter1, ref DbDataAdapter Comptes_Adapter1, ref DbDataAdapter Journaux_Adapter1,
            ref DbDataAdapter LibellesAutomatiques_Adapter1, ref DbDataAdapter Ecritures_Adapter1, ref DbDataAdapter Bilan_Adapter1);
        void Build_Adapters();
    }
}
