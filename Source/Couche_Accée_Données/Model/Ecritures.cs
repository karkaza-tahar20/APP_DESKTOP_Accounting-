using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace CoucheAcceeDonnees
{
    public class Ecritures
    {
        private CAD db;

        public Ecritures(CAD db1)
        {
            db = db1;
        }

        public int Enregister(EcritureModel ecriture, bool cpa)
        {
            Console.WriteLine("Enregistrer Ecriture");
            int b = 0;
            DbTransaction tran = db.load_tran();
            try
            {

                DataRow dr = db.Ds.Tables["Ecritures"].NewRow();

                dr["iDate"] = ecriture.iDate;
                Console.WriteLine("Enregistrer Ecriture IDDate");
                dr["Compte"] = ecriture.Compte;
                Console.WriteLine("Enregistrer Ecriture Compte");
                dr["ContrePartie"] = ecriture.ContrePartie;
                Console.WriteLine("Enregistrer Ecriture Cparti");
                dr["N_Ordre"] = ecriture.N_Ordre;
                Console.WriteLine("Enregistrer Ecriture N_Order");
                dr["Libelle"] = ecriture.Libelle;
                Console.WriteLine("Enregistrer Ecriture Libelle1");
                dr["Libelle2"] = ecriture.Libelle2;
                Console.WriteLine("Enregistrer Ecriture Libelle2");
                dr["Debit"] = ecriture.Debit;
                Console.WriteLine("Enregistrer Ecriture Debit");
                dr["Montant"] = ecriture.Montant;
                Console.WriteLine("Enregistrer Ecriture Montant");
                dr["CodeJournal"] = ecriture.CodeJournal;
                Console.WriteLine("Enregistrer Ecriture CodeJournal");
                dr["Annee"] = ecriture.Annee;
                Console.WriteLine("Enregistrer Ecriture Annee");
                dr["JourMois"] = ecriture.JourMois;
                Console.WriteLine("Enregistrer Ecriture JourMois");
                //dr["CodeLibelleAutomatique"] = ecriture.CodeLibelleAutomatique;
                // dr["CodeLibelleAutomatique"] = ecriture.Compte;
                db.Ds.Tables["Ecritures"].Rows.Add(dr);
                Console.WriteLine("Enregistrer Ecriture Add dr");

                if (cpa == true)
                {
                    Console.WriteLine("Enregistrer Ecriture cpa=true");
                    DataRow dr1 = db.Ds.Tables["Ecritures"].NewRow();

                    dr1["iDate"] = ecriture.iDate;
                    dr1["Compte"] = ecriture.ContrePartie;
                    dr1["ContrePartie"] = ecriture.Compte;
                    dr1["N_Ordre"] = ecriture.N_Ordre;
                    dr1["Libelle"] = ecriture.Libelle;
                    dr["Libelle2"] = ecriture.Libelle2;
                    dr1["Debit"] = !ecriture.Debit;
                    dr1["Montant"] = ecriture.Montant;
                    dr1["CodeJournal"] = ecriture.CodeJournal;
                    dr1["Annee"] = ecriture.Annee;
                    dr1["JourMois"] = ecriture.JourMois;
                    //dr1["CodeLibelleAutomatique"] = ecriture.Compte;
                    //dr1["CodeLibelleAutomatique"] = ecriture.CodeLibelleAutomatique;
                    db.Ds.Tables["Ecritures"].Rows.Add(dr1);
                    Console.WriteLine("Enregistrer Ecriture Add dr2");
                }
                Console.WriteLine("Avant Update_Ecritures()");
                db.Update_Ecritures();
                Console.WriteLine("Update_Ecritures()");
                tran.Commit();


            }
            catch (DbException ex)
            {
                Console.WriteLine("Caaaaatch");
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

        public IList<EcritureModel> Consulter(string req, string tri)
        {
            DataRow[] drs = db.Ds.Tables["Ecritures"].Select(req, tri);
            IList<EcritureModel> ecritures = new List<EcritureModel>();
           
            foreach (DataRow dr in drs)
            {
                EcritureModel ecriture_model = new EcritureModel();
                ecriture_model.CodeJournal = dr["CodeJournal"].ToString();
                ecriture_model.Annee = dr["Annee"].ToString();
                ecriture_model.JourMois = dr["JourMois"].ToString();
                ecriture_model.Compte = dr["Compte"].ToString();
                ecriture_model.ContrePartie = dr["ContrePartie"].ToString();
                ecriture_model.N_Ordre = dr["N_Ordre"].ToString();
                //ecriture_model.CodeLibelleAutomatique = dr["CodeLibelleAutomatique"].ToString();
                ecriture_model.Libelle = dr["Libelle"].ToString();
                ecriture_model.Libelle2 = dr["Libelle2"].ToString();
                ecriture_model.Debit = (bool)dr["Debit"];
                ecriture_model.Montant = dr["Montant"].ToString();
                ecritures.Add(ecriture_model);
         
            }

            return ecritures;
        }

        public void Add(EcritureModel ecriture, bool cpa)
        {
                DataRow dr = db.Ds.Tables["Ecritures"].NewRow();

                dr["iDate"] = ecriture.iDate;
                dr["Compte"] = ecriture.Compte;
                dr["ContrePartie"] = ecriture.ContrePartie;
                dr["N_Ordre"] = ecriture.N_Ordre;
                dr["Libelle"] = ecriture.Libelle;
                dr["Libelle2"] = ecriture.Libelle2;
                dr["Debit"] = ecriture.Debit;
                dr["Montant"] = ecriture.Montant;
                dr["CodeJournal"] = ecriture.CodeJournal;
                dr["Annee"] = ecriture.Annee;
                dr["JourMois"] = ecriture.JourMois;
               
                db.Ds.Tables["Ecritures"].Rows.Add(dr);

                if (cpa == true)
                {
                    DataRow dr1 = db.Ds.Tables["Ecritures"].NewRow();

                    dr1["iDate"] = ecriture.iDate;
                    dr1["Compte"] = ecriture.ContrePartie;
                    dr1["ContrePartie"] = ecriture.Compte;
                    dr1["N_Ordre"] = ecriture.N_Ordre;
                    dr1["Libelle"] = ecriture.Libelle;
                    dr1["Libelle2"] = ecriture.Libelle2;
                    dr1["Debit"] = !ecriture.Debit;
                    dr1["Montant"] = ecriture.Montant;
                    dr1["CodeJournal"] = ecriture.CodeJournal;
                    dr1["Annee"] = ecriture.Annee;
                    dr1["JourMois"] = ecriture.JourMois;
                    
                    db.Ds.Tables["Ecritures"].Rows.Add(dr1);

                }

        }

    }
}
