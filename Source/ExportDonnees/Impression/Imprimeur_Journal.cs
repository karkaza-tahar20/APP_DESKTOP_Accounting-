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
using Export.Commun;

namespace Impression
{
    public class Imprimeur_Journal : Imprimeur
    {
       
        double ptdeb, ptcred;
                  
        public override void BuildDocument()
        {
            np = 1;
            cl = 0;
            ptdeb = ptcred = 0;
            Document = new PrintDocument();
            Document.PrintPage += Document_PrintPage;
            Document.DefaultPageSettings.PaperSize = new PaperSize("Lettre", 850, 1100);

        }

        protected override void Document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
                    if (k == 0)
                    {
                        string s = Captions[k].Text + " " + np.ToString()+"/"+num_pages.ToString();
                        g.DrawString(s, fnt, Brushes.Black, rec, sf);

                    }
                    else
                    {
                        string s = Captions[k].Text;
                        g.DrawString(s, fnt, Brushes.Black, rec, sf);
                    }
                }

            }
            PointF p = new PointF();
            p.X = tbl.posX; p.Y = tbl.posY;
            p = tbl.PrintHeader(g, p);
            
            for (int j = 0; j < tbl.LinesInPage; j++)
            {
                if (Lignes.Count > cl)
                {
                    ExportBase Ligne = (ExportBase)Lignes[cl];
                    if (Ligne.get_prop("Debit").Replace(".","") != "")
                        ptdeb += double.Parse(Ligne.get_prop("Debit").Replace(".", ""));
                    if (Ligne.get_prop("Credit").Replace(".", "") != "")
                        ptcred += double.Parse(Ligne.get_prop("Credit").Replace(".", ""));

                    if ((cl % tbl.LinesInPage) == 0)
                    {
                        if (cl != 0)
                        {
                            string rd = Fonctions.format04(ptdeb.ToString());
                            string rc = Fonctions.format04(ptcred.ToString());
                            p = tbl.PrintReport(g, p, "Report :", rd, rc);
                        }
                        if (Lignes.Count > 1) p = tbl.PrintRow(g, p, cl);
                        else p = tbl.PrintRow(g, p, cl);
                    }

                    else if ((cl % tbl.LinesInPage == tbl.LinesInPage - 1) || (cl == Lignes.Count - 1))
                    {
                        p = tbl.PrintRow(g, p, cl);
                        p = tbl.PrintFooter(g, p);
                        string rd = Fonctions.format04(ptdeb.ToString());
                        string rc = Fonctions.format04(ptcred.ToString());
                        p = tbl.PrintFreport(g, p, "Total Page :", rd, rc);
                        

                    }

                    else p = tbl.PrintRow(g, p, cl);
                    cl++;
                }
                else
                {
                   
                    e.HasMorePages = false;
                    return;
                }

            }
            np++;
            e.HasMorePages = true;
        }

      
    }
}
