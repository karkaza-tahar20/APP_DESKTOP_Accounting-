using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace ComptabiliteGenerale.Saisie.ViewModel
{
    public class SaisieBilanVM
    {
        DbProviderFactory factory;
        string provider;
        string connectionString ;

        public List<LigneBilan> Lignes { get; set; }

        public string CompteActif { get; set; }
        public string LibelleActif { get; set; }

        //public string compte_intitule1 { get; set; }

        //public string compte_intitule2 { get; set; }
        public double SoldeActif { get; set; }

        public double TotaleActif { get; set; }

        public string ComptePassif { get; set; }
        public string LibellePassif { get; set; }

        public double SoldePassif { get; set; }

        public double TotalePassif { get; set; }

        private double soldeActif, soldePassif;

        public SaisieBilanVM()
        {
           
            provider = "System.Data.SqlClient";
            connectionString = "Data Source=DESKTOP-RGPDGSP;Initial Catalog=Compta;Integrated Security=True";
            Lignes = new List<LigneBilan>();
            Lignes = GetAll();
            TotaleActif = 00.00; TotalePassif = 00.00;
            for (int i =0; i<Lignes.Count(); i++)
            {
                 soldeActif = double.Parse( Lignes[i].SoldeActif);
                this.TotaleActif += soldeActif;
                 soldePassif = double.Parse(Lignes[i].SoldePassif);
                this.TotalePassif += soldePassif;

            }
            

        }

        public List<LigneBilan> GetAll()
        {
            var bilans = new List<LigneBilan>();
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source=DESKTOP-RGPDGSP;Initial Catalog=Compta;Integrated Security=True";
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "Select * From Billan ;";
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bilans.Add(new LigneBilan
                        {
                            CompteActif = (string)reader["CompteActif"],
                            LibelleActif = (string)reader["LibelleActif"],
                            SoldeActif = (string)reader["SoldeActif"],
                            //TotaleActif = (string)reader["TotaleActif"],

                            ComptePassif = (string)reader["ComptePassif"],
                            LibellePassif = (string)reader["LibellePassif"],
                            SoldePassif = (string)reader["SoldePassif"],
                            //TotalePassif = (string)reader["TotalePassif"]

                        });
                    }
                }
            }

            return bilans;
        }

    }
}
