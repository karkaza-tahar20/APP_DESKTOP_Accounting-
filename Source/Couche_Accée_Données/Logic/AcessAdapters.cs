using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Data.Common;

namespace CoucheAcceeDonnees
{
    public class AcessAdapters : IAdapters
    {
        private OleDbDataAdapter Dossier_Adapter;
        private OleDbDataAdapter Comptes_Adapter;
        private OleDbDataAdapter Journaux_Adapter;
        private OleDbDataAdapter LibellesAutomatiques_Adapter;
        private OleDbDataAdapter Ecritures_Adapter;
        private OleDbDataAdapter Bilan_Adapter;
        private OleDbConnection Con;

        public AcessAdapters(OleDbConnection Conn)
        {
            Con = Conn;
        }

        public void Build_Adapters()
        {
            #region Dossier_Adapter

            Dossier_Adapter = new OleDbDataAdapter();
            Dossier_Adapter.SelectCommand = new OleDbCommand();
            Dossier_Adapter.SelectCommand.Connection = Con;
            Dossier_Adapter.SelectCommand.CommandText = "SELECT * FROM Dossier";

            Dossier_Adapter.InsertCommand = new OleDbCommand();
            Dossier_Adapter.InsertCommand.Connection = Con;
            Dossier_Adapter.InsertCommand.CommandText = "INSERT INTO Dossier(IDDossier, RaisonSocial, Annee,NomSociete, Ville, Adresse,Telephone, Email) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@IDDossier", System.Data.OleDb.OleDbType.Integer, 4, "IDDossier"));
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@RaisonSocial", System.Data.OleDb.OleDbType.VarWChar, 50, "RaisonSocial"));
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Annee", System.Data.OleDb.OleDbType.Integer, 4, "Annee"));
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NomSociete", System.Data.OleDb.OleDbType.VarWChar, 50, "NomSociete"));
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ville", System.Data.OleDb.OleDbType.VarWChar, 50, "Ville"));
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Adresse", System.Data.OleDb.OleDbType.VarWChar, 100, "Adresse"));
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Telephone", System.Data.OleDb.OleDbType.VarWChar, 10, "Telephone"));
            Dossier_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email", System.Data.OleDb.OleDbType.VarWChar, 20, "Email"));


            Console.WriteLine("Commande Update ACCESS !!!");
            Dossier_Adapter.UpdateCommand = new OleDbCommand();
            Dossier_Adapter.UpdateCommand.Connection = Con;
            Dossier_Adapter.UpdateCommand.CommandText = "UPDATE Dossier SET IDDossier = ?, RaisonSocial = ?, Annee = ?, NomSociete = ?, Ville = ?, Adresse = ?, Telephone = ?, Email = ? WHERE (IDDossier = ?) ";
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@IDDossier", System.Data.OleDb.OleDbType.Integer, 4, "IDDossier"));
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@RaisonSocial", System.Data.OleDb.OleDbType.VarWChar, 50, "RaisonSocial"));
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Annee", System.Data.OleDb.OleDbType.Integer, 4, "Annee"));
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NomSociete", System.Data.OleDb.OleDbType.VarWChar, 50, "NomSociete"));
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ville", System.Data.OleDb.OleDbType.VarWChar, 50, "Ville"));
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Adresse", System.Data.OleDb.OleDbType.VarWChar, 100, "Adresse"));
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Telephone", System.Data.OleDb.OleDbType.VarWChar, 10, "Telephone"));
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email", System.Data.OleDb.OleDbType.VarWChar, 20, "Email"));
            Dossier_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@OldIDDossier", System.Data.OleDb.OleDbType.Integer, 4, "IDDossier")).SourceVersion = DataRowVersion.Original;

            Dossier_Adapter.DeleteCommand = new OleDbCommand();
            Dossier_Adapter.DeleteCommand.Connection = Con;
            Dossier_Adapter.DeleteCommand.CommandText = "DELETE FROM Dossier WHERE (IDDossier = ?)";
            Dossier_Adapter.DeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@IDDossier", System.Data.OleDb.OleDbType.Integer, 4, "IDDossier"));

            #endregion


            #region Comptes_Adapter

            Comptes_Adapter = new OleDbDataAdapter();
            Comptes_Adapter.SelectCommand = new OleDbCommand();
            Comptes_Adapter.SelectCommand.Connection = Con;
            Comptes_Adapter.SelectCommand.CommandText = "Select * from Comptes";

            Comptes_Adapter.InsertCommand = new OleDbCommand();
            Comptes_Adapter.InsertCommand.Connection = Con;
            Comptes_Adapter.InsertCommand.CommandText = "INSERT INTO Comptes(Compte, Intitule, Niveau, MouvementDebit, MouvementCredit, CompteResultat) VALUES (?, ?, ?, ?, ?, ?)";
            Comptes_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Compte", System.Data.OleDb.OleDbType.Integer, 4, "Compte"));
            Comptes_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Intitule", System.Data.OleDb.OleDbType.VarWChar, 50, "Intitule"));
            Comptes_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Niveau", System.Data.OleDb.OleDbType.TinyInt, 1, "Niveau"));
            Comptes_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@MouvementDebit", System.Data.OleDb.OleDbType.Double, 8, "MouvementDebit"));
            Comptes_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@MouvementCredit", System.Data.OleDb.OleDbType.Double, 8, "MouvementCredit"));
            Comptes_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@CompteResultat", System.Data.OleDb.OleDbType.Integer, 4, "CompteResultat"));

            Comptes_Adapter.UpdateCommand = new OleDbCommand();
            Comptes_Adapter.UpdateCommand.Connection = Con;
            Comptes_Adapter.UpdateCommand.CommandText = "UPDATE Comptes SET Compte = ?, Intitule = ?, Niveau = ?, MouvementDebit = ?, MouvementCredit = ?, CompteResultat = ? WHERE (Compte = ?)";
            Comptes_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Compte", System.Data.OleDb.OleDbType.Integer, 4, "Compte"));
            Comptes_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Intitule", System.Data.OleDb.OleDbType.VarWChar, 50, "Intitule"));
            Comptes_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Niveau", System.Data.OleDb.OleDbType.TinyInt, 1, "Niveau"));
            Comptes_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@MouvementDebit", System.Data.OleDb.OleDbType.Double, 8, "MouvementDebit"));
            Comptes_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@MouvementCredit", System.Data.OleDb.OleDbType.Double, 8, "MouvementCredit"));
            Comptes_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@CompteResultat", System.Data.OleDb.OleDbType.Integer, 4, "CompteResultat"));
            Comptes_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@OldCompte", System.Data.OleDb.OleDbType.Integer, 4, "Compte")).SourceVersion = DataRowVersion.Original;

            Comptes_Adapter.DeleteCommand = new OleDbCommand();
            Comptes_Adapter.DeleteCommand.Connection = Con;
            Comptes_Adapter.DeleteCommand.CommandText = "DELETE FROM Comptes WHERE (Compte = ?)";
            Comptes_Adapter.DeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Compte", System.Data.OleDb.OleDbType.Integer, 4, "Compte"));

            #endregion


            #region Journaux_Adapter

            Journaux_Adapter = new OleDbDataAdapter();
            Journaux_Adapter.SelectCommand = new OleDbCommand();
            Journaux_Adapter.SelectCommand.Connection = Con;
            Journaux_Adapter.SelectCommand.CommandText = "SELECT * FROM Journaux";

            Journaux_Adapter.InsertCommand = new OleDbCommand();
            Journaux_Adapter.InsertCommand.Connection = Con;
            Journaux_Adapter.InsertCommand.CommandText = "INSERT INTO Journaux(Code, Intitule, Compte, Cpa) VALUES (?, ?, ?, ?)";
            Journaux_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Code", System.Data.OleDb.OleDbType.Integer, 4, "Code"));
            Journaux_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Intitule", System.Data.OleDb.OleDbType.VarWChar, 50, "Intitule"));
            Journaux_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Compte", System.Data.OleDb.OleDbType.Integer, 4, "Compte"));
            Journaux_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Cpa", System.Data.OleDb.OleDbType.Boolean, 1, "Cpa"));

            Journaux_Adapter.UpdateCommand = new OleDbCommand();
            Journaux_Adapter.UpdateCommand.Connection = Con;
            Journaux_Adapter.UpdateCommand.CommandText = "UPDATE Journaux SET Code = ?, Intitule = ?, Compte = ?, Cpa = ? WHERE (Code = ?) ";
            Journaux_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Code", System.Data.OleDb.OleDbType.Integer, 4, "Code"));
            Journaux_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Intitule", System.Data.OleDb.OleDbType.VarWChar, 50, "Intitule"));
            Journaux_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Compte", System.Data.OleDb.OleDbType.Integer, 4, "Compte"));
            Journaux_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Cpa", System.Data.OleDb.OleDbType.Boolean, 1, "Cpa"));
            Journaux_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@OldCode", System.Data.OleDb.OleDbType.Integer, 4, "Code")).SourceVersion = DataRowVersion.Original;

            Journaux_Adapter.DeleteCommand = new OleDbCommand();
            Journaux_Adapter.DeleteCommand.Connection = Con;
            Journaux_Adapter.DeleteCommand.CommandText = "DELETE FROM Journaux WHERE (Code = ?)";
            Journaux_Adapter.DeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Code", System.Data.OleDb.OleDbType.Integer, 4, "Code"));

            #endregion


            #region LibellesAutomatiques_Adapter

            LibellesAutomatiques_Adapter = new OleDbDataAdapter();
            LibellesAutomatiques_Adapter.SelectCommand = new OleDbCommand();
            LibellesAutomatiques_Adapter.SelectCommand.Connection = Con;
            LibellesAutomatiques_Adapter.SelectCommand.CommandText = "SELECT * FROM LibellesAutomatiques";

            LibellesAutomatiques_Adapter.InsertCommand = new OleDbCommand();
            LibellesAutomatiques_Adapter.InsertCommand.Connection = Con;
            LibellesAutomatiques_Adapter.InsertCommand.CommandText = "INSERT INTO LibellesAutomatiques(Code, Intitule) VALUES (?, ?)";
            LibellesAutomatiques_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Code", System.Data.OleDb.OleDbType.Integer, 4, "Code"));
            LibellesAutomatiques_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Intitule", System.Data.OleDb.OleDbType.VarWChar, 50, "Intitule"));


            LibellesAutomatiques_Adapter.UpdateCommand = new OleDbCommand();
            LibellesAutomatiques_Adapter.UpdateCommand.Connection = Con;
            LibellesAutomatiques_Adapter.UpdateCommand.CommandText = "UPDATE LibellesAutomatiques SET Code = ?, Intitule = ? WHERE (Code = ?) ";
            LibellesAutomatiques_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Code", System.Data.OleDb.OleDbType.Integer, 4, "Code"));
            LibellesAutomatiques_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Intitule", System.Data.OleDb.OleDbType.VarWChar, 50, "Intitule"));
            LibellesAutomatiques_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@OldCode", System.Data.OleDb.OleDbType.Integer, 4, "Code")).SourceVersion = DataRowVersion.Original;

            LibellesAutomatiques_Adapter.DeleteCommand = new OleDbCommand();
            LibellesAutomatiques_Adapter.DeleteCommand.Connection = Con;
            LibellesAutomatiques_Adapter.DeleteCommand.CommandText = "DELETE FROM LibellesAutomatiques WHERE (Code = ?)";
            LibellesAutomatiques_Adapter.DeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Code", System.Data.OleDb.OleDbType.Integer, 4, "Code"));

            #endregion


            #region Ecritures_Adapter
            Ecritures_Adapter = new OleDbDataAdapter();
            Ecritures_Adapter.SelectCommand = new OleDbCommand();
            Ecritures_Adapter.SelectCommand.Connection = Con;
            Ecritures_Adapter.SelectCommand.CommandText = "SELECT * FROM Ecritures";

            Ecritures_Adapter.InsertCommand = new OleDbCommand();
            Ecritures_Adapter.InsertCommand.Connection = Con;
            Ecritures_Adapter.InsertCommand.CommandText = "INSERT INTO Ecritures(iDate, Compte, ContrePartie, N_Ordre, Libelle, Libelle2, Debit, Montant, CodeJournal, Annee, JourMois) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@iDate", System.Data.OleDb.OleDbType.Integer, 4, "iDate"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Compte", System.Data.OleDb.OleDbType.Integer, 4, "Compte"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ContrePartie", System.Data.OleDb.OleDbType.Integer, 4, "ContrePartie"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@N_Ordre", System.Data.OleDb.OleDbType.BigInt, 8, "N_Ordre"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Libelle", System.Data.OleDb.OleDbType.VarWChar, 50, "Libelle"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Libelle2", System.Data.OleDb.OleDbType.VarWChar, 50, "Libelle2"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Debit", System.Data.OleDb.OleDbType.Boolean, 1, "Debit"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Montant", System.Data.OleDb.OleDbType.Double, 8, "Montant"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@CodeJournal", System.Data.OleDb.OleDbType.Integer, 4, "CodeJournal"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Annee", System.Data.OleDb.OleDbType.VarWChar, 50, "Annee"));
            Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@JourMois", System.Data.OleDb.OleDbType.VarWChar, 50, "JourMois"));
           // Ecritures_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@CodeLibelleAutomatique", System.Data.OleDb.OleDbType.TinyInt, 1, "CodeLibelleAutomatique"));
            
            Ecritures_Adapter.UpdateCommand = new OleDbCommand();
            Ecritures_Adapter.UpdateCommand.Connection = Con;
            Ecritures_Adapter.UpdateCommand.CommandText = "UPDATE Ecritures SET iDate = ?, Compte = ?, ContrePartie = ?, N_Ordre = ?, Libelle = ?, Libelle2 = ?, Debit = ?, Montant = ?, CodeJournal = ?, Annee = ?, JourMois = ? WHERE (IdEcriture = ?) ";
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@iDate", System.Data.OleDb.OleDbType.Integer, 4, "iDate"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Compte", System.Data.OleDb.OleDbType.Integer, 4, "Compte"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ContrePartie", System.Data.OleDb.OleDbType.Integer, 4, "ContrePartie"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@N_Ordre", System.Data.OleDb.OleDbType.BigInt, 8, "N_Ordre"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Libelle", System.Data.OleDb.OleDbType.VarWChar, 50, "Libelle"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Libelle2", System.Data.OleDb.OleDbType.VarWChar, 50, "Libelle2"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Debit", System.Data.OleDb.OleDbType.Boolean, 1, "Debit"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Montant", System.Data.OleDb.OleDbType.Double, 8, "Montant"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@CodeJournal", System.Data.OleDb.OleDbType.Integer, 4, "CodeJournal"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Annee", System.Data.OleDb.OleDbType.VarWChar, 50, "Annee"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@JourMois", System.Data.OleDb.OleDbType.VarWChar, 50, "JourMois"));
            //Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@CodeLibelleAutomatique", System.Data.OleDb.OleDbType.TinyInt, 1, "CodeLibelleAutomatique"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@IdEcriture", System.Data.OleDb.OleDbType.BigInt, 8, "IdEcriture"));
            Ecritures_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@OldIdEcriture", System.Data.OleDb.OleDbType.BigInt, 8, "IdEcriture")).SourceVersion = DataRowVersion.Original;

            Ecritures_Adapter.DeleteCommand = new OleDbCommand();
            Ecritures_Adapter.DeleteCommand.Connection = Con;
            Ecritures_Adapter.DeleteCommand.CommandText = "DELETE FROM Ecritures WHERE (IdEcriture = ?) ";
            Ecritures_Adapter.DeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@IdEcriture", System.Data.OleDb.OleDbType.BigInt, 8, "IdEcriture"));

            #endregion


            #region Bilan_Adapter

            Bilan_Adapter = new OleDbDataAdapter();
            Bilan_Adapter.SelectCommand = new OleDbCommand();
            Bilan_Adapter.SelectCommand.Connection = Con;
            Bilan_Adapter.SelectCommand.CommandText = "SELECT * FROM Billan";

            Bilan_Adapter.InsertCommand = new OleDbCommand();
            Bilan_Adapter.InsertCommand.Connection = Con;
            Bilan_Adapter.InsertCommand.CommandText = "INSERT INTO Billan(id, CompteActif, LibelleActif, SoldeActif, TotaleActif, ComptePassif, LibellePassif, SoldePassif, TotalePassif) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";

            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@CompteActif", System.Data.OleDb.OleDbType.Integer, 8, "CompteActif"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@id", System.Data.OleDb.OleDbType.Integer, 8, "id"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@LibelleActif", System.Data.OleDb.OleDbType.VarWChar, 100, "LibelleActif"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@SoldeActif", System.Data.OleDb.OleDbType.Double, 20, "SoldeActif"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@TotaleActif", System.Data.OleDb.OleDbType.Double, 20, "TotaleActif"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ComptePassif", System.Data.OleDb.OleDbType.Integer, 8, "ComptePassif"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@LibellePassif", System.Data.OleDb.OleDbType.VarWChar, 100, "LibellePassif"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@SoldePassif", System.Data.OleDb.OleDbType.Double, 8, "SoldePassif"));
            Bilan_Adapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@TotalePassif", System.Data.OleDb.OleDbType.Double, 20, "TotalePassif"));
            


            Bilan_Adapter.UpdateCommand = new OleDbCommand();
            Bilan_Adapter.UpdateCommand.Connection = Con;
            Bilan_Adapter.UpdateCommand.CommandText = "UPDATE Billan SET CompteActif = ?, LibelleActif = ?, SoldeActif = ?, TotaleActif = ?, ComptePassif = ?, LibellePassif = ?, SoldePassif = ?, TotalePassif = ? WHERE (id = ?) ";
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@CompteActif", System.Data.OleDb.OleDbType.Integer, 8, "CompteActif"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@LibelleActif", System.Data.OleDb.OleDbType.VarWChar, 100, "LibelleActif"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@SoldeActif", System.Data.OleDb.OleDbType.Double, 20, "SoldeActif"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@TotaleActif", System.Data.OleDb.OleDbType.Double, 20, "TotaleActif"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ComptePassif", System.Data.OleDb.OleDbType.Integer, 8, "ComptePassif"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@LibellePassif", System.Data.OleDb.OleDbType.VarWChar, 100, "LibellePassif"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@SoldePassif", System.Data.OleDb.OleDbType.Double, 8, "SoldePassif"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@TotalePassif", System.Data.OleDb.OleDbType.Double, 20, "TotalePassif"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@id", System.Data.OleDb.OleDbType.Integer, 8, "id"));
            Bilan_Adapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@id", System.Data.OleDb.OleDbType.Integer, 8, "id")).SourceVersion = DataRowVersion.Original;

            Bilan_Adapter.DeleteCommand = new OleDbCommand();
            Bilan_Adapter.DeleteCommand.Connection = Con;
            Bilan_Adapter.DeleteCommand.CommandText = "DELETE FROM Billan WHERE (id = ?) ";
            Bilan_Adapter.DeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@id", System.Data.OleDb.OleDbType.BigInt, 8, "id"));


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
