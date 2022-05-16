using System;
using System.Drawing;
using System.Drawing.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using Utilitaire;
using CoucheAcceeDonnees;
using Impression;
using Excel;
using Export.Commun;
using Compta.Commun;


namespace LivresCompta
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class AffichageJourauxUI : System.Windows.Forms.Form
	{
        public System.Windows.Forms.Form parent;
        private System.Windows.Forms.MainMenu mainMenu1;
        private MainMenu mainMenu2;
        private MenuItem Menu_Affichage;
        private MenuItem Menu_Affichage_UJournal;
        private MenuItem Menu_Affichage_PJournal;  
        private MenuItem Menu_Affichage_GJournal;
       
        private MenuItem Menu_Export;
        private MenuItem Menu_Imprimer;
        private MenuItem Menu_Excel;

        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label journal;
		private System.Windows.Forms.Label tdebit;
		private System.Windows.Forms.Label tcredit;
        private System.Windows.Forms.Label periode;
        private System.Windows.Forms.Label warn;
		
		private System.Windows.Forms.ComboBox JournalCombo;
        
        private Button Imprimer_Button;
        private Button Excel_Button; 

        private System.Windows.Forms.SaveFileDialog Sfd;
        private IContainer components;
             
        private System.Windows.Forms.DataGrid dg;
        
        public string Font_Path;
        
        AffichageJournauxLogic Logic;
        JournalVM view_model;

        SelectionDatesVM SelectionDates_VM; 
         
        string an;
        string date_debut;
        private Label label1;
        private Label label2;
        private Label IntituleTxt;
        private MenuItem Menu_Quitter;
        string date_fin;

		

		public AffichageJourauxUI()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

        public AffichageJourauxUI(CAD db, string an1)
        {
            //
            // Requis pour la prise en charge du Concepteur Windows Forms
            //
            InitializeComponent();
            an = an1;

            date_debut = "01/01/" + an;
            date_fin = "31/12/" + an;


            Logic = new AffichageJournauxLogic(db, date_debut);
            

            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AffichageJourauxUI));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.dg = new System.Windows.Forms.DataGrid();
            this.tdebit = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tcredit = new System.Windows.Forms.Label();
            this.journal = new System.Windows.Forms.Label();
            this.periode = new System.Windows.Forms.Label();
            this.warn = new System.Windows.Forms.Label();
            this.JournalCombo = new System.Windows.Forms.ComboBox();
            this.Sfd = new System.Windows.Forms.SaveFileDialog();
            this.mainMenu2 = new System.Windows.Forms.MainMenu(this.components);
            this.Menu_Affichage = new System.Windows.Forms.MenuItem();
            this.Menu_Affichage_UJournal = new System.Windows.Forms.MenuItem();
            this.Menu_Affichage_PJournal = new System.Windows.Forms.MenuItem();
            this.Menu_Affichage_GJournal = new System.Windows.Forms.MenuItem();
            this.Menu_Export = new System.Windows.Forms.MenuItem();
            this.Menu_Imprimer = new System.Windows.Forms.MenuItem();
            this.Menu_Excel = new System.Windows.Forms.MenuItem();
            this.Menu_Quitter = new System.Windows.Forms.MenuItem();
            this.Imprimer_Button = new System.Windows.Forms.Button();
            this.Excel_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IntituleTxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // dg
            // 
            this.dg.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dg.CaptionVisible = false;
            this.dg.DataMember = "";
            this.dg.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dg.Location = new System.Drawing.Point(6, 147);
            this.dg.Name = "dg";
            this.dg.ParentRowsBackColor = System.Drawing.SystemColors.Desktop;
            this.dg.RowHeaderWidth = 0;
            this.dg.Size = new System.Drawing.Size(789, 255);
            this.dg.TabIndex = 9;
            // 
            // tdebit
            // 
            this.tdebit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tdebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tdebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tdebit.Location = new System.Drawing.Point(552, 417);
            this.tdebit.Name = "tdebit";
            this.tdebit.Size = new System.Drawing.Size(108, 19);
            this.tdebit.TabIndex = 14;
            this.tdebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(477, 417);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "Total ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tcredit
            // 
            this.tcredit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tcredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tcredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcredit.Location = new System.Drawing.Point(660, 417);
            this.tcredit.Name = "tcredit";
            this.tcredit.Size = new System.Drawing.Size(110, 19);
            this.tcredit.TabIndex = 15;
            this.tcredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // journal
            // 
            this.journal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.journal.Location = new System.Drawing.Point(203, 14);
            this.journal.Name = "journal";
            this.journal.Size = new System.Drawing.Size(360, 24);
            this.journal.TabIndex = 21;
            this.journal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // periode
            // 
            this.periode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periode.Location = new System.Drawing.Point(64, 51);
            this.periode.Name = "periode";
            this.periode.Size = new System.Drawing.Size(651, 21);
            this.periode.TabIndex = 22;
            this.periode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // warn
            // 
            this.warn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warn.ForeColor = System.Drawing.Color.Red;
            this.warn.Location = new System.Drawing.Point(225, 89);
            this.warn.Name = "warn";
            this.warn.Size = new System.Drawing.Size(261, 23);
            this.warn.TabIndex = 24;
            this.warn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JournalCombo
            // 
            this.JournalCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JournalCombo.Location = new System.Drawing.Point(52, 122);
            this.JournalCombo.Name = "JournalCombo";
            this.JournalCombo.Size = new System.Drawing.Size(59, 21);
            this.JournalCombo.TabIndex = 25;
            this.JournalCombo.SelectedIndexChanged += new System.EventHandler(this.JournalCombo_SelectedIndexChanged);
            // 
            // Sfd
            // 
            this.Sfd.FileName = "doc1";
            this.Sfd.FileOk += new System.ComponentModel.CancelEventHandler(this.Sfd_FileOk);
            // 
            // mainMenu2
            // 
            this.mainMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_Affichage,
            this.Menu_Export,
            this.Menu_Quitter});
            // 
            // Menu_Affichage
            // 
            this.Menu_Affichage.Index = 0;
            this.Menu_Affichage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_Affichage_UJournal,
            this.Menu_Affichage_PJournal,
            this.Menu_Affichage_GJournal});
            this.Menu_Affichage.Text = "Menu &Affichage";
            // 
            // Menu_Affichage_UJournal
            // 
            this.Menu_Affichage_UJournal.Index = 0;
            this.Menu_Affichage_UJournal.Shortcut = System.Windows.Forms.Shortcut.CtrlJ;
            this.Menu_Affichage_UJournal.Text = "Afficher &Journal";
            this.Menu_Affichage_UJournal.Click += new System.EventHandler(this.Menu_Affichage_UJournal_Click);
            // 
            // Menu_Affichage_PJournal
            // 
            this.Menu_Affichage_PJournal.Index = 1;
            this.Menu_Affichage_PJournal.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.Menu_Affichage_PJournal.Text = "Afficher &Plusieurs Journaux";
            this.Menu_Affichage_PJournal.Click += new System.EventHandler(this.Menu_Affichage_PJournal_Click);
            // 
            // Menu_Affichage_GJournal
            // 
            this.Menu_Affichage_GJournal.Index = 2;
            this.Menu_Affichage_GJournal.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
            this.Menu_Affichage_GJournal.Text = "Afficher Journal &Global";
            this.Menu_Affichage_GJournal.Click += new System.EventHandler(this.Menu_Affichage_GJournal_Click);
            // 
            // Menu_Export
            // 
            this.Menu_Export.Index = 1;
            this.Menu_Export.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_Imprimer,
            this.Menu_Excel});
            this.Menu_Export.Text = "Menu &Export";
            // 
            // Menu_Imprimer
            // 
            this.Menu_Imprimer.Index = 0;
            this.Menu_Imprimer.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
            this.Menu_Imprimer.Text = "&Imprimer";
            // 
            // Menu_Excel
            // 
            this.Menu_Excel.Index = 1;
            this.Menu_Excel.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.Menu_Excel.Text = "&Excel";
            this.Menu_Excel.Click += new System.EventHandler(this.Menu_Excel_Click);
            // 
            // Menu_Quitter
            // 
            this.Menu_Quitter.Index = 2;
            this.Menu_Quitter.Text = "Menu &Quitter";
            this.Menu_Quitter.Click += new System.EventHandler(this.Menu_Quitter_Click);
            // 
            // Imprimer_Button
            // 
            this.Imprimer_Button.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Imprimer_Button.Location = new System.Drawing.Point(219, 433);
            this.Imprimer_Button.Name = "Imprimer_Button";
            this.Imprimer_Button.Size = new System.Drawing.Size(88, 25);
            this.Imprimer_Button.TabIndex = 26;
            this.Imprimer_Button.Text = "Imprimer";
            this.Imprimer_Button.UseVisualStyleBackColor = true;
            this.Imprimer_Button.Click += new System.EventHandler(this.Imprimer_Button_Click);
            // 
            // Excel_Button
            // 
            this.Excel_Button.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Excel_Button.Location = new System.Drawing.Point(67, 433);
            this.Excel_Button.Name = "Excel_Button";
            this.Excel_Button.Size = new System.Drawing.Size(88, 25);
            this.Excel_Button.TabIndex = 27;
            this.Excel_Button.Text = "Excel";
            this.Excel_Button.UseVisualStyleBackColor = true;
            this.Excel_Button.Click += new System.EventHandler(this.Excel_Button_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 21);
            this.label1.TabIndex = 28;
            this.label1.Text = "Code ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(128, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 21);
            this.label2.TabIndex = 29;
            this.label2.Text = "Intitulé ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IntituleTxt
            // 
            this.IntituleTxt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.IntituleTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IntituleTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IntituleTxt.Location = new System.Drawing.Point(188, 123);
            this.IntituleTxt.Name = "IntituleTxt";
            this.IntituleTxt.Size = new System.Drawing.Size(221, 19);
            this.IntituleTxt.TabIndex = 30;
            this.IntituleTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AffichageJourauxUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(796, 474);
            this.Controls.Add(this.IntituleTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Excel_Button);
            this.Controls.Add(this.Imprimer_Button);
            this.Controls.Add(this.JournalCombo);
            this.Controls.Add(this.warn);
            this.Controls.Add(this.periode);
            this.Controls.Add(this.journal);
            this.Controls.Add(this.tcredit);
            this.Controls.Add(this.tdebit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dg);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenu2;
            this.Name = "AffichageJourauxUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Affichage Journal";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.AffichageJourauxUI_Closing);
            this.Load += new System.EventHandler(this.AffichageJourauxUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


        private void AffichageJourauxUI_Load(object sender, System.EventArgs e)
		{
            buildDataStyle(dg);
				
		}

        private void AffichageJourauxUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}   
        
        private void Menu_Quitter_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        
        private void Menu_Affichage_UJournal_Click(object sender, EventArgs e)
        {
            JournalCombo.Items.Clear();
            journal.Text = "";
            tdebit.Text = "";
            tcredit.Text = "";

            SelectionJournalVM SelectionJournal_VM = new SelectionJournalVM();
            SelectionJournalUI select = new SelectionJournalUI();
            select.SelectionJournal_VM = SelectionJournal_VM;
            select.an = an;
            select.JournauxLogic = Logic;
            select.ShowDialog();

            if (SelectionJournal_VM.valid == true)
            {
                periode.Text = "Periode du: " + SelectionJournal_VM.date1 + " Au " + SelectionJournal_VM.date2;
                date_debut = SelectionJournal_VM.idate1;
                date_fin = SelectionJournal_VM.idate2;
                string idj = SelectionJournal_VM.idj;
                JournalCombo.Items.Add(idj);
            }

            if (JournalCombo.Items.Count > 0)
            {
                warn.Text = "Veuillez patienter SVP";
                this.Refresh();
                JournalCombo.SelectedIndex = 0; 
            }

            warn.Text = "";

        }

        private void Menu_Affichage_PJournal_Click(object sender, EventArgs e)
        {
            dg.DataSource = null;
            JournalCombo.Items.Clear();
            journal.Text = "";
            tdebit.Text = "";
            tcredit.Text = "";


            SelectionJournauxVM SelectionJournaux_VM = new SelectionJournauxVM();
            SelectionJournauxUI select = new SelectionJournauxUI();
            select.SelectionJournaux_VM = SelectionJournaux_VM;
            select.JournauxLogic = Logic;
            select.an = an;

            select.ShowDialog();
            warn.Text = "Veuillez patienter SVP";
            this.Refresh();
            if (SelectionJournaux_VM.valid == true)
            {
                periode.Text = "Periode du: " + SelectionJournaux_VM.date1 + " Au " + SelectionJournaux_VM.date2;
                date_debut = SelectionJournaux_VM.idate1;
                date_fin = SelectionJournaux_VM.idate2;
                string[] idjs = SelectionJournaux_VM.idjs;
                for (int i = 0; i < idjs.Length; i++)
                {
                    JournalCombo.Items.Add(idjs[i]);
                }

            }
            if (JournalCombo.Items.Count > 0) JournalCombo.SelectedIndex = 0;

            warn.Text = "";

        } 
        
        private void Menu_Affichage_GJournal_Click(object sender, EventArgs e)
        {
            dg.DataSource = null;
            JournalCombo.Items.Clear();
            JournalCombo.Text = "";
            IntituleTxt.Text = "";
            journal.Text = "";
            tdebit.Text = "";
            tcredit.Text = "";
          
            SelectionDatesUI select = new SelectionDatesUI();
            SelectionDates_VM = new SelectionDatesVM();
            select.SelectionDates_VM = SelectionDates_VM;
            select.an = an;


            select.ShowDialog(); 
            
            warn.Text = "Veuillez patienter SVP";
            this.Refresh();

            if (SelectionDates_VM.valid == true)
            {
                periode.Text = "Periode du: " + SelectionDates_VM.date1 + " Au " + SelectionDates_VM.date2;
                date_debut = SelectionDates_VM.idate1;
                date_fin = SelectionDates_VM.idate2;
                IntituleTxt.Text = "Global";
                view_model = Logic.get_journal_global(date_debut, date_fin);
                dg.DataSource = view_model.Lignes;
                tdebit.Text = Fonctions.format04(view_model.total_debit.ToString());
                tcredit.Text = Fonctions.format04(view_model.total_credit.ToString());
              


            }
            warn.Text = "";

        }
	 	
        private void JournalCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
             if (JournalCombo.Items.Count > 0)
                 Journal(JournalCombo.SelectedItem.ToString());
             
   		}

        private void Journal(string code)
        { 
            this.Refresh();
            dg.DataSource = null;
            view_model = Logic.get_journal(code, date_debut, date_fin);
            dg.DataSource = view_model.Lignes;
            IntituleTxt.Text = view_model.intitule_journal;
            tdebit.Text = Fonctions.format04(view_model.total_debit.ToString());
            tcredit.Text = Fonctions.format04(view_model.total_credit.ToString());
            warn.Text = "";
            
        }

        private void Exit(object sender, System.EventArgs e)
		{
			this.Close();
		
		}
		
		private void buildDataStyle ( DataGrid dg )
		{
			DataGridTableStyle style = new DataGridTableStyle();
            style.MappingName = "ArrayList";
			//style.AlternatingBackColor = System.Drawing.Color.Bisque;
			DataGridTextBoxColumn Date = new DataGridTextBoxColumn();
			Date.HeaderText = "Date";
			Date.MappingName = "Date";
			Date.Width = 80;
			DataGridTextBoxColumn Compte = new DataGridTextBoxColumn();
			Compte.HeaderText = "Compte";
			Compte.MappingName = "Compte";
			Compte.Width = 65;
			DataGridTextBoxColumn Cpart = new DataGridTextBoxColumn();
			Cpart.HeaderText = "Cpart";
            Cpart.MappingName = "Contre_Partie";
			Cpart.Width = 65;
			DataGridTextBoxColumn Piece = new DataGridTextBoxColumn();
			Piece.HeaderText = "Piece";
			Piece.MappingName = "Piece";
			Piece.Width = 80;
			DataGridTextBoxColumn Designation = new DataGridTextBoxColumn();
			Designation.HeaderText = "Libéllé";
            Designation.MappingName = "Libelle";
			Designation.Width = 240;
			DataGridTextBoxColumn Debit = new DataGridTextBoxColumn();
			Debit.HeaderText = "Debit";
			Debit.MappingName = "Debit";
			Debit.Width = 110;
			Debit.Alignment =HorizontalAlignment.Right;
			DataGridTextBoxColumn Credit = new DataGridTextBoxColumn();
			Credit.HeaderText = "Credit";
			Credit.MappingName = "Credit";
			Credit.Width = 110;
			Credit.Alignment =HorizontalAlignment.Right;
			style.GridColumnStyles.AddRange( new DataGridColumnStyle[] {Date,Compte,Cpart,Piece,Designation,Debit,Credit});
			dg.TableStyles.Add(style);
            dg.Enabled = true;
            dg.AllowDrop = false;
            dg.ReadOnly = true;
		}

        private void Imprimer_Button_Click(object sender, EventArgs e)
        {

            if (JournalCombo.Items.Count == 0)
            {
                Impression.Imprimeur_Journal printer = new Impression.Imprimeur_Journal();
                view_model = Logic.get_journal_global(date_debut, date_fin);
                printer.Lignes = view_model.Lignes;
                if (printer.Lignes.Count > 0)
                {
                    buildcaptions(printer);
                    buildtableau(printer);
                    printer.BuildDocument();
                    printer.print_preview();
                }
                return;
      
            }


            for (int i = 0; i < JournalCombo.Items.Count; i++)
            {
                Impression.Imprimeur_Journal printer = new Impression.Imprimeur_Journal();
                view_model = Logic.get_journal(JournalCombo.Items[i].ToString(), date_debut, date_fin);
                printer.Lignes = view_model.Lignes;
                if (printer.Lignes.Count > 0)
                {
                    buildcaptions(printer);
                    buildtableau(printer);
                    printer.BuildDocument();
                    printer.print_preview();
                }

            }
            


           
        }

        private void buildcaptions(Impression.Imprimeur_Journal printer)
        {
            FontFamily ffm = new FontFamily("Arial");
            Font fnt1 = new Font(ffm, 9);
            Font fnt2 = new Font(ffm, 10);
            Font fnt3 = new Font(ffm, 11, FontStyle.Bold);


            printer.Captions = new List<Caption>();

            Caption caption1 = new Caption();
            caption1.Text = "Page : ";
            caption1.rec = new RectangleF(710, 10, 100, 20);
            caption1.fnt = fnt1;
            printer.Captions.Add(caption1);

            Caption caption2 = new Caption();
            DateTime dt = DateTime.Now;
            string date = "Date : " + dt.ToShortDateString();
            caption2.Text = date;
            caption2.rec = new RectangleF(590, 35, 300, 20);
            caption2.fnt = fnt2;
            printer.Captions.Add(caption2); 
            
            Caption caption5 = new Caption();
            caption5.Text = "Journal " + view_model.code_journal + " : " + view_model.intitule_journal;
            caption5.rec = new RectangleF(245, 60, 300, 20);
            caption5.fnt = fnt3;
            printer.Captions.Add(caption5);

            Caption caption4 = new Caption();
            caption4.Text = periode.Text;
            caption4.rec = new RectangleF(247, 90, 300, 20);
            caption4.fnt = fnt2;
            printer.Captions.Add(caption4);

          




        }

        private void buildtableau(Impression.Imprimeur_Journal printer)
        {
            FontFamily ffm = new FontFamily("Arial");

            //Font fnt = new Font(ffm,Font.GetHeight(g));
            Font fnt09 = new Font(ffm, 9);
            Font Bfnt09 = new Font(ffm, 9, FontStyle.Bold);
            printer.tbl = new Tableau(Bfnt09,2F);

            printer.tbl.Header_Font = Bfnt09;
            printer.tbl.Header_alignment = Alignment.center;
            printer.tbl.Header_height = 2.2f;
            printer.tbl.Header_margin = 0.5f;
            printer.tbl.Cell_height = 1.5f;
            printer.tbl.LinesInPage = 40;
            printer.tbl.Lignes = printer.Lignes;
            printer.num_pages = printer.tbl.Lignes.Count / printer.tbl.LinesInPage;
            if (printer.tbl.Lignes.Count % printer.tbl.LinesInPage != 0) printer.num_pages++;
            printer.tbl.posX = 10;
            printer.tbl.posY = 130;

            Tableau.colonne tblc0 = new Tableau.colonne();
            tblc0.title = "Date"; ;
            tblc0.width = 6;
            tblc0.Column_Font = fnt09;
            tblc0.mapping = "Date";
            tblc0.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc0);

            Tableau.colonne tblc1 = new Tableau.colonne();
            tblc1.title = "N°Compte";
            tblc1.width = 5.5F;
            tblc1.Column_Font = fnt09;
            tblc1.mapping = "Compte";
            tblc1.Zeropadding = 8;
            tblc1.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc1);

            Tableau.colonne tblc2 = new Tableau.colonne();
            tblc2.title = "C/partie";
            tblc2.width = 5.5F;
            tblc2.Column_Font = fnt09;
            tblc2.mapping = "Contre_Partie";
            tblc2.Zeropadding = 8;
            tblc2.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc2);

            Tableau.colonne tblc3 = new Tableau.colonne();
            tblc3.title = "Pièce";
            tblc3.width = 6F;
            tblc3.Column_Font = fnt09;
            tblc3.mapping = "Piece";
            tblc3.Zeropadding = 10;
            tblc3.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc3);

            Tableau.colonne tblc4 = new Tableau.colonne();
            tblc4.title = "Libéllé";
            tblc4.width = 18F;
            tblc4.Column_Font = fnt09;
            tblc4.mapping = "Libelle";
            tblc4.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc4);

            Tableau.colonne tblc5 = new Tableau.colonne();
            tblc5.title = "Débit";
            tblc5.width = 8F;
            tblc5.Column_Font = fnt09;
            tblc5.mapping = "Debit";
            tblc5.Cell_alignAlignment = Alignment.right;
            printer.tbl.PutColInContainer(tblc5);

            Tableau.colonne tblc6 = new Tableau.colonne();
            tblc6.title = "Crédit";
            tblc6.width = 8F;
            tblc6.Column_Font = fnt09;
            tblc6.mapping = "Credit";
            tblc6.Cell_alignAlignment = Alignment.right;
            printer.tbl.PutColInContainer(tblc6);

        } 
        
        private void Menu_Excel_Click(object sender, EventArgs e)
        {
           
            Sfd.FileName = "";
            Sfd.ShowDialog();
            

        }

        private void Excel_Button_Click(object sender, EventArgs e)
        {
            
            Sfd.FileName = "";
            Sfd.ShowDialog();
      
        }

        private void Sfd_FileOk(object sender, CancelEventArgs e)
        {
            string filename = ((SaveFileDialog)sender).FileName;
            DialogResult drs = MessageBox.Show("Voulez vraiment utiliser ce fichier \n" + filename + " \n" + "comme fichier d'export de données vers Excel ?", "", MessageBoxButtons.YesNo);
            if (DialogResult.No == drs)
            {
                MessageBox.Show("Opération annulée");
                return;
            }
            SVP svp = new SVP();
            svp.Show();
            svp.Refresh();
            
            ExcelBuilder excel = new ExcelBuilder();
            bool b = excel.set_execl_app();
            if ( b == false )
            {
                MessageBox.Show("Excel n'est proprement installé !!");
                return;
            }
            
            excel.filename = filename;

            if (JournalCombo.Items.Count == 0)
            {
                view_model = Logic.get_journal_global(date_debut, date_fin);
                excel.Lignes = view_model.Lignes;
                Journal2Excel(ref excel, 1, false);
            }
           
            for (int i = 0; i < JournalCombo.Items.Count; i++)
            {
                view_model = Logic.get_journal(JournalCombo.Items[i].ToString(), date_debut, date_fin);
                excel.Lignes = view_model.Lignes;
                Journal2Excel(ref excel, i + 1, true);
            }
            
            excel.save();
            svp.Hide();
            svp.Close();
            MessageBox.Show("Le fichier excel : " + filename + " a eté crée \n");

        }

        private void Journal2Excel(ref ExcelBuilder excel,int sheet_item, bool add)
        {
            Phrase[] Header = new Phrase[2];
            Header[0] = new Phrase();
            Header[0].Words = new String[] { periode.Text };
            Header[0].Spaces = new int[] { 10, 0, 10 };
            Header[0].length = 7;
            Header[0].build();
            Header[1] = new Phrase();
            Header[1].Words = new String[] { "Journal " + view_model.code_journal + " : " + view_model.intitule_journal };
            Header[1].Spaces = new int[] { 10, 0, 10 };
            Header[1].length = 7;
            Header[1].build();

            excel.Header = Header;
            excel.TableHeader = new String[] { "Date", "N°Compte", "C/partie", "Pièce", "Libéllé", "Débit", "Crédit" };
            excel.TableFooter = new String[] { "", "", "", "", "Totaux", Fonctions.format04(view_model.total_debit.ToString()), Fonctions.format04(view_model.total_credit.ToString()) };
            excel.RowHight = 15;
            
            excel.TableColumnStyle = new Excel.ColumnStyle[7];
            excel.TableColumnStyle[0] = new Excel.ColumnStyle();
            excel.TableColumnStyle[0].Align = Alignment.left;
            excel.TableColumnStyle[0].ColumnWidth = 10;
            excel.TableColumnStyle[0].Format = "";
            excel.TableColumnStyle[1] = new Excel.ColumnStyle();
            excel.TableColumnStyle[1].Align = Alignment.left;
            excel.TableColumnStyle[1].ColumnWidth = 10;
            excel.TableColumnStyle[1].Format = "";
            excel.TableColumnStyle[2] = new Excel.ColumnStyle();
            excel.TableColumnStyle[2].Align = Alignment.left;
            excel.TableColumnStyle[2].ColumnWidth = 10;
            excel.TableColumnStyle[2].Format = "";
            excel.TableColumnStyle[3] = new Excel.ColumnStyle();
            excel.TableColumnStyle[3].Align = Alignment.left;
            excel.TableColumnStyle[3].ColumnWidth = 10;
            excel.TableColumnStyle[3].Format = "";
            excel.TableColumnStyle[4] = new Excel.ColumnStyle();
            excel.TableColumnStyle[4].Align = Alignment.left;
            excel.TableColumnStyle[4].ColumnWidth = 25;
            excel.TableColumnStyle[4].Format = "";
            excel.TableColumnStyle[5] = new Excel.ColumnStyle();
            excel.TableColumnStyle[5].Align = Alignment.right;
            excel.TableColumnStyle[5].ColumnWidth = 15;
            excel.TableColumnStyle[5].Format = "0,00";
            excel.TableColumnStyle[6] = new Excel.ColumnStyle();
            excel.TableColumnStyle[6].Align = Alignment.right;
            excel.TableColumnStyle[6].ColumnWidth = 15;
            excel.TableColumnStyle[6].Format = "0,00";

            string journal_Int = "Journal " + view_model.intitule_journal;


            excel.set_sheet(journal_Int, sheet_item,add);
          
            excel.WriteDoc();
               

           
        }



       


        

      
	
        	
		
		
		
	
		

      

		

		
		

		


		
	

	

	
		
	



	

		

		

		

	}

	
	
	}

