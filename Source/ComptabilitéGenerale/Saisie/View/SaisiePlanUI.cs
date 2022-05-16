using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using CoucheAcceeDonnees;
using Utilitaire;

namespace SaisieCompta
{
	/// <summary>
	/// Description résumée de SaisiePlan.
	/// </summary>
	public class SaisiePlanUI : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button ConsultButton;
		private System.Windows.Forms.Button ModifButton;
		private System.Windows.Forms.Button SupprimButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox IntlTxt;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox NivTxt;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox SolcredTxt;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox SoldebTxt;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button ClearButton;
		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox CmptResTxt;
		private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider ep;
        private IContainer components;
		public System.Windows.Forms.TextBox CmptTxt;
		private System.Windows.Forms.ContextMenu contextmenu;
		private System.Windows.Forms.MenuItem menu_Affichage_Plan;
		
		public System.Windows.Forms.Form parent;
		private System.Windows.Forms.TextBox AnvdTxt;
		private System.Windows.Forms.TextBox AnvcTxt;
		private System.Windows.Forms.TextBox MvcTxt;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox MvdTxt;
		private System.Windows.Forms.Label label11;

        CAD db;
        private Label warn;
        public SaisiePlanLogic Logic;
        SaisiePlanVM model;


		public SaisiePlanUI()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

        public SaisiePlanUI(CAD db1)
        {
            InitializeComponent();
            db = db1;
            Logic = new SaisiePlanLogic(db);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaisiePlanUI));
            this.SaveButton = new System.Windows.Forms.Button();
            this.ConsultButton = new System.Windows.Forms.Button();
            this.ModifButton = new System.Windows.Forms.Button();
            this.SupprimButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CmptTxt = new System.Windows.Forms.TextBox();
            this.IntlTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NivTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AnvdTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AnvcTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SolcredTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SoldebTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.CmptResTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.contextmenu = new System.Windows.Forms.ContextMenu();
            this.menu_Affichage_Plan = new System.Windows.Forms.MenuItem();
            this.MvcTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.MvdTxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.warn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.SaveButton.Location = new System.Drawing.Point(24, 24);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(96, 25);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "&Enregistrer";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ConsultButton
            // 
            this.ConsultButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.ConsultButton.Location = new System.Drawing.Point(200, 24);
            this.ConsultButton.Name = "ConsultButton";
            this.ConsultButton.Size = new System.Drawing.Size(96, 25);
            this.ConsultButton.TabIndex = 9;
            this.ConsultButton.Text = "&Consulter";
            this.ConsultButton.UseVisualStyleBackColor = true;
            this.ConsultButton.Click += new System.EventHandler(this.ConsultButton_Click);
            // 
            // ModifButton
            // 
            this.ModifButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.ModifButton.Location = new System.Drawing.Point(381, 24);
            this.ModifButton.Name = "ModifButton";
            this.ModifButton.Size = new System.Drawing.Size(96, 25);
            this.ModifButton.TabIndex = 10;
            this.ModifButton.Text = "&Modifier";
            this.ModifButton.UseVisualStyleBackColor = true;
            this.ModifButton.Click += new System.EventHandler(this.ModifButton_Click);
            // 
            // SupprimButton
            // 
            this.SupprimButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.SupprimButton.Location = new System.Drawing.Point(576, 24);
            this.SupprimButton.Name = "SupprimButton";
            this.SupprimButton.Size = new System.Drawing.Size(96, 25);
            this.SupprimButton.TabIndex = 11;
            this.SupprimButton.Text = "&Supprimer";
            this.SupprimButton.UseVisualStyleBackColor = true;
            this.SupprimButton.Click += new System.EventHandler(this.SupprimButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(21, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Compte          ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmptTxt
            // 
            this.CmptTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CmptTxt.Location = new System.Drawing.Point(176, 106);
            this.CmptTxt.MaxLength = 8;
            this.CmptTxt.Name = "CmptTxt";
            this.CmptTxt.Size = new System.Drawing.Size(120, 20);
            this.CmptTxt.TabIndex = 0;
            this.CmptTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmptTxt_KeyDown);
            this.CmptTxt.Validating += new System.ComponentModel.CancelEventHandler(this.cmptTxt_Validating);
            // 
            // IntlTxt
            // 
            this.IntlTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IntlTxt.Location = new System.Drawing.Point(176, 138);
            this.IntlTxt.MaxLength = 30;
            this.IntlTxt.Name = "IntlTxt";
            this.IntlTxt.Size = new System.Drawing.Size(248, 20);
            this.IntlTxt.TabIndex = 1;
            this.IntlTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IntlTxt_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(21, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Intitulé            ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NivTxt
            // 
            this.NivTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NivTxt.Location = new System.Drawing.Point(176, 210);
            this.NivTxt.MaxLength = 1;
            this.NivTxt.Name = "NivTxt";
            this.NivTxt.Size = new System.Drawing.Size(24, 20);
            this.NivTxt.TabIndex = 3;
            this.NivTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NivTxt_KeyDown);
            this.NivTxt.Validating += new System.ComponentModel.CancelEventHandler(this.NivTxt_Validating);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(21, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Niveau           ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AnvdTxt
            // 
            this.AnvdTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnvdTxt.Location = new System.Drawing.Point(176, 258);
            this.AnvdTxt.MaxLength = 15;
            this.AnvdTxt.Name = "AnvdTxt";
            this.AnvdTxt.Size = new System.Drawing.Size(136, 20);
            this.AnvdTxt.TabIndex = 4;
            this.AnvdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AnvdTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MvdTxt_KeyDown);
            this.AnvdTxt.Validating += new System.ComponentModel.CancelEventHandler(this.MvdTxt_Validating);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(21, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "A  Nouveau Débit     ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AnvcTxt
            // 
            this.AnvcTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnvcTxt.Location = new System.Drawing.Point(536, 258);
            this.AnvcTxt.MaxLength = 15;
            this.AnvcTxt.Name = "AnvcTxt";
            this.AnvcTxt.Size = new System.Drawing.Size(136, 20);
            this.AnvcTxt.TabIndex = 5;
            this.AnvcTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AnvcTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MvcTxt_KeyDown);
            this.AnvcTxt.Validating += new System.ComponentModel.CancelEventHandler(this.MvcTxt_Validating);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(397, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "A  Nouvau  Crédit     ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SolcredTxt
            // 
            this.SolcredTxt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.SolcredTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SolcredTxt.Location = new System.Drawing.Point(536, 338);
            this.SolcredTxt.MaxLength = 15;
            this.SolcredTxt.Name = "SolcredTxt";
            this.SolcredTxt.ReadOnly = true;
            this.SolcredTxt.Size = new System.Drawing.Size(136, 20);
            this.SolcredTxt.TabIndex = 7;
            this.SolcredTxt.TabStop = false;
            this.SolcredTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(434, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "Solde Crédit   ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SoldebTxt
            // 
            this.SoldebTxt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.SoldebTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SoldebTxt.Location = new System.Drawing.Point(176, 338);
            this.SoldebTxt.MaxLength = 15;
            this.SoldebTxt.Name = "SoldebTxt";
            this.SoldebTxt.ReadOnly = true;
            this.SoldebTxt.Size = new System.Drawing.Size(136, 20);
            this.SoldebTxt.TabIndex = 6;
            this.SoldebTxt.TabStop = false;
            this.SoldebTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(61, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "Solde Débit    ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.ClearButton.Location = new System.Drawing.Point(256, 378);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(96, 23);
            this.ClearButton.TabIndex = 12;
            this.ClearButton.Text = "E&ffacer";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.ExitButton.Location = new System.Drawing.Point(528, 394);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(96, 23);
            this.ExitButton.TabIndex = 13;
            this.ExitButton.Text = "&Quitter";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(232, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "1-2";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmptResTxt
            // 
            this.CmptResTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CmptResTxt.Location = new System.Drawing.Point(176, 170);
            this.CmptResTxt.MaxLength = 8;
            this.CmptResTxt.Name = "CmptResTxt";
            this.CmptResTxt.Size = new System.Drawing.Size(120, 20);
            this.CmptResTxt.TabIndex = 2;
            this.CmptResTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmptResTxt_KeyDown);
            this.CmptResTxt.Validating += new System.ComponentModel.CancelEventHandler(this.CmptResTxt_Validating);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(21, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 23);
            this.label9.TabIndex = 19;
            this.label9.Text = "Compte  Resultat        ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // contextmenu
            // 
            this.contextmenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menu_Affichage_Plan});
            // 
            // menu_Affichage_Plan
            // 
            this.menu_Affichage_Plan.Index = 0;
            this.menu_Affichage_Plan.Text = "Affichage Plan Comptable";
            this.menu_Affichage_Plan.Click += new System.EventHandler(this.menu_Affichage_Plan_Click);
            // 
            // MvcTxt
            // 
            this.MvcTxt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.MvcTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MvcTxt.Location = new System.Drawing.Point(536, 298);
            this.MvcTxt.MaxLength = 15;
            this.MvcTxt.Name = "MvcTxt";
            this.MvcTxt.ReadOnly = true;
            this.MvcTxt.Size = new System.Drawing.Size(136, 20);
            this.MvcTxt.TabIndex = 21;
            this.MvcTxt.TabStop = false;
            this.MvcTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(434, 295);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 23);
            this.label10.TabIndex = 23;
            this.label10.Text = "Mvts Crédit     ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MvdTxt
            // 
            this.MvdTxt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.MvdTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MvdTxt.Location = new System.Drawing.Point(176, 298);
            this.MvdTxt.MaxLength = 15;
            this.MvdTxt.Name = "MvdTxt";
            this.MvdTxt.ReadOnly = true;
            this.MvdTxt.Size = new System.Drawing.Size(136, 20);
            this.MvdTxt.TabIndex = 20;
            this.MvdTxt.TabStop = false;
            this.MvdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(62, 298);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 23);
            this.label11.TabIndex = 22;
            this.label11.Text = "Mvts Débit     ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // warn
            // 
            this.warn.AutoSize = true;
            this.warn.Location = new System.Drawing.Point(176, 65);
            this.warn.Name = "warn";
            this.warn.Size = new System.Drawing.Size(0, 13);
            this.warn.TabIndex = 24;
            // 
            // SaisiePlanUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(704, 438);
            this.ContextMenu = this.contextmenu;
            this.Controls.Add(this.warn);
            this.Controls.Add(this.MvcTxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.MvdTxt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CmptResTxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SolcredTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SoldebTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AnvcTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AnvdTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NivTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IntlTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmptTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SupprimButton);
            this.Controls.Add(this.ModifButton);
            this.Controls.Add(this.ConsultButton);
            this.Controls.Add(this.SaveButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SaisiePlanUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saisie Compte Schématique";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SaisiePlanUI_Closing);
            this.Load += new System.EventHandler(this.SaisiePlanUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void SaisiePlanUI_Load(object sender, System.EventArgs e)
		{
            CmptTxt.Focus();
			
		
		}

        private void SaisiePlanUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		
		}
	
		#region validation+curseur
		private void cmptTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) IntlTxt.Focus();
		}

		private void IntlTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) CmptResTxt.Focus();
			if ( e.KeyData == Keys.Up) CmptTxt.Focus();
		
		}

		private void CmptResTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) NivTxt.Focus();
			if ( e.KeyData == Keys.Up) IntlTxt.Focus();
		
		}

		private void NivTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) AnvdTxt.Focus();
			if (e.KeyData == Keys.Up) CmptResTxt.Focus();

		
		}

		private void MvdTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) AnvcTxt.Focus();
			if (e.KeyData == Keys.Up) NivTxt.Focus();

		
		}

		private void MvcTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) SaveButton.Focus();
			if (e.KeyData == Keys.Up) AnvdTxt.Focus();
		
		}

		private void cmptTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{

            bool b = Validator.valide_N(CmptTxt.Text);
            if (b == false)
            {
                CmptTxt.ForeColor = Color.Red;
                ep.SetError(CmptTxt, "Format numerique invalide");
            }
            else
            {
                CmptTxt.ForeColor = Color.Black;
                ep.SetError(CmptTxt, "");
            }
			
		
		}

		private void CmptResTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (CmptResTxt.Text != "")
            {
                bool b = Validator.valide_N(CmptResTxt.Text);
                if (b == false)
                {
                    CmptResTxt.ForeColor = Color.Red;
                    ep.SetError(CmptResTxt, "Format numerique invalide");
                }
                else
                {
                    CmptResTxt.ForeColor = Color.Black;
                    ep.SetError(CmptResTxt, "");
                }
            }
            
		
		}

		private void NivTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{

            bool b = true;
            if ((NivTxt.Text != "1") && (NivTxt.Text != "2"))
                b = false;

            if (b == false)
            {
                NivTxt.ForeColor = Color.Red;
                ep.SetError(NivTxt, "Format numerique invalide");
            }
            else
            {
                NivTxt.ForeColor = Color.Black;
                ep.SetError(NivTxt, "");
            }
		  	
		}

		private void MvdTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (AnvdTxt.Text == "") AnvdTxt.Text = "0,00";
            else
            {
                AnvdTxt.Text = AnvdTxt.Text.Replace('.', ',');
                bool b = Validator.valide_F(AnvdTxt.Text);
                if (b == false)
                {
                    AnvdTxt.ForeColor = Color.Red;
                    ep.SetError(AnvdTxt, "Format invalide");
                }
                else
                {
                    AnvdTxt.ForeColor = Color.Black;
                    ep.SetError(AnvdTxt, "");
                    if (MvdTxt.Text == "") MvdTxt.Text = "0,00";
                    MvdTxt.Text = MvdTxt.Text.Replace('.', ',');
                    double Solded = Double.Parse(MvdTxt.Text) + Double.Parse(AnvdTxt.Text);
                    SoldebTxt.Text = Fonctions.format1(Solded.ToString());
                }
            }
		}

		private void MvcTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (AnvcTxt.Text == "") AnvcTxt.Text = "0,00";
            else
            {
                AnvcTxt.Text = AnvcTxt.Text.Replace('.', ',');
                bool b = Validator.valide_F(AnvcTxt.Text);
                if (b == false)
                {
                    AnvcTxt.ForeColor = Color.Red;
                    ep.SetError(AnvcTxt, "Format invalide");
                }
                else
                {
                    AnvcTxt.ForeColor = Color.Black;
                    ep.SetError(AnvcTxt, "");
                    if (MvcTxt.Text == "") MvcTxt.Text = "0,00";
                    MvcTxt.Text = MvcTxt.Text.Replace('.', ',');
                    double Solcred = Double.Parse(MvcTxt.Text) + Double.Parse(AnvcTxt.Text);
                    SolcredTxt.Text = Fonctions.format1(Solcred.ToString());
                }
            }
			
		
		}
		
		

        #endregion

		private void SaveButton_Click(object sender, System.EventArgs e)
		{
            Enregistrer();
		}

		private void ConsultButton_Click(object sender, System.EventArgs e)
		{
            Consulter();
		}
		
		private void ModifButton_Click(object sender, System.EventArgs e)
		{
            Modifier();
		}

		private void SupprimButton_Click(object sender, System.EventArgs e)
		{
            Supprimer();
		}

        void Enregistrer()
        {
            model = new SaisiePlanVM();
            model.Compte = CmptTxt.Text;
            model.Intitule = IntlTxt.Text;
            model.CompteResultat = CmptResTxt.Text;
            if (model.CompteResultat == "") model.CompteResultat = "0";
            model.Niveau = NivTxt.Text;
            model.AnouveauDebit = AnvdTxt.Text;
            model.AnouveauCredit = AnvcTxt.Text;
            

            if (validate_form() == false)
            {
                warn.Text = "Données saisis invalides !";
                return;
            }

            int res = Logic.Enregistrer(model);
            if (res == 1)
            {
                warn.Text = "Compte existe deja !";
                return;
            }
            model = null;
            Effacer();



        }

        void Consulter()
        {
            model = new SaisiePlanVM();
            model.Compte = CmptTxt.Text;

            if (validate_key() == false)
            {
                warn.Text = "Données saisis invalides !";
                return;
            }

            int res = Logic.Consulter(ref model);
            
            if (res == 0)
            {
                CmptTxt.Text = model.Compte;
                IntlTxt.Text = model.Intitule;
                CmptResTxt.Text = model.CompteResultat;
                NivTxt.Text = model.Niveau;
                AnvdTxt.Text = model.AnouveauDebit;
                AnvcTxt.Text = model.AnouveauCredit;
                MvdTxt.Text = model.MouvementDebit;
                MvcTxt.Text = model.MouvementCredit;
                SoldebTxt.Text = model.SoldDebit;
                SolcredTxt.Text = model.SoldCredit;

            }
            if (res == 1)
            {
                warn.Text = "Compte inexistant !";
                model = null;
            }


        }

        void Modifier()
        {
            if (model == null) return;

            model.Compte = CmptTxt.Text;
            model.Intitule = IntlTxt.Text;
            model.CompteResultat = CmptResTxt.Text;
            model.Niveau = NivTxt.Text;
            model.AnouveauDebit = AnvdTxt.Text;
            model.AnouveauCredit = AnvcTxt.Text;

            if (validate_form() == false)
            {
                warn.Text = "Données saisis invalides !";
                return;
            }
            
            
            int res = Logic.Modifier(model);
            if (res == 1)
            {
                warn.Text = "Ce compte existe deja !";
                return;
            }
            model = null;
            Effacer();

        }

        void Supprimer()
        {
            if (model == null) return;
            if (validate_key() == false)
            {
                warn.Text = "Données saisis invalides !";
                return;
            }

            int res = Logic.Supprimer(model);
            if (res == 1)
            {
                warn.Text = "Compte mouvementé !";
                return;
            }
            if (res == 2)
            {
                warn.Text = "Compte inexistant !";
                return;
            }

            model = null;
            Effacer();
            
        }

		
		
		private void Effacer()
		{
            warn.Text = "";
            ep.SetError(CmptTxt,"");
            CmptTxt.ForeColor = Color.Black;
			CmptTxt.Text = "";
			IntlTxt.Text = "";
            ep.SetError(CmptResTxt,"");
            CmptResTxt.ForeColor = Color.Black;
            CmptResTxt.Text = "";
            ep.SetError(NivTxt,"");
            NivTxt.ForeColor = Color.Black;
            NivTxt.Text = "";
            ep.SetError(AnvdTxt,"");
            AnvdTxt.ForeColor = Color.Black;
            AnvdTxt.Text = "";
			ep.SetError(AnvcTxt,"");
            AnvcTxt.ForeColor = Color.Black;
			AnvcTxt.Text = "";
			MvdTxt.Text = "";
			MvcTxt.Text = "";
			SoldebTxt.Text = "";
			SolcredTxt.Text = "";
            CmptTxt.Focus();
			

		}
	
		private void ClearButton_Click(object sender, System.EventArgs e)
		{
			Effacer();
					
		}

		private void ExitButton_Click(object sender, System.EventArgs e)
		{
            this.Close();
		
		}

        bool validate_key()
        {
            Dictionary<string, string> Errors = model.validate_key();

            string error_compte = Errors["Compte"];
            if (error_compte != "")
            {
                CmptTxt.ForeColor = Color.Red;
                ep.SetError(CmptTxt, error_compte);
            }
            else
            {

                CmptTxt.ForeColor = Color.Black;
                ep.SetError(CmptTxt, "");
            }
          
            return model.Ok;
        }

        bool validate_form()
        {

            Dictionary<string, string> Errors = model.validate();

            string error_compte = Errors["Compte"];
            if (error_compte != "")
            {
                CmptTxt.ForeColor = Color.Red;
                ep.SetError(CmptTxt, error_compte);
            }
            else
            {
                CmptTxt.ForeColor = Color.Black;
                ep.SetError(CmptTxt, "");
            }


            string error_compte_resultat = Errors["CompteResultat"];
            if (error_compte_resultat != "")
            {
                CmptResTxt.ForeColor = Color.Red;
                ep.SetError(CmptResTxt, error_compte_resultat);
            }
            else
            {
                CmptResTxt.ForeColor = Color.Black;
                ep.SetError(CmptResTxt, error_compte_resultat);
            }

            string error_niveau = Errors["Niveau"];
            if (error_niveau != "")
            {
                NivTxt.ForeColor = Color.Red;
                ep.SetError(NivTxt, error_niveau);
            }
            else
            {
                NivTxt.ForeColor = Color.Black;
                ep.SetError(NivTxt, error_niveau);
            }

            string error_anouveau_debit = Errors["AnouveauDebit"];
            if (error_anouveau_debit != "")
            {
                AnvdTxt.ForeColor = Color.Red;
                ep.SetError(AnvdTxt, error_anouveau_debit);
            }
            else
            {
                AnvdTxt.ForeColor = Color.Black;
                ep.SetError(AnvdTxt, error_anouveau_debit);
            }


            string error_anouveau_credit = Errors["AnouveauCredit"];
            if (error_anouveau_credit != "")
            {
                AnvcTxt.ForeColor = Color.Red;
                ep.SetError(AnvcTxt, error_anouveau_credit);
            }
            else
            {
                AnvcTxt.ForeColor = Color.Black;
                ep.SetError(AnvcTxt, error_anouveau_credit);
            }

            return model.Ok;
        }

        private void menu_Affichage_Plan_Click(object sender, EventArgs e)
        {
            EditionCompta.ListingPlanComptableUI view = new EditionCompta.ListingPlanComptableUI(db);
            view.ShowDialog();
        }

      

		
		
	}
}
