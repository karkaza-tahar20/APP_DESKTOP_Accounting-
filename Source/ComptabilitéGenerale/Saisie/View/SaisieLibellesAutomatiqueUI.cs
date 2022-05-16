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
	/// Description résumée de libelAut.
	/// </summary>
	public class SaisieLibellesAutomatiqueUI : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox IntlTxt;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox CdeTxt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button SupprimButton;
		private System.Windows.Forms.Button ModifButton;
		private System.Windows.Forms.Button ConsultButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.Button ClearButton;
		private System.Windows.Forms.ErrorProvider ep;
		private System.Windows.Forms.ContextMenu contextmenu;
        private System.Windows.Forms.MenuItem menu_aff_libelles;
		
		public System.Windows.Forms.Form parent;


        CAD db;
        private IContainer components;
        private Label warn;

        public SaisieLibellesAutomatiquesLogic Logic;
        SaisieLibellesAutomatiquesVM model;


        public SaisieLibellesAutomatiqueUI()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}
      

        public SaisieLibellesAutomatiqueUI(CAD db1)
        {
            InitializeComponent();

            db = db1;
            Logic = new SaisieLibellesAutomatiquesLogic(db);

        }

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
	 
      protected override void Dispose(bool disposing)
      {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaisieLibellesAutomatiqueUI));
            this.IntlTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CdeTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SupprimButton = new System.Windows.Forms.Button();
            this.ModifButton = new System.Windows.Forms.Button();
            this.ConsultButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.contextmenu = new System.Windows.Forms.ContextMenu();
            this.menu_aff_libelles = new System.Windows.Forms.MenuItem();
            this.warn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // IntlTxt
            // 
            this.IntlTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IntlTxt.Location = new System.Drawing.Point(137, 137);
            this.IntlTxt.MaxLength = 100;
            this.IntlTxt.Name = "IntlTxt";
            this.IntlTxt.Size = new System.Drawing.Size(271, 20);
            this.IntlTxt.TabIndex = 2;
            this.IntlTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IntlTxt_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(17, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 23);
            this.label2.TabIndex = 31;
            this.label2.Text = "Intitulé                     :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CdeTxt
            // 
            this.CdeTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CdeTxt.Location = new System.Drawing.Point(137, 105);
            this.CdeTxt.MaxLength = 2;
            this.CdeTxt.Name = "CdeTxt";
            this.CdeTxt.Size = new System.Drawing.Size(55, 20);
            this.CdeTxt.TabIndex = 1;
            this.CdeTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cdeTxt_KeyDown);
            this.CdeTxt.Validating += new System.ComponentModel.CancelEventHandler(this.cdeTxt_Validating);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(17, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 30;
            this.label1.Text = "Code                       :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SupprimButton
            // 
            this.SupprimButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.SupprimButton.Location = new System.Drawing.Point(456, 24);
            this.SupprimButton.Name = "SupprimButton";
            this.SupprimButton.Size = new System.Drawing.Size(96, 23);
            this.SupprimButton.TabIndex = 6;
            this.SupprimButton.Text = "&Supprimer";
            this.SupprimButton.UseVisualStyleBackColor = true;
            this.SupprimButton.Click += new System.EventHandler(this.SupprimButton_Click);
            // 
            // ModifButton
            // 
            this.ModifButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.ModifButton.Location = new System.Drawing.Point(312, 24);
            this.ModifButton.Name = "ModifButton";
            this.ModifButton.Size = new System.Drawing.Size(96, 23);
            this.ModifButton.TabIndex = 5;
            this.ModifButton.Text = "&Modifier";
            this.ModifButton.UseVisualStyleBackColor = true;
            this.ModifButton.Click += new System.EventHandler(this.ModifButton_Click);
            // 
            // ConsultButton
            // 
            this.ConsultButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.ConsultButton.Location = new System.Drawing.Point(168, 24);
            this.ConsultButton.Name = "ConsultButton";
            this.ConsultButton.Size = new System.Drawing.Size(96, 23);
            this.ConsultButton.TabIndex = 4;
            this.ConsultButton.Text = "&Consulter";
            this.ConsultButton.UseVisualStyleBackColor = true;
            this.ConsultButton.Click += new System.EventHandler(this.ConsultButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.SaveButton.Location = new System.Drawing.Point(24, 24);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(96, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "&Enregistrer";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.ExitButton.Location = new System.Drawing.Point(457, 217);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(96, 23);
            this.ExitButton.TabIndex = 8;
            this.ExitButton.Text = "&Quitter";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.ClearButton.Location = new System.Drawing.Point(193, 193);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(96, 23);
            this.ClearButton.TabIndex = 7;
            this.ClearButton.Text = "E&ffacer";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            this.ep.DataMember = "";
            // 
            // contextmenu
            // 
            this.contextmenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menu_aff_libelles});
            // 
            // menu_aff_libelles
            // 
            this.menu_aff_libelles.Index = 0;
            this.menu_aff_libelles.Text = "Affichage Plan Libelles";
            // 
            // warn
            // 
            this.warn.AutoSize = true;
            this.warn.Location = new System.Drawing.Point(213, 68);
            this.warn.Name = "warn";
            this.warn.Size = new System.Drawing.Size(0, 13);
            this.warn.TabIndex = 32;
            // 
            // SaisieLibellesAutomatiqueUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(576, 259);
            this.ContextMenu = this.contextmenu;
            this.Controls.Add(this.warn);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.IntlTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CdeTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SupprimButton);
            this.Controls.Add(this.ModifButton);
            this.Controls.Add(this.ConsultButton);
            this.Controls.Add(this.SaveButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SaisieLibellesAutomatiqueUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Libellés Automatiques";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SaisieLibelAutUI_Closing);
            this.Load += new System.EventHandler(this.SaisieLibelAutUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


        private void SaisieLibelAutUI_Load(object sender, System.EventArgs e)
		{
            CdeTxt.Focus();
		}
        private void SaisieLibelAutUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			

		
		}
	
		#region validation + curseur 

		private void cdeTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) IntlTxt.Focus();
		}

		private void IntlTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) SaveButton.Focus();
			if ( e.KeyData == Keys.Up) CdeTxt.Focus();
		}

		private void cdeTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            bool b = Validator.valide_N(CdeTxt.Text);
            if (b == false)
            {
                CdeTxt.ForeColor = Color.Red;
                ep.SetError(CdeTxt, "Format numerique invalide");
            }
            else
            {
                CdeTxt.ForeColor = Color.Black;
                ep.SetError(CdeTxt, "");
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
            model = new SaisieLibellesAutomatiquesVM();
            model.Code = CdeTxt.Text;
            model.Intitule = IntlTxt.Text;

            if (validate() == false)
            {
                warn.Text = "Données saisis invalides !";
                return;
            }

            int res = Logic.Enregistrer(model);
            if (res == 1)
            {
                warn.Text = "Code libelle inexistant !";
                return;
            }
            model = null;
            Effacer();



        }

        void Consulter()
        {
            model = new SaisieLibellesAutomatiquesVM();
            model.Code = CdeTxt.Text;
            if (validate() == false)
            {
                warn.Text = "Données saisis invalides !";
                return;
            }

            int res = Logic.Consulter(ref model);
            
            if (res == 0)
            {
                CdeTxt.Text = model.Code;
                IntlTxt.Text = model.Intitule;

            }
            if (res == 1)
            {
                warn.Text = "Code libelle inexistant !";
                model = null;
            }
          


        }

        void Modifier()
        {
            if (model == null) return;

            model.Code = CdeTxt.Text;
            model.Intitule = IntlTxt.Text;

            if (validate() == false)
            {
                warn.Text = "Données saisis invalides !";
                return;
            }

            int res = Logic.Modifier(model);
            if (res == 1)
            {
                warn.Text = "Code libelle existe deja !";
                return;
            }
            model = null;
            Effacer();

        }

        void Supprimer()
        {
            if (model == null) return;

            if (validate() == false)
            {
                warn.Text = "Données saisis invalides !";
                return;
            }

            int res = Logic.Supprimer(model);
            if (res == 1)
            {
                warn.Text = "Code libelle inexistant !";
                return;
            }

            model = null;
            Effacer();

        }

        void Effacer()
        {
            warn.Text = "";

            CdeTxt.Text = "";
            CdeTxt.ForeColor = Color.Black;
            ep.SetError(CdeTxt, "");
            IntlTxt.Text = "";

            CdeTxt.Focus();


        }

        bool validate()
        {
            Dictionary<string, string> Errors = model.validate();

            string error_code = Errors["Code"];
            if (error_code != "")
            {
                CdeTxt.ForeColor = Color.Red;
                ep.SetError(CdeTxt, error_code);
            }
            else
            {
                CdeTxt.ForeColor = Color.Black;
                ep.SetError(CdeTxt, "");
            }

            return model.Ok;

          
        }
	
		private void ClearButton_Click(object sender, System.EventArgs e)
		{
            Effacer();
		
		}

	
		private void ExitButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		

		

		

		

	}
}
