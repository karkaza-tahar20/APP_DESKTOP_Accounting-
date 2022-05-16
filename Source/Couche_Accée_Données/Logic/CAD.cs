using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace CoucheAcceeDonnees
{
    public class CAD
    {
        private DbDataAdapter Dossier_Adapter;
        private DbDataAdapter Comptes_Adapter;
        private DbDataAdapter Journaux_Adapter;
        private DbDataAdapter LibellesAutomatiques_Adapter;
        private DbDataAdapter Ecritures_Adapter;
        private DbDataAdapter Bilan_Adapter;
        
        public DataSet Ds;

        public CAD(IAdapters adapters)
        {
            adapters.Get_Adapters(ref Dossier_Adapter, ref Comptes_Adapter, ref Journaux_Adapter, ref LibellesAutomatiques_Adapter, ref Ecritures_Adapter, ref Bilan_Adapter);   
            Ds = new DataSet();
        }

        public void Fill_Dossier()
        {
            Console.WriteLine("8-1-1");
            Dossier_Adapter.Fill(Ds, "Dossier");
            Console.WriteLine("8-1-2");
        }

        public void Update_Dossier()
        {
            Console.WriteLine("Update Dossier CAD !!!");
            Dossier_Adapter.Update(Ds, "Dossier");
        }
        
        private void Refresh_Comptes()
        {
            Ds.Tables["Comptes"].Clear();
            Comptes_Adapter.Fill(Ds, "Comptes");
        }

        private void Refresh_LibellesAutomatiques()
        {
            Ds.Tables["LibellesAutomatiques"].Clear();
            LibellesAutomatiques_Adapter.Fill(Ds, "LibellesAutomatiques");
        }

        private void Refresh_Journaux()
        {
            Ds.Tables["Journaux"].Clear();
            Journaux_Adapter.Fill(Ds, "Journaux");
        }

        private void Refresh_Ecritures()
        {
            Ds.Tables["Ecritures"].Clear();
            Ecritures_Adapter.Fill(Ds, "Ecritures");
        }

        private void Refresh_Bilan()
        {
            Ds.Tables["Billan"].Clear();
            Bilan_Adapter.Fill(Ds, "Billan");
        }

        public void Fill_Comptes()
        {
            if (Ds.Tables["Comptes"] == null)
                Comptes_Adapter.Fill(Ds, "Comptes");
            else Refresh_Comptes();
            
        }
        
        public void Fill_LibellesAutomatiques()
        {
            if (Ds.Tables["LibellesAutomatiques"] == null)
                LibellesAutomatiques_Adapter.Fill(Ds, "LibellesAutomatiques");
            else Refresh_LibellesAutomatiques();
        }

        public void Fill_Journaux()
        {
            if (Ds.Tables["Journaux"] == null)
                Journaux_Adapter.Fill(Ds, "Journaux");
            else Refresh_Journaux();
        }

        public void Fill_Ecritures()
        {
            if (Ds.Tables["Ecritures"] == null)
                Ecritures_Adapter.Fill(Ds, "Ecritures");
            else Refresh_Ecritures();

        }

        public void Fill_Bilan()
        {
            if (Ds.Tables["Billan"] == null)
                Bilan_Adapter.Fill(Ds, "Billan");
            else Refresh_Bilan();

        }

        public void Update_Comptes()
        {
            Comptes_Adapter.Update(Ds, "Comptes");
        }

        public void Update_LibellesAutomatiques()
        {
            LibellesAutomatiques_Adapter.Update(Ds, "LibellesAutomatiques");
        }

        public void Update_Journaux()
        {
            Journaux_Adapter.Update(Ds, "Journaux");
        }

        public void Update_Ecritures()
        {
            try
            {
                Console.WriteLine("le code Update1");
                Ecritures_Adapter.Update(Ds, "Ecritures");

                Console.WriteLine("le code Update2");
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void Update_Bilan()
        {
            try
            {
                Console.WriteLine("le code CAD Update_Bilan()");
                Bilan_Adapter.Update(Ds, "Billan");

            }
            catch (DbException ex)
            {
                Console.WriteLine(ex);
            }

        }


        public DbTransaction load_tran()
        {
            DbTransaction tran = Ecritures_Adapter.InsertCommand.Connection.BeginTransaction();
            Ecritures_Adapter.DeleteCommand.Transaction = tran;
            Ecritures_Adapter.InsertCommand.Transaction = tran;
            Ecritures_Adapter.UpdateCommand.Transaction = tran;
            return tran;
        }

        public DbTransaction load_tran2()
        {
            DbTransaction tran1 = Bilan_Adapter.InsertCommand.Connection.BeginTransaction();
            Bilan_Adapter.DeleteCommand.Transaction = tran1;
            Bilan_Adapter.InsertCommand.Transaction = tran1;
            Bilan_Adapter.UpdateCommand.Transaction = tran1;
            return tran1;
        }












    }
}
