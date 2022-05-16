using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Printing;
using System.Collections;
using System.Data;
using Utilitaire;

namespace Impression
{
    public class Imprimeur
    {
        public DataTable dt;
        public ArrayList Lignes;
        public Tableau tbl;

        public List<Caption> Captions;
        protected PrintDocument Document;
        public int num_pages;
        protected int np;
        protected int cl;
        
     
        public virtual void BuildDocument()
        {
            np = 1;
            cl = 0;
            Document = new PrintDocument();
            Document.PrintPage += Document_PrintPage;
            Document.DefaultPageSettings.PaperSize = new PaperSize("Lettre", 850, 1100);
            
        }

        protected virtual void Document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            if (Lignes.Count > cl)
            {
                for (int k = 0; k < Captions.Count; k++)
                { 
                    Font fnt = Captions[k].fnt;
                    RectangleF rec = Captions[k].rec;
                    if (k == Captions.Count - 1)
                    {
                        string s = Captions[k].Text + " " + np.ToString() + "/" + num_pages.ToString();
                        g.DrawString(s, fnt, Brushes.Black, rec, sf);

                    }
                    else
                    {
                        string s = Captions[k].Text ;
                        g.DrawString(s, fnt, Brushes.Black, rec, sf);
                    }
                }
                
            }
            PointF p = new PointF();
            p.X = tbl.posX; p.Y = tbl.posY;
            p = tbl.PrintHeader(g, p);

             for (int j = 0; j < tbl.LinesInPage; j++)
             {
                 if (tbl.Lignes.Count > cl)
                 {
                     if ((cl % tbl.LinesInPage) == 0)
                     {
                         if (tbl.Lignes.Count > 1) p = tbl.PrintRow(g, p, cl);
                         else p = tbl.PrintRow(g, p, cl);
                     }
                     else if ((cl % tbl.LinesInPage == tbl.LinesInPage - 1) || (cl == tbl.Lignes.Count - 1)) p = tbl.PrintRow(g, p, cl);
                     else p = tbl.PrintRow(g, p, cl);
                     cl++;
                 }
                 else
                 {
                     tbl.PrintFooter(g,p);
                     e.HasMorePages = false;
                     return;
                 }

             }
             np++;
             tbl.PrintFooter(g, p);
             e.HasMorePages = true;
        }

        public void print()
        {
            Document.Print();
        } 
        
        public void print_preview()
        {
            PrintPreviewDialog ppw = new PrintPreviewDialog();
            ppw.Document = Document;
            ppw.WindowState = FormWindowState.Maximized;
            ppw.PrintPreviewControl.Zoom = 1;
            ppw.Show();
        }


      

 

       

    }
}
