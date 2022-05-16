using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excelns = Microsoft.Office.Interop.Excel;
using Export.Commun;

namespace Excel
{
    public class ColumnStyle
    {
        public Alignment Align { get; set; }
        public string Format { get; set; }
        public double ColumnWidth{ get; set; }
    }
}
