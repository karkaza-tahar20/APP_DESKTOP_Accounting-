using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Utilitaire;
using SaisieCompta;
using CoucheAcceeDonnees;


namespace SaisieCompta
{
	/// <summary>
	/// Description résumée de JrnAux.
	/// </summary>
	public class SaisieJournauxUI : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button SupprimButton;
		private System.Windows.Forms.Button ModifButton;
		private System.Windows.Forms.Button ConsultButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.TextBox IntlTxt;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox CdeTxt;
		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.ErrorProvider ep;
		private System.Windows.Forms.ContextMenu contextmenu;
        private System.Windows.Forms.MenuItem menu_Affichage_journaux;
        private IContainer components;
		
		public System.Windows.Forms.Form parent;

        CAD db;
        private Label warn;
       
        SaisieJournauxLogic Logic;
        SaisieJournauxVM model;
		
		public SaisieJournauxUI()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

        public SaisieJournauxUI(CAD db1)
        {
            InitializeComponent();
            
            db = db1;
            Logic = new SaisieJournauxLogic(db);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaisieJournauxUI));
            this.SupprimButton = new System.Windows.Forms.Button();
            this.ModifButton = new System.Windows.Forms.Button();
            this.ConsultButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.IntlTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CdeTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.contextmenu = new System.Windows.Forms.ContextMenu();
            this.menu_Affichage_journaux = new System.Windows.Forms.MenuItem();
            this.warn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // SupprimButton
            // 
            this.SupprimButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.SupprimButton.Location = new System.Drawing.Point(456, 24);
            this.SupprimButton.Name = "SupprimButton";
            this.SupprimButton.Size = new System.Drawing.Size(96, 25);
            this.SupprimButton.TabIndex = 8;
            this.SupprimButton.Text = "&Supprimer";
            this.SupprimButton.UseVisualStyleBackColor = true;
            this.SupprimButton.Click += new System.EventHandler(this.SupprimButton_Click);
            // 
            // ModifButton
            // 
            this.ModifButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.ModifButton.Location = new System.Drawing.Point(256, 24);
            this.ModifButton.Name = "ModifButton";
            this.ModifButton.Size = new System.Drawing.Size(96, 25);
            this.ModifButton.TabIndex = 7;
            this.ModifButton.Text = "&Modifier";
            this.ModifButton.UseVisualStyleBackColor = true;
            this.ModifButton.Click += new System.EventHandler(this.ModifButton_Click);
            // 
            // ConsultButton
            // 
            this.ConsultButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.ConsultButton.Location = new System.Drawing.Point(256, 85);
            this.ConsultButton.Name = "ConsultButton";
            this.ConsultButton.Size = new System.Drawing.Size(96, 25);
            this.ConsultButton.TabIndex = 6;
            this.ConsultButton.Text = "&Consulter";
            this.ConsultButton.UseVisualStyleBackColor = true;
            this.ConsultButton.Click += new System.EventHandler(this.ConsultButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.SaveButton.Location = new System.Drawing.Point(40, 24);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(96, 25);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "&Enregistrer";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // IntlTxt
            // 
            this.IntlTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IntlTxt.Location = new System.Drawing.Point(153, 162);
            this.IntlTxt.MaxLength = 30;
            this.IntlTxt.Name = "IntlTxt";
            this.IntlTxt.Size = new System.Drawing.Size(248, 20);
            this.IntlTxt.TabIndex = 2;
            this.IntlTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IntlTxt_KeyDown);
            this.IntlTxt.Validating += new System.ComponentModel.CancelEventHandler(this.IntlTxt_Validating);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(24, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Intitulé                     :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CdeTxt
            // 
            this.CdeTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CdeTxt.Location = new System.Drawing.Point(150, 88);
            this.CdeTxt.MaxLength = 4;
            this.CdeTxt.Name = "CdeTxt";
            this.CdeTxt.Size = new System.Drawing.Size(48, 20);
            this.CdeTxt.TabIndex = 1;
            this.CdeTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cdeTxt_KeyDown);
            this.CdeTxt.Validating += new System.ComponentModel.CancelEventHandler(this.cdeTxt_Validating);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(24, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Code Journal          ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.ExitButton.Location = new System.Drawing.Point(466, 225);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(96, 25);
            this.ExitButton.TabIndex = 10;
            this.ExitButton.Text = "&Quitter";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.ClearButton.Location = new System.Drawing.Point(325, 225);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(96, 25);
            this.ClearButton.TabIndex = 9;
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
            this.menu_Affichage_journaux});
            // 
            // menu_Affichage_journaux
            // 
            this.menu_Affichage_journaux.Index = 0;
            this.menu_Affichage_journaux.Text = "Affichage journaux auxilliers";
            this.menu_Affichage_journaux.Click += new System.EventHandler(this.menu_Affichage_journaux_Click);
            // 
            // warn
            // 
            this.warn.AutoSize = true;
            this.warn.ForeColor = System.Drawing.Color.Red;
            this.warn.Location = new System.Drawing.Point(197, 70);
            this.warn.Name = "warn";
            this.warn.Size = new System.Drawing.Size(0, 13);
            this.warn.TabIndex = 29;
            // 
            // SaisieJournauxUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(585, 259);
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
            this.Name = "SaisieJournauxUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Journaux Auxiliaires";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SaisieJrnAuxUI_Closing);
            this.Load += new System.EventHandler(this.SaisieJrnAuxUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void SaisieJrnAuxUI_Load(object sender, System.EventArgs e)
		{
            CdeTxt.Focus();
		}

        private void SaisieJrnAuxUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		
		}
	
		
		#region validation+curseur


		private void cdeTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) IntlTxt.Focus();
		}

		private void IntlTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) //CmptTxt.Focus();
			if ( e.KeyData == Keys.Up) CdeTxt.Focus();
		
		}
		
		private void cmptTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if ((e.KeyData == Keys.Down) || (e.KeyData == Keys.Enter)) //CpaButton.Focus();
			if ( e.KeyData == Keys.Up) IntlTxt.Focus();
		
		}

		private void CpoTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) SaveButton.Focus();
			//if (e.KeyData == Keys.Up) CmptTxt.Focus();
		
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

		private void IntlTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
		
		}

		/*private void cmptTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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
			
         		
		}*/

			
		
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

        
        private void ClearButton_Click(object sender, System.EventArgs e)
        {
            Effacer();
		}

		private void ExitButton_Click(object sender, System.EventArgs e)
		{
		     this.Close();
		}

        void Enregistrer()
        {
            model = new SaisieJournauxVM();
            model.Code = CdeTxt.Text;
            model.Intitule = IntlTxt.Text;
            model.Compte = CdeTxt.Text;
            model.ContrePartieAutomatique = false;

           
            if (validate_form() == false)
            {
                warn.Text = "Données saisis invalides !";
                return;
            }

            int res = Logic.Enregistrer(model);
            if (res == 1)
            {
                warn.Text = "Code journal existe deja !";
                return;
            }
            model = null;
            Effacer();

        }

        void Consulter()
        {
            model = new SaisieJournauxVM();
            model.Code = CdeTxt.Text;
            if (validate_key() == false)
            {
                warn.Text = "Données saisis invalides !";
                return;
            }
            
            int res = Logic.Consulter(ref model);
            if (res == 0)
            {
                CdeTxt.Text = model.Code;
                IntlTxt.Text = model.Intitule;
                //CmptTxt.Text = model.Compte;
                //CpaButton.Checked = model.ContrePartieAutomatique;

            }
            if (res == 1)
            {
                warn.Text = "Code journal inexistant !";
                model = null;
            }


        }

        void Modifier()
        {
            if (model == null) return;

            model.Code = CdeTxt.Text;
            model.Intitule = IntlTxt.Text;
            model.Compte = CdeTxt.Text;
            model.ContrePartieAutomatique = false;

            if (validate_form() == false)
            {
                warn.Text = "Données saisis invalides !";
                return;
            }
           
            int res = Logic.Modifier(model);
            if (res == 1)
            {
                warn.Text = "Ce journal existe deja !";
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
                warn.Text = "Code journal inexistant !";
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
            IntlTxt.ForeColor = Color.Black;
            ep.SetError(IntlTxt, "");

            //CmptTxt.Text = "";
            //CmptTxt.ForeColor = Color.Black;
            //ep.SetError(CmptTxt, "");


           // CpaButton.ForeColor = Color.Black;
            //CpaButton.Checked = false;
            //ep.SetError(CpaButton, "");

            CdeTxt.Focus();


        }



        bool validate_key()
        {
           
            Dictionary<string, string> Errors = model.valide_key();

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

        bool validate_form()
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

             string error_compte = Errors["Compte"];
            /* if (error_compte != "")
             {
                 //CmptTxt.ForeColor = Color.Red;
                 //ep.SetError(CmptTxt, error_compte);
                 
             }
             else
             {
                 CmptTxt.ForeColor = Color.Black;
                 ep.SetError(CmptTxt, "");
             } */    
            


            return model.Ok;
        }

		

		private void menu_Affichage_journaux_Click(object sender, System.EventArgs e)
		{
            EditionCompta.ListingJournauxUI view = new EditionCompta.ListingJournauxUI(db);
            view.ShowDialog();
			
		}

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
