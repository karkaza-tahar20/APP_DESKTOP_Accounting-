using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Utilitaire;

namespace LivresCompta
{
	/// <summary>
	/// Description résumée de Selection_Compte.
	/// </summary>
    public class SelectionCompteUI : System.Windows.Forms.Form
	{
        public System.Windows.Forms.Form parent;
		private System.Windows.Forms.Label label1;	
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label l2;
		private System.Windows.Forms.Label l1;
	
        public System.Windows.Forms.TextBox DFTxt;
		public System.Windows.Forms.TextBox DDTxt;
        public System.Windows.Forms.TextBox cmptintl;

		private System.Windows.Forms.ComboBox cmptcombo;

		private System.Windows.Forms.ErrorProvider ep;

		private System.Windows.Forms.Button submit;
		private System.Windows.Forms.Button cancel;

	    
        public string id;
        private IContainer components;

        public SelectionCompteVM SelectionCompte_VM;

        public AffichageGrandLivreLogic GrandLivreLogic; 


        public DataSet ds;
        public string an;

        public SelectionCompteUI()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionCompteUI));
            this.label1 = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.DFTxt = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.Label();
            this.DDTxt = new System.Windows.Forms.TextBox();
            this.l1 = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.cancel = new System.Windows.Forms.Button();
            this.cmptcombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmptintl = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(42, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Compte ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.submit.Location = new System.Drawing.Point(110, 112);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(96, 25);
            this.submit.TabIndex = 2;
            this.submit.Text = "&Valider";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.Valider_Click);
            // 
            // DFTxt
            // 
            this.DFTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DFTxt.Location = new System.Drawing.Point(319, 57);
            this.DFTxt.MaxLength = 10;
            this.DFTxt.Name = "DFTxt";
            this.DFTxt.Size = new System.Drawing.Size(80, 20);
            this.DFTxt.TabIndex = 7;
            this.DFTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DFTxt_KeyDown);
            this.DFTxt.Validating += new System.ComponentModel.CancelEventHandler(this.DFTxt_Validating);
            // 
            // l2
            // 
            this.l2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.l2.Location = new System.Drawing.Point(239, 57);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(96, 24);
            this.l2.TabIndex = 6;
            this.l2.Text = "Date Fin      ";
            this.l2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DDTxt
            // 
            this.DDTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DDTxt.Location = new System.Drawing.Point(110, 57);
            this.DDTxt.MaxLength = 10;
            this.DDTxt.Name = "DDTxt";
            this.DDTxt.Size = new System.Drawing.Size(80, 20);
            this.DDTxt.TabIndex = 5;
            this.DDTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DDTxt_KeyDown);
            this.DDTxt.Validating += new System.ComponentModel.CancelEventHandler(this.DDTxt_Validating);
            // 
            // l1
            // 
            this.l1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.l1.Location = new System.Drawing.Point(16, 57);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(88, 24);
            this.l1.TabIndex = 4;
            this.l1.Text = "Date Debut  ";
            this.l1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.cancel.Location = new System.Drawing.Point(286, 112);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(104, 25);
            this.cancel.TabIndex = 8;
            this.cancel.Text = "&Annuler";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.Anuller_Click);
            // 
            // cmptcombo
            // 
            this.cmptcombo.Location = new System.Drawing.Point(110, 12);
            this.cmptcombo.Name = "cmptcombo";
            this.cmptcombo.Size = new System.Drawing.Size(96, 21);
            this.cmptcombo.TabIndex = 9;
            this.cmptcombo.SelectedIndexChanged += new System.EventHandler(this.idcombo_SelectedIndexChanged);
            this.cmptcombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.idcombo_KeyDown);
            this.cmptcombo.Validating += new System.ComponentModel.CancelEventHandler(this.idcombo_Validating);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(239, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "Intitulé ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmptintl
            // 
            this.cmptintl.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmptintl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmptintl.Location = new System.Drawing.Point(319, 12);
            this.cmptintl.MaxLength = 10;
            this.cmptintl.Name = "cmptintl";
            this.cmptintl.ReadOnly = true;
            this.cmptintl.Size = new System.Drawing.Size(144, 20);
            this.cmptintl.TabIndex = 17;
            // 
            // SelectionCompteUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(504, 163);
            this.Controls.Add(this.cmptintl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmptcombo);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.DFTxt);
            this.Controls.Add(this.l2);
            this.Controls.Add(this.DDTxt);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SelectionCompteUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SelectionCompteUI_Closing);
            this.Load += new System.EventHandler(this.SelectionCompteUI_Loaded);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


        private void SelectionCompteUI_Loaded(object sender, System.EventArgs e)
		{
            string[] comptes = GrandLivreLogic.get_comptes();

            for (int i = 0; i < comptes.Length; i++)
            {
                cmptcombo.Items.Add(comptes[i]);
            }
           
            cmptcombo.Select();
            cmptintl.Text = "";
            
		
		}

        private void SelectionCompteUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		} 
        
        private void idcombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            string idj = cmptcombo.SelectedItem.ToString();
            cmptintl.Text = GrandLivreLogic.get_compte_intitule(idj);

        }
        
        private void idcombo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyData == Keys.Enter) DDTxt.Focus();
		}
        private void DDTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) DFTxt.Focus();
			if (e.KeyData == Keys.Up) cmptcombo.Focus();
		}
        private void DFTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) submit.Focus();;
            if (e.KeyData == Keys.Up) DDTxt.Focus();
		}
		
		private void idcombo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (cmptcombo.Text != "")
            {
                if (cmptcombo.Items.IndexOf(cmptcombo.Text) != -1)
                    cmptcombo.SelectedIndex = cmptcombo.Items.IndexOf(cmptcombo.Text);
                cmptcombo.ForeColor = Color.Black;
                ep.SetError( cmptcombo, "" );
            }
            else
            {
                cmptcombo.ForeColor = Color.Red;
                ep.SetError( cmptcombo,"le compte n'est pas sélectionné");

            }
		
		}
        private void DDTxt_Validating(object sender, CancelEventArgs e)
        {
            int ret = Validator.valide_DT(DDTxt.Text, an);
            if (ret != 0)
            {
                DDTxt.ForeColor = Color.Red;
                ep.SetError(DDTxt, "Format Date invalide");
            }
            else
            {
                DDTxt.ForeColor = Color.Black;
                ep.SetError(DDTxt,"");
            }

        }
        private void DFTxt_Validating(object sender, CancelEventArgs e)
        {
            int ret = Validator.valide_DT(DFTxt.Text, an);
            if (ret != 0)
            {
                DFTxt.ForeColor = Color.Red;
                ep.SetError(DFTxt, "Format Date invalide");
            }
            else
            {
                DFTxt.ForeColor = Color.Black;
                ep.SetError(DFTxt, "");
            }
        }

		
		private void Valider_Click(object sender, System.EventArgs e)
		{
            valide();
            if (SelectionCompte_VM.valid == true)
            {
                Close();
            }
		}
	
        private void Anuller_Click(object sender, System.EventArgs e)
		{
            SelectionCompte_VM.valid = false;
            Close();
		}

        private void valide()
        {
            bool b = true;

            int ret0 = Validator.valide_DT(DDTxt.Text, an);
            if (ret0 != 0)
            {
                DDTxt.ForeColor = Color.Red;
                ep.SetError(DDTxt, "Format Date invalide");
                b = false;

            }
            else
            {
                DDTxt.ForeColor = Color.Black;
                ep.SetError(DDTxt, "");

            }
            int ret1 = Validator.valide_DT(DFTxt.Text, an);
            if (ret1 != 0)
            {
                DFTxt.ForeColor = Color.Red;
                ep.SetError(DFTxt, "Format Date invalide");
                b = false;

            }
            else
            {
                DFTxt.ForeColor = Color.Black;
                ep.SetError(DFTxt, "");

            }

            if ((ret0 == 0) && (ret1 == 0))
            {
                if (Fonctions.DateToInt(DDTxt.Text) > Fonctions.DateToInt(DFTxt.Text))
                {
                    DDTxt.ForeColor = Color.Red;
                    ep.SetError(DDTxt,"Date Debut inferieure a Date Fin");
                    DFTxt.ForeColor = Color.Red;
                    ep.SetError(DFTxt,"Date Fin inferieure a Date Debut");
                    b = false;

                }
                else
                {
                    DDTxt.ForeColor = Color.Black;
                    ep.SetError(DDTxt, "");
                    DFTxt.ForeColor = Color.Black;
                    ep.SetError(DFTxt, "");

                }

            }

            if (cmptcombo.SelectedIndex == -1)
            {
                cmptcombo.ForeColor = Color.Red;
                ep.SetError(cmptcombo, "le compte n'est pas sélectionné");
                b = false;

            }
            else
            {
                cmptcombo.ForeColor = Color.Black;
                ep.SetError(cmptcombo,"");
            }

            if (b == true)
            {
                SelectionCompte_VM.valid = true;
                SelectionCompte_VM.cmpt = cmptcombo.SelectedItem.ToString();
                SelectionCompte_VM.Intl = cmptintl.Text;
                SelectionCompte_VM.date1 = DDTxt.Text;
                SelectionCompte_VM.date2 = DFTxt.Text;
                SelectionCompte_VM.idate1 = Fonctions.DateToInt(DDTxt.Text).ToString();
                SelectionCompte_VM.idate2 = Fonctions.DateToInt(DFTxt.Text).ToString();
            }
            else SelectionCompte_VM.valid = false;



        }

       

	
		
	}
}
