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
    public class Imprimeur_GrandLivre : Imprimeur
    {
        
       
        double ptdeb, ptcred;
        double mdeb, mcred;
        double anouv; 
        bool firstdate;
        

        public void Set(double anouv1, double rdeb1, double rcred1, bool firstdate1)
        { 
            anouv = anouv1;
            ptdeb = rdeb1;
            ptcred = rcred1;
            firstdate = firstdate1;
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
                        string s = Captions[k].Text + " " + np.ToString() + "/" + num_pages.ToString();
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
                    double deb = 0;
                    double cred = 0;
                    ExportBase Ligne = (ExportBase)Lignes[cl];
                    if (Ligne.get_prop("Debit").Replace(".", "") != "")
                        deb = double.Parse(Ligne.get_prop("Debit").Replace(".", ""));
                    if (Ligne.get_prop("Credit").Replace(".", "") != "")
                        cred = double.Parse(Ligne.get_prop("Credit").Replace(".", ""));

                    if ((cl % tbl.LinesInPage) == 0)
                    {
                        string rd = Fonctions.format04(ptdeb.ToString());
                        string rc = Fonctions.format04(ptcred.ToString());

                        if ((firstdate == true) && (cl == 0)) p = tbl.PrintReport(g, p, "", "", "");
                        else p = tbl.PrintReport(g, p, "Report :", rd, rc);

                        p = tbl.PrintRow(g, p, cl);

                        ptdeb += deb;
                        ptcred += cred;

                        if (((firstdate == true) && (cl != 0)) || (firstdate == false))
                        {
                            mdeb += deb;
                            mcred += cred;
                        }
                    }


                    else
                    {
                        p = tbl.PrintRow(g, p, cl);

                        ptdeb += deb;
                        ptcred += cred;
                        mdeb += deb;
                        mcred += cred;

                    }

                    if ((cl % tbl.LinesInPage == tbl.LinesInPage - 1) || (cl == Lignes.Count - 1))
                    {
                        p = tbl.PrintFooter(g, p);

                        string rd1 = Fonctions.format04(ptdeb.ToString());
                        string rc1 = Fonctions.format04(ptcred.ToString());

                        string rd10 = Fonctions.format04(mdeb.ToString());
                        string rc10 = Fonctions.format04(mcred.ToString());

                        string sd1 = "";
                        string sc1 = "";
                        string sld1 = "Solde ";
                        if (ptdeb > ptcred)
                        {
                            sld1 += "Débiteur";
                            sd1 = Fonctions.format04((ptdeb - ptcred).ToString());
                        }
                        if (ptdeb < ptcred)
                        {
                            sld1 += "Créditeur";
                            sc1 = Fonctions.format04((ptcred - ptdeb).ToString());

                        }

                        p.X = 50;
                        p.Y += 10;
                        p = GrandLivre_Footer(tbl.Header_Font, "A nouveau", "mvts débit", "mvts crédit", "Totaux", rd1, rc1).PrintHeader1(g, p);
                        p.Y += 10;
                        p = GrandLivre_Footer(tbl.Header_Font, Fonctions.format04(anouv.ToString()), rd10, rc10, sld1, sd1, sc1).PrintHeader1(g, p);
                        np++;


                    }

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

        private Tableau GrandLivre_Footer(Font fnt, string anouv, string mvdeb, string mvcred, string tsld, string debit, string credit)
        {

            Tableau tbla = new Tableau(tbl.Header_Font,2);

            tbla.Header_Font = fnt;
            tbla.Header_alignment = Alignment.center;
            tbla.Header_height = 2.2f;
            tbla.Header_margin = 0.5f;
            tbla.Cell_height = 1.5f;

            Tableau.colonne tblc0 = new Tableau.colonne();
            tblc0.title = anouv;
            tblc0.width = 10;
            tblc0.Cell_alignAlignment = Alignment.right;
            tbla.PutColInContainer(tblc0);
            Tableau.colonne tblc1 = new Tableau.colonne();
            tblc1.title = mvdeb;
            tblc1.width = 10;
            tblc1.Cell_alignAlignment = Alignment.right;
            tbla.PutColInContainer(tblc1);
            Tableau.colonne tblc3 = new Tableau.colonne();
            tblc3.title = mvcred;
            tblc3.width = 10;
            tblc3.Cell_alignAlignment = Alignment.right;
            tbla.PutColInContainer(tblc3);
            Tableau.colonne tblc5 = new Tableau.colonne();
            tblc5.title = tsld;
            tblc5.width = 10;
            tblc5.Cell_alignAlignment = Alignment.right;
            tbla.PutColInContainer(tblc5);
            Tableau.colonne tblc6 = new Tableau.colonne();
            tblc6.title = debit;
            tblc6.width = 7;
            tblc6.Cell_alignAlignment = Alignment.right;
            tbla.PutColInContainer(tblc6);
            Tableau.colonne tblc7 = new Tableau.colonne();
            tblc7.title = credit;
            tblc7.width = 7;
            tblc7.Cell_alignAlignment = Alignment.right;
            tbla.PutColInContainer(tblc7);
            return tbla;

        }

      
      
    }
}
