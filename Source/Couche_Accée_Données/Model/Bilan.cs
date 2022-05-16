using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace CoucheAcceeDonnees.Model
{
    public class Bilan
    {
        private CAD db;
        public Bilan(CAD db1)
        {
            db = db1;
        }

        public int Enregister(BilanModel bilan,int a)
        {
            int v = Random();
            a = v;
            Console.WriteLine("Enregistrer Bilan");
            int b = 0;
            DbTransaction tran = db.load_tran2();
            try
            {

                DataRow dr = db.Ds.Tables["Billan"].NewRow();

                dr["id"] = a;
                dr["CompteActif"] = bilan.CompteActif;
                Console.WriteLine("Enregistrer Ecriture CompteActif");
                dr["LibelleActif"] = bilan.LibelleActif;
                Console.WriteLine("Enregistrer Ecriture LibelleActif");
                dr["SoldeActif"] = bilan.SoldeActif;
                Console.WriteLine("Enregistrer Ecriture SoldeActif");
                dr["TotaleActif"] = bilan.TotaleActif;
                Console.WriteLine("Enregistrer Ecriture TotaleActif");
                dr["ComptePassif"] = bilan.ComptePassif;
                Console.WriteLine("Enregistrer Ecriture ComptePassif");
                dr["LibellePassif"] = bilan.LibellePassif;
                Console.WriteLine("Enregistrer Ecriture LibellePassif");
                dr["SoldePassif"] = bilan.SoldePassif;
                Console.WriteLine("Enregistrer Ecriture SoldePassif");
                dr["TotalePassif"] = bilan.TotalePassif;
                Console.WriteLine("Enregistrer Ecriture TotalePassif");
               
                db.Ds.Tables["Billan"].Rows.Add(dr);
                Console.WriteLine("Enregistrer Billan Add dr");

                Console.WriteLine("Avant Update_Bilan()");
                db.Update_Bilan();
                Console.WriteLine("Update_Bilan()");
                tran.Commit();


            }
            catch (DbException ex)
            {
                Console.WriteLine("Caaaaatch  Bilan");
                b = 1;
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

        private int Random()
        {
            throw new NotImplementedException();
        }
    }
}
