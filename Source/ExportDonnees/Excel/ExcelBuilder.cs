using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;
using Excelns = Microsoft.Office.Interop.Excel;
using Export.Commun;

namespace Excel
{
    public class ExcelBuilder
    {
        Excelns.Application excel_app;
        Excelns.Workbook excel_book;
        Excelns.Worksheet excel_sheet;

        object misValue = System.Reflection.Missing.Value;
                
        
        public string filename;
        public Phrase[] Header;
        public string[] TableHeader;
        public string[] Reports;
        public ArrayList Lignes;
        public string[] TableFooter;
        public string[] TableFooter_bis;
        public Phrase[] Footer;
        
        public double RowHight;
        
        public ColumnStyle[] TableColumnStyle;

        public ExcelBuilder()
        {
            
        }
        
        public bool set_execl_app()
        {
            excel_app = new Microsoft.Office.Interop.Excel.Application();
            if (excel_app == null) return false;
            else
            {
                excel_book = excel_app.Workbooks.Add(misValue);
                return true;
            }
        }

        public void set_sheet(string name,int sheet_item, bool add)
        {
            if ( add == true )
                excel_book.Worksheets.Add(excel_book.Worksheets[sheet_item + 1], misValue, misValue, misValue);
            excel_sheet = (Excelns.Worksheet)excel_book.Worksheets.get_Item(sheet_item);
            excel_sheet.Name = name;
           
        }

       

        public int WriteHeader()
        {
            for (int i = 0; i < Header.Length; i++)
            {
                char debut = 'A';
                char fin =(char)( debut + Header[i].length-1);
                excel_sheet.Cells[i+1, 1] = Header[i].Text;
                
                Excelns.Range rng = excel_sheet.get_Range(debut.ToString() + (i + 1).ToString(), fin.ToString() + (i + 1).ToString());
                rng.Merge(true);
                rng.Font.Bold = true;
                Excelns.Borders brds = rng.Borders;
                brds.LineStyle = Excelns.XlLineStyle.xlContinuous;
                if ( Header[i].Align == Alignment.center)
                    rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                if ( Header[i].Align == Alignment.right)
                    rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                if (Header[i].Align == Alignment.left)
                    rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                brds.Weight = 3d;

            }
            return Header.Length;

        } 
        
        public int WriteLine(int line, string[] Captions)
        {
            for (int i = 1; i < Captions.Length + 1; i++)
            {
                excel_sheet.Cells[line, i] = Captions[i - 1];
            }

            return line ;
        }

        public int WriteTable(int line)
        {
            line = WriteLine(line, TableHeader);
            if (Reports != null)
            {
                line++;
                line = WriteLine(line, Reports);
            }

            for (int j = 0; j < Lignes.Count; j++)
            {
                for (int k = 0; k < TableHeader.Length; k++)
                {
                    ExportBase Ligne = (ExportBase)Lignes[j];
                    excel_sheet.Cells[j + 1 + line, k + 1] = Ligne.get_prop(k);
                }
            }
            line = line + Lignes.Count + 1;
            if ( TableFooter != null ) line = WriteLine(line, TableFooter);
            line++;
            if (TableFooter_bis != null) line = WriteLine(line, TableFooter_bis);

            return line++;
        }

        void StyleTable(int line1,int line2)
        {
            excel_sheet.Rows.RowHeight = RowHight;


            for (int i = 0; i < TableColumnStyle.Length; i++)
            {
                Char colone = (char)('A' + i);

                Excelns.Range rngh = excel_sheet.get_Range(colone.ToString() + line1.ToString(), colone.ToString() + line1.ToString());
                rngh.Merge(true); 
                rngh.HorizontalAlignment = Excelns.XlHAlign.xlHAlignCenter;

                string R1 = colone.ToString() + (line1+1).ToString();
                string R2 = colone.ToString() + line2.ToString();

                Excelns.Range rngc = excel_sheet.get_Range(R1, R2);
                rngc.Merge(true); 
                
                rngc.EntireColumn.ColumnWidth = TableColumnStyle[i].ColumnWidth;

                if (TableColumnStyle[i].Align == Alignment.center)
                    rngc.HorizontalAlignment = Excelns.XlHAlign.xlHAlignCenter;
                if (TableColumnStyle[i].Align == Alignment.left)
                    rngc.HorizontalAlignment = Excelns.XlHAlign.xlHAlignLeft;
                if (TableColumnStyle[i].Align == Alignment.right)
                    rngc.HorizontalAlignment = Excelns.XlHAlign.xlHAlignRight;

                rngc.NumberFormat = TableColumnStyle[i].Format;
               
            }

           

        }

        public void WriteFooter(int line)
        {
            for (int i = 0; i < Footer.Length; i++)
            {
                char debut = 'A';
                char fin = (char)(debut + Footer[i].length);
                Excelns.Range rng = excel_sheet.get_Range(debut.ToString() + (line + i).ToString(), fin.ToString() + (line + i).ToString());
                rng.Merge(true);
                rng.Font.Bold = true;
                excel_sheet.Cells[1, i] = Footer[i].Text;
                Excelns.Borders brds = rng.Borders;
                brds.LineStyle = Excelns.XlLineStyle.xlContinuous;
                rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                brds.Weight = 3d;
            }
        }

        public void WriteDoc()
        {
            int line = 0;
            if (Header != null) line = WriteHeader();
            line = line + 2 ;

            if (Lignes != null)
            { 
                int line1 = line;
                line = WriteTable(line);
                int line2 = line;
                StyleTable(line1, line2);
            }

            if (Footer != null) WriteFooter(line);

        }

        public void save()
        {
            //excel_sheet.Columns.AutoFit();
            excel_book.SaveAs(filename, Excelns.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excelns.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            excel_book.Close(true, misValue, misValue);
            excel_app.Quit();

            releaseObject(excel_sheet);
            releaseObject(excel_book);
            releaseObject(excel_app);


        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
