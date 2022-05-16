using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;
using Utilitaire;
using CoucheAcceeDonnees;


namespace SaisieCompta
{
    class SaisieOpLogic
    {
        DataBaseAcess db;
        public System.Data.DataSet ds;
        private System.Data.DataTable dt_table;

        public System.Data.DataTable table
        {
            get { return dt_table; }

        }

        public string Journal_Intitule;
        public string Contre_Partie;
        public bool cpa;
       
        
        public string Compte_Intitule;
        public string Libellé_Intitule;

        public double mdeb;
        public double mcred;
        public double cdeb;
        public double ccred;

        /*........... Ecriture ........*/
        public string iDate;
        public string Date;
        public string Cmpt;
        public string Cpart;
        public string Piece;
        public string Libelle;
        public bool debit;
        public string Mnt;
        public string Idjour;
        public string Exercice;
        public string La;
        /*..............................*/



        public SaisieOpLogic(DataBaseAcess db0)
        {
            db = db0;
            dt_table = new DataTable("Ecritures");
            DataColumn dc0 = new DataColumn("Date", typeof(string));
            dt_table.Columns.Add(dc0);
            DataColumn dc1 = new DataColumn("Compte", typeof(string));
            dt_table.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("CPartie", typeof(string));
            dt_table.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn("N°Ordre", typeof(string));
            dt_table.Columns.Add(dc3);
            DataColumn dc4 = new DataColumn("La", typeof(string));
            dt_table.Columns.Add(dc4);
            DataColumn dc5 = new DataColumn("Libellé", typeof(string));
            dt_table.Columns.Add(dc5);
            DataColumn dc6 = new DataColumn("DC", typeof(string));
            dt_table.Columns.Add(dc6);
            DataColumn dc7 = new DataColumn("Montant", typeof(string));
            dt_table.Columns.Add(dc7);

            ds = db.Ds;
            db.Fill_Comptes();
            db.Fill_Ecritures();
            db.Fill_LibellesAutomatiques();
            db.Fill_Journaux();
       }

        

        public int Enregister(bool cpa)
        {
            int b = 0; 
            SqlTransaction tran = db.load_tran();
            try
            {

                DataRow dr = ds.Tables["Ecritures"].NewRow();

                dr["iDate"] = iDate;
                dr["Cmpt"] = Cmpt;
                dr["Cpart"] = Cpart;
                dr["npcompta"] = Piece;
                dr["Libellé"] = Libelle;
                dr["debit"] = debit;
                dr["Mnt"] = Mnt;
                dr["IdJournal"] = Idjour;
                dr["Exercice"] = Exercice;
                dr["date"] = Date;
                dr["la"] = La;
                ds.Tables["op"].Rows.Add(dr);

                if (cpa == true)
                {
                    DataRow dr1 = ds.Tables["op"].NewRow();
                   
                    dr1["iDate"] = iDate;
                    dr1["Cmpt"] = Cpart;
                    dr1["Cpart"] = Cmpt;
                    dr1["npcompta"] = Piece;
                    dr1["Libellé"] = Libelle;
                    dr1["debit"] = !debit;
                    dr1["Mnt"] = Mnt;
                    dr1["IdJournal"] = Idjour;
                    dr1["Exercice"] = Exercice;
                    dr1["date"] = Date;
                    dr1["la"] = La;
                    ds.Tables["op"].Rows.Add(dr1);

                }

                // datagrid
                DataRow row = dt_table.NewRow();
                row["Date"] = Date;
                row["Compte"] = Cmpt;
                row["CPartie"] = Cpart;
                row["N°Ordre"] = Piece;
                row["La"] = La;
                row["Libellé"] = dr["Libellé"].ToString();
              
                double mnt = (double)dr["Mnt"];
                if (debit == true)
                {
                    row["DC"] = "D";
                    mdeb += mnt;
                    cdeb += mnt;
                }
                else
                {
                    row["DC"] = "C";
                    mcred += mnt;
                    ccred += mnt;
                }
                row["Montant"] = Fonctions.format1(mnt.ToString());
                dt_table.Rows.Add(row);

                if (cpa == true)
                {
                    DataRow row1 = dt_table.NewRow();
                    row1["Date"] = Date;
                    row1["Compte"] = Cpart;
                    row1["CPartie"] = Cmpt;
                    row1["N°Ordre"] = Piece;
                    row1["La"] = La;
                    row1["Libellé"] = dr["Libellé"].ToString();

                    mnt = (double)dr["Mnt"];
                    if (debit == true)
                    {
                        row1["DC"] = "C";
                        mcred += mnt;
                        ccred += mnt;
                    }
                    else
                    {
                        row1["DC"] = "D";
                        mdeb += mnt; 
                        cdeb += mnt;
                    }
                    row1["Montant"] = Fonctions.format1(mnt.ToString());
                    dt_table.Rows.Add(row1);

                }

                db.Update_Ecritures();
                tran.Commit();


            }
            catch (SqlException ex)
            {
                b = 1;
                MessageBox.Show(ex.ToString());
                try
                {
                    tran.Rollback();
                }
                catch (Exception iex)
                {
                    b = 2;
                }
 
            }
            finally
            {
                tran.Dispose();
            }

            return b;
          
        }

        public int get_compte_intitulé(string Cmpt)
        {
            DataRow[] drjs = ds.Tables["Plan"].Select("Cmpt = " + Cmpt);
            Compte_Intitule = "";
            if (drjs.Length > 0)
            {
                Compte_Intitule = drjs[0]["Int"].ToString();
                return 0;
            }

            return 1;
        }

        public int get_journal(string idj)
        {
            DataRow[] drjs = ds.Tables["jouraux"].Select("Cde = " + idj);
            Journal_Intitule = "";
            if (drjs.Length > 0)
            {
                Journal_Intitule = drjs[0]["Int"].ToString();
                Contre_Partie = drjs[0]["Cmpt"].ToString();
                cpa = (bool)(drjs[0]["Cpa"]);
                return 0;
            }
            return 1;
        }

        public int get_libelle_intitule(string id)
        {
            DataRow[] drjs = ds.Tables["Libelles"].Select("Cde = " + id);
            Libellé_Intitule = "";
            if (drjs.Length > 0)
            {
                Libellé_Intitule = drjs[0]["Int"].ToString();
                return 0;
            }
            return 1;
        }

        public void Afficher_Mouvements(string idj, string idate1, string idate2)
        {
            dt_table.Clear();
            mdeb = 0;
            mcred = 0;
            DataRow[] drs = ds.Tables["op"].Select("IdJournal =" + idj + " and iDate <=" + idate2 + "and iDate >=" + idate1, "npcompta");
            foreach (DataRow dr in drs)
            {
                DataRow row = dt_table.NewRow();
                row["Date"] = dr["date"].ToString();
                row["Compte"] = dr["Cmpt"].ToString();
                row["CPartie"] = dr["Cpart"].ToString();
                row["N°Ordre"] = dr["npcompta"].ToString();
                row["La"] = dr["la"].ToString();
                row["Libellé"] = dr["Libellé"].ToString();
                bool st = (bool)dr["debit"];
                double mnt = (double) dr["Mnt"];
                if (st == true)
                {
                    row["DC"] = "D";
                    mdeb += mnt;
                }
                else
                {
                    row["DC"] = "C"; 
                    mcred += mnt;
                }
                row["Montant"] = Fonctions.format1(mnt.ToString());
                dt_table.Rows.Add(row);
               
               
           }
            
        }

        public void Afficher_Mouvements_Mois(string idj, string mois, string an)
        {
            dt_table.Clear();
            mdeb = 0;
            mcred = 0;
            string ddate = "0/" + mois + "/" + an;
            string fdate = "31/" + mois + "/" + an;
            int idate1 = Fonctions.DateToInt(ddate);
            int idate2 = Fonctions.DateToInt(fdate);
            DataRow[] drs = ds.Tables["op"].Select("IdJournal =" + idj + " and iDate <=" + idate2 + "and iDate >=" + idate1, "npcompta");
            foreach (DataRow dr in drs)
            {
                DataRow row = dt_table.NewRow();
                row["Date"] = dr["date"].ToString();
                row["Compte"] = dr["Cmpt"].ToString();
                row["CPartie"] = dr["Cpart"].ToString();
                row["N°Ordre"] = dr["npcompta"].ToString();
                row["La"] = dr["la"].ToString();
                row["Libellé"] = dr["Libellé"].ToString();
                bool st = (bool)dr["debit"];
                double mnt = (double)dr["Mnt"];
                if (st == true)
                {
                    row["DC"] = "D";
                    mdeb += mnt;
                }
                else
                {
                    row["DC"] = "C";
                    mcred += mnt;
                }
                row["Montant"] = Fonctions.format1(mnt.ToString());
                dt_table.Rows.Add(row);


            }

        }

        public void Afficher_Cumuls(string idj)
        {
            cdeb = 0;
            ccred = 0;
            DataRow[] drs = ds.Tables["op"].Select("IdJournal =" + idj , "npcompta");
            foreach (DataRow dr in drs)
            {
                bool st = (bool)dr["debit"];
                double mnt = (double)dr["Mnt"];
                if (st == true) cdeb += mnt;
                else ccred += mnt;
                
            }

        }



    }
}
