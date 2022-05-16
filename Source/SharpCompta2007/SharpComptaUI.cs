using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Globalization;
using CoucheAcceeDonnees;


 namespace  SharpCompta
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class SharpComptaUI : System.Windows.Forms.Form
	{
       
		private System.Windows.Forms.MainMenu mainMenu1;
        private MenuItem Menu_PlanComptable;
        private MenuItem Menu_Saisie_PlanComptable;
        private MenuItem menuItem5;
        private MenuItem Menu_Listing_PlanComptable;
        private MenuItem Menu_JournauxAuxiliaires;
        private MenuItem Menu_Saisie_JournauxAuxilliaires;
        private MenuItem menuItem4;
        private MenuItem Menu_Listing_JournauxAuxilliaires;
        private MenuItem Menu_LibellesAutomatiques;
        private MenuItem Menu_Saisie_LibellésAutomatiques;
        private MenuItem menuItem3;
        private MenuItem Menu_Listing_LibellesAutomatiques;
        private MenuItem Menu_Livres;
        private MenuItem Menu_Affichage_GrandLivre;
        private MenuItem menuItem1;
        private MenuItem Menu_Affichage_Balance;
        private MenuItem Menu_Donnees;
        private MenuItem Menu_Affichage_Importations; 
        
        private MenuItem menu_apropos;
        private Label SoftwareInfo;
        private Label AuthorInfo;
        private Label ContactInfo;

        private IContainer components;

        CoucheAcceeDonnees.CAD db;
        SqlConnection SqlServerConnection;
        OleDbConnection AcessConnection;
        private string an;
        private MenuItem menu_dossier;
        private MenuItem menuItem6;
        private MenuItem menuItem2;
        private MenuItem menuItem7;
        private MenuItem menuItem8;
        private MenuItem menuItem9;
        private MenuItem menuItem10;
        private MenuItem menuItem11;
        private MenuItem menuItem12;
        private MenuItem menuItem13;
        private string RaisonSocial;
        

        public SharpComptaUI()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharpComptaUI));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.Menu_PlanComptable = new System.Windows.Forms.MenuItem();
            this.Menu_Saisie_PlanComptable = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.Menu_Listing_PlanComptable = new System.Windows.Forms.MenuItem();
            this.Menu_JournauxAuxiliaires = new System.Windows.Forms.MenuItem();
            this.Menu_Saisie_JournauxAuxilliaires = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.Menu_Listing_JournauxAuxilliaires = new System.Windows.Forms.MenuItem();
            this.Menu_LibellesAutomatiques = new System.Windows.Forms.MenuItem();
            this.Menu_Saisie_LibellésAutomatiques = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.Menu_Listing_LibellesAutomatiques = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.Menu_Livres = new System.Windows.Forms.MenuItem();
            this.Menu_Affichage_GrandLivre = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.Menu_Affichage_Balance = new System.Windows.Forms.MenuItem();
            this.Menu_Donnees = new System.Windows.Forms.MenuItem();
            this.menu_dossier = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.Menu_Affichage_Importations = new System.Windows.Forms.MenuItem();
            this.menu_apropos = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.SoftwareInfo = new System.Windows.Forms.Label();
            this.AuthorInfo = new System.Windows.Forms.Label();
            this.ContactInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_PlanComptable,
            this.Menu_JournauxAuxiliaires,
            this.Menu_LibellesAutomatiques,
            this.menuItem2,
            this.menuItem10,
            this.Menu_Livres,
            this.Menu_Donnees,
            this.menu_apropos,
            this.menuItem13});
            // 
            // Menu_PlanComptable
            // 
            this.Menu_PlanComptable.Index = 0;
            this.Menu_PlanComptable.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_Saisie_PlanComptable,
            this.menuItem5,
            this.Menu_Listing_PlanComptable});
            this.Menu_PlanComptable.Text = "Compte Schématique ";
            this.Menu_PlanComptable.Click += new System.EventHandler(this.Menu_PlanComptable_Click);
            // 
            // Menu_Saisie_PlanComptable
            // 
            this.Menu_Saisie_PlanComptable.Index = 0;
            this.Menu_Saisie_PlanComptable.Text = "Saisie";
            this.Menu_Saisie_PlanComptable.Click += new System.EventHandler(this.Menu_Saisie_PlanComptable_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "-";
            // 
            // Menu_Listing_PlanComptable
            // 
            this.Menu_Listing_PlanComptable.Index = 2;
            this.Menu_Listing_PlanComptable.Text = "Affichage";
            this.Menu_Listing_PlanComptable.Click += new System.EventHandler(this.Menu_Affichage_PlanComptable_Click);
            // 
            // Menu_JournauxAuxiliaires
            // 
            this.Menu_JournauxAuxiliaires.Index = 1;
            this.Menu_JournauxAuxiliaires.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_Saisie_JournauxAuxilliaires,
            this.menuItem4,
            this.Menu_Listing_JournauxAuxilliaires});
            this.Menu_JournauxAuxiliaires.Text = "Journaux Auxilliaires";
            // 
            // Menu_Saisie_JournauxAuxilliaires
            // 
            this.Menu_Saisie_JournauxAuxilliaires.Index = 0;
            this.Menu_Saisie_JournauxAuxilliaires.Text = "Saisie";
            this.Menu_Saisie_JournauxAuxilliaires.Click += new System.EventHandler(this.Menu_Saisie_JournauxAuxilliaires_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "-";
            // 
            // Menu_Listing_JournauxAuxilliaires
            // 
            this.Menu_Listing_JournauxAuxilliaires.Index = 2;
            this.Menu_Listing_JournauxAuxilliaires.Text = "Affichage";
            this.Menu_Listing_JournauxAuxilliaires.Click += new System.EventHandler(this.Menu_Affichage_JournauxAuxilliaires_Click);
            // 
            // Menu_LibellesAutomatiques
            // 
            this.Menu_LibellesAutomatiques.Index = 2;
            this.Menu_LibellesAutomatiques.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_Saisie_LibellésAutomatiques,
            this.menuItem3,
            this.Menu_Listing_LibellesAutomatiques});
            this.Menu_LibellesAutomatiques.Text = "Plan Comptable";
            // 
            // Menu_Saisie_LibellésAutomatiques
            // 
            this.Menu_Saisie_LibellésAutomatiques.Index = 0;
            this.Menu_Saisie_LibellésAutomatiques.Text = "Saisie";
            this.Menu_Saisie_LibellésAutomatiques.Click += new System.EventHandler(this.Menu_Saisie_LibellésAutomatiques_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // Menu_Listing_LibellesAutomatiques
            // 
            this.Menu_Listing_LibellesAutomatiques.Index = 2;
            this.Menu_Listing_LibellesAutomatiques.Text = "Affichage";
            this.Menu_Listing_LibellesAutomatiques.Click += new System.EventHandler(this.Menu_Affichage_LibellesAutomatiques_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7,
            this.menuItem8,
            this.menuItem9});
            this.menuItem2.Text = "Ecritures";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.Text = "Saisie";
            this.menuItem7.Click += new System.EventHandler(this.Menu_Saisie_Operations_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 1;
            this.menuItem8.Text = "-";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.Text = "Affichage Journaux";
            this.menuItem9.Click += new System.EventHandler(this.Menu_Affichage_Journaux_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 4;
            this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem11,
            this.menuItem12});
            this.menuItem10.Text = "Bilan";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 0;
            this.menuItem11.Text = "Saisie";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 1;
            this.menuItem12.Text = "Exporter";
            // 
            // Menu_Livres
            // 
            this.Menu_Livres.Index = 5;
            this.Menu_Livres.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_Affichage_GrandLivre,
            this.menuItem1,
            this.Menu_Affichage_Balance});
            this.Menu_Livres.Text = "Livres";
            // 
            // Menu_Affichage_GrandLivre
            // 
            this.Menu_Affichage_GrandLivre.Index = 0;
            this.Menu_Affichage_GrandLivre.Text = "Grand Livre";
            this.Menu_Affichage_GrandLivre.Click += new System.EventHandler(this.Menu_Affichage_GrandLivre_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "-";
            // 
            // Menu_Affichage_Balance
            // 
            this.Menu_Affichage_Balance.Index = 2;
            this.Menu_Affichage_Balance.Text = "Balance";
            this.Menu_Affichage_Balance.Click += new System.EventHandler(this.Menu_Affichage_Balance_Click);
            // 
            // Menu_Donnees
            // 
            this.Menu_Donnees.Index = 6;
            this.Menu_Donnees.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menu_dossier,
            this.menuItem6,
            this.Menu_Affichage_Importations});
            this.Menu_Donnees.Text = "Informations";
            this.Menu_Donnees.Click += new System.EventHandler(this.Menu_Donnees_Click);
            // 
            // menu_dossier
            // 
            this.menu_dossier.Index = 0;
            this.menu_dossier.Text = "Société";
            this.menu_dossier.Click += new System.EventHandler(this.menu_dossier_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 1;
            this.menuItem6.Text = "-";
            // 
            // Menu_Affichage_Importations
            // 
            this.Menu_Affichage_Importations.Index = 2;
            this.Menu_Affichage_Importations.Text = "Ajouter";
            this.Menu_Affichage_Importations.Click += new System.EventHandler(this.Menu_Affichage_Importations_Click);
            // 
            // menu_apropos
            // 
            this.menu_apropos.Index = 7;
            this.menu_apropos.Text = "A propos !";
            this.menu_apropos.Click += new System.EventHandler(this.menu_apropos_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 8;
            this.menuItem13.Text = "";
            // 
            // SoftwareInfo
            // 
            this.SoftwareInfo.AutoSize = true;
            this.SoftwareInfo.BackColor = System.Drawing.Color.White;
            this.SoftwareInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoftwareInfo.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.SoftwareInfo.Location = new System.Drawing.Point(12, 28);
            this.SoftwareInfo.Name = "SoftwareInfo";
            this.SoftwareInfo.Size = new System.Drawing.Size(0, 25);
            this.SoftwareInfo.TabIndex = 0;
            // 
            // AuthorInfo
            // 
            this.AuthorInfo.AutoSize = true;
            this.AuthorInfo.BackColor = System.Drawing.Color.White;
            this.AuthorInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorInfo.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.AuthorInfo.Location = new System.Drawing.Point(434, 28);
            this.AuthorInfo.Name = "AuthorInfo";
            this.AuthorInfo.Size = new System.Drawing.Size(0, 25);
            this.AuthorInfo.TabIndex = 1;
            // 
            // ContactInfo
            // 
            this.ContactInfo.AutoSize = true;
            this.ContactInfo.BackColor = System.Drawing.Color.White;
            this.ContactInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactInfo.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.ContactInfo.Location = new System.Drawing.Point(766, 28);
            this.ContactInfo.Name = "ContactInfo";
            this.ContactInfo.Size = new System.Drawing.Size(0, 25);
            this.ContactInfo.TabIndex = 2;
            // 
            // SharpComptaUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(822, 423);
            this.Controls.Add(this.ContactInfo);
            this.Controls.Add(this.AuthorInfo);
            this.Controls.Add(this.SoftwareInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "SharpComptaUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hivernage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SuperCompta_Closing);
            this.Load += new System.EventHandler(this.SuperCompta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
				

		private void SuperCompta_Load(object sender, System.EventArgs e)
		{
            try
            { 
                string ConnString = "";
                IAdapters Adapters = null;

                string DataBase = System.Configuration.ConfigurationManager.AppSettings.Get("DataBase");

                if (DataBase == "SqlServer")
                {
                    Console.WriteLine("1");
                    ConnString = System.Configuration.ConfigurationManager.AppSettings.Get("SqlServer_ConnectionString");
                    Console.WriteLine("2");
                    SqlServerConnection = new SqlConnection(ConnString);
                    Console.WriteLine("3");
                    SqlServerConnection.Open();
                    Console.WriteLine("4");
                    Adapters = new SqlServerAdapters(SqlServerConnection);
                    Console.WriteLine("5");
                    Adapters.Build_Adapters();
                    Console.WriteLine("6");
                    db = new CAD(Adapters);
                    Console.WriteLine("7");
                }

                else if (DataBase == "Access")
                {
                    ConnString = System.Configuration.ConfigurationManager.AppSettings.Get("Access_ConnectionString");
                    AcessConnection = new OleDbConnection(ConnString);
                    AcessConnection.Open();
                    Adapters = new AcessAdapters(AcessConnection);
                    Adapters.Build_Adapters();
                    db = new CAD(Adapters);
                }

                else return;
                Console.WriteLine("8");
                DossierLogic Dossier_Logic = new DossierLogic(db);
                Console.WriteLine("9");
                DossierModel model = new DossierModel();
                Console.WriteLine("10");
                model.IDDossier = "1";
                Console.WriteLine("11");
                Dossier_Logic.Consulter(ref model);
                Console.WriteLine("12");
                RaisonSocial = model.RaisonSocial;
                Console.WriteLine("13");
                an = model.Annee;
                                          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
			
		}
        
		
		private void SuperCompta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
                if (SqlServerConnection != null)
                    if (SqlServerConnection.State != ConnectionState.Closed) SqlServerConnection.Close();
                if (AcessConnection != null)
                    if (AcessConnection.State != ConnectionState.Closed) AcessConnection.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void Exit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        private void Menu_Saisie_PlanComptable_Click(object sender, EventArgs e)
        {
            try
            {
                SaisieCompta.SaisiePlanUI view = new SaisieCompta.SaisiePlanUI(db);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        private void Menu_Affichage_PlanComptable_Click(object sender, EventArgs e)
        {
            try
            {
                EditionCompta.ListingPlanComptableUI view = new EditionCompta.ListingPlanComptableUI(db);
                view.RaisonSocial = RaisonSocial;
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Menu_Saisie_LibellésAutomatiques_Click(object sender, EventArgs e)
        {
            try
            {
                SaisieCompta.SaisieLibellesAutomatiqueUI view = new SaisieCompta.SaisieLibellesAutomatiqueUI(db);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   
        private void Menu_Affichage_LibellesAutomatiques_Click(object sender, EventArgs e)
        {
            try
            {
                EditionCompta.ListingLibellesAutUI view = new EditionCompta.ListingLibellesAutUI(db);
                view.RaisonSocial = RaisonSocial;
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Menu_Saisie_JournauxAuxilliaires_Click(object sender, EventArgs e)
        {
            try
            {
                SaisieCompta.SaisieJournauxUI view = new SaisieCompta.SaisieJournauxUI(db);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  
        
        private void Menu_Affichage_JournauxAuxilliaires_Click(object sender, EventArgs e)
        {
            try
            {
                EditionCompta.ListingJournauxUI view = new EditionCompta.ListingJournauxUI(db);
                view.RaisonSocial = RaisonSocial;
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Menu_Saisie_Operations_Click(object sender, EventArgs e)
        {
            try
            {
                SaisieCompta.SaisieEcrituresUI view = new SaisieCompta.SaisieEcrituresUI(db, an);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

 

        private void Menu_Affichage_Journaux_Click(object sender, EventArgs e)
        {
            try
            {
                LivresCompta.AffichageJourauxUI view = new LivresCompta.AffichageJourauxUI(db, an);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Menu_Affichage_GrandLivre_Click(object sender, EventArgs e)
        {
            try
            {
                LivresCompta.AffichageGrandLivreUI view = new LivresCompta.AffichageGrandLivreUI(db, an);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Menu_Affichage_Balance_Click(object sender, EventArgs e)
        {
            try
            {
                LivresCompta.AffichageBalanceUI view = new LivresCompta.AffichageBalanceUI(db, an);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        
        private void menu_dossier_Click(object sender, EventArgs e)
        {
            try
            {
                CoucheAcceeDonnees.DossierUI view = new CoucheAcceeDonnees.DossierUI(db);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Menu_Affichage_Importations_Click(object sender, EventArgs e)
        {
            try
            {
                CoucheAcceeDonnees.ImportationDonneesUI view = new CoucheAcceeDonnees.ImportationDonneesUI(db);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void menu_apropos_Click(object sender, EventArgs e)
        {
            SoftwareInfo.Text = "Software : Hivernage version 1.0";
            AuthorInfo.Text = "Author : Karkaza Tahar";
            ContactInfo.Text = "Contact : Taher00karkaza@gmail.com";
        }

        private void Menu_Donnees_Click(object sender, EventArgs e)
        {

        }

        private void menuItem11_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("L'appel du view billan dans Sharp");
                ComptabiliteGenerale.Saisie.View.SaisieBilanUI view = new ComptabiliteGenerale.Saisie.View.SaisieBilanUI(db,an);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Menu_PlanComptable_Click(object sender, EventArgs e)
        {

        }
    }
}
