using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
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
	public class AffichageGrandLivreUI : System.Windows.Forms.Form
	{
        public System.Windows.Forms.Form parent; 

		private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menu;
		private System.Windows.Forms.MenuItem Menu_Quitter;
        private System.Windows.Forms.MenuItem Menu_Compte;
		private System.Windows.Forms.MenuItem Menu_PlusieursComptes;

		private System.Windows.Forms.DataGrid dg;
		      
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label tdebit;
		private System.Windows.Forms.Label tcredit;
		private System.Windows.Forms.Label periode;
		private System.Windows.Forms.Label rdebit;
		private System.Windows.Forms.Label rcredit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label scredit;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label sdebit;
		private System.Windows.Forms.Label mvcredit;
		private System.Windows.Forms.Label mvdebit;
		private System.Windows.Forms.Label anouveau;
		private System.Windows.Forms.Label IntTxt;
		private System.Windows.Forms.Label SldTxt;  
        private System.Windows.Forms.Label warn;
		
	    private System.Windows.Forms.ComboBox CompteCombo;
        
        private System.Windows.Forms.SaveFileDialog Sfd;
        private System.Windows.Forms.Button Imprimer_Button;
		private System.Windows.Forms.Button Excel_Button;
	     
        public string Font_Path;
        private IContainer components;

        AffichageGrandLivreLogic Logic;
        GrandLivreVM view_model;
        
        string an;

        string date_debut;
        private MenuItem menuItem1;
        private MenuItem Menu_Imprimer;
        private MenuItem Menu_Excel;
        string date_fin;
     

		
        public AffichageGrandLivreUI()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}


        public AffichageGrandLivreUI(CAD db, string an1)
        {
            InitializeComponent();

            an = an1;

            date_debut = "01/01/" + an;
            date_fin = "31/12/" + an;

            Logic = new AffichageGrandLivreLogic(db, date_debut);
            


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AffichageGrandLivreUI));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menu = new System.Windows.Forms.MenuItem();
            this.Menu_Compte = new System.Windows.Forms.MenuItem();
            this.Menu_PlusieursComptes = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.Menu_Imprimer = new System.Windows.Forms.MenuItem();
            this.Menu_Excel = new System.Windows.Forms.MenuItem();
            this.Menu_Quitter = new System.Windows.Forms.MenuItem();
            this.Imprimer_Button = new System.Windows.Forms.Button();
            this.dg = new System.Windows.Forms.DataGrid();
            this.tdebit = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tcredit = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.periode = new System.Windows.Forms.Label();
            this.rdebit = new System.Windows.Forms.Label();
            this.rcredit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scredit = new System.Windows.Forms.Label();
            this.SldTxt = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.sdebit = new System.Windows.Forms.Label();
            this.mvcredit = new System.Windows.Forms.Label();
            this.mvdebit = new System.Windows.Forms.Label();
            this.anouveau = new System.Windows.Forms.Label();
            this.IntTxt = new System.Windows.Forms.Label();
            this.CompteCombo = new System.Windows.Forms.ComboBox();
            this.warn = new System.Windows.Forms.Label();
            this.Sfd = new System.Windows.Forms.SaveFileDialog();
            this.Excel_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menu,
            this.menuItem1,
            this.Menu_Quitter});
            // 
            // menu
            // 
            this.menu.Index = 0;
            this.menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_Compte,
            this.Menu_PlusieursComptes});
            this.menu.Text = "Menu &Affichage";
            // 
            // Menu_Compte
            // 
            this.Menu_Compte.Index = 0;
            this.Menu_Compte.Shortcut = System.Windows.Forms.Shortcut.CtrlU;
            this.Menu_Compte.Text = "Grand Livre : Compte &unique  ";
            this.Menu_Compte.Click += new System.EventHandler(this.Menu_Compte_Click);
            // 
            // Menu_PlusieursComptes
            // 
            this.Menu_PlusieursComptes.Index = 1;
            this.Menu_PlusieursComptes.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.Menu_PlusieursComptes.Text = "Grand Livre : &Plusieurs Comptes";
            this.Menu_PlusieursComptes.Click += new System.EventHandler(this.Menu_PlusieursComptes_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_Imprimer,
            this.Menu_Excel});
            this.menuItem1.Text = "Menu &Export";
            // 
            // Menu_Imprimer
            // 
            this.Menu_Imprimer.Index = 0;
            this.Menu_Imprimer.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
            this.Menu_Imprimer.Text = "&Imprimer";
            this.Menu_Imprimer.Click += new System.EventHandler(this.Menu_Imprimer_Click);
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
            this.Menu_Quitter.Shortcut = System.Windows.Forms.Shortcut.CtrlQ;
            this.Menu_Quitter.Text = "&Quitter";
            this.Menu_Quitter.Click += new System.EventHandler(this.Menu_Quitter_Click);
            // 
            // Imprimer_Button
            // 
            this.Imprimer_Button.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Imprimer_Button.Location = new System.Drawing.Point(207, 484);
            this.Imprimer_Button.Name = "Imprimer_Button";
            this.Imprimer_Button.Size = new System.Drawing.Size(88, 25);
            this.Imprimer_Button.TabIndex = 8;
            this.Imprimer_Button.Text = "&Imprimer";
            this.Imprimer_Button.UseVisualStyleBackColor = true;
            this.Imprimer_Button.Click += new System.EventHandler(this.Imprimer_Button_Click);
            // 
            // dg
            // 
            this.dg.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dg.CaptionVisible = false;
            this.dg.DataMember = "";
            this.dg.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dg.Location = new System.Drawing.Point(6, 158);
            this.dg.Name = "dg";
            this.dg.ParentRowsBackColor = System.Drawing.SystemColors.Desktop;
            this.dg.RowHeaderWidth = 0;
            this.dg.Size = new System.Drawing.Size(786, 252);
            this.dg.TabIndex = 9;
            // 
            // tdebit
            // 
            this.tdebit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tdebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tdebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tdebit.Location = new System.Drawing.Point(532, 416);
            this.tdebit.Name = "tdebit";
            this.tdebit.Size = new System.Drawing.Size(108, 19);
            this.tdebit.TabIndex = 14;
            this.tdebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(442, 414);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "Totaux ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tcredit
            // 
            this.tcredit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tcredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tcredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcredit.Location = new System.Drawing.Point(640, 416);
            this.tcredit.Name = "tcredit";
            this.tcredit.Size = new System.Drawing.Size(108, 19);
            this.tcredit.TabIndex = 15;
            this.tcredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(468, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 21);
            this.label8.TabIndex = 16;
            this.label8.Text = "Report ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // periode
            // 
            this.periode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periode.Location = new System.Drawing.Point(50, 42);
            this.periode.Name = "periode";
            this.periode.Size = new System.Drawing.Size(651, 21);
            this.periode.TabIndex = 22;
            this.periode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdebit
            // 
            this.rdebit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rdebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rdebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdebit.Location = new System.Drawing.Point(528, 134);
            this.rdebit.Name = "rdebit";
            this.rdebit.Size = new System.Drawing.Size(108, 19);
            this.rdebit.TabIndex = 17;
            this.rdebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rcredit
            // 
            this.rcredit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rcredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rcredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rcredit.Location = new System.Drawing.Point(636, 134);
            this.rcredit.Name = "rcredit";
            this.rcredit.Size = new System.Drawing.Size(108, 19);
            this.rcredit.TabIndex = 23;
            this.rcredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Compte ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(174, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Intitulé ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // scredit
            // 
            this.scredit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.scredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scredit.Location = new System.Drawing.Point(640, 436);
            this.scredit.Name = "scredit";
            this.scredit.Size = new System.Drawing.Size(108, 19);
            this.scredit.TabIndex = 30;
            this.scredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SldTxt
            // 
            this.SldTxt.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.SldTxt.Location = new System.Drawing.Point(396, 436);
            this.SldTxt.Name = "SldTxt";
            this.SldTxt.Size = new System.Drawing.Size(116, 21);
            this.SldTxt.TabIndex = 28;
            this.SldTxt.Text = "Solde ";
            this.SldTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(4, 416);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 24);
            this.label7.TabIndex = 31;
            this.label7.Text = "A nouveau";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(112, 416);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 24);
            this.label9.TabIndex = 32;
            this.label9.Text = "Mvts débit";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(220, 416);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 24);
            this.label10.TabIndex = 33;
            this.label10.Text = "Mvts crédit";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sdebit
            // 
            this.sdebit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sdebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sdebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sdebit.Location = new System.Drawing.Point(532, 436);
            this.sdebit.Name = "sdebit";
            this.sdebit.Size = new System.Drawing.Size(108, 19);
            this.sdebit.TabIndex = 29;
            this.sdebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mvcredit
            // 
            this.mvcredit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mvcredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mvcredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mvcredit.Location = new System.Drawing.Point(220, 440);
            this.mvcredit.Name = "mvcredit";
            this.mvcredit.Size = new System.Drawing.Size(108, 19);
            this.mvcredit.TabIndex = 34;
            this.mvcredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mvdebit
            // 
            this.mvdebit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mvdebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mvdebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mvdebit.Location = new System.Drawing.Point(112, 440);
            this.mvdebit.Name = "mvdebit";
            this.mvdebit.Size = new System.Drawing.Size(108, 19);
            this.mvdebit.TabIndex = 35;
            this.mvdebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // anouveau
            // 
            this.anouveau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.anouveau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.anouveau.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.anouveau.Location = new System.Drawing.Point(4, 440);
            this.anouveau.Name = "anouveau";
            this.anouveau.Size = new System.Drawing.Size(108, 19);
            this.anouveau.TabIndex = 36;
            this.anouveau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IntTxt
            // 
            this.IntTxt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.IntTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IntTxt.Location = new System.Drawing.Point(246, 96);
            this.IntTxt.Name = "IntTxt";
            this.IntTxt.Size = new System.Drawing.Size(254, 20);
            this.IntTxt.TabIndex = 38;
            this.IntTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CompteCombo
            // 
            this.CompteCombo.Location = new System.Drawing.Point(74, 97);
            this.CompteCombo.Name = "CompteCombo";
            this.CompteCombo.Size = new System.Drawing.Size(94, 21);
            this.CompteCombo.TabIndex = 39;
            this.CompteCombo.SelectedIndexChanged += new System.EventHandler(this.CmptBox_SelectedIndexChanged);
            // 
            // warn
            // 
            this.warn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warn.ForeColor = System.Drawing.Color.Red;
            this.warn.Location = new System.Drawing.Point(174, 132);
            this.warn.Name = "warn";
            this.warn.Size = new System.Drawing.Size(248, 20);
            this.warn.TabIndex = 40;
            this.warn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Sfd
            // 
            this.Sfd.FileName = "doc1";
            this.Sfd.FileOk += new System.ComponentModel.CancelEventHandler(this.Sfd_FileOk);
            // 
            // Excel_Button
            // 
            this.Excel_Button.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Excel_Button.Location = new System.Drawing.Point(63, 484);
            this.Excel_Button.Name = "Excel_Button";
            this.Excel_Button.Size = new System.Drawing.Size(88, 25);
            this.Excel_Button.TabIndex = 45;
            this.Excel_Button.Text = "&Excel";
            this.Excel_Button.UseVisualStyleBackColor = true;
            this.Excel_Button.Click += new System.EventHandler(this.Excel_Button_Click);
            // 
            // AffichageGrandLivreUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(796, 521);
            this.Controls.Add(this.Excel_Button);
            this.Controls.Add(this.warn);
            this.Controls.Add(this.CompteCombo);
            this.Controls.Add(this.IntTxt);
            this.Controls.Add(this.anouveau);
            this.Controls.Add(this.mvdebit);
            this.Controls.Add(this.mvcredit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.scredit);
            this.Controls.Add(this.sdebit);
            this.Controls.Add(this.SldTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rcredit);
            this.Controls.Add(this.periode);
            this.Controls.Add(this.rdebit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tcredit);
            this.Controls.Add(this.tdebit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.Imprimer_Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.Name = "AffichageGrandLivreUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Affichage Grand Livre";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.AffichageGrandLivreUI_Closing);
            this.Load += new System.EventHandler(this.AffichageGrandLivreUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		//[STAThread]
		//static void Main() 
		//{
		//	Application.Run(new ficheclient());
		//}

        private void AffichageGrandLivreUI_Load(object sender, System.EventArgs e)
		{
            buildDataStyle(dg);
            
		}



        private void AffichageGrandLivreUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
						
		}

        private void Menu_Quitter_Click(object sender, System.EventArgs e)
		{
			this.Close();
        }
		
        private void Menu_Compte_Click(object sender, System.EventArgs e)
		{
            CompteCombo.Items.Clear();
            CompteCombo.Text = "";
            periode.Text = "";
            IntTxt.Text = "";
            rdebit.Text = "";
            rcredit.Text = "";
            tdebit.Text = "";
            tcredit.Text = "";
            sdebit.Text = "";
            scredit.Text = "";
            mvcredit.Text = "";
            mvdebit.Text = "";
            anouveau.Text = "";
            SldTxt.Text = "Solde :"; 
            
            dg.DataSource = null;
            view_model = null;
            
                        
            SelectionCompteUI select = new SelectionCompteUI();
            SelectionCompteVM SelectionCompte_VM = new SelectionCompteVM();

            select.GrandLivreLogic = Logic;
            select.an = an;
            select.SelectionCompte_VM = SelectionCompte_VM;
            
            select.ShowDialog();

            warn.Text = "Veuillez patienter SVP";
            this.Refresh();

            if (SelectionCompte_VM.valid == true)
            {
                periode.Text = "Periode du: " + SelectionCompte_VM.date1 + " Au " + SelectionCompte_VM.date2;
                date_debut = SelectionCompte_VM.date1;
                date_fin = SelectionCompte_VM.date2;
                string compte = SelectionCompte_VM.cmpt;

                CompteCombo.Items.Add(compte);
                CompteCombo.SelectedIndex = 0;
        

            }
            

            warn.Text = "";
		}
	
		private void CmptBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (CompteCombo.Items.Count > 0)
            {
                dg.DataSource = null;
                view_model = Logic.get_grand_livre(CompteCombo.SelectedItem.ToString(), date_debut, date_fin);
                if ((view_model.Lignes.Count != 0) || (view_model.anouveau != 0) || (view_model.report_debit != 0) || (view_model.report_credit != 0))
                {
                    ShowGrandLivre();
                    
                }
                else
                {
                    rdebit.Text = "";
                    rcredit.Text = "";
                    tdebit.Text = "";
                    tcredit.Text = "";
                    sdebit.Text = "";
                    scredit.Text = "";
                    mvcredit.Text = "";
                    mvdebit.Text = "";
                    anouveau.Text = "";
                    SldTxt.Text = "Solde :"; 
                }
                
                this.Refresh();
            }
        }

        void ShowGrandLivre()
        {
            
            dg.DataSource = view_model.Lignes;

            IntTxt.Text = view_model.intitule;

            rdebit.Text = Fonctions.format04(view_model.report_debit.ToString());
            rcredit.Text = Fonctions.format04(view_model.report_credit.ToString());
            tdebit.Text = Fonctions.format04(view_model.total_debit.ToString());
            tcredit.Text = Fonctions.format04(view_model.total_credit.ToString());
            sdebit.Text = Fonctions.format04(view_model.solde_debit.ToString());
            scredit.Text = Fonctions.format04(view_model.solde_credit.ToString());
            SldTxt.Text = view_model.solde;

            anouveau.Text = Fonctions.format04(view_model.anouveau.ToString());
            mvdebit.Text = Fonctions.format04(view_model.mvts_debit.ToString());
            mvcredit.Text = Fonctions.format04(view_model.mvts_credit.ToString());
            tcredit.Text = Fonctions.format04(view_model.total_credit.ToString());
                       
            
        }



        private void Menu_PlusieursComptes_Click(object sender, System.EventArgs e)
		{
            CompteCombo.Items.Clear();
            CompteCombo.Text = "";
            periode.Text = "";
            IntTxt.Text = "";
            rdebit.Text = "";
            rcredit.Text = "";
            tdebit.Text = "";
            tcredit.Text = "";
            sdebit.Text = "";
            scredit.Text = "";
            mvcredit.Text = "";
            mvdebit.Text = "";
            anouveau.Text = "";

            dg.DataSource = null;
            view_model = null;


            SelectionComptesVM SelectionComptes_VM = new SelectionComptesVM();
            SelectionComptesUI select = new SelectionComptesUI();
            select.SelectionComptes_VM = SelectionComptes_VM;
            select.GrandLivreLogic = Logic;
            select.an = an;
            
            select.ShowDialog();
            warn.Text = "Veuillez patienter SVP";
            this.Refresh();


            if (SelectionComptes_VM.valid == true)
            {
                periode.Text = "Periode du: " + SelectionComptes_VM.date1 + " Au " + SelectionComptes_VM.date2;
                date_debut = SelectionComptes_VM.date1;
                date_fin = SelectionComptes_VM.date2;
                string[] comptes = SelectionComptes_VM.cmpts;

                for (int i = 0; i < comptes.Length; i++)
                {
                    CompteCombo.Items.Add(comptes[i]);
                }

                CompteCombo.SelectedIndex = 0;
           }
            

            warn.Text = "";
            this.Refresh();
		
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
			DataGridTextBoxColumn JL = new DataGridTextBoxColumn();
			JL.HeaderText = "JL";
            JL.MappingName = "Code_Journal";
			JL.Width = 40;
			DataGridTextBoxColumn Cpart = new DataGridTextBoxColumn();
			Cpart.HeaderText = "Cpart";
            Cpart.MappingName = "Contre_Partie";
			Cpart.Width = 65;
			DataGridTextBoxColumn Piece = new DataGridTextBoxColumn();
			Piece.HeaderText = "Piece";
			Piece.MappingName = "Piece";
			Piece.Width = 80;
            DataGridTextBoxColumn Libelle = new DataGridTextBoxColumn();
            Libelle.HeaderText = "Libéllé";
            Libelle.MappingName = "Libelle";
            Libelle.Width = 240;
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
            style.GridColumnStyles.AddRange(new DataGridColumnStyle[] { Date, JL, Cpart, Piece, Libelle, Debit, Credit });
			dg.TableStyles.Add(style);
			dg.ReadOnly = true;
		}

    
        private void Menu_Imprimer_Click(object sender, EventArgs e)
        {
            print();

        }


        private void Imprimer_Button_Click(object sender, System.EventArgs e)
		{
            print();
        }

        private void print()
        {  
            bool b = false;
            if (date_debut == "01/01/"+an) b = true;
           
            for (int i = 0; i < CompteCombo.Items.Count; i++)
            {
                Impression.Imprimeur_GrandLivre printer = new Impression.Imprimeur_GrandLivre();
                view_model = Logic.get_grand_livre(CompteCombo.Items[i].ToString(), date_debut, date_fin);
                if ((view_model.Lignes.Count != 0) || (view_model.anouveau != 0) || (view_model.report_debit != 0) || (view_model.report_credit != 0))
                {
                    printer.Lignes = view_model.Lignes;
                    if (printer.Lignes.Count > 0)
                    {
                        buildcaptions(printer);
                        buildtableau(printer);
                        printer.Set(view_model.anouveau, view_model.report_debit, view_model.report_credit, b);
                        printer.BuildDocument();
                        printer.print_preview();
                        //printer.print();
                    }
                }
            }
            
                  
            

        }

        private void buildcaptions(Impression.Imprimeur_GrandLivre printer)
        {
            FontFamily ffm = new FontFamily("Arial");
            Font fnt1 = new Font(ffm, 9);
            Font fnt2 = new Font(ffm, 10);
            Font fnt3 = new Font(ffm, 13, FontStyle.Bold);
            Font fnt4 = new Font(ffm, 11, FontStyle.Bold);

            printer.Captions = new List<Caption>();

            Caption caption1 = new Caption();
            caption1.Text = "Page : ";
            caption1.rec = new RectangleF(740, 10, 100, 20);
            caption1.fnt = fnt1;
            printer.Captions.Add(caption1);

            Caption caption2 = new Caption();
            DateTime dt = DateTime.Now;
            string date = "Date : " + dt.ToShortDateString();
            caption2.Text = date;
            caption2.rec = new RectangleF(590, 35, 300, 20);
            caption2.fnt = fnt2;
            printer.Captions.Add(caption2);

            Caption caption31 = new Caption();
            caption31.Text = "Grand Livre";
            caption31.rec = new RectangleF(247, 20, 300, 20);
            caption31.fnt = fnt3;
            printer.Captions.Add(caption31);

            Caption caption4 = new Caption();
            caption4.Text = periode.Text.ToString();
            caption4.rec = new RectangleF(247, 60, 300, 20);
            caption4.fnt = fnt4;
            printer.Captions.Add(caption4);

            Caption caption5 = new Caption();
            caption5.Text = "Compte : " + view_model.compte;
            caption5.rec = new RectangleF(10, 110, 200, 20);
            caption5.fnt = fnt2;
            printer.Captions.Add(caption5);

            Caption caption6 = new Caption();
            caption6.Text = "Intitulé : " + view_model.intitule;
            caption6.rec = new RectangleF(210, 110, 300, 20);
            caption6.fnt = fnt2;
            printer.Captions.Add(caption6);




        }

        private void buildtableau(Impression.Imprimeur_GrandLivre printer)
        {
            FontFamily ffm = new FontFamily("Arial");
            Font fnt09 = new Font(ffm, 9);
            Font Bfnt09 = new Font(ffm, 9, FontStyle.Bold);
            printer.tbl = new Tableau(Bfnt09,2);

            printer.tbl.Header_Font = Bfnt09;
            printer.tbl.Header_alignment = Alignment.center;
            printer.tbl.Header_height = 2.2f;
            printer.tbl.Header_margin = 0.5f;
            printer.tbl.Cell_height = 1.4f;
            printer.tbl.LinesInPage = 40;

            printer.tbl.Lignes = printer.Lignes;
            printer.num_pages = printer.Lignes.Count / printer.tbl.LinesInPage;
            if (printer.Lignes.Count % printer.tbl.LinesInPage != 0) printer.num_pages++;
            printer.tbl.posX = 10;
            printer.tbl.posY = 130;

            Tableau.colonne tblc0 = new Tableau.colonne();
            tblc0.title = "Date"; 
            tblc0.width = 6;
            tblc0.Column_Font = fnt09;
            tblc0.mapping = "Date";
            tblc0.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc0);

            Tableau.colonne tblc1 = new Tableau.colonne();
            tblc1.title = "JL";
            tblc1.width = 4F;
            tblc1.Column_Font = fnt09;
            tblc1.mapping = "Code_Journal";
            tblc1.Zeropadding = 4;
            tblc1.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc1);

            Tableau.colonne tblc2 = new Tableau.colonne();
            tblc2.title = "C/partie";
            tblc2.width = 6;
            tblc2.Column_Font = fnt09;
            tblc2.mapping = "Contre_Partie";
            tblc2.Zeropadding = 8;
            tblc2.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc2);

            Tableau.colonne tblc3 = new Tableau.colonne();
            tblc3.title = "Pièce";
            tblc3.width = 7;
            tblc3.Column_Font = fnt09;
            tblc3.mapping = "Piece";
            tblc3.Zeropadding = 10;
            tblc3.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc3);

            Tableau.colonne tblc4 = new Tableau.colonne();
            tblc4.title = "Libéllé";
            tblc4.width = 20;
            tblc4.Column_Font = fnt09;
            tblc4.mapping = "Libelle";
            tblc4.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc4);

            Tableau.colonne tblc5 = new Tableau.colonne();
            tblc5.title = "Débit";
            tblc5.width = 7;
            tblc5.Column_Font = fnt09;
            tblc5.mapping = "Debit";
            tblc5.Cell_alignAlignment = Alignment.right;
            printer.tbl.PutColInContainer(tblc5);

            Tableau.colonne tblc6 = new Tableau.colonne();
            tblc6.title = "Crédit";
            tblc6.width = 7;
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

	    private void Excel_Button_Click(object sender, System.EventArgs e)
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
            if (b == false)
            {
                MessageBox.Show("Excel n'est proprement installé !!");
                return;
            }

            excel.filename = filename;


            for (int i = 0; i < CompteCombo.Items.Count; i++)
            {
                view_model = Logic.get_grand_livre(CompteCombo.Items[i].ToString(), date_debut, date_fin);
                if ((view_model.Lignes.Count != 0) || (view_model.anouveau != 0) || (view_model.report_debit != 0) || (view_model.report_credit != 0))
                {
                    excel.Lignes = view_model.Lignes;
                    GrandLivre2Excel(ref excel, i + 1, true);
                }
            }


            excel.save();
            svp.Hide();
            svp.Close();
            MessageBox.Show("Le fichier excel : " + filename + " a eté crée \n");

        }

        private void GrandLivre2Excel(ref ExcelBuilder excel, int sheet_item, bool add)
        {
            Phrase[] Header = new Phrase[2];
            Header[0] = new Phrase();
            Header[0].Words = new String[] { "Grand Livre : " + periode.Text };
            Header[0].Spaces = new int[] { 10, 0, 10 };
            Header[0].length = 7;
            Header[0].build();
            Header[1] = new Phrase();
            Header[1].Words = new String[] { "Compte " + view_model.compte + " : " + view_model.intitule };
            Header[1].Spaces = new int[] { 10, 0, 10 };
            Header[1].length = 7;
            Header[1].build();

            excel.Header = Header;
            excel.TableHeader = new String[] { "Date", "JL", "C/partie", "Pièce", "Libéllé", "Débit", "Crédit" };
            excel.Reports = new String[] { "", "", "", "", "Reports", Fonctions.format04(view_model.report_debit.ToString()), Fonctions.format04(view_model.report_credit.ToString()) };
            excel.TableFooter = new String[] { "A nouveau", "Mvts dédit", "Mvts crédit", "", "Totaux", Fonctions.format04(view_model.total_debit.ToString()), Fonctions.format04(view_model.total_credit.ToString()) };
            excel.TableFooter_bis = new String[] { Fonctions.format04(view_model.anouveau.ToString()), Fonctions.format04(view_model.mvts_debit.ToString()), Fonctions.format04(view_model.mvts_credit.ToString()), "", "Solde", Fonctions.format04(view_model.solde_debit.ToString()), Fonctions.format04(view_model.solde_credit.ToString()) };
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

            string Compte_Int = "Compte " + view_model.compte;


            excel.set_sheet(Compte_Int, sheet_item,add);

            excel.WriteDoc();



        }



       

    

      









	

	

		
		

		
		

		

		}

	
	
	}

