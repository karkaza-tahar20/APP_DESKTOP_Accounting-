using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace CoucheAcceeDonnees
{
    public class SqlServerAdapters : IAdapters
    {
        private SqlDataAdapter Dossier_Adapter;
        private SqlDataAdapter Comptes_Adapter;
        private SqlDataAdapter Journaux_Adapter;
        private SqlDataAdapter LibellesAutomatiques_Adapter;
        private SqlDataAdapter Ecritures_Adapter;
        private SqlDataAdapter Bilan_Adapter;

        private SqlConnection Con;

        public SqlServerAdapters(SqlConnection Conn)
        {
            Con = Conn;
        }

        public void Build_Adapters()
        {
            #region Dossier_Adapter
            Console.WriteLine("t1");
            Dossier_Adapter = new SqlDataAdapter();
            Console.WriteLine("t2");
            Dossier_Adapter.SelectCommand = new SqlCommand();
            Console.WriteLine("t3");
            Dossier_Adapter.SelectCommand.Connection = Con;
            Console.WriteLine("t4");
            Dossier_Adapter.SelectCommand.CommandText = "SELECT * FROM Dossier";
            Console.WriteLine("t5");

            Dossier_Adapter.InsertCommand = new SqlCommand();
            Dossier_Adapter.InsertCommand.Connection = Con;
            Dossier_Adapter.InsertCommand.CommandText = "INSERT INTO Dossier(IDDossier, RaisonSocial, Annee, NomSociete, Ville, Adresse, Telephone, Email) VALUES (@IDDossier, @RaisonSocial, @Annee,@NomSociete, @Ville, @Adresse ,@Telephone, @Email)";
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDDossier", System.Data.SqlDbType.Int, 4, "IDDossier"));
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RaisonSocial", System.Data.SqlDbType.NVarChar, 50, "RaisonSocial"));
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Annee", System.Data.SqlDbType.Int, 4, "Annee"));
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NomSociete", System.Data.SqlDbType.NVarChar, 50, "NomSociete"));
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Ville", System.Data.SqlDbType.NVarChar, 50, "Ville"));
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Adresse", System.Data.SqlDbType.NVarChar, 100, "Adresse"));
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Telephone", System.Data.SqlDbType.NVarChar, 10, "Telephone"));
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 20, "Email"));


            Dossier_Adapter.UpdateCommand = new SqlCommand();
            Dossier_Adapter.UpdateCommand.Connection = Con;
            Dossier_Adapter.UpdateCommand.CommandText = "UPDATE Dossier SET IDDossier = @IDDossier, RaisonSocial = @RaisonSocial, Annee = @Annee, NomSociete = @NomSociete, Ville=@Ville ,Adresse=@Adresse ,Telephone=@Telephone ,Email= @Email WHERE (IDDossier = @IDDossier) ";
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDDossier", System.Data.SqlDbType.Int, 4, "IDDossier"));
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RaisonSocial", System.Data.SqlDbType.NVarChar, 50, "RaisonSocial"));
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Annee", System.Data.SqlDbType.Int, 4, "Annee"));
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NomSociete", System.Data.SqlDbType.Int, 4, "NomSociete"));
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Ville", System.Data.SqlDbType.NVarChar, 50, "Ville"));
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Adresse", System.Data.SqlDbType.Int, 4, "Adresse"));
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Telephone", System.Data.SqlDbType.NVarChar, 4, "Telephone"));
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50, "Email"));


            Dossier_Adapter.DeleteCommand = new SqlCommand();
            Dossier_Adapter.DeleteCommand.Connection = Con;
            Dossier_Adapter.DeleteCommand.CommandText = "DELETE FROM Dossier WHERE (IDDossier = @IDDossier)";
            Dossier_Adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDDossier", System.Data.SqlDbType.Int, 4, "IDDossier"));

            #endregion

            #region Comptes_Adapter

            Comptes_Adapter = new SqlDataAdapter();
            Comptes_Adapter.SelectCommand = new SqlCommand();
            Comptes_Adapter.SelectCommand.Connection = Con;
            Comptes_Adapter.SelectCommand.CommandText = "Select * from Comptes";

            Comptes_Adapter.InsertCommand = new SqlCommand();
            Comptes_Adapter.InsertCommand.Connection = Con;
            Comptes_Adapter.InsertCommand.CommandText = "INSERT INTO Comptes(Compte, Intitule, Niveau, MouvementDebit, MouvementCredit, CompteResultat) VALUES (@Compte, @Intitule, @Niveau, @MouvementDebit, @MouvementCredit, @CompteResultat); SELECT Compte, Intitule, Niveau, MouvementDebit, MouvementCredit, CompteResultat FROM Comptes WHERE (Compte = @Compte)";
            Comptes_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Compte", System.Data.SqlDbType.Int, 4, "Compte"));
            Comptes_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Intitule", System.Data.SqlDbType.NVarChar, 50, "Intitule"));
            Comptes_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Niveau", System.Data.SqlDbType.TinyInt, 1, "Niveau"));
            Comptes_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MouvementDebit", System.Data.SqlDbType.Float, 8, "MouvementDebit"));
            Comptes_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MouvementCredit", System.Data.SqlDbType.Float, 8, "MouvementCredit"));
            Comptes_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompteResultat", System.Data.SqlDbType.Int, 4, "CompteResultat"));

            Comptes_Adapter.UpdateCommand = new SqlCommand();
            Comptes_Adapter.UpdateCommand.Connection = Con;
            Comptes_Adapter.UpdateCommand.CommandText = "UPDATE Comptes SET Compte = @Compte, Intitule = @Intitule, Niveau = @Niveau, MouvementDebit = @MouvementDebit, MouvementCredit = @MouvementCredit, CompteResultat = @CompteResultat WHERE (Compte = @Compte); SELECT Compte, Intitule, Niveau, MouvementDebit, MouvementCredit, CompteResultat FROM Comptes WHERE (Compte = @Compte)";
            Comptes_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Compte", System.Data.SqlDbType.Int, 4, "Compte"));
            Comptes_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Intitule", System.Data.SqlDbType.NVarChar, 50, "Intitule"));
            Comptes_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Niveau", System.Data.SqlDbType.TinyInt, 1, "Niveau"));
            Comptes_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MouvementDebit", System.Data.SqlDbType.Float, 8, "MouvementDebit"));
            Comptes_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MouvementCredit", System.Data.SqlDbType.Float, 8, "MouvementCredit"));
            Comptes_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompteResultat", System.Data.SqlDbType.Int, 4, "CompteResultat"));

            Comptes_Adapter.DeleteCommand = new SqlCommand();
            Comptes_Adapter.DeleteCommand.Connection = Con;
            Comptes_Adapter.DeleteCommand.CommandText = "DELETE FROM Comptes WHERE (Compte = @Compte)";
            Comptes_Adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Compte", System.Data.SqlDbType.Int, 4, "Compte"));

            #endregion


            #region Journaux_Adapter

            Journaux_Adapter = new SqlDataAdapter();
            Journaux_Adapter.SelectCommand = new SqlCommand();
            Journaux_Adapter.SelectCommand.Connection = Con;
            Journaux_Adapter.SelectCommand.CommandText = "SELECT * FROM Journaux";

            Journaux_Adapter.InsertCommand = new SqlCommand();
            Journaux_Adapter.InsertCommand.Connection = Con;
            Journaux_Adapter.InsertCommand.CommandText = "INSERT INTO Journaux(Code, Intitule, Compte, Cpa) VALUES (@Code, @Intitule, @Compte, @Cpa); SELECT Code, Intitule, Compte, Cpa FROM Journaux WHERE (Code = @Code)";
            Journaux_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.Int, 4, "Code"));
            Journaux_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Intitule", System.Data.SqlDbType.NVarChar, 50, "Intitule"));
            Journaux_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Compte", System.Data.SqlDbType.Int, 4, "Compte"));
            Journaux_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cpa", System.Data.SqlDbType.Bit, 1, "Cpa"));

            Journaux_Adapter.UpdateCommand = new SqlCommand();
            Journaux_Adapter.UpdateCommand.Connection = Con;
            Journaux_Adapter.UpdateCommand.CommandText = "UPDATE Journaux SET Code = @Code, Intitule = @Intitule, Compte = @Compte, Cpa = @Cpa WHERE (Code = @Code) ; SELECT Code, Intitule, Compte, Cpa FROM Journaux WHERE (Code = @Code)";
            Journaux_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.Int, 4, "Code"));
            Journaux_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Intitule", System.Data.SqlDbType.NVarChar, 50, "Intitule"));
            Journaux_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Compte", System.Data.SqlDbType.Int, 4, "Compte"));
            Journaux_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cpa", System.Data.SqlDbType.Bit, 1, "Cpa"));

            Journaux_Adapter.DeleteCommand = new SqlCommand();
            Journaux_Adapter.DeleteCommand.Connection = Con;
            Journaux_Adapter.DeleteCommand.CommandText = "DELETE FROM Journaux WHERE (Code = @Code)";
            Journaux_Adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.Int, 4, "Code"));

            #endregion


            #region LibellesAutomatiques_Adapter
            LibellesAutomatiques_Adapter = new SqlDataAdapter();
            LibellesAutomatiques_Adapter.SelectCommand = new SqlCommand();
            LibellesAutomatiques_Adapter.SelectCommand.Connection = Con;
            LibellesAutomatiques_Adapter.SelectCommand.CommandText = "SELECT * FROM LibellesAutomatiques";

            LibellesAutomatiques_Adapter.InsertCommand = new SqlCommand();
            LibellesAutomatiques_Adapter.InsertCommand.Connection = Con;
            LibellesAutomatiques_Adapter.InsertCommand.CommandText = "INSERT INTO LibellesAutomatiques(Code, Intitule) VALUES (@Code, @Intitule); SELECT Code, Intitule FROM LibellesAutomatiques WHERE (Code = @Code)";
            LibellesAutomatiques_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.Int, 4, "Code"));
            LibellesAutomatiques_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Intitule", System.Data.SqlDbType.NVarChar, 50, "Intitule"));

            LibellesAutomatiques_Adapter.UpdateCommand = new SqlCommand();
            LibellesAutomatiques_Adapter.UpdateCommand.Connection = Con;
            LibellesAutomatiques_Adapter.UpdateCommand.CommandText = "UPDATE LibellesAutomatiques SET Code = @Code, Intitule = @Intitule WHERE (Code = @Code) ; SELECT Code, Intitule FROM LibellesAutomatiques WHERE (Code = @Code)";
            LibellesAutomatiques_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.Int, 4, "Code"));
            LibellesAutomatiques_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Intitule", System.Data.SqlDbType.NVarChar, 50, "Intitule"));

            LibellesAutomatiques_Adapter.DeleteCommand = new SqlCommand();
            LibellesAutomatiques_Adapter.DeleteCommand.Connection = Con;
            LibellesAutomatiques_Adapter.DeleteCommand.CommandText = "DELETE FROM LibellesAutomatiques WHERE (Code = @Code)";
            LibellesAutomatiques_Adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.Int, 4, "Code"));
            #endregion


            #region Ecritures_Adapter
            Ecritures_Adapter = new SqlDataAdapter();
            Ecritures_Adapter.SelectCommand = new SqlCommand();
            Ecritures_Adapter.SelectCommand.Connection = Con;
            Ecritures_Adapter.SelectCommand.CommandText = "SELECT * FROM Ecritures";


            Ecritures_Adapter.InsertCommand = new SqlCommand();
            Ecritures_Adapter.InsertCommand.Connection = Con;
            Ecritures_Adapter.InsertCommand.CommandText = "INSERT INTO Ecritures(iDate, Compte, ContrePartie, N_Ordre, Libelle, Libelle2, Debit, Montant, CodeJournal, Annee, JourMois) VALUES (@iDate, @Compte, @ContrePartie, @N_Ordre, @Libelle, @Libelle2, @Debit, @Montant, @CodeJournal, @Annee, @JourMois); SELECT iDate, Compte, ContrePartie, N_Ordre, Libelle, Libelle2, Debit, Montant, CodeJournal, Annee, JourMois FROM Ecritures WHERE (IdEcriture = @@IDENTITY)";
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iDate", System.Data.SqlDbType.Int, 4, "iDate"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Compte", System.Data.SqlDbType.Int, 4, "Compte"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContrePartie", System.Data.SqlDbType.Int, 4, "ContrePartie"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@N_Ordre", System.Data.SqlDbType.BigInt, 8, "N_Ordre"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Libelle", System.Data.SqlDbType.NVarChar, 50, "Libelle"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Libelle2", System.Data.SqlDbType.NVarChar, 50, "Libelle2"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Debit", System.Data.SqlDbType.Bit, 1, "Debit"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Montant", System.Data.SqlDbType.Float, 8, "Montant"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodeJournal", System.Data.SqlDbType.Int, 4, "CodeJournal"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Annee", System.Data.SqlDbType.NVarChar, 50, "Annee"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JourMois", System.Data.SqlDbType.NVarChar, 50, "JourMois"));
            //Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodeLibelleAutomatique", System.Data.SqlDbType.TinyInt, 1, "CodeLibelleAutomatique"));
           
            Ecritures_Adapter.UpdateCommand = new SqlCommand();
            Ecritures_Adapter.UpdateCommand.Connection = Con;
            Ecritures_Adapter.UpdateCommand.CommandText = "UPDATE Ecritures SET iDate = @iDate, Compte = @Compte, ContrePartie = @ContrePartie, N_Ordre = @N_Ordre, Libelle = @Libelle,Libelle2 = @Libelle2, Debit = @Debit, Montant = @Montant, CodeJournal = @CodeJournal, Annee = @Annee, JourMois = @JourMois WHERE (IdEcriture = @IdEcriture) ; SELECT iDate, Compte, ContrePartie, N_Ordre, Libelle,Libelle2, Debit, Montant, CodeJournal, Annee, JourMois FROM Ecritures WHERE (IdEcriture = @@IDENTITY)";
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iDate", System.Data.SqlDbType.Int, 4, "iDate"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Compte", System.Data.SqlDbType.Int, 4, "Compte"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContrePartie", System.Data.SqlDbType.Int, 4, "ContrePartie"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@N_Ordre", System.Data.SqlDbType.BigInt, 8, "N_Ordre"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Libelle", System.Data.SqlDbType.NVarChar, 50, "Libelle"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Libelle2", System.Data.SqlDbType.NVarChar, 50, "Libelle2"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Debit", System.Data.SqlDbType.Bit, 1, "Debit"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Montant", System.Data.SqlDbType.Float, 8, "Montant"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodeJournal", System.Data.SqlDbType.Int, 4, "CodeJournal"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Annee", System.Data.SqlDbType.NVarChar, 50, "Annee"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JourMois", System.Data.SqlDbType.NVarChar, 50, "JourMois"));
           // Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodeLibelleAutomatique", System.Data.SqlDbType.TinyInt, 1, "CodeLibelleAutomatique"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdEcriture", System.Data.SqlDbType.BigInt, 8, "IdEcriture"));
           
            Ecritures_Adapter.DeleteCommand = new SqlCommand();
            Ecritures_Adapter.DeleteCommand.Connection = Con;
            Ecritures_Adapter.DeleteCommand.CommandText = "DELETE FROM Ecritures WHERE (IdEcriture = @IdEcriture) ";
            Ecritures_Adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdEcriture", System.Data.SqlDbType.BigInt, 8, "IdEcriture"));

            #endregion

            #region Bilan_Adapter
            Bilan_Adapter = new SqlDataAdapter();
            Bilan_Adapter.SelectCommand = new SqlCommand();
            Bilan_Adapter.SelectCommand.Connection = Con;
            Bilan_Adapter.SelectCommand.CommandText = "SELECT * FROM Billan";


            Bilan_Adapter.InsertCommand = new SqlCommand();
            Bilan_Adapter.InsertCommand.Connection = Con;
            Bilan_Adapter.InsertCommand.CommandText = "INSERT INTO Billan(id,CompteActif, LibelleActif, SoldeActif, TotaleActif,ComptePassif, LibellePassif, SoldePassif, TotalePassif) VALUES (@id,@CompteActif, @LibelleActif, @SoldeActif, @TotaleActif, @ComptePassif, @LibellePassif, @SoldePassif, @TotalePassif); SELECT id,CompteActif, LibelleActif, SoldeActif, TotaleActif,ComptePassif, LibellePassif, SoldePassif, TotalePassif FROM Billan WHERE (id = @id)";
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.Int, 8, "id"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompteActif", System.Data.SqlDbType.Int, 8, "CompteActif"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LibelleActif", System.Data.SqlDbType.NVarChar, 50, "LibelleActif"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SoldeActif", System.Data.SqlDbType.Float, 20, "SoldeActif"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TotaleActif", System.Data.SqlDbType.Float, 20, "TotaleActif"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ComptePassif", System.Data.SqlDbType.Int, 8, "ComptePassif"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LibellePassif", System.Data.SqlDbType.NVarChar, 50, "LibellePassif"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SoldePassif", System.Data.SqlDbType.Float, 20, "SoldePassif"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TotalePassif", System.Data.SqlDbType.Float, 20, "TotalePassif"));

            

            Bilan_Adapter.UpdateCommand = new SqlCommand();
            Bilan_Adapter.UpdateCommand.Connection = Con;
            Bilan_Adapter.UpdateCommand.CommandText = "UPDATE Billan SET CompteActif = @CompteActif, LibelleActif = @LibelleActif, SoldeActif = @SoldeActif, TotaleActif = @TotaleActif, ComptePassif = @ComptePassif, LibellePassif = @LibellePassif, SoldePassif = @SoldePassif, TotalePassif = @TotalePassif WHERE (IdEcriture = @IdEcriture) ; SELECT iDate, Compte, ContrePartie, N_Ordre, Libelle,Libelle2, Debit, Montant, CodeJournal, Annee, JourMois FROM Ecritures WHERE (id = @id)";
            //Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.Int, 4, "id"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompteActif", System.Data.SqlDbType.Int, 8, "CompteActif"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LibelleActif", System.Data.SqlDbType.NVarChar, 50, "LibelleActif"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SoldeActif", System.Data.SqlDbType.Float, 20, "SoldeActif"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TotaleActif", System.Data.SqlDbType.Float, 20, "TotaleActif"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ComptePassif", System.Data.SqlDbType.Int, 8, "ComptePassif"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LibellePassif", System.Data.SqlDbType.NVarChar, 50, "LibellePassif"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SoldePassif", System.Data.SqlDbType.Float, 20, "SoldePassif"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TotalePassif", System.Data.SqlDbType.Float, 20, "TotalePassif"));

            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.Int, 8, "id"));

            Bilan_Adapter.DeleteCommand = new SqlCommand();
            Bilan_Adapter.DeleteCommand.Connection = Con;
            Bilan_Adapter.DeleteCommand.CommandText = "DELETE FROM Billan WHERE (id = @id) ";
            Bilan_Adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.Int, 8, "id"));

           #endregion

        }

        public void Get_Adapters(ref DbDataAdapter Dossier_Adapter1, ref DbDataAdapter Comptes_Adapter1, ref DbDataAdapter Journaux_Adapter1,
                   ref DbDataAdapter LibellesAutomatiques_Adapter1, ref DbDataAdapter Ecritures_Adapter1, ref DbDataAdapter Bilan_Adapter1)
        {
            Dossier_Adapter1 = Dossier_Adapter;
            Comptes_Adapter1 = Comptes_Adapter;
            Journaux_Adapter1 = Journaux_Adapter;
            LibellesAutomatiques_Adapter1 = LibellesAutomatiques_Adapter;
            Ecritures_Adapter1 = Ecritures_Adapter;
           Bilan_Adapter1 = Bilan_Adapter;




        }

    }
}
