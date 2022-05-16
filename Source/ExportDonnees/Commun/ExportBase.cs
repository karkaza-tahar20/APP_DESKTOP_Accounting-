using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Export.Commun
{
    public abstract class ExportBase
    {
        public int pops_num;

        public abstract string get_prop(string prop);

        public abstract string get_prop(int index);
    }
}
