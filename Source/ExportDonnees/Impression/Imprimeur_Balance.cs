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
    public class Imprimeur_Balance : Imprimeur
    {
               
        public string Niveau;
        double panouv, pmdeb, pmcred, psdeb, pscred;
       

        public override void BuildDocument()
        {
            np = 1;
            cl = 0;
            panouv = pmdeb = pmcred = psdeb = pscred = 0;

            Document = new PrintDocument();
            Document.PrintPage += Document_PrintPage;
            Document.DefaultPageSettings.PaperSize = new PaperSize("Lettre", 850, 1100);

        }

        protected override void Document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            for (int k = 0; k < Captions.Count; k++)
            {
                Font fnt = Captions[k].fnt;
                RectangleF rec = Captions[k].rec;
                if (k == 0)
                {
                    string s = Captions[k].Text + " " + np.ToString() + "/" + num_pages.ToString();
                    g.DrawString(s, fnt, Brushes.Black, rec, sf);
                }
                else
                {
                    string s = Captions[k].Text;
                    g.DrawString(s, fnt, Brushes.Black, rec, sf);
                }
            }


            PointF p = new PointF();
            p.X = tbl.posX; p.Y = tbl.posY;
            p = tbl.PrintHeader(g, p);

            for (int j = 0; j < tbl.LinesInPage; j++)
            {
                if (Lignes.Count > cl)
                {
                    double anouv, mdebit, mcredit, sdebit, scredit;
                    anouv = mdebit = mcredit = sdebit = scredit = 0;
                    string niv = "";
                    ExportBase Ligne = (ExportBase)Lignes[cl];
                    if (Ligne.get_prop("Anouv").Replace(".", "") != "")
                        anouv = double.Parse(Ligne.get_prop("Anouv").Replace(".", ""));
                    if (Ligne.get_prop("Mvtdeb").Replace(".", "") != "")
                        mdebit = double.Parse(Ligne.get_prop("Mvtdeb").Replace(".", ""));
                    if (Ligne.get_prop("Mvtcred").Replace(".", "") != "")
                        mcredit = double.Parse(Ligne.get_prop("Mvtcred").Replace(".", ""));
                    if (Ligne.get_prop("Sldeb").Replace(".", "") != "")
                        sdebit = double.Parse(Ligne.get_prop("Sldeb").Replace(".", ""));
                    if (Ligne.get_prop("Sldcred").Replace(".", "") != "")
                        scredit = double.Parse(Ligne.get_prop("Sldcred").Replace(".", ""));
                    niv = Ligne.get_prop("Niv").ToString();
                    if (niv == Niveau)
                    {
                        panouv += anouv;
                        pmdeb += mdebit;
                        pmcred += mcredit;
                        psdeb += sdebit;
                        pscred += scredit;
                    }

                    if ((cl % tbl.LinesInPage) == 0)
                    {
                        if (cl != 0)
                        {
                            string sanouv = Fonctions.format04(panouv.ToString());
                            string mdeb = Fonctions.format04(pmdeb.ToString());
                            string mcred = Fonctions.format04(pmcred.ToString());
                            string sdeb = Fonctions.format04(psdeb.ToString());
                            string scred = Fonctions.format04(pscred.ToString());
                            p = tbl.PrintReport(g, p, "Report :", sanouv, mdeb, mcred, sdeb, scred);
                        }
                    }

                    p = tbl.PrintRow(g, p, cl);


                    if ((cl % tbl.LinesInPage == tbl.LinesInPage - 1) || (cl == Lignes.Count - 1))
                    {
                        string sanouv = Fonctions.format04(panouv.ToString());
                        string mdeb = Fonctions.format04(pmdeb.ToString());
                        string mcred = Fonctions.format04(pmcred.ToString());
                        string sdeb = Fonctions.format04(psdeb.ToString());
                        string scred = Fonctions.format04(pscred.ToString());

                        p = tbl.PrintFooter(g, p);
                        p = tbl.PrintFreport(g, p, "Total Page :", sanouv, mdeb, mcred, sdeb, scred);


                    }
                    cl++;
                    if (cl == Lignes.Count)
                    {
                        e.HasMorePages = false;
                        return;
                    }
                    else e.HasMorePages = true;
                    
                }
            }
            np++;
        }

  
    }

   
}