using System;
using System.Drawing;
using System.Drawing.Text;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Utilitaire;

namespace LivresCompta
{
	/// <summary>
	/// Description résumée de dcdebufin.
	/// </summary>
    public class SelectionDateComptesUI : System.Windows.Forms.Form
	{
        public System.Windows.Forms.Form parent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label l2;
		
		public System.Windows.Forms.TextBox CompteF;
		public System.Windows.Forms.TextBox CompteD;
		public System.Windows.Forms.TextBox Date;

		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Button submit;

        public bool ok;
		public string dDate;
        private System.Windows.Forms.ErrorProvider ep;
        private IContainer components;

        public SelectionDateComptesVM SelectionDateComptes_VM;

        
        public string an;

        public SelectionDateComptesUI()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionDateComptesUI));
            this.CompteF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CompteD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.submit = new System.Windows.Forms.Button();
            this.Date = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // CompteF
            // 
            this.CompteF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CompteF.Location = new System.Drawing.Point(144, 99);
            this.CompteF.MaxLength = 8;
            this.CompteF.Name = "CompteF";
            this.CompteF.Size = new System.Drawing.Size(88, 20);
            this.CompteF.TabIndex = 3;
            this.CompteF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompteF_KeyDown);
            this.CompteF.Validating += new System.ComponentModel.CancelEventHandler(this.CompteF_Validating);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(19, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Compte Fin ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CompteD
            // 
            this.CompteD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CompteD.Location = new System.Drawing.Point(144, 67);
            this.CompteD.MaxLength = 8;
            this.CompteD.Name = "CompteD";
            this.CompteD.Size = new System.Drawing.Size(88, 20);
            this.CompteD.TabIndex = 2;
            this.CompteD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompteD_KeyDown);
            this.CompteD.Validating += new System.ComponentModel.CancelEventHandler(this.CompteD_Validating);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(4, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Compte Debut ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.cancel.Location = new System.Drawing.Point(168, 155);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(72, 25);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "&Annuler";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.submit.Location = new System.Drawing.Point(64, 155);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(72, 25);
            this.submit.TabIndex = 4;
            this.submit.Text = "&Valider";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // Date
            // 
            this.Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Date.Location = new System.Drawing.Point(144, 35);
            this.Date.MaxLength = 10;
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(88, 20);
            this.Date.TabIndex = 1;
            this.Date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Date_KeyDown);
            this.Date.Validating += new System.ComponentModel.CancelEventHandler(this.Date_Validating);
            // 
            // l2
            // 
            this.l2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.l2.Location = new System.Drawing.Point(44, 35);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(77, 24);
            this.l2.TabIndex = 16;
            this.l2.Text = "Date Fin Periode :";
            this.l2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            this.ep.DataMember = "";
            // 
            // SelectionDateComptesUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(280, 214);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.l2);
            this.Controls.Add(this.CompteF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CompteD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.submit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectionDateComptesUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SelectionDateComptesUI_Closing);
            this.Load += new System.EventHandler(this.SelectionDateComptesUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


        private void SelectionDateComptesUI_Load(object sender, System.EventArgs e)
		{
			Date.Focus();
		}
        private void SelectionDateComptesUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
    	
        }
        private void Date_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) CompteD.Focus();
		}
        private void CompteD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) CompteF.Focus();
			if ( e.KeyData == Keys.Up) Date.Focus();
		
		}
        private void CompteF_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) submit.Focus();
			if ( e.KeyData == Keys.Up) CompteD.Focus();
		
		}
        private void Date_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            int ret = Validator.valide_DT(Date.Text, an);
            if (ret != 0)
            {
                Date.ForeColor = Color.Red;
                ep.SetError(Date ,"Format Date invalide");
            }
            else
            {
                Date.ForeColor = Color.Black;
                ep.SetError(Date , "");
            }
		
		}
        private void CompteD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            bool b = Validator.valide_N(CompteD.Text);
            if (b == true)
            {
                CompteD.ForeColor = Color.Black;
                ep.SetError( CompteD , "" );
            }
            else
            {
                CompteD.ForeColor = Color.Red;
                ep.SetError(CompteD , "Format Compte invalide");
            }
		
		}
        private void CompteF_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            bool b = Validator.valide_N(CompteF.Text);
            if (b == true)
            {
                CompteF.ForeColor = Color.Black;
                ep.SetError( CompteF, "" );
            }
            else
            {
                CompteF.ForeColor = Color.Red;
                ep.SetError(CompteF, "Format Compte invalide");
            }
		
		}
		


		private void submit_Click(object sender, System.EventArgs e)
		{
            valide();
            if (SelectionDateComptes_VM.valid == true)
            {
                Close();
            }
		}
	
        private void cancel_Click(object sender, System.EventArgs e)
		{
            SelectionDateComptes_VM.valid = false;
            Close();
		}

        private void valide()
        {
            bool b = true;

            int ret0 = Validator.valide_DT(Date.Text, an);
            if (ret0 != 0)
            {
                Date.ForeColor = Color.Red;
                ep.SetError(Date, "Format Date invalide");
                b = false;

            }
            else
            {
                Date.ForeColor = Color.Black;
                ep.SetError(Date, "");

            }

            bool b1 = Validator.valide_N(CompteD.Text);
            if (b1 == true)
            {
                CompteD.ForeColor = Color.Black;
                ep.SetError(CompteD, "");
            }
            else
            {
                CompteD.ForeColor = Color.Red;
                ep.SetError( CompteD, "Format Compte invalide");
                b = false;
            }


            bool b2 = Validator.valide_N(CompteF.Text);
            if (b2 == true)
            {
                CompteF.ForeColor = Color.Black;
                ep.SetError(CompteF, "");

            }
            else
            {
                CompteF.ForeColor = Color.Red;
                ep.SetError(CompteF, "Format Compte invalide");
                b = false;
            }

            if ((b1 == true) && (b2 == true))
            {
                if (Int32.Parse(CompteD.Text) > Int32.Parse(CompteF.Text))
                {
                    CompteD.ForeColor = Color.Red;
                    ep.SetError(CompteD, "Compte Debut superieur a Compte Fin");
                    CompteF.ForeColor = Color.Red;
                    ep.SetError(CompteF, "Comte Fin inferieur a Compte Debut");
                    b = false;

                }
                else
                {
                    CompteD.ForeColor = Color.Black;
                    ep.SetError(CompteD, "");
                    CompteF.ForeColor = Color.Black;
                    ep.SetError(CompteF,"");

                }

            }


            if (b == true)
            {
                SelectionDateComptes_VM.valid = true;
                SelectionDateComptes_VM.compted = CompteD.Text;
                SelectionDateComptes_VM.comptef = CompteF.Text;
                SelectionDateComptes_VM.date = Date.Text;
                SelectionDateComptes_VM.idate = Fonctions.DateToInt(Date.Text).ToString();




            }


        }

	}
}
