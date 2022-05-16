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
using System.IO;
using System.Text;
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
	public class AffichageBalanceUI : System.Windows.Forms.Form
	{
        public System.Windows.Forms.Form parent;
 
		private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem Menu_Quitter;
		private System.Windows.Forms.MenuItem Menu_Affichage;
        private System.Windows.Forms.MenuItem Menu_Balance_General;
        private System.Windows.Forms.MenuItem Menu_Balance_Resume; 
        private MenuItem Menu_Export;
        private MenuItem Menu_Imprimer;
        private MenuItem Menu_Excel;

        private System.Windows.Forms.Label dfcompte;
		private System.Windows.Forms.Label sdebit;
		private System.Windows.Forms.Label scredit;
		private System.Windows.Forms.Label mcredit;
		private System.Windows.Forms.Label mdebit;
		private System.Windows.Forms.Label anouv;
        private System.Windows.Forms.Label warn;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label periode;

        private System.Windows.Forms.DataGrid dg;

		private System.Windows.Forms.SaveFileDialog Sfd;
        
        private Button Imprimer_Button;
        private Button Excel_Button;
        
        private IContainer components;

        private string Niveau;
        
        public string Font_Path;

        AffichageBalanceLogic Logic;
        BalanceVM view_model;

        string an;
        string dDate;
        
        public AffichageBalanceUI()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

        public AffichageBalanceUI(CAD db, string an1)
        {
            InitializeComponent();
            an = an1;
            dDate = "01/01/" + an;
            Logic = new AffichageBalanceLogic(db, dDate);
            

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AffichageBalanceUI));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.Menu_Affichage = new System.Windows.Forms.MenuItem();
            this.Menu_Balance_General = new System.Windows.Forms.MenuItem();
            this.Menu_Balance_Resume = new System.Windows.Forms.MenuItem();
            this.Menu_Export = new System.Windows.Forms.MenuItem();
            this.Menu_Imprimer = new System.Windows.Forms.MenuItem();
            this.Menu_Excel = new System.Windows.Forms.MenuItem();
            this.Menu_Quitter = new System.Windows.Forms.MenuItem();
            this.dg = new System.Windows.Forms.DataGrid();
            this.sdebit = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.scredit = new System.Windows.Forms.Label();
            this.periode = new System.Windows.Forms.Label();
            this.dfcompte = new System.Windows.Forms.Label();
            this.mcredit = new System.Windows.Forms.Label();
            this.mdebit = new System.Windows.Forms.Label();
            this.anouv = new System.Windows.Forms.Label();
            this.warn = new System.Windows.Forms.Label();
            this.Sfd = new System.Windows.Forms.SaveFileDialog();
            this.Imprimer_Button = new System.Windows.Forms.Button();
            this.Excel_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_Affichage,
            this.Menu_Export,
            this.Menu_Quitter});
            // 
            // Menu_Affichage
            // 
            this.Menu_Affichage.Index = 0;
            this.Menu_Affichage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_Balance_General,
            this.Menu_Balance_Resume});
            this.Menu_Affichage.Text = "Menu &Affichage";
            // 
            // Menu_Balance_General
            // 
            this.Menu_Balance_General.Index = 0;
            this.Menu_Balance_General.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
            this.Menu_Balance_General.Text = "Balance &Generale";
            this.Menu_Balance_General.Click += new System.EventHandler(this.Menu_Balance_General_Click);
            // 
            // Menu_Balance_Resume
            // 
            this.Menu_Balance_Resume.Index = 1;
            this.Menu_Balance_Resume.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
            this.Menu_Balance_Resume.Text = "Balance &Resumé";
            this.Menu_Balance_Resume.Click += new System.EventHandler(this.Menu_Balance_Resume_Click);
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
            // dg
            // 
            this.dg.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dg.CaptionVisible = false;
            this.dg.DataMember = "";
            this.dg.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dg.Location = new System.Drawing.Point(3, 147);
            this.dg.Name = "dg";
            this.dg.ParentRowsBackColor = System.Drawing.SystemColors.Desktop;
            this.dg.RowHeaderWidth = 0;
            this.dg.Size = new System.Drawing.Size(795, 255);
            this.dg.TabIndex = 9;
            // 
            // sdebit
            // 
            this.sdebit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sdebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sdebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sdebit.Location = new System.Drawing.Point(580, 405);
            this.sdebit.Name = "sdebit";
            this.sdebit.Size = new System.Drawing.Size(100, 18);
            this.sdebit.TabIndex = 14;
            this.sdebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(200, 405);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "Totaux  ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // scredit
            // 
            this.scredit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.scredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scredit.Location = new System.Drawing.Point(680, 405);
            this.scredit.Name = "scredit";
            this.scredit.Size = new System.Drawing.Size(100, 18);
            this.scredit.TabIndex = 15;
            this.scredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // periode
            // 
            this.periode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periode.Location = new System.Drawing.Point(102, 92);
            this.periode.Name = "periode";
            this.periode.Size = new System.Drawing.Size(651, 21);
            this.periode.TabIndex = 22;
            this.periode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dfcompte
            // 
            this.dfcompte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dfcompte.Location = new System.Drawing.Point(102, 56);
            this.dfcompte.Name = "dfcompte";
            this.dfcompte.Size = new System.Drawing.Size(651, 21);
            this.dfcompte.TabIndex = 23;
            this.dfcompte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mcredit
            // 
            this.mcredit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mcredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mcredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mcredit.Location = new System.Drawing.Point(480, 405);
            this.mcredit.Name = "mcredit";
            this.mcredit.Size = new System.Drawing.Size(100, 18);
            this.mcredit.TabIndex = 25;
            this.mcredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mdebit
            // 
            this.mdebit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mdebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mdebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdebit.Location = new System.Drawing.Point(380, 405);
            this.mdebit.Name = "mdebit";
            this.mdebit.Size = new System.Drawing.Size(100, 18);
            this.mdebit.TabIndex = 24;
            this.mdebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // anouv
            // 
            this.anouv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.anouv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.anouv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.anouv.Location = new System.Drawing.Point(280, 405);
            this.anouv.Name = "anouv";
            this.anouv.Size = new System.Drawing.Size(100, 18);
            this.anouv.TabIndex = 26;
            this.anouv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // warn
            // 
            this.warn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warn.ForeColor = System.Drawing.Color.Red;
            this.warn.Location = new System.Drawing.Point(278, 124);
            this.warn.Name = "warn";
            this.warn.Size = new System.Drawing.Size(248, 20);
            this.warn.TabIndex = 41;
            this.warn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Sfd
            // 
            this.Sfd.FileOk += new System.ComponentModel.CancelEventHandler(this.Sfd_FileOk);
            // 
            // Imprimer_Button
            // 
            this.Imprimer_Button.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Imprimer_Button.Location = new System.Drawing.Point(154, 447);
            this.Imprimer_Button.Name = "Imprimer_Button";
            this.Imprimer_Button.Size = new System.Drawing.Size(88, 25);
            this.Imprimer_Button.TabIndex = 42;
            this.Imprimer_Button.Text = "&Imprimer";
            this.Imprimer_Button.UseVisualStyleBackColor = true;
            this.Imprimer_Button.Click += new System.EventHandler(this.Imprimer_Button_Click);
            // 
            // Excel_Button
            // 
            this.Excel_Button.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Excel_Button.Location = new System.Drawing.Point(17, 447);
            this.Excel_Button.Name = "Excel_Button";
            this.Excel_Button.Size = new System.Drawing.Size(88, 25);
            this.Excel_Button.TabIndex = 43;
            this.Excel_Button.Text = "&Excel";
            this.Excel_Button.UseVisualStyleBackColor = true;
            this.Excel_Button.Click += new System.EventHandler(this.Excel_Button_Click);
            // 
            // AffichageBalanceUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(804, 506);
            this.Controls.Add(this.Excel_Button);
            this.Controls.Add(this.Imprimer_Button);
            this.Controls.Add(this.warn);
            this.Controls.Add(this.anouv);
            this.Controls.Add(this.mcredit);
            this.Controls.Add(this.mdebit);
            this.Controls.Add(this.dfcompte);
            this.Controls.Add(this.periode);
            this.Controls.Add(this.scredit);
            this.Controls.Add(this.sdebit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.Name = "AffichageBalanceUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Affichage Balance Generale";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.AffichageBalanceUI_Closing);
            this.Load += new System.EventHandler(this.AffichageBalanceUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion



        private void AffichageBalanceUI_Load(object sender, System.EventArgs e)
		{
            buildDataStyle(dg);
		}

        private void AffichageBalanceUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
				
			
		}
        
        private void Menu_Quitter_Click(object sender, System.EventArgs e)
		{
			this.Close();
		
		}

        private void Menu_Balance_General_Click(object sender, System.EventArgs e)
		{
            this.Text = "Balance Generale";
            Niveau = "1";
            periode.Text = "";
            dfcompte.Text = "";
            sdebit.Text = "";
            scredit.Text = "";
            mdebit.Text = "";
            mcredit.Text = "";
            anouv.Text = "";


            view_model = null;
            dg.DataSource = null;

            SelectionDateComptesVM select_DateComptes_VM = new SelectionDateComptesVM();
            SelectionDateComptesUI select = new SelectionDateComptesUI();
                        
            select.an = an;
            select.SelectionDateComptes_VM = select_DateComptes_VM;


            select.ShowDialog();
            
            warn.Text = "Veuillez patienter SVP";
            this.Refresh();


            if (select_DateComptes_VM.valid == true)
            {
                periode.Text = " Date Debut : " + dDate + "      " + " Date Fin :" + select_DateComptes_VM.date;
                dfcompte.Text = "Compte Debut : " + select_DateComptes_VM.compted + "      " + "Compte Fin :" + select_DateComptes_VM.comptef;
                string date_fin = select_DateComptes_VM.date;
                string compted = select_DateComptes_VM.compted;
                string comptef = select_DateComptes_VM.comptef;

                view_model = Logic.Balance_General(compted, comptef, date_fin);
                dg.DataSource = view_model.Lignes;


                anouv.Text = Fonctions.format04(view_model.total_anvouveau.ToString());
                mdebit.Text = Fonctions.format04(view_model.total_mvts_debit.ToString());
                mcredit.Text = Fonctions.format04(view_model.total_mvts_credit.ToString());
                sdebit.Text = Fonctions.format04(view_model.total_solde_debit.ToString());
                scredit.Text = Fonctions.format04(view_model.total_solde_credit.ToString());
            }

            warn.Text = "";
            
		}

        private void Menu_Balance_Resume_Click(object sender, System.EventArgs e)
		{
            this.Text = "Balance Resumé";
            Niveau = "2";
            periode.Text = "";
            dfcompte.Text = "";
            sdebit.Text = "";
            scredit.Text = "";
            mdebit.Text = "";
            mcredit.Text = "";
            anouv.Text = "";

            view_model = null;
            dg.DataSource = null;


            SelectionDateComptesVM SelectionDateComptes_VM = new SelectionDateComptesVM();
            SelectionDateComptesUI select = new SelectionDateComptesUI();
            
            select.an = an;
            select.SelectionDateComptes_VM = SelectionDateComptes_VM;

            select.ShowDialog();
            warn.Text = "Veuillez patienter SVP";
            this.Refresh();


            if (SelectionDateComptes_VM.valid == true)
            {
                periode.Text = " Date Debut : " + dDate + "      " + " Date Fin :" + SelectionDateComptes_VM.date;
                dfcompte.Text = "Compte Debut : " + SelectionDateComptes_VM.compted + "      " + "Compte Fin :" + SelectionDateComptes_VM.comptef;
                string date_fin = SelectionDateComptes_VM.date;
                string compted = SelectionDateComptes_VM.compted;
                string comptef = SelectionDateComptes_VM.comptef;

                view_model = Logic.Balance_Resume(compted, comptef, date_fin);
                dg.DataSource = view_model.Lignes;


                anouv.Text = Fonctions.format04(view_model.total_anvouveau.ToString());
                mdebit.Text = Fonctions.format04(view_model.total_mvts_debit.ToString());
                mcredit.Text = Fonctions.format04(view_model.total_mvts_credit.ToString());
                sdebit.Text = Fonctions.format04(view_model.total_solde_debit.ToString());
                scredit.Text = Fonctions.format04(view_model.total_solde_credit.ToString());
            }
            warn.Text = "";
    			
		}
		
		
		private void buildDataStyle ( DataGrid dg )
		{
			DataGridTableStyle style = new DataGridTableStyle();
            style.MappingName = "ArrayList";
			//style.AlternatingBackColor = System.Drawing.Color.Bisque;
			
			DataGridTextBoxColumn Compte = new DataGridTextBoxColumn();
			Compte.HeaderText = "Compte";
			Compte.MappingName = "Compte";
			Compte.Width = 60;
			DataGridTextBoxColumn Designation = new DataGridTextBoxColumn();
			Designation.HeaderText = "Libéllé";
			Designation.MappingName = "Designation";
			Designation.Width = 200;
			DataGridTextBoxColumn Anouv = new DataGridTextBoxColumn();
			Anouv.HeaderText = "A nouveau";
			Anouv.MappingName = "Anouv";
			Anouv.Width = 100;
			Anouv.Alignment = HorizontalAlignment.Right;
			DataGridTextBoxColumn Mvtdeb = new DataGridTextBoxColumn();
			Mvtdeb.HeaderText = "Mvt Debit";
			Mvtdeb.MappingName = "Mvtdeb";
			Mvtdeb.Width = 100;
			Mvtdeb.Alignment = HorizontalAlignment.Right;
			DataGridTextBoxColumn Mvtcred = new DataGridTextBoxColumn();
			Mvtcred.HeaderText = "Mvt Credit";
			Mvtcred.MappingName = "Mvtcred";
			Mvtcred.Width = 100;
			Mvtcred.Alignment = HorizontalAlignment.Right;
			
			DataGridTextBoxColumn Sldeb = new DataGridTextBoxColumn();
			Sldeb.HeaderText = "Solde Debit";
			Sldeb.MappingName = "Sldeb";
			Sldeb.Width = 100;
            Sldeb.Alignment = HorizontalAlignment.Right;
			DataGridTextBoxColumn Sldcred = new DataGridTextBoxColumn();
			Sldcred.HeaderText = "Solde Credit";
			Sldcred.MappingName = "Sldcred";
			Sldcred.Width = 100;
			Sldcred.Alignment = HorizontalAlignment.Right;
			style.GridColumnStyles.AddRange( new DataGridColumnStyle[] {Compte,Designation,Anouv,Mvtdeb,Mvtcred,Sldeb,Sldcred});
			dg.TableStyles.Add(style);

           	dg.ReadOnly = true;
		}

	    private void Imprimer_Button_Click(object sender, EventArgs e)
        {
            if (view_model != null) print();
        }  
        
        private void Menu_Imprimer_Click(object sender, EventArgs e)
        {
            if (view_model != null) print();
        }

        private void print()
        {
            Impression.Imprimeur_Balance printer = new Impression.Imprimeur_Balance();

            printer.Lignes = view_model.Lignes;
            printer.Niveau = Niveau;

            buildtableau(printer);
            buildcaptions(printer);

            printer.BuildDocument();

            printer.print_preview();
        }

        private void buildcaptions(Imprimeur_Balance printer)
        {
            FontFamily ffm = new FontFamily("Arial");
            Font fnt1 = new Font(ffm, 9);
            Font fnt2 = new Font(ffm, 10);
            Font fnt3 = new Font(ffm, 13, FontStyle.Bold);
            Font fnt4 = new Font(ffm, 11, FontStyle.Bold);

            printer.Captions = new List<Caption>();

            Caption caption1 = new Caption();
            caption1.Text = "Page : ";
            caption1.rec = new RectangleF(710, 15, 100, 20);
            caption1.fnt = fnt1;
            printer.Captions.Add(caption1);

            Caption caption2 = new Caption();
            DateTime dt = DateTime.Now;
            string date = "Date : " + dt.ToShortDateString();
            caption2.Text = date;
            caption2.rec = new RectangleF(590, 35, 300, 20);
            caption2.fnt = fnt2;
            printer.Captions.Add(caption2);

            Caption caption3 = new Caption();
            caption3.Text = this.Text;
            caption3.rec = new RectangleF(255, 35, 300, 20);
            caption3.fnt = fnt4;
            printer.Captions.Add(caption3);

            Caption caption4 = new Caption();
            caption4.Text = periode.Text;
            caption4.rec = new RectangleF(149, 65, 500, 20);
            caption4.fnt = fnt2;
            printer.Captions.Add(caption4);

            Caption caption5 = new Caption();
            caption5.Text = dfcompte.Text;
            caption5.rec = new RectangleF(147, 85, 500, 20);
            caption5.fnt = fnt2;
            printer.Captions.Add(caption5);

        }

        private void buildtableau(Impression.Imprimeur_Balance printer)
        {
            FontFamily ffm = new FontFamily("times");

            
            Font Ifnt = new Font(ffm, 8f);
            Font Cfnt = new Font(ffm, 9, FontStyle.Regular);
            Font Hfnt = new Font(ffm, 9,FontStyle.Bold);
            printer.tbl = new Tableau(Hfnt, 2);
            printer.tbl.Lignes = printer.Lignes;

            printer.tbl.Header_Font = Hfnt;
            printer.tbl.Header_alignment = Alignment.center;
            printer.tbl.Header_height = 2.2f;
            printer.tbl.Header_margin = 0.5f;
            printer.tbl.Cell_height = 1.5f;
            printer.tbl.LinesInPage = 40;
            printer.num_pages = printer.tbl.Lignes.Count / printer.tbl.LinesInPage;
            if (printer.tbl.Lignes.Count % printer.tbl.LinesInPage != 0) printer.num_pages++;
            printer.tbl.posX = 10;
            printer.tbl.posY = 130;

            Tableau.colonne tblc1 = new Tableau.colonne();
            tblc1.title = "N°Compte";
            tblc1.width = 5.4f;
            tblc1.Column_Font = Cfnt;
            tblc1.mapping = "Compte";
            tblc1.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc1);

            Tableau.colonne tblc2 = new Tableau.colonne();
            tblc2.title = "Intitulé";
            tblc2.width = 13F;
            tblc2.Column_Font = Ifnt;
            tblc2.mapping = "Designation";
            tblc2.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc2);

            Tableau.colonne tblc3 = new Tableau.colonne();
            tblc3.title = "A nouveau";
            tblc3.width = 7.5F;
            tblc3.Column_Font = Cfnt;
            tblc3.mapping = "Anouv";
            tblc3.Cell_alignAlignment = Alignment.right;
            printer.tbl.PutColInContainer(tblc3);

            Tableau.colonne tblc4 = new Tableau.colonne();
            tblc4.title = "Mvt Débit";
            tblc4.width = 7.9F;
            tblc4.Column_Font = Cfnt;
            tblc4.mapping = "Mvtdeb";
            tblc4.Cell_alignAlignment = Alignment.right;
            printer.tbl.PutColInContainer(tblc4);

            Tableau.colonne tblc5 = new Tableau.colonne();
            tblc5.title = "Mvt Crédit";
            tblc5.width = 7.9F;
            tblc5.Column_Font =Cfnt;
            tblc5.mapping = "Mvtcred";
            tblc5.Cell_alignAlignment = Alignment.right;
            printer.tbl.PutColInContainer(tblc5);

            Tableau.colonne tblc6 = new Tableau.colonne();
            tblc6.title = "Solde Débit";
            tblc6.width = 7.3F;
            tblc6.Column_Font = Cfnt;
            tblc6.mapping = "Sldeb";
            tblc6.Cell_alignAlignment = Alignment.right;
            printer.tbl.PutColInContainer(tblc6);

            Tableau.colonne tblc7 = new Tableau.colonne();
            tblc7.title = "Solde Crédit";
            tblc7.width = 7.3F;
            tblc7.Column_Font = Cfnt;
            tblc7.mapping = "Sldcred";
            tblc7.Cell_alignAlignment = Alignment.right;
            printer.tbl.PutColInContainer(tblc7);

        }

        private void Excel_Button_Click(object sender, EventArgs e)
        {
            if (view_model != null)
            {
                Sfd.FileName = "";
                Sfd.ShowDialog();
            }

        } 
        
        private void Menu_Excel_Click(object sender, EventArgs e)
        {
            if (view_model != null)
            {
                Sfd.FileName = "";
                Sfd.ShowDialog();
            }

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

            Phrase[] Header = new Phrase[3];
            Header[0] = new Phrase();
            Header[0].Words = new String[] { this.Text };
            Header[0].Spaces = new int[] { 10, 0, 10 };
            Header[0].length = 7;
            Header[0].build();
            Header[1] = new Phrase();
            Header[1].Words = new String[] { periode.Text };
            Header[1].Spaces = new int[] { 10, 0, 10 };
            Header[1].length = 7;
            Header[1].build();
            Header[2] = new Phrase();
            Header[2].Words = new String[] { dfcompte.Text };
            Header[2].Spaces = new int[] { 10, 0, 10 };
            Header[2].length = 7;
            Header[2].build();
            
            excel.filename = filename;
            excel.Header = Header;
            excel.TableHeader = new String[] { "Compte", "Libéllé", "A nouveau", "Mvt Débit", "Mvt Crédit", "Solde Débit", "Solde Crédit" };
            excel.TableFooter = new String[] { "", "Totaux :", Fonctions.format04(view_model.total_anvouveau.ToString()), Fonctions.format04(view_model.total_mvts_debit.ToString()), Fonctions.format04(view_model.total_mvts_credit.ToString()), Fonctions.format04(view_model.total_solde_debit.ToString()), Fonctions.format04(view_model.total_solde_credit.ToString()) };
            
            excel.RowHight = 15;
            excel.Lignes = view_model.Lignes;

            excel.TableColumnStyle = new Excel.ColumnStyle[7];
            excel.TableColumnStyle[0] = new Excel.ColumnStyle();
            excel.TableColumnStyle[0].Align = Alignment.left;
            excel.TableColumnStyle[0].ColumnWidth = 10;
            excel.TableColumnStyle[0].Format = "";
            excel.TableColumnStyle[1] = new Excel.ColumnStyle();
            excel.TableColumnStyle[1].Align = Alignment.left;
            excel.TableColumnStyle[1].ColumnWidth = 25;
            excel.TableColumnStyle[1].Format = "";
            excel.TableColumnStyle[2] = new Excel.ColumnStyle();
            excel.TableColumnStyle[2].Align = Alignment.right;
            excel.TableColumnStyle[2].ColumnWidth = 15;
            excel.TableColumnStyle[2].Format = "0,00";
            excel.TableColumnStyle[3] = new Excel.ColumnStyle();
            excel.TableColumnStyle[3].Align = Alignment.left;
            excel.TableColumnStyle[3].ColumnWidth = 15;
            excel.TableColumnStyle[3].Format = "0,00";
            excel.TableColumnStyle[4] = new Excel.ColumnStyle();
            excel.TableColumnStyle[4].Align = Alignment.left;
            excel.TableColumnStyle[4].ColumnWidth = 15;
            excel.TableColumnStyle[4].Format = "0,00";
            excel.TableColumnStyle[5] = new Excel.ColumnStyle();
            excel.TableColumnStyle[5].Align = Alignment.right;
            excel.TableColumnStyle[5].ColumnWidth = 15;
            excel.TableColumnStyle[5].Format = "0,00";
            excel.TableColumnStyle[6] = new Excel.ColumnStyle();
            excel.TableColumnStyle[6].Align = Alignment.right;
            excel.TableColumnStyle[6].ColumnWidth = 15;
            excel.TableColumnStyle[6].Format = "0,00";


            excel.set_sheet(this.Text, 1, false);
            excel.WriteDoc();
            excel.save();

            svp.Hide();
            svp.Close();

            MessageBox.Show("Le fichier excel : " + filename + " a eté crée \n");

        }	

     

       
		
	
		
	

		


		

		
    }

	
	
	

}

