using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Printing;
using System.Data;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;
using Export.Commun;

namespace Impression
{
    /// <summary>
    /// Description résumée de Tableau.
    /// </summary>
    /// 
   
    public class Tableau
    {
        public struct colonne
        {
            public Font Column_Font;

            public float width;
            public string title;
            public string mapping;
            public int padding;
            public int Zeropadding;
            public float Cell_margin;

            public Alignment Cell_alignAlignment;
        } 
        
        private List<colonne> Container;
       
        public Font Header_Font; //header font
       
        public int Header_Rows;
        public int LinesInPage;
        public float Header_height;
        public float Header_margin;
        public float Cell_height;
        public Alignment Header_alignment;
        public float posX;
        public float posY;
      
        public DataRow[] drs;
        public ArrayList Lignes;

        float h;
        public Pen Frame_Pen;

        public Tableau(Font fnt,float frame_thickness)
        {
            //
            // TODO : ajoutez ici la logique du constructeur
            //
            Container = new List<colonne>(0);
            Header_Font = fnt;
            Frame_Pen = new Pen(new SolidBrush(Color.Black), frame_thickness);

            h = Header_Font.GetHeight();
        }
       
       
        private void DrawHeaderString(String s, Graphics g,Font fnt, RectangleF rec, Pen pen,StringFormat sf)
        {
            PointF P_lt = new PointF();
            PointF P_lb = new PointF();
            PointF P_rt = new PointF();
            PointF P_rb = new PointF();
            PointF P_lb1 = new PointF();
            PointF P_rb1 = new PointF();

            P_lt.X = rec.Left;
            P_lt.Y = rec.Top;
            P_lb.X = rec.Left;
            P_lb.Y = rec.Bottom;

            P_lb1.X = rec.Left;
            P_lb1.Y = rec.Bottom + Header_margin*h;

            P_rt.X = rec.Right;
            P_rt.Y = rec.Top;
            P_rb.X = rec.Right;
            P_rb.Y = rec.Bottom;

            P_rb1.X = rec.Right;
            P_rb1.Y = rec.Bottom + Header_margin*h; 
            
            g.DrawLine(pen, P_lt, P_lb1);
            g.DrawLine(pen, P_rt, P_rb1);
           
            g.DrawLine(pen, P_lt, P_rt);
            g.DrawLine(pen, P_lb, P_rb);
            
            rec.Y = rec.Y + (rec.Height) / 2 - h/2;
            rec.Height = h;
            g.DrawString(s, fnt, Brushes.Black,rec, sf);
            
          
           
        }
        private void DrawHeader1String(String s, Graphics g, Font fnt, RectangleF rec, Pen pen, StringFormat sf)
        {
            PointF P_lt = new PointF();
            PointF P_lb = new PointF();
            PointF P_rt = new PointF();
            PointF P_rb = new PointF();
          
            P_lt.X = rec.Left;
            P_lt.Y = rec.Top;
            P_lb.X = rec.Left;
            P_lb.Y = rec.Bottom;

            P_rt.X = rec.Right;
            P_rt.Y = rec.Top;
            P_rb.X = rec.Right;
            P_rb.Y = rec.Bottom;
                      

            g.DrawLine(pen, P_lt, P_lb);
            g.DrawLine(pen, P_rt, P_rb);

            g.DrawLine(pen, P_lt, P_rt);
            g.DrawLine(pen, P_lb, P_rb);

            rec.Y = rec.Y + (rec.Height) / 2 - h / 2;
            rec.Height = h;
            rec.Width = rec.Width -  Header_margin * h;
            g.DrawString(s, fnt, Brushes.Black, rec, sf);



        }
        private void DrawRowString(String s, Graphics g, Font fnt, RectangleF rec, Pen pen, StringFormat sf,float margin)
        {
            PointF P_lt = new PointF();
            PointF P_lb = new PointF();
            PointF P_rt = new PointF();
            PointF P_rb = new PointF();

            P_lt.X = rec.Left;
            P_lt.Y = rec.Top;
            P_lb.X = rec.Left;
            P_lb.Y = rec.Bottom;

            P_rt.X = rec.Right;
            P_rt.Y = rec.Top;
            P_rb.X = rec.Right;
            P_rb.Y = rec.Bottom;
            
            g.DrawLine(pen, P_lt, P_lb);
            g.DrawLine(pen, P_rt, P_rb);
                  
            rec.Y = rec.Y + (rec.Height) / 2 - h / 2;
            rec.X = rec.X + margin ;
            rec.Width = rec.Width - 2 * margin;
            rec.Height = h;

            g.DrawString(s, fnt, Brushes.Black, rec, sf);
            
            

        }
        private void DrawReportString(String s, Graphics g, Font fnt, RectangleF rec, Pen pen, StringFormat sf, float margin)
        {
            PointF P_lt = new PointF();
            PointF P_lb = new PointF();
            PointF P_rt = new PointF();
            PointF P_rb = new PointF();

            P_lt.X = rec.Left;
            P_lt.Y = rec.Top;
            P_lb.X = rec.Left;
            P_lb.Y = rec.Bottom + 2 * Header_margin * h; 

            P_rt.X = rec.Right;
            P_rt.Y = rec.Top;
            P_rb.X = rec.Right;
            P_rb.Y = rec.Bottom + 2 * Header_margin * h;
            
            g.DrawLine(pen, P_lt, P_lb);
            g.DrawLine(pen, P_rt, P_rb);  

            rec.Y = rec.Y + (rec.Height) / 2 - h / 2;
            rec.X = rec.X + margin;
            rec.Width = rec.Width - 2 * margin;
            rec.Height = h;

            g.DrawString(s, fnt, Brushes.Black, rec, sf);

           

        }
        private void DrawFReportString(String s, Graphics g, Font fnt, RectangleF rec, Pen pen, StringFormat sf, float margin)
        {
            PointF P_lt = new PointF();
            PointF P_lb = new PointF();
            PointF P_rt = new PointF();
            PointF P_rb = new PointF();

            P_lt.X = rec.Left;
            P_lt.Y = rec.Top;
            P_lb.X = rec.Left;
            P_lb.Y = rec.Bottom;

            P_rt.X = rec.Right;
            P_rt.Y = rec.Top;
            P_rb.X = rec.Right;
            P_rb.Y = rec.Bottom;

            rec.Y = rec.Y + (rec.Height) / 2 - h / 2;
            rec.X = rec.X + margin;
            rec.Width = rec.Width - 2 * margin;
            rec.Height = h;

            g.DrawString(s, fnt, Brushes.Black, rec, sf);

            g.DrawLine(pen, P_lt, P_lb);
            g.DrawLine(pen, P_rt, P_rb);

            g.DrawLine(pen, P_lt, P_rt);
            g.DrawLine(pen, P_lb, P_rb);

        }
        private void DrawFootRect(Graphics g, RectangleF rec, Pen pen)
        {
            PointF P_lt = new PointF();
            PointF P_lb = new PointF();
            PointF P_rt = new PointF();
            PointF P_rb = new PointF();
            PointF P_lb1 = new PointF();
            PointF P_rb1 = new PointF();

            P_lt.X = rec.Left;
            P_lt.Y = rec.Top;
            P_lb.X = rec.Left;
            P_lb.Y = rec.Bottom;

            P_lb1.X = rec.Left;
            P_lb1.Y = rec.Bottom ;

            P_rt.X = rec.Right;
            P_rt.Y = rec.Top;
            P_rb.X = rec.Right;
            P_rb.Y = rec.Bottom;

            P_rb1.X = rec.Right;
            P_rb1.Y = rec.Bottom ;

            g.DrawLine(pen, P_lt, P_lb1);
            g.DrawLine(pen, P_rt, P_rb1);
            g.DrawLine(pen, P_lb1, P_rb1);
          

        }
       
        public void PutColInContainer(colonne col)
        {
            Container.Add(col);
        }
        
        public PointF PrintHeader(Graphics g, PointF pt)
        {
             // p : point d'affichage
            PointF p = pt;
            float X = pt.X;

            StringFormat sf= new StringFormat();
            if (Header_alignment == Alignment.center)
                sf.Alignment = StringAlignment.Center;
            else if (Header_alignment == Alignment.left)
                sf.Alignment = StringAlignment.Near;
            else if (Header_alignment == Alignment.right)
                sf.Alignment = StringAlignment.Far;
           

            string[] Ncol = new String[Container.Count];
            for (int i = 0; i < Ncol.Length; i++)
            {
                Ncol[i] = Container[i].title;
            }
            float[] lrgs = new float[Container.Count + 1];
            lrgs[0] = 0;
            for (int i = 1; i < lrgs.Length; i++)
            {
                lrgs[i] = Container[i - 1].width * h;

            }
                    
            for (int i = 1; i < lrgs.Length; i++)
            {
                string s = Ncol[i - 1];
                p.X = p.X + lrgs[i - 1];
                RectangleF rec = new RectangleF(p.X, p.Y, lrgs[i], (Header_height) * h);
                DrawHeaderString(s, g, Header_Font, rec, Frame_Pen,sf);
            }
            

            pt.X = X;
            pt.Y = p.Y + (Header_height+Header_margin) * h ;
            return pt;
            

        }
        public PointF PrintHeader1(Graphics g, PointF pt)
        {
             // p : point d'affichage
            PointF p = pt;
            float X = pt.X;
                       
            string[] Ncol = new String[Container.Count];
            for (int i = 0; i < Ncol.Length; i++)
            {
                Ncol[i] = Container[i].title;
            }
            float[] lrgs = new float[Container.Count + 1];
            lrgs[0] = 0;
            for (int i = 1; i < lrgs.Length; i++)
            {
                lrgs[i] = Container[i - 1].width * h;

            }
           

            for (int i = 1; i < lrgs.Length; i++)
            {
                string s = Ncol[i - 1];
                p.X = p.X + lrgs[i - 1];

                StringFormat sf = new StringFormat();
                if (Container[i - 1].Cell_alignAlignment == Alignment.center)
                   sf.Alignment = StringAlignment.Center;
                else if (Container[i - 1].Cell_alignAlignment == Alignment.left)
                   sf.Alignment = StringAlignment.Near;
                else if (Container[i - 1].Cell_alignAlignment == Alignment.right)
                   sf.Alignment = StringAlignment.Far;
                RectangleF rec = new RectangleF(p.X, p.Y, lrgs[i], (Header_height) * h);
                DrawHeader1String(s, g, Header_Font, rec, Frame_Pen, sf);
            }


            pt.X = X;
            pt.Y = p.Y + (Header_height) * h;
            return pt;

        }
           
        public PointF PrintRow(Graphics g, PointF pt, int index)
        {
            // p : point d'angle basse droite. 
            PointF p = pt;
            float X = pt.X;

            string[] champs = new String[Container.Count];
            for (int i = 0; i < champs.Length; i++)
            {
                ExportBase Ligne = (ExportBase)Lignes[index];
                
                champs[i] = Ligne.get_prop(Container[i].mapping);
                
            }
            float[] lrgs = new float[Container.Count + 1];
            lrgs[0] = 0;
            for (int i = 1; i < lrgs.Length; i++)
            {
                lrgs[i] = Container[i - 1].width * h;

            }

            //p.X = 20;
            //p.Y = 70;
            for (int i = 1; i < lrgs.Length; i++)
            {
                Font Column_Font = Container[i - 1].Column_Font;
                if (Column_Font == null) Column_Font = Header_Font;

                string s = "";
                if (champs[i - 1] != "") 
                    s = champs[i - 1].PadLeft(Container[i - 1].Zeropadding, '0');
                if (s == "00000000") s = "";
                s = s.PadLeft(Container[i - 1].padding, ' ');

                p.X = p.X + lrgs[i - 1];

                StringFormat sf = new StringFormat();
                if (Container[i - 1].Cell_alignAlignment == Alignment.center)
                    sf.Alignment = StringAlignment.Center;
                else if (Container[i - 1].Cell_alignAlignment == Alignment.left)
                    sf.Alignment = StringAlignment.Near;
                else if (Container[i - 1].Cell_alignAlignment == Alignment.right)
                    sf.Alignment = StringAlignment.Far;

                RectangleF rec;
                rec = new RectangleF(p.X, p.Y, lrgs[i], Cell_height * h);
                DrawRowString(s, g, Column_Font, rec, Frame_Pen, sf, Header_margin * h);

            }
            pt.X = X;
            pt.Y = p.Y + Cell_height * h;

            return pt;
        }

        public PointF PrintFooter(Graphics g, PointF pt)
        {
              // p : point d'affichage
            PointF p = pt;
            float X = pt.X; 
              
            float[] lrgs = new float[Container.Count + 1];
            lrgs[0] = 0;
            for (int i = 1; i < lrgs.Length; i++)
            {
                lrgs[i] = Container[i - 1].width * h;

            }
          

            for (int i = 1; i < lrgs.Length; i++)
            {
               
                p.X = p.X + lrgs[i - 1];
                RectangleF rec = new RectangleF(p.X, p.Y, lrgs[i], (Header_margin) * h);
                DrawFootRect(g, rec, Frame_Pen);
            }


            pt.X = X;
            pt.Y = p.Y + (Header_margin) * h;
            return pt;
        }
   
        

        public PointF PrintReport(Graphics g, PointF pt, string report, string debit, string credit)
        {
            float X = pt.X;
           
            string[] champs = new String[Container.Count];
          
            for (int i = 0; i < champs.Length; i++)
            {
                
                champs[i] = "";
                if (i == champs.Length - 1)
                {
                    if (credit != "") champs[i] = credit;
                    else champs[i] = "";
                }
                if (i == champs.Length - 2)
                {
                    if (debit != "") champs[i] = debit;
                    else champs[i] = "";
                }
                if (i == champs.Length - 3) champs[i] = report;


            }
            float[] lrgs = new float[Container.Count + 1];
            lrgs[0] = 0;
            for (int i = 1; i < lrgs.Length; i++)
            {
                lrgs[i] = Container[i - 1].width * h;

            }

            // p : point d'affichage
            PointF p = pt;
            p.Y = pt.Y;
         
            
            for (int i = 1; i < lrgs.Length; i++)
            {
                Font Column_Font = Container[i - 1].Column_Font;
                if (Column_Font == null) Column_Font = Header_Font; 
              
                string s = champs[i - 1];
                p.X = p.X + lrgs[i - 1];

                StringFormat sf = new StringFormat();
                if (Container[i - 1].Cell_alignAlignment == Alignment.center)
                    sf.Alignment = StringAlignment.Center;
                else if (Container[i - 1].Cell_alignAlignment == Alignment.left)
                    sf.Alignment = StringAlignment.Near;
                else if (Container[i - 1].Cell_alignAlignment == Alignment.right)
                    sf.Alignment = StringAlignment.Far;

                RectangleF rec = new RectangleF(p.X, p.Y, lrgs[i], (Cell_height) * h);
                DrawReportString(s, g, Column_Font, rec, Frame_Pen, sf, Header_margin * h);
                
       
            }
          

            pt.X = X;
            pt.Y = p.Y + Cell_height + 4 * Header_margin * h;
            return pt;
        }
     
        public PointF PrintFreport(Graphics g, PointF pt, string areport, string debit, string credit)
        {
            float X = pt.X;
           
            string[] champs = new String[Container.Count];

            for (int i = 0; i < champs.Length; i++)
            {
                champs[i] = "";
                if (i == champs.Length - 1)
                {
                    if (credit != "") champs[i] = credit;
                    else
                    {
                        champs[i] = "";
                        
                    }
                }
                if (i == champs.Length - 2)
                {
                    if (debit != "") champs[i] = debit;
                    else champs[i] = "";
                }
                if (i == champs.Length - 3) champs[i] = areport;


            }
            float[] lrgs = new float[Container.Count + 1];
            lrgs[0] = 0;
            for (int i = 1; i < lrgs.Length; i++)
            {
                lrgs[i] = Container[i - 1].width * h;

            }
            // p : point d'affichage
            PointF p = pt;
            p.Y = pt.Y+2*h;
                      
            for (int i = 1; i < lrgs.Length; i++)
            {
                StringFormat sf = new StringFormat();
                if (Container[i - 1].Cell_alignAlignment == Alignment.center)
                    sf.Alignment = StringAlignment.Center;
                else if (Container[i - 1].Cell_alignAlignment == Alignment.left)
                    sf.Alignment = StringAlignment.Near;
                else if (Container[i - 1].Cell_alignAlignment == Alignment.right)
                    sf.Alignment = StringAlignment.Far;
 
                Font Column_Font = Container[i - 1].Column_Font;
                if (Column_Font == null) Column_Font = Header_Font;

                string s = champs[i - 1];
                p.X = p.X + lrgs[i - 1];

                RectangleF rec = new RectangleF(p.X, p.Y, lrgs[i], (Cell_height) * h);
                
                if (i > lrgs.Length - 4)
                {
                    DrawFReportString(s, g, Column_Font, rec, Frame_Pen, sf, Header_margin * h);
                    
                }
            }
            
            pt.X = X;
            pt.Y = p.Y + Cell_height * h + 0.5F * h;
            return pt;
           

        }
        
        public PointF PrintReport(Graphics g, PointF pt, string report, string anouv, string mdebit, string mcredit, string sdebit, string scredit)
        {
            float X = pt.X;
            
            string[] champs = new String[Container.Count];

            for (int i = 0; i < champs.Length; i++)
            {
                champs[i] = "";
                if (i == champs.Length - 1)
                {
                    if (scredit != "") champs[i] = scredit;
                    else champs[i] = "";
                    
                }
                if (i == champs.Length - 2)
                {
                    if (sdebit != "") champs[i] = sdebit;
                    else champs[i] = "";
                }
                if (i == champs.Length - 3)
                {
                    if (mcredit != "") champs[i] = mcredit;
                    else champs[i] = "";
                }
                if (i == champs.Length - 4)
                {
                    if (mdebit != "") champs[i] = mdebit;
                    else champs[i] = "";
                }
                if (i == champs.Length - 5)
                {
                    if (anouv != "") champs[i] = anouv;
                    else champs[i] = "";
                }
                if (i == champs.Length - 6) champs[i] = report;

            }
            float[] lrgs = new float[Container.Count + 1];
            lrgs[0] = 0;
            for (int i = 1; i < lrgs.Length; i++)
            {
                lrgs[i] = Container[i - 1].width * h;

            }

            // p : point d'affichage
            PointF p = pt;
            p.Y = pt.Y;


            for (int i = 1; i < lrgs.Length; i++)
            {
                StringFormat sf = new StringFormat();
                if (Container[i - 1].Cell_alignAlignment == Alignment.center)
                    sf.Alignment = StringAlignment.Center;
                else if (Container[i - 1].Cell_alignAlignment == Alignment.left)
                    sf.Alignment = StringAlignment.Near;
                else if (Container[i - 1].Cell_alignAlignment == Alignment.right)
                    sf.Alignment = StringAlignment.Far;

                
                Font Column_Font = Container[i - 1].Column_Font;
                if (Column_Font == null) Column_Font = Header_Font;

                string s = champs[i - 1];
                p.X = p.X + lrgs[i - 1];
                
                RectangleF rec = new RectangleF(p.X, p.Y, lrgs[i], (Cell_height) * h);

                DrawReportString(s, g, Column_Font, rec, Frame_Pen, sf, Header_margin * h);
                

            }


            pt.X = X;
            pt.Y = p.Y + Cell_height * h ;
            return pt;
        }
        public PointF PrintFreport(Graphics g, PointF pt, string report, string anouv, string mdebit, string mcredit, string sdebit, string scredit)
        {
            float X = pt.X;
            
            string[] champs = new String[Container.Count];

       
            for (int i = 0; i < champs.Length; i++)
            {
                champs[i] = "";
                if (i == champs.Length - 1)
                {
                    if (scredit != "") champs[i] = scredit;
                    else champs[i] = "";
                        
                    
                }
                if (i == champs.Length - 2)
                {
                    if (sdebit != "") champs[i] = sdebit;
                    else champs[i] = "";
                }
                if (i == champs.Length - 3)
                {
                    if (mcredit != "") champs[i] = mcredit;
                    else champs[i] = "";
                }
                if (i == champs.Length - 4)
                {
                    if (mdebit != "") champs[i] = mdebit;
                    else champs[i] = "";
                }
                if (i == champs.Length - 5)
                {
                    if (anouv != "") champs[i] = anouv;
                    else champs[i] = "";
                }
                if (i == champs.Length - 6) champs[i] = report;


            }
            float[] lrgs = new float[Container.Count + 1];
            lrgs[0] = 0;
            for (int i = 1; i < lrgs.Length; i++)
            {
                lrgs[i] = Container[i - 1].width * h;

            }
            // p : point d'affichage
            PointF p = pt;
            p.Y = pt.Y + 2 * h;

            for (int i = 1; i < lrgs.Length; i++)
            {
                StringFormat sf = new StringFormat();
                if (Container[i - 1].Cell_alignAlignment == Alignment.center)
                    sf.Alignment = StringAlignment.Center;
                else if (Container[i - 1].Cell_alignAlignment == Alignment.left)
                    sf.Alignment = StringAlignment.Near;
                else if (Container[i - 1].Cell_alignAlignment == Alignment.right)
                    sf.Alignment = StringAlignment.Far;

                

                Font Column_Font = Container[i - 1].Column_Font;
                if (Column_Font == null) Column_Font = Header_Font;

                string s = champs[i - 1];
                p.X = p.X + lrgs[i - 1];
                
                RectangleF rec = new RectangleF(p.X, p.Y, lrgs[i], (Cell_height) * h);

                               
                if (i > lrgs.Length - 7)
                {
                    DrawFReportString(s, g, Column_Font, rec, Frame_Pen, sf, Header_margin * h);
                }
            }

            pt.X = X;
            pt.Y = p.Y + Cell_height * h + 0.5F * h;
            return pt;
           

        }

             
    }
}
