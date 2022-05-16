using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using Utilitaire;
using CoucheAcceeDonnees;
using Compta.Commun;
using ComptabiliteGenerale;
using SaisieCompta;


namespace SaisieCompta
{
	/// <summary>
	/// Description résumée de SaisieOp.
	/// </summary>
	public class SaisieEcrituresUI : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
	    private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
        private Label warn;

        private System.Windows.Forms.TextBox AnneeTxt;
        private System.Windows.Forms.TextBox CodeJournalTxt;
		private System.Windows.Forms.TextBox IntituleTxt;
        private System.Windows.Forms.TextBox STxt;
		private System.Windows.Forms.TextBox LibelTxt;
        private System.Windows.Forms.TextBox OrderTxt;
		private System.Windows.Forms.TextBox CpartTxt;
		private System.Windows.Forms.TextBox CmptTxt;
		private System.Windows.Forms.TextBox MoisTxt;
		private System.Windows.Forms.TextBox MntTxt;
        private System.Windows.Forms.TextBox JourMoisTxt;
        private System.Windows.Forms.TextBox MDiffTxt;
		private System.Windows.Forms.TextBox MCredTxt;
		private System.Windows.Forms.TextBox MDebTxt;
		private System.Windows.Forms.TextBox CMvtDTxt;	
        private System.Windows.Forms.TextBox CMvtCTxt;
        private System.Windows.Forms.TextBox CDiffTxt;
        private System.Windows.Forms.TextBox LibelTxt2;
        private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.Button ClearButton;
		private System.Windows.Forms.Button PlanButton;
		private System.Windows.Forms.Button CmptButton;
        private System.Windows.Forms.Button MvtButton;
        private System.Windows.Forms.Button SlaButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox cpabutton; 
        
        private DataGridView dg;
		   
		public System.Windows.Forms.Form parent;
		
        private IContainer components;
        
  

        CAD db;
        SaisieEcrituresLogic Logic;
        SaisieEcrituresVM view_model;

        
        int liblength;
        string mlibel;
        string mlibel2;

        string Contre_Partie;
        string an;
        public string dDate;
        public string fDate;
        string djour;
        string fjour;
        int idDt;
        int ifDt;

        string Mois;
       
        private ErrorProvider ep;
        //private TextBox LibelTxt;
        bool form_ok = true;

        
		
	    public SaisieEcrituresUI()
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
				if(components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaisieEcrituresUI));
            this.PlanButton = new System.Windows.Forms.Button();
            this.CmptButton = new System.Windows.Forms.Button();
            this.MvtButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CodeJournalTxt = new System.Windows.Forms.TextBox();
            this.IntituleTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MoisTxt = new System.Windows.Forms.TextBox();
            this.MntTxt = new System.Windows.Forms.TextBox();
            this.STxt = new System.Windows.Forms.TextBox();
            this.LibelTxt = new System.Windows.Forms.TextBox();
            this.LibelTxt2 = new System.Windows.Forms.TextBox();
            this.OrderTxt = new System.Windows.Forms.TextBox();
            this.CpartTxt = new System.Windows.Forms.TextBox();
            this.CmptTxt = new System.Windows.Forms.TextBox();
            this.JourMoisTxt = new System.Windows.Forms.TextBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.MDiffTxt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.MCredTxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.MDebTxt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SlaButton = new System.Windows.Forms.Button();
            this.CMvtDTxt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CMvtCTxt = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.CDiffTxt = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.AnneeTxt = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cpabutton = new System.Windows.Forms.CheckBox();
            this.dg = new System.Windows.Forms.DataGridView();
            this.warn = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // PlanButton
            // 
            this.PlanButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.PlanButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LavenderBlush;
            this.PlanButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush;
            this.PlanButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.PlanButton.Location = new System.Drawing.Point(168, 12);
            this.PlanButton.Name = "PlanButton";
            this.PlanButton.Size = new System.Drawing.Size(225, 23);
            this.PlanButton.TabIndex = 93;
            this.PlanButton.Text = "Afficher &Comptes Schématique";
            this.PlanButton.UseCompatibleTextRendering = true;
            this.PlanButton.UseVisualStyleBackColor = true;
            this.PlanButton.Click += new System.EventHandler(this.PlanButton_Click);
            // 
            // CmptButton
            // 
            this.CmptButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.CmptButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LavenderBlush;
            this.CmptButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush;
            this.CmptButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.CmptButton.Location = new System.Drawing.Point(419, 12);
            this.CmptButton.Name = "CmptButton";
            this.CmptButton.Size = new System.Drawing.Size(113, 23);
            this.CmptButton.TabIndex = 94;
            this.CmptButton.Text = "Creer &Compte";
            this.CmptButton.UseCompatibleTextRendering = true;
            this.CmptButton.UseVisualStyleBackColor = true;
            this.CmptButton.Click += new System.EventHandler(this.CmptButton_Click);
            // 
            // MvtButton
            // 
            this.MvtButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.MvtButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LavenderBlush;
            this.MvtButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush;
            this.MvtButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.MvtButton.Location = new System.Drawing.Point(2, 12);
            this.MvtButton.Name = "MvtButton";
            this.MvtButton.Size = new System.Drawing.Size(160, 23);
            this.MvtButton.TabIndex = 95;
            this.MvtButton.Text = "Afficher &Mouvements";
            this.MvtButton.UseCompatibleTextRendering = true;
            this.MvtButton.UseVisualStyleBackColor = true;
            this.MvtButton.Click += new System.EventHandler(this.MvtButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Code Journal :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CodeJournalTxt
            // 
            this.CodeJournalTxt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.CodeJournalTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CodeJournalTxt.Location = new System.Drawing.Point(144, 65);
            this.CodeJournalTxt.MaxLength = 4;
            this.CodeJournalTxt.Name = "CodeJournalTxt";
            this.CodeJournalTxt.Size = new System.Drawing.Size(36, 20);
            this.CodeJournalTxt.TabIndex = 1;
            this.CodeJournalTxt.TextChanged += new System.EventHandler(this.CodeJournalTxt_TextChanged);
            this.CodeJournalTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CdeTxt_KeyDown);
            this.CodeJournalTxt.Validating += new System.ComponentModel.CancelEventHandler(this.CdeTxt_Validating);
            // 
            // IntituleTxt
            // 
            this.IntituleTxt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.IntituleTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IntituleTxt.Location = new System.Drawing.Point(306, 65);
            this.IntituleTxt.MaxLength = 30;
            this.IntituleTxt.Name = "IntituleTxt";
            this.IntituleTxt.ReadOnly = true;
            this.IntituleTxt.Size = new System.Drawing.Size(248, 20);
            this.IntituleTxt.TabIndex = 1;
            this.IntituleTxt.TabStop = false;
            this.IntituleTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(232, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 23);
            this.label2.TabIndex = 25;
            this.label2.Text = "Intitulé   :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(70, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "Mois :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MoisTxt
            // 
            this.MoisTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MoisTxt.Location = new System.Drawing.Point(144, 119);
            this.MoisTxt.MaxLength = 2;
            this.MoisTxt.Name = "MoisTxt";
            this.MoisTxt.Size = new System.Drawing.Size(33, 20);
            this.MoisTxt.TabIndex = 3;
            this.MoisTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MtTxt_KeyDown);
            this.MoisTxt.Validating += new System.ComponentModel.CancelEventHandler(this.MtTxt_Validating);
            // 
            // MntTxt
            // 
            this.MntTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MntTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MntTxt.Location = new System.Drawing.Point(605, 390);
            this.MntTxt.MaxLength = 15;
            this.MntTxt.Name = "MntTxt";
            this.MntTxt.Size = new System.Drawing.Size(173, 20);
            this.MntTxt.TabIndex = 90;
            this.MntTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MntTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MntTxt_KeyDown);
            this.MntTxt.Validating += new System.ComponentModel.CancelEventHandler(this.MntTxt_Validating);
            // 
            // STxt
            // 
            this.STxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.STxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STxt.Location = new System.Drawing.Point(541, 390);
            this.STxt.MaxLength = 1;
            this.STxt.Name = "STxt";
            this.STxt.Size = new System.Drawing.Size(64, 20);
            this.STxt.TabIndex = 89;
            this.STxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.STxt_KeyDown);
            this.STxt.Validating += new System.ComponentModel.CancelEventHandler(this.STxt_Validating);
            // 
            // LibelTxt
            // 
            this.LibelTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LibelTxt.Location = new System.Drawing.Point(257, 390);
            this.LibelTxt.MaxLength = 40;
            this.LibelTxt.Name = "LibelTxt";
            this.LibelTxt.Size = new System.Drawing.Size(144, 20);
            this.LibelTxt.TabIndex = 88;
            this.LibelTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LibelTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LibelTxt_KeyDown);
            this.LibelTxt.Validating += new System.ComponentModel.CancelEventHandler(this.LibelTxt_Validating);
            // 
            // LibelTxt2
            // 
            this.LibelTxt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LibelTxt2.Location = new System.Drawing.Point(399, 390);
            this.LibelTxt2.MaxLength = 40;
            this.LibelTxt2.Name = "LibelTxt2";
            this.LibelTxt2.Size = new System.Drawing.Size(144, 20);
            this.LibelTxt2.TabIndex = 156;
            this.LibelTxt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OrderTxt
            // 
            this.OrderTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OrderTxt.Location = new System.Drawing.Point(191, 390);
            this.OrderTxt.MaxLength = 4;
            this.OrderTxt.Name = "OrderTxt";
            this.OrderTxt.Size = new System.Drawing.Size(66, 20);
            this.OrderTxt.TabIndex = 86;
            this.OrderTxt.TextChanged += new System.EventHandler(this.OrderTxt_TextChanged);
            this.OrderTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PieceTxt_KeyDown);
            this.OrderTxt.Validating += new System.ComponentModel.CancelEventHandler(this.PieceTxt_Validating);
            // 
            // CpartTxt
            // 
            this.CpartTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CpartTxt.Location = new System.Drawing.Point(125, 390);
            this.CpartTxt.MaxLength = 8;
            this.CpartTxt.Name = "CpartTxt";
            this.CpartTxt.Size = new System.Drawing.Size(66, 20);
            this.CpartTxt.TabIndex = 85;
            this.CpartTxt.TextChanged += new System.EventHandler(this.CpartTxt_TextChanged);
            this.CpartTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CpartTxt_KeyDown);
            this.CpartTxt.Validating += new System.ComponentModel.CancelEventHandler(this.CpartTxt_Validating);
            // 
            // CmptTxt
            // 
            this.CmptTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CmptTxt.Location = new System.Drawing.Point(59, 390);
            this.CmptTxt.MaxLength = 8;
            this.CmptTxt.Name = "CmptTxt";
            this.CmptTxt.Size = new System.Drawing.Size(66, 20);
            this.CmptTxt.TabIndex = 84;
            this.CmptTxt.TextChanged += new System.EventHandler(this.CmptTxt_TextChanged);
            this.CmptTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmptTxt_KeyDown);
            this.CmptTxt.Validating += new System.ComponentModel.CancelEventHandler(this.cmptTxt_Validating);
            // 
            // JourMoisTxt
            // 
            this.JourMoisTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.JourMoisTxt.Location = new System.Drawing.Point(2, 390);
            this.JourMoisTxt.MaxLength = 5;
            this.JourMoisTxt.Name = "JourMoisTxt";
            this.JourMoisTxt.Size = new System.Drawing.Size(57, 20);
            this.JourMoisTxt.TabIndex = 83;
            this.JourMoisTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateTxt_KeyDown);
            this.JourMoisTxt.Validating += new System.ComponentModel.CancelEventHandler(this.DateTxt_Validating);
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.ExitButton.Location = new System.Drawing.Point(691, 510);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(96, 25);
            this.ExitButton.TabIndex = 100;
            this.ExitButton.Text = "&Quitter";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClearButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LavenderBlush;
            this.ClearButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush;
            this.ClearButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.ClearButton.Location = new System.Drawing.Point(34, 430);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(96, 23);
            this.ClearButton.TabIndex = 99;
            this.ClearButton.Text = "E&ffacer";
            this.ClearButton.UseCompatibleTextRendering = true;
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // MDiffTxt
            // 
            this.MDiffTxt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.MDiffTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MDiffTxt.Location = new System.Drawing.Point(463, 454);
            this.MDiffTxt.Name = "MDiffTxt";
            this.MDiffTxt.ReadOnly = true;
            this.MDiffTxt.Size = new System.Drawing.Size(144, 20);
            this.MDiffTxt.TabIndex = 136;
            this.MDiffTxt.TabStop = false;
            this.MDiffTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(463, 430);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 24);
            this.label12.TabIndex = 137;
            this.label12.Text = "Difference";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MCredTxt
            // 
            this.MCredTxt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.MCredTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MCredTxt.Location = new System.Drawing.Point(319, 454);
            this.MCredTxt.Name = "MCredTxt";
            this.MCredTxt.ReadOnly = true;
            this.MCredTxt.Size = new System.Drawing.Size(144, 20);
            this.MCredTxt.TabIndex = 138;
            this.MCredTxt.TabStop = false;
            this.MCredTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(319, 430);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 24);
            this.label13.TabIndex = 139;
            this.label13.Text = "Mvts Credits du Mois";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MDebTxt
            // 
            this.MDebTxt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.MDebTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MDebTxt.Location = new System.Drawing.Point(175, 454);
            this.MDebTxt.Name = "MDebTxt";
            this.MDebTxt.ReadOnly = true;
            this.MDebTxt.Size = new System.Drawing.Size(144, 20);
            this.MDebTxt.TabIndex = 140;
            this.MDebTxt.TabStop = false;
            this.MDebTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(175, 430);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(144, 24);
            this.label14.TabIndex = 141;
            this.label14.Text = "Mvts Debits Du Mois";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SlaButton
            // 
            this.SlaButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.SlaButton.Location = new System.Drawing.Point(556, 12);
            this.SlaButton.Name = "SlaButton";
            this.SlaButton.Size = new System.Drawing.Size(192, 23);
            this.SlaButton.TabIndex = 142;
            this.SlaButton.Text = "Creer L&ibelle Automatique";
            this.SlaButton.UseCompatibleTextRendering = true;
            this.SlaButton.UseVisualStyleBackColor = true;
            this.SlaButton.Click += new System.EventHandler(this.SlaButton_Click);
            // 
            // CMvtDTxt
            // 
            this.CMvtDTxt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.CMvtDTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CMvtDTxt.Location = new System.Drawing.Point(175, 499);
            this.CMvtDTxt.Name = "CMvtDTxt";
            this.CMvtDTxt.ReadOnly = true;
            this.CMvtDTxt.Size = new System.Drawing.Size(144, 20);
            this.CMvtDTxt.TabIndex = 146;
            this.CMvtDTxt.TabStop = false;
            this.CMvtDTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(175, 475);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(144, 24);
            this.label15.TabIndex = 147;
            this.label15.Text = "Cumule Mvts Debits ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CMvtCTxt
            // 
            this.CMvtCTxt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.CMvtCTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CMvtCTxt.Location = new System.Drawing.Point(319, 499);
            this.CMvtCTxt.Name = "CMvtCTxt";
            this.CMvtCTxt.ReadOnly = true;
            this.CMvtCTxt.Size = new System.Drawing.Size(144, 20);
            this.CMvtCTxt.TabIndex = 144;
            this.CMvtCTxt.TabStop = false;
            this.CMvtCTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(319, 475);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(144, 24);
            this.label16.TabIndex = 145;
            this.label16.Text = "Cumule Mvts Credit ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CDiffTxt
            // 
            this.CDiffTxt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.CDiffTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CDiffTxt.Location = new System.Drawing.Point(463, 499);
            this.CDiffTxt.Name = "CDiffTxt";
            this.CDiffTxt.ReadOnly = true;
            this.CDiffTxt.Size = new System.Drawing.Size(144, 20);
            this.CDiffTxt.TabIndex = 148;
            this.CDiffTxt.TabStop = false;
            this.CDiffTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(463, 475);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(144, 24);
            this.label17.TabIndex = 149;
            this.label17.Text = "Difference";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AnneeTxt
            // 
            this.AnneeTxt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AnneeTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnneeTxt.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.AnneeTxt.Location = new System.Drawing.Point(739, 65);
            this.AnneeTxt.Margin = new System.Windows.Forms.Padding(4, 4, 3, 3);
            this.AnneeTxt.MaxLength = 4;
            this.AnneeTxt.Name = "AnneeTxt";
            this.AnneeTxt.ReadOnly = true;
            this.AnneeTxt.Size = new System.Drawing.Size(48, 20);
            this.AnneeTxt.TabIndex = 2;
            this.AnneeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AnneeTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AnTxt_KeyDown);
            this.AnneeTxt.Validating += new System.ComponentModel.CancelEventHandler(this.AnTxt_Validating);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(659, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 23);
            this.label18.TabIndex = 151;
            this.label18.Text = "Exercice :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cpabutton
            // 
            this.cpabutton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cpabutton.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpabutton.Location = new System.Drawing.Point(567, 119);
            this.cpabutton.Name = "cpabutton";
            this.cpabutton.Size = new System.Drawing.Size(220, 20);
            this.cpabutton.TabIndex = 152;
            this.cpabutton.Text = "Activer contre partie automatique";
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.AllowUserToResizeRows = false;
            this.dg.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Location = new System.Drawing.Point(-5, 187);
            this.dg.Name = "dg";
            this.dg.RowHeadersWidth = 8;
            this.dg.Size = new System.Drawing.Size(802, 197);
            this.dg.TabIndex = 153;
            this.dg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellContentClick);
            this.dg.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dg_CellFormatting);
            // 
            // warn
            // 
            this.warn.AutoSize = true;
            this.warn.ForeColor = System.Drawing.Color.Red;
            this.warn.Location = new System.Drawing.Point(273, 161);
            this.warn.Name = "warn";
            this.warn.Size = new System.Drawing.Size(0, 13);
            this.warn.TabIndex = 154;
            // 
            // SaveButton
            // 
            this.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LavenderBlush;
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush;
            this.SaveButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(662, 441);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(128, 25);
            this.SaveButton.TabIndex = 155;
            this.SaveButton.Text = "Enregistrer (F10)";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // SaisieEcrituresUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(802, 554);
            this.Controls.Add(this.LibelTxt2);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.warn);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.cpabutton);
            this.Controls.Add(this.AnneeTxt);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.CDiffTxt);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.CMvtDTxt);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.CMvtCTxt);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.SlaButton);
            this.Controls.Add(this.MDebTxt);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.MCredTxt);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.MDiffTxt);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.MntTxt);
            this.Controls.Add(this.STxt);
            this.Controls.Add(this.LibelTxt);
            this.Controls.Add(this.OrderTxt);
            this.Controls.Add(this.CpartTxt);
            this.Controls.Add(this.CmptTxt);
            this.Controls.Add(this.JourMoisTxt);
            this.Controls.Add(this.MoisTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IntituleTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CodeJournalTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MvtButton);
            this.Controls.Add(this.CmptButton);
            this.Controls.Add(this.PlanButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SaisieEcrituresUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saisie des Ecritures";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SaisieOpUI_Closing);
            this.Load += new System.EventHandler(this.SaisieOpUI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SaisieOpUI_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public SaisieEcrituresUI(CAD db1)
        {
            InitializeComponent();

            db = db1;
            Logic = new SaisieEcrituresLogic(db);
            view_model = new SaisieEcrituresVM();
            dg.DataSource = view_model.Lignes;
            buildDataStyle(dg);

       }

        public SaisieEcrituresUI(CAD db1, string an1)
        {
            InitializeComponent();
            an = an1;
            dDate = "01/01/"+ an;
            fDate = "31/12/"+ an;
            db = db1;

            Logic = new SaisieEcrituresLogic(db);
            view_model = new SaisieEcrituresVM();
            dg.DataSource = view_model.Lignes;
            buildDataStyle(dg);
       

        }

        private void Lim_Dates()
        {
            idDt = Fonctions.DateToInt(dDate);
            ifDt = Fonctions.DateToInt(fDate);
            string[] sddt = dDate.Split(new char[] { '/' });
            string[] sfdt = fDate.Split(new char[] { '/' });
            djour = sddt[0];
            fjour = sfdt[0];
            

        }


        private void SaisieOpUI_Load(object sender, System.EventArgs e)
		{
            Mois = "";
            AnneeTxt.Text = an;
            Lim_Dates();
            CodeJournalTxt.Focus();
		
		}


        private void SaisieOpUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		
		}

        private void buildDataStyle(DataGridView dg)
        {
            
            dg.Columns[0].Width = 57;
            dg.Columns[0].HeaderText = "jj/mm";
            
            dg.Columns[1].Width = 66;
            
            dg.Columns[2].Width = 66;
            
            dg.Columns[3].Width = 66;
          
            
            dg.Columns[4].Width = 144;
            dg.Columns[5].Width = 144;
            dg.Columns[6].Width = 64;
            dg.Columns[7].Width = 168;
            dg.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg.ReadOnly = true;
        }
	
	
		#region curseur+validation

        private void SaisieOpUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F10) Enregistrer(); 

        }

        private void CdeTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) MoisTxt.Focus();
            
        }
	    private void AnTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            
		}
		private void MtTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter) 
	    	{
		    	JourMoisTxt.Focus();
		    	JourMoisTxt.SelectAll();
	    	}
		}
		private void DateTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
    		if (e.KeyData == Keys.Enter) 
	    	{
		    	CmptTxt.Focus();
	    		CmptTxt.SelectAll();
	    	}
		}
		private void cmptTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter) 
	    	{
	    		CpartTxt.Focus();
	    		CpartTxt.SelectAll();
    		}
		}
        private void CpartTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyData == Keys.Enter) 
	    	{
                LibelTxt2.Focus();
                if (mlibel2 != "") LibelTxt2.Select(liblength, LibelTxt2.Text.Length - liblength);
                else LibelTxt2.Select(LibelTxt2.Text.Length, 0);
                OrderTxt.Focus();
	    		OrderTxt.SelectAll();
	    	}
		}
		private void PieceTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyData == Keys.Enter) 
	    	{
                //LaTxt.Focus();
                LibelTxt.Focus();
                //LaTxt.SelectAll();
                LibelTxt.SelectAll();
            }
			if (e.KeyData == Keys.Up)
			{
				
				if ((Validator.valide_N(OrderTxt.Text) == true )&&(OrderTxt.Text != "")) 
				{
					OrderTxt.Text = (Int32.Parse(OrderTxt.Text)+1).ToString();

				}
			}

		}
		/*private void LaTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter) 
			{
				LibelTxt.Focus();
                if (mlibel != "") LibelTxt.Select(liblength, LibelTxt.Text.Length - liblength);
                else LibelTxt.Select(LibelTxt.Text.Length, 0);

            }
	    	
		}*/
		private void LibelTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
    		if (e.KeyData == Keys.Enter) 
	    	{
		    	STxt.Focus();
		    	STxt.SelectAll();
		    }
		}
        private void LibelTxt2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                STxt.Focus();
                STxt.SelectAll();
            }
        }
        private void STxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter) 
			{
				MntTxt.Focus();
                MntTxt.SelectAll();
			}
		}
		private void MntTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyData == Keys.Enter)
            {
                JourMoisTxt.Focus();
                JourMoisTxt.SelectAll();
            }
			
	    }

  
        private void CdeTxt_Validating(object sender, CancelEventArgs e)
        {
            bool b = valide_CdeTxt(true);
            if (b == true)
            {
                Logic.Afficher_Cumuls(ref view_model, CodeJournalTxt.Text);
                RefreshPied();
                IntituleTxt.Text = view_model.journal_intitule;
                Contre_Partie = view_model.contre_partie;
                AnneeTxt.Text = an;
                cpabutton.Checked = view_model.cpa;

            }

        }
		
 		private void AnTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            
			
		}
		private void MtTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (IntituleTxt.Text == "") return;
            bool b = valide_MoisTxt(true);
            if ((b == true) && (Mois != MoisTxt.Text))
            {
                Logic.Afficher_Mouvements_Mois(ref view_model, CodeJournalTxt.Text, MoisTxt.Text, AnneeTxt.Text);
                if (view_model.Lignes.Count > 0)
                {
                    dg.DataSource = null;
                    dg.DataSource = view_model.Lignes;
                    buildDataStyle(dg);
                    dg.FirstDisplayedScrollingRowIndex = dg.Rows.Count - 1;
                }
                Mois = MoisTxt.Text;
                RefreshPied();


            }
            
           
		}
	    private void DateTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            valide_DateTxt(true);
			
		}
		private void cmptTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            valide_CmptTxt(true);
		}
		private void CpartTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            valide_CpartTxt(true);
			
		}
		private void PieceTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            valide_OrderTxt(true);
		}
		
		/*private void LaTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            valide_LaTxt(true);
	     }*/
	    private void LibelTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            valide_LibelTxt(true);
		}
	
      	private void STxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            valide_STxt(true);
		}
		
		private void MntTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            valide_MntTxt(true);
	    }
		
       
		#endregion
 
        private void dg_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dg.Columns[e.ColumnIndex].Name == "DC")
            {
                string stringValue = (string)e.Value;
                if ( stringValue == "D") 
                    e.CellStyle.ForeColor = Color.Red;
                if (stringValue == "C")
                    e.CellStyle.ForeColor = Color.Blue;
                

            }
            if (this.dg.Columns[e.ColumnIndex].Name == "Montant")
            {
                LigneEcriture ligne = ((List<LigneEcriture>)dg.DataSource)[e.RowIndex];
                if (ligne.DC.ToString() == "D")
                    e.CellStyle.ForeColor = Color.Red;
                if (ligne.DC.ToString() == "C")
                    e.CellStyle.ForeColor = Color.Blue;


            }

    

        }
               
        private void MvtButton_Click(object sender, System.EventArgs e)
		{
            warn.Text = "";
            MoisTxt.Text = "";
            Afficher_Mouvements();
			
		}
		private void PlanButton_Click(object sender, System.EventArgs e)
		{
            warn.Text = "";
            Afficher_Plan();
			
		}

		private void CmptButton_Click(object sender, System.EventArgs e)
		{
            warn.Text = "";
            Creer_Compte();
		
		}

		private void SlaButton_Click(object sender, System.EventArgs e)
		{
            warn.Text = "";
            Creer_LA();
		
		}

		/*private void LaButton_Click(object sender, System.EventArgs e)
		{
            warn.Text = "";
            Afficher_LA();
		
		} */
        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Enregistrer();
            
        }

        

        private void ClearButton_Click(object sender, System.EventArgs e)
		{
            Effacer();
	    }

		private void ExitButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        public void RefreshPied()
        {
            MDebTxt.Text = Fonctions.format1(view_model.mouvements_debit.ToString());
            MCredTxt.Text = Fonctions.format1(view_model.mouvements_credit.ToString());
            double diff = view_model.mouvements_credit - view_model.mouvements_debit;
            MDiffTxt.Text = Fonctions.format1(diff.ToString());
            if (view_model.mouvements_debit > view_model.mouvements_credit) MDiffTxt.ForeColor = Color.Red;
            else if (view_model.mouvements_debit < view_model.mouvements_credit) MDiffTxt.ForeColor = Color.Blue;
            else MDiffTxt.ForeColor = Color.Black;

            CMvtDTxt.Text = Fonctions.format1(view_model.cumul_debit.ToString());
            CMvtCTxt.Text = Fonctions.format1(view_model.cumul_credit.ToString());
            diff = view_model.cumul_credit - view_model.cumul_debit;
            CDiffTxt.Text = Fonctions.format1(diff.ToString());
            if (view_model.cumul_debit > view_model.cumul_credit) CDiffTxt.ForeColor = Color.Red;
            else if (view_model.cumul_debit < view_model.cumul_credit) CDiffTxt.ForeColor = Color.Blue;
            else CDiffTxt.ForeColor = Color.Black;



        }
       

        void Enregistrer()
        {
            form_ok = true;
            valide_form();
            if (form_ok == true)
            {
                EcritureModel ecriture = new EcritureModel();
                CompteModel compte1 = new CompteModel();
                CompteModel compte2 = new CompteModel();
                compte1.Niveau = "1";
                compte2.Niveau = "1";

                ecriture.Annee = AnneeTxt.Text;
                Console.WriteLine(JourMoisTxt.Text + "/" + AnneeTxt.Text);

                ecriture.iDate = Fonctions.DateToInt(JourMoisTxt.Text + "/" + AnneeTxt.Text).ToString();

                ecriture.CodeJournal = CodeJournalTxt.Text;
                ecriture.JourMois = JourMoisTxt.Text;
                ecriture.N_Ordre = OrderTxt.Text;

                ecriture.Compte = CmptTxt.Text;
                compte1.Compte = ecriture.Compte;
                compte1.CompteResultat = ecriture.Compte;


                ecriture.ContrePartie = CpartTxt.Text;
                compte2.Compte = ecriture.ContrePartie;
                compte2.CompteResultat = ecriture.ContrePartie;
                //ecriture.CodeLibelleAutomatique = LaTxt.Text;
                //ecriture.CodeLibelleAutomatique = CmptTxt.Text;
                ecriture.Libelle = LibelTxt.Text;
                compte1.Intitule = ecriture.Libelle;
                ecriture.Libelle2 = LibelTxt2.Text;
                compte2.Intitule = ecriture.Libelle2;
                
                ecriture.Montant = MntTxt.Text.Replace('.', ',');

                if (STxt.Text == "D")
                {
                    ecriture.Debit = true;
                    compte1.AnouveauDebit = ecriture.Montant;
                    compte1.AnouveauCredit = "00.00";
                    compte2.AnouveauCredit = ecriture.Montant;
                    compte2.AnouveauDebit = "00.00";
                }
                if (STxt.Text == "C") { 
                    ecriture.Debit = false;
                    compte1.AnouveauCredit = ecriture.Montant;
                    compte1.AnouveauDebit = "00.00";
                    compte2.AnouveauDebit = ecriture.Montant;
                    compte2.AnouveauCredit= "00.00";

                } 

                

                bool arg = false;
                if (cpabutton.Checked == true) arg = true;
                int mess = Logic.Enregister(ref view_model,ecriture, arg);
                
                if (mess == 0)
                {
                    //warn.Text = "Operation enregistrée avec succée";
                    dg.DataSource = null;
                    dg.DataSource = view_model.Lignes;
                    buildDataStyle(dg);
                    dg.FirstDisplayedScrollingRowIndex = dg.Rows.Count - 1;
                    RefreshPied();

                }
                if (mess == 1) warn.Text = "Echec de l'enregistrement Saisie";
                if (mess == 2) warn.Text = "Echec de l'enregistrement Saisie1";

                Console.WriteLine("Modifier Compte Apel !!!");
                 ModifierCompte(compte1,compte2);
                Console.WriteLine("Modifier Compte Apres Apel !!!");
                JourMoisTxt.Focus();
                JourMoisTxt.SelectAll();
                
               

            }


        }
        private void ModifierCompte(CompteModel compte1, CompteModel compte2)
        {
            try
            {
                Console.WriteLine("Modifier Compte Implementation !!!");
                if (compte1 == null && compte2 == null) Console.WriteLine("Les comptes Recus Sont Vides !!!"); ;
                Console.WriteLine("Avant c1");
                CoucheAcceeDonnees.Comptes c1 = new CoucheAcceeDonnees.Comptes(db);
                Console.WriteLine("Apres c1");
                Console.WriteLine("Avant c2");
                CoucheAcceeDonnees.Comptes c2 = new CoucheAcceeDonnees.Comptes(db);
                Console.WriteLine("Apres c1");
                Console.WriteLine(compte1.Compte);
                Console.WriteLine(compte2.Compte);
                Console.WriteLine(compte1.Intitule);
                Console.WriteLine(compte2.Intitule);
                Console.WriteLine(compte1.Niveau);
                Console.WriteLine(compte2.Niveau);
                Console.WriteLine(compte1.CompteResultat);
                Console.WriteLine(compte2.CompteResultat);
                Console.WriteLine(compte1.AnouveauDebit);
                Console.WriteLine(compte2.AnouveauDebit);
                Console.WriteLine(compte1.AnouveauCredit);
                Console.WriteLine(compte2.AnouveauCredit);
                Console.WriteLine("Avant c1.modifier !!!!");
                Console.WriteLine(c1.Modifier(compte1));
                Console.WriteLine(c2.Modifier(compte2));
                Console.WriteLine("Apres c2.modifier !!!!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Caaaatch2222");
                Console.WriteLine(ex);
            }
        }

        void Afficher_Mouvements()
        {
            if (IntituleTxt.Text != "")
            {
                SelectionDatesVM SelectionDates_VM = new SelectionDatesVM();
                SelectionDatesUI select = new SelectionDatesUI();
                select.SelectionDates_VM = SelectionDates_VM;
                select.an = an;
                select.ShowDialog();
                if (SelectionDates_VM.valid == true)
                {

                    string iDate1 = SelectionDates_VM.idate1;
                    string iDate2 = SelectionDates_VM.idate2;
                    Logic.Afficher_Mouvements(ref view_model,CodeJournalTxt.Text, iDate1, iDate2);
                    if (view_model.Lignes.Count > 0)
                    {
                        dg.DataSource = null;
                        dg.DataSource = view_model.Lignes;
                        buildDataStyle(dg);
                        dg.FirstDisplayedScrollingRowIndex = dg.Rows.Count - 1;
                        RefreshPied();
                        this.Refresh();
                    }

                }
            }


        }

        void Afficher_Plan()
        {
            EditionCompta.ListingPlanComptableUI view = new EditionCompta.ListingPlanComptableUI(db);
            view.ShowDialog();
        }

        void Creer_Compte()
        {
            SaisieCompta.SaisiePlanUI view = new SaisieCompta.SaisiePlanUI(db);
            view.ShowDialog();

        }

        void Afficher_LA()
        {
            EditionCompta.ListingLibellesAutUI view = new EditionCompta.ListingLibellesAutUI(db);
            view.ShowDialog();
        }

        void Creer_LA()
        {
            SaisieCompta.SaisieLibellesAutomatiqueUI view = new SaisieCompta.SaisieLibellesAutomatiqueUI(db);
            view.ShowDialog();

        }

        void Effacer()
        {
            //dg.DataSource = null;
            //view_model.Lignes.Clear();
            //dg.DataSource = view_model.Lignes;
            //buildDataStyle(dg);

            CodeJournalTxt.Text = "";
            CodeJournalTxt.ForeColor = Color.Black;
            ep.SetError( CodeJournalTxt, "");
            IntituleTxt.Text = "";

            MoisTxt.Text = "";
            MoisTxt.ForeColor = Color.Black;
            ep.SetError(MoisTxt , "");

            JourMoisTxt.Text = "";
            JourMoisTxt.ForeColor = Color.Black;
            ep.SetError( JourMoisTxt, "");

            CmptTxt.Text = "";
            CmptTxt.ForeColor = Color.Black;
            ep.SetError( CmptTxt, "");

            CpartTxt.Text = "";
            CpartTxt.ForeColor = Color.Black;
            ep.SetError(CpartTxt , "");

            OrderTxt.Text = "";
            OrderTxt.ForeColor = Color.Black;
            ep.SetError( OrderTxt , "");

            /*LaTxt.Text = "";
            LaTxt.ForeColor = Color.Black;
            ep.SetError( LaTxt  , "");*/

            LibelTxt.Text = "";
            LibelTxt.ForeColor = Color.Black;
            ep.SetError( LibelTxt, "");

            LibelTxt2.Text = "";
            LibelTxt2.ForeColor = Color.Black;
            ep.SetError(LibelTxt2, "");

            STxt.Text = "";
            STxt.ForeColor = Color.Black;
            ep.SetError(STxt, "");

            MntTxt.Text = "";
            MntTxt.ForeColor = Color.Black;
            ep.SetError(MntTxt, "");

            MDebTxt.Text = "";
            MCredTxt.Text = "";
            MDiffTxt.Text = "";

            CMvtDTxt.Text = "";
            CMvtCTxt.Text = "";
            CDiffTxt.Text = "";

            warn.Text = "";

            Mois = "";

            CodeJournalTxt.Focus();



        }


        void valide_form()
        {

            form_ok = valide_CdeTxt(form_ok);
            form_ok = valide_MoisTxt(form_ok);
            form_ok = valide_DateTxt(form_ok);
            form_ok = valide_CmptTxt(form_ok);
            form_ok = valide_CpartTxt(form_ok);
            form_ok = valide_OrderTxt(form_ok);
            //form_ok = valide_LaTxt(form_ok);
            form_ok = valide_LibelTxt(form_ok);
            form_ok = valide_LibelTxt2(form_ok);
            form_ok = valide_STxt(form_ok);
            form_ok = valide_MntTxt(form_ok);

        }

        bool valide_CdeTxt(bool b)
        {
            if (Validator.valide_N(CodeJournalTxt.Text) == false)
            {
                b = false;
                IntituleTxt.Text = "";
                CodeJournalTxt.ForeColor = Color.Red;
                warn.Text = "Format code journal invalide";
                ep.SetError(CodeJournalTxt, "Format code journal invalide");
            }
            else
            {
                if (CodeJournalTxt.Text == "9000")
                {
                    b = false;
                    IntituleTxt.Text = "";
                    CodeJournalTxt.ForeColor = Color.Red;
                    warn.Text = "Ce Code est reservé au journal A nouveau";
                    ep.SetError(CodeJournalTxt, "Ce Code est reservé au journal A nouveau");
                }
                else
                {
                    int ret = Logic.get_journal(ref view_model,CodeJournalTxt.Text);
                    if (ret == 0)
                    {
                        CodeJournalTxt.ForeColor = Color.Black;
                        warn.Text = "";
                        ep.SetError(CodeJournalTxt, "");

                    }
                    else
                    {
                        b = false;
                        IntituleTxt.Text = "";
                        CodeJournalTxt.ForeColor = Color.Red;
                        warn.Text = "Code Journal Inexistant";
                        ep.SetError(CodeJournalTxt, "Code Journal Inexistant");

                    }
                }

            }

            return b;
        }

        
        bool valide_MoisTxt(bool b)
        {
            
            if (Validator.valide_N(MoisTxt.Text) == false)
            {
                b = false;
                MoisTxt.ForeColor = Color.Red;
                warn.Text = "Format numerique invalide";
                ep.SetError(MoisTxt, "Format numerique invalide");
            }
            else
            {
                int mois = Int32.Parse(MoisTxt.Text);
                if ((0 < mois) && (mois < 13))
                {
                    string ddat = djour + "/" + MoisTxt.Text + "/" + AnneeTxt.Text;
                    string fdat = fjour + "/" + MoisTxt.Text + "/" + AnneeTxt.Text;
                    if ((Fonctions.DateToInt(ddat) < idDt) || (Fonctions.DateToInt(fdat) > ifDt))
                    {
                        b = false;
                        MoisTxt.ForeColor = Color.Red;
                        warn.Text = "Date non incluse dans l'exercice courant";
                        ep.SetError(MoisTxt, "Date non incluse dans l'exercice courant");

                    }
                    else
                    {

                        MoisTxt.ForeColor = Color.Black;
                        warn.Text = "";
                        ep.SetError(MoisTxt, "");

                    }
                }

            }
            return b;
        }

        bool valide_DateTxt(bool b)
        {
            if (valide_MoisTxt(true) == false) return false;
            if (Validator.valide_DT_OP(JourMoisTxt.Text) == false)
            {
                b = false;
                JourMoisTxt.ForeColor = Color.Red;
                warn.Text = "Format Date invalide ( JJ/MM )";
                ep.SetError(JourMoisTxt,"Format Date invalide ( JJ/MM )");
            }
            else
            {
                char[] sep = { '/' };
                string[] subs = JourMoisTxt.Text.Split(sep);
                if ((Int32.Parse(subs[1]) != Int32.Parse(MoisTxt.Text)))
                {
                    b = false;
                    JourMoisTxt.ForeColor = Color.Red;
                    warn.Text = "La date ne correspond pas au mois entré";
                    ep.SetError(JourMoisTxt, "La date ne correspond pas au mois entré");
                }
                else
                {
                    string dat = subs[0] + "/" + MoisTxt.Text + "/" + AnneeTxt.Text;
                    if ((Fonctions.DateToInt(dat) < idDt) || (Fonctions.DateToInt(dat) > ifDt))
                    {
                        b = false;
                        JourMoisTxt.ForeColor = Color.Red;
                        warn.Text = "Date non incluse dans l'exercice courant";
                        ep.SetError(JourMoisTxt, "Date non incluse dans l'exercice courant");
                    }
                    else
                    {
                        if (Validator.valide_DT(dat, AnneeTxt.Text) == 4)
                        {
                            b = false;
                            JourMoisTxt.ForeColor = Color.Red;
                            ep.SetError(JourMoisTxt, "Jour hors mois");
                            warn.Text = "Jour hors mois";

                        }
                        else
                        {
                            JourMoisTxt.ForeColor = Color.Black;
                            ep.SetError(JourMoisTxt, "");
                            warn.Text = "";
                        }
                    }


                }
            }


            return b;
        }

        bool valide_CmptTxt(bool b)
        {

            if (Validator.valide_N(CmptTxt.Text) == false)
            {
                b = false;
                CmptTxt.ForeColor = Color.Red;
                warn.Text = "Le Format du compte est invalide";
                ep.SetError(CmptTxt, "Le Format du compte est invalide");
            }
            else
            {
                int ret = Logic.get_libelle_intitule(ref view_model, CmptTxt.Text);
                if (ret == 0)
                {
                    
                    CmptTxt.ForeColor = Color.Black;
                    warn.Text = view_model.libelle_intitule;
                    LibelTxt.Text = view_model.libelle_intitule + " ";
                    liblength = LibelTxt.Text.Length;
                    //LibelTxt.Text += mlibel;
                    ep.SetError(CmptTxt, "");

                }            
                else
                {
                    CmptTxt.ForeColor = Color.Red;
                    warn.Text = "Compte Inexistant";
                    ep.SetError(CmptTxt, "Compte Inexistant");

                }
                /*int ret = Logic.get_compte_intitule(ref view_model,CmptTxt.Text);
               if (ret == 0)
               {
                   CmptTxt.ForeColor = Color.Black;
                   warn.Text = view_model.compte_intitule;

                   //LibelTxt.Text = view_model.libelle_intitule + " ";
                   //liblength = LibelTxt2.Text.Length;
                   //LibelTxt2.Text += mlibel2;
                  // CpartTxt.Text = Contre_Partie;
                   ep.SetError(CmptTxt, "");

               }*/


            }

            return b;
        }

        bool valide_CpartTxt(bool b)
        {
            if (Validator.valide_N(CpartTxt.Text) == false)
            {
                b = false;
                CpartTxt.ForeColor = Color.Red;
                ep.SetError(CpartTxt, "Le Format du compte est invalide");
                warn.Text = "Le Format du compte est invalide";
                Contre_Partie = CpartTxt.Text;
            }
            else
            {
                int ret = Logic.get_libelle_intitule(ref view_model,CpartTxt.Text);
                if (ret == 0)
                {
                    CpartTxt.ForeColor = Color.Black;
                    //warn.Text = view_model.compte_intitule;
                    // LibelTxt2.Text = view_model.compte_intitule + " ";
                    warn.Text = view_model.libelle_intitule;
                    LibelTxt2.Text = view_model.libelle_intitule + " ";
                    liblength = LibelTxt2.Text.Length;
                    //LibelTxt2.Text += mlibel;
                    ep.SetError(CpartTxt, "");

                }
                else
                {
                    CpartTxt.ForeColor = Color.Red;
                    warn.Text = "Compte Inexistant";
                    ep.SetError(CpartTxt, "Compte Inexistant");

                }

            }
            return b;

        }

        bool valide_OrderTxt(bool b)
        {
            if (Validator.valide_N(OrderTxt.Text) != true)
            {
                b = false;
                warn.Text  = "Format Numero Ordre invalide";
                OrderTxt.ForeColor = Color.Red;
                ep.SetError(OrderTxt, "Format Numero Ordre invalide");
               
            }
            else
            {
                warn.Text  = "";
                OrderTxt.ForeColor = Color.Black;
                ep.SetError(OrderTxt, "");
               
            }
            return b;
        }

        /*bool valide_LaTxt(bool b)
        {
            if (Validator.valide_N(LaTxt.Text) == false)
            {
                b = false;
                LaTxt.ForeColor = Color.Red;
                ep.SetError(LaTxt, "Le Format du code libellé est invalide");
                warn.Text = "Le Format du code libellé est invalide";
            }
            else
            {
                int ret = Logic.get_libelle_intitule(ref view_model, LaTxt.Text);
                if (ret == 0)
                {
                    LaTxt.ForeColor = Color.Black;
                    warn.Text = view_model.libelle_intitule;
                    LibelTxt.Text = view_model.libelle_intitule + " ";
                    liblength = LibelTxt.Text.Length;
                    LibelTxt.Text += mlibel;
                    ep.SetError(LaTxt, "");

                }
                else
                {
                    LaTxt.ForeColor = Color.Red;
                    ep.SetError(LaTxt, "Code libellé Inexistant");
                    warn.Text = "Code libellé Inexistant";

                }

            }
            return b;
        }*/

        bool valide_LibelTxt(bool b)
        {
            if (LibelTxt.Text == "")
            {
                b = false;
                LibelTxt.ForeColor = Color.Red;
                ep.SetError(LibelTxt, "Code libellé Inexistant");
                warn.Text = "Libellé automatique inspecifié";

            }
            else
            {
                if (LibelTxt.Text.Length > liblength) mlibel = LibelTxt.Text.Substring(liblength, LibelTxt.Text.Length - liblength);
                else mlibel = "";
                LibelTxt.ForeColor = Color.Black;
                ep.SetError(LibelTxt, "");
                warn.Text = "";
            }
            return b;

        }
        bool valide_LibelTxt2(bool b)
        {
            if (LibelTxt2.Text == "")
            {
                b = false;
                LibelTxt2.ForeColor = Color.Red;
                ep.SetError(LibelTxt2, "Code libellé 2 Inexistant");
                warn.Text = "Libellé 2 automatique inspecifié";

            }
            else
            {
                if (LibelTxt2.Text.Length > liblength) mlibel2 = LibelTxt2.Text.Substring(liblength, LibelTxt2.Text.Length - liblength);
                else mlibel2 = "";
                LibelTxt2.ForeColor = Color.Black;
                ep.SetError(LibelTxt2, "");
                warn.Text = "";
            }
            return b;

        }

        bool valide_STxt(bool b)
        {
            STxt.Text = STxt.Text.ToUpper();
            if ((STxt.Text != "D") && (STxt.Text != "C") && (STxt.Text != "d") && (STxt.Text != "c"))
            {
                b = false;
                STxt.ForeColor = Color.Red;
                ep.SetError(STxt, "Format D/C invalide");
                warn.Text = "Format D/C invalide";

            }
            else
            {
                STxt.ForeColor = Color.Black;
                STxt.Text = STxt.Text.ToUpper();
                ep.SetError(STxt, "");
                warn.Text = "";
            }
            return b;
        }

        bool valide_MntTxt(bool b)
        {
            MntTxt.Text = MntTxt.Text.Replace(".", ",");
            if (Validator.valide_F(MntTxt.Text) == false)
            {
                b = false;
                MntTxt.ForeColor = Color.Red;
                ep.SetError(MntTxt, "Format montant invalide");
                warn.Text = "Format montant invalide";
            }
            else
            {
                MntTxt.ForeColor = Color.Black;
                ep.SetError(MntTxt, "");
                warn.Text = "";

            }
            return b;
        }

        private void CodeJournalTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void CpartTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void OrderTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void LaTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CmptTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
