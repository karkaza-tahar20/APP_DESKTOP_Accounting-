using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Utilitaire;

namespace CoucheAcceeDonnees
{
    class ImportationDonneeslogic
    {
        CAD db;
        private System.Data.DataSet ds;

        struct donneesTable
        {
            public string compte;
            public string intl;
            public string niv;
            public double anouv;
            public double mdeb;
            public double mcred;
            public double sdeb;
            public double scred;
        }

        Dictionary<string, int> dictio;

        public ImportationDonneeslogic(CAD db0)
        {
            db = db0;
            ds = db.Ds;
            db.Fill_Comptes();
            db.Fill_Ecritures();
            db.Fill_LibellesAutomatiques();
            db.Fill_Journaux();
        }

        public void importer_donnees()
        {
            DataRow[] drs_op = ds.Tables["Ecritures"].Select("");
            foreach (DataRow dr in drs_op)
                dr.Delete();
            db.Update_Ecritures();
            ds.AcceptChanges();


        }

        public void importer_donnees_anouveaux()
        {
            /* ........ Construction du dictionnaire et le tableau structure données ........ */
           
            dictio = new Dictionary<string, int>();

            DataRow[] drs = ds.Tables["Comptes"].Select();
            donneesTable[] dn_tables = new donneesTable[drs.Length];
            int i = 0;
            foreach (DataRow dr in drs)
            {
                double anv = 0;

                if (dr["MouvementCredit"].ToString() != "") anv -= (double)dr["MouvementCredit"];
                if (dr["MouvementDebit"].ToString() != "") anv += (double)dr["MouvementDebit"];

                donneesTable dn_table = new donneesTable();

                dn_table.compte = dr["Compte"].ToString();
                dn_table.intl = dr["Intitule"].ToString();
                dn_table.niv = dr["Niveau"].ToString();
                dn_table.anouv = anv;
                dn_table.mdeb = 0;
                dn_table.mcred = 0;

                dn_tables[i] = dn_table;
                dictio.Add(dn_table.compte, i);

                i++;
            }

            /*........... calcul mouvements ....................*/

            DataRow[] drops = ds.Tables["Ecritures"].Select("");
            foreach (DataRow dr in drops)
            {

                string cmpt = dr["Compte"].ToString();
                if (dictio.ContainsKey(cmpt) == true)
                {
                    bool debit = (bool)dr["Debit"];
                    double mnt = (double)dr["Montant"];
                    int index = dictio[cmpt];
                    if (debit == true) dn_tables[index].mdeb += mnt;
                    else dn_tables[index].mcred += mnt;
                }
            }


            for (int j = 0; j < dn_tables.Length; j++)
            {

                if (dn_tables[j].niv == "1")
                {
                    if (dn_tables[j].anouv >= 0)
                    {
                        if (dn_tables[j].anouv + dn_tables[j].mdeb >= dn_tables[j].mcred)
                        {
                            dn_tables[j].sdeb = dn_tables[j].anouv + dn_tables[j].mdeb - dn_tables[j].mcred;
                            dn_tables[j].scred = 0;
                        }
                        else
                        {
                            dn_tables[j].sdeb = 0;
                            dn_tables[j].scred = dn_tables[j].mcred - dn_tables[j].anouv - dn_tables[j].mdeb;
                        }

                    }
                    if (dn_tables[j].anouv < 0)
                    {
                        if (dn_tables[j].mcred - dn_tables[j].anouv >= dn_tables[j].mdeb)
                        {
                            dn_tables[j].sdeb = 0;
                            dn_tables[j].scred = dn_tables[j].mcred - dn_tables[j].anouv - dn_tables[j].mdeb;
                        }
                        else
                        {
                            dn_tables[j].sdeb = dn_tables[j].mdeb - dn_tables[j].mcred + dn_tables[j].anouv;
                            dn_tables[j].scred = 0;
                        }
                    }


                    DataRow[] drows = ds.Tables["plan"].Select("Compte =" + dn_tables[j].compte);

                    if (drows.Length > 0)
                    {
                        drows[0]["MouvementCredit"] = dn_tables[j].scred;
                        drows[0]["MouvementDebit"] = dn_tables[j].sdeb;
                    }

                }

            }

            db.Update_Comptes();
            ds.AcceptChanges();
            
            /*....................................................*/

            DataRow[] drs_op = ds.Tables["Ecritures"].Select("");
            foreach (DataRow dr in drs_op)
                dr.Delete();
            db.Update_Ecritures();
            ds.AcceptChanges();




        }

        public void raz_donnees()
        {
            DataRow[] drs_op = ds.Tables["Ecritures"].Select("");
            foreach (DataRow dr in drs_op)
                dr.Delete();
            DataRow[] drs_JourAux = ds.Tables["Journaux"].Select("");
            foreach (DataRow dr in drs_JourAux)
                dr.Delete();
            DataRow[] drs_Libelles = ds.Tables["LibellesAutomatiques"].Select("");
            foreach (DataRow dr in drs_Libelles)
                dr.Delete();
            DataRow[] drs_plan = ds.Tables["Comptes"].Select("");
            foreach (DataRow dr in drs_plan)
                dr.Delete();

            db.Update_Ecritures();
            db.Update_Journaux();
            db.Update_LibellesAutomatiques();
            db.Update_Comptes();
            
            ds.AcceptChanges();

        }

   }
}
