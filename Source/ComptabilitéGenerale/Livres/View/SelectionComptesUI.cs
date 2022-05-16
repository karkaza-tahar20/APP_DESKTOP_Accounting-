using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Utilitaire;

namespace LivresCompta
{
	
	public class SelectionComptesUI : System.Windows.Forms.Form
	{
        public System.Windows.Forms.Form parent;		
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        
        public System.Windows.Forms.TextBox DFTxt;
		public System.Windows.Forms.TextBox DDTxt;

		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Button submit;
		
		public System.Windows.Forms.TextBox cmptintd;
		public System.Windows.Forms.TextBox cmptintf;

		public System.Windows.Forms.ComboBox cmptdcombo;
		public System.Windows.Forms.ComboBox cmptfcombo;
		        
		private System.Windows.Forms.ErrorProvider ep;

        public SelectionComptesVM SelectionComptes_VM;

        public AffichageGrandLivreLogic GrandLivreLogic; 

        public DataSet ds;
        public string an;
        private IContainer components;

        public SelectionComptesUI()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionComptesUI));
            this.cmptintd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmptdcombo = new System.Windows.Forms.ComboBox();
            this.cancel = new System.Windows.Forms.Button();
            this.DFTxt = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.Label();
            this.DDTxt = new System.Windows.Forms.TextBox();
            this.l1 = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmptintf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmptfcombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // cmptintd
            // 
            this.cmptintd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmptintd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmptintd.Location = new System.Drawing.Point(384, 32);
            this.cmptintd.MaxLength = 10;
            this.cmptintd.Name = "cmptintd";
            this.cmptintd.ReadOnly = true;
            this.cmptintd.Size = new System.Drawing.Size(144, 20);
            this.cmptintd.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(281, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 23);
            this.label6.TabIndex = 26;
            this.label6.Text = "Intitulé  ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmptdcombo
            // 
            this.cmptdcombo.Location = new System.Drawing.Point(152, 31);
            this.cmptdcombo.Name = "cmptdcombo";
            this.cmptdcombo.Size = new System.Drawing.Size(106, 21);
            this.cmptdcombo.TabIndex = 25;
            this.cmptdcombo.SelectedIndexChanged += new System.EventHandler(this.idjdcombo_SelectedIndexChanged);
            this.cmptdcombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.idjdcombo_KeyDown);
            this.cmptdcombo.Validating += new System.ComponentModel.CancelEventHandler(this.idjdcombo_Validating);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.cancel.Location = new System.Drawing.Point(332, 179);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(104, 25);
            this.cancel.TabIndex = 24;
            this.cancel.Text = "&Annuler";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.Annuler_Click);
            // 
            // DFTxt
            // 
            this.DFTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DFTxt.Location = new System.Drawing.Point(383, 130);
            this.DFTxt.MaxLength = 10;
            this.DFTxt.Name = "DFTxt";
            this.DFTxt.Size = new System.Drawing.Size(80, 20);
            this.DFTxt.TabIndex = 23;
            this.DFTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DFTxt_KeyDown);
            this.DFTxt.Validating += new System.ComponentModel.CancelEventHandler(this.DFTxt_Validating);
            // 
            // l2
            // 
            this.l2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.l2.Location = new System.Drawing.Point(287, 130);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(90, 24);
            this.l2.TabIndex = 22;
            this.l2.Text = "Date Fin      ";
            this.l2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DDTxt
            // 
            this.DDTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DDTxt.Location = new System.Drawing.Point(177, 130);
            this.DDTxt.MaxLength = 10;
            this.DDTxt.Name = "DDTxt";
            this.DDTxt.Size = new System.Drawing.Size(80, 20);
            this.DDTxt.TabIndex = 21;
            this.DDTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DDTxt_KeyDown);
            this.DDTxt.Validating += new System.ComponentModel.CancelEventHandler(this.DDTxt_Validating);
            // 
            // l1
            // 
            this.l1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.l1.Location = new System.Drawing.Point(49, 133);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(88, 24);
            this.l1.TabIndex = 20;
            this.l1.Text = "Date Debut  ";
            this.l1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.submit.Location = new System.Drawing.Point(172, 179);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(96, 25);
            this.submit.TabIndex = 19;
            this.submit.Text = "&Valider";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.Valider_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(26, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Compte Debut ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmptintf
            // 
            this.cmptintf.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmptintf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmptintf.Location = new System.Drawing.Point(384, 72);
            this.cmptintf.MaxLength = 10;
            this.cmptintf.Name = "cmptintf";
            this.cmptintf.ReadOnly = true;
            this.cmptintf.Size = new System.Drawing.Size(144, 20);
            this.cmptintf.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(280, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "Intitulé ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmptfcombo
            // 
            this.cmptfcombo.Location = new System.Drawing.Point(152, 72);
            this.cmptfcombo.Name = "cmptfcombo";
            this.cmptfcombo.Size = new System.Drawing.Size(106, 21);
            this.cmptfcombo.TabIndex = 29;
            this.cmptfcombo.SelectedIndexChanged += new System.EventHandler(this.idjfcombo_SelectedIndexChanged);
            this.cmptfcombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.idjfcombo_KeyDown);
            this.cmptfcombo.Validating += new System.ComponentModel.CancelEventHandler(this.idjfcombo_Validating);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(39, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 24);
            this.label3.TabIndex = 28;
            this.label3.Text = "Compte Fin ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            this.ep.DataMember = "";
            // 
            // SelectionComptesUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(568, 226);
            this.Controls.Add(this.cmptintf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmptfcombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmptintd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmptdcombo);
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
            this.Name = "SelectionComptesUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SelectionComptesUI_Closing);
            this.Load += new System.EventHandler(this.SelectionComptesUI_Loaded);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void SelectionComptesUI_Loaded(object sender, System.EventArgs e)
		{
            string[] comptes = GrandLivreLogic.get_comptes();

            for (int i = 0; i < comptes.Length; i++)
            {
                cmptdcombo.Items.Add(comptes[i]);
                cmptfcombo.Items.Add(comptes[i]);
            }

            cmptintd.Text = "";
            cmptintf.Text = "";
            cmptdcombo.Select();
		}

        private void SelectionComptesUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			     	
		}
        
        private void idjdcombo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter) cmptfcombo.Focus();
		}

		private void idjfcombo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyData == Keys.Enter) DDTxt.Focus();
		}

		private void DDTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter) DFTxt.Focus();
		}

        private void DFTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyData == Keys.Enter) submit.Focus();
		}
        
        private void idjdcombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            string idjd = cmptdcombo.SelectedItem.ToString();
            cmptintd.Text = GrandLivreLogic.get_compte_intitule(idjd);
         
		
		}
        
        private void idjfcombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            string idjf = cmptfcombo.SelectedItem.ToString();
            cmptintf.Text = GrandLivreLogic.get_compte_intitule(idjf);
		
		}
        
		private void idjdcombo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (cmptdcombo.Text != "")
            {
                if (cmptdcombo.Items.IndexOf(cmptdcombo.Text) != -1)
                    cmptdcombo.SelectedIndex = cmptdcombo.Items.IndexOf(cmptdcombo.Text);
                cmptdcombo.ForeColor = Color.Black;
                ep.SetError(cmptdcombo, "");
            }
            else
            {
                cmptdcombo.ForeColor = Color.Red;
                ep.SetError(cmptdcombo, "le compte debut n'est pas sélectionné");

            }
		
		}

		private void idjfcombo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (cmptfcombo.Text != "")
            {
                if (cmptfcombo.Items.IndexOf(cmptdcombo.Text) != -1)
                    cmptfcombo.SelectedIndex = cmptdcombo.Items.IndexOf(cmptfcombo.Text);
                cmptfcombo.ForeColor = Color.Black;
                ep.SetError(cmptfcombo, "");
            }
            else
            {
                cmptfcombo.ForeColor = Color.Red;
                ep.SetError(cmptfcombo, "le compte fin n'est pas sélectionné");

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
                ep.SetError(DDTxt, "");
            }

        }

        private void DFTxt_Validating(object sender, CancelEventArgs e)
        {
            int ret = Validator.valide_DT(DFTxt.Text, an);
            if (ret != 0)
            {
                DFTxt.ForeColor = Color.Red;
                ep.SetError(DDTxt, "Format Date invalide");
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
            if (SelectionComptes_VM.valid == true) this.Close();
		
		}
		
		private void Annuler_Click(object sender, System.EventArgs e)
		{
            SelectionComptes_VM.valid = false;
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
                ep.SetError(DDTxt, "");
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
                    ep.SetError(DDTxt, "Date Debut superieur a Date Fin");
                    DFTxt.ForeColor = Color.Red;
                    ep.SetError(DFTxt, "Date Fin inferieur a Date Debut");
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

            if (cmptdcombo.SelectedIndex == -1)
            {
                cmptdcombo.ForeColor = Color.Red;
                ep.SetError(cmptdcombo, "le compte debut n'est pas sélectionné");
                b = false;

            }
            else
            {
                cmptdcombo.ForeColor = Color.Black;
                ep.SetError(cmptdcombo, "");
            }

            if (cmptfcombo.SelectedIndex == -1)
            {
                cmptfcombo.ForeColor = Color.Red;
                ep.SetError(cmptfcombo,"le compte fin n'est pas sélectionné");
                b = false;

            }
            else
            {
                cmptfcombo.ForeColor = Color.Black;
                ep.SetError(cmptfcombo, "");
            }

            if ((cmptdcombo.SelectedIndex != -1) && (cmptfcombo.SelectedIndex != -1))
            {
                if (Int32.Parse(cmptdcombo.SelectedItem.ToString()) > Int32.Parse(cmptfcombo.SelectedItem.ToString()))
                {
                    cmptdcombo.ForeColor = Color.Red;
                    ep.SetError(cmptdcombo, "Compte Debut superieur a Compte Fin");
                    cmptfcombo.ForeColor = Color.Red;
                    ep.SetError(cmptfcombo, "Compte Fin inferieur a Compte debut");
                    b = false;

                }
                else
                {
                    cmptdcombo.ForeColor = Color.Black;
                    ep.SetError(cmptdcombo, "");
                    cmptfcombo.ForeColor = Color.Black;
                    ep.SetError(cmptfcombo,"");

                }


            }


            if (b == true)
            {
                SelectionComptes_VM.valid = true;

                SelectionComptes_VM.intld = cmptintd.Text;
                SelectionComptes_VM.intlf = cmptintf.Text;
                SelectionComptes_VM.date1 = DDTxt.Text;
                SelectionComptes_VM.date2 = DFTxt.Text;
                SelectionComptes_VM.idate1 = Fonctions.DateToInt(DDTxt.Text).ToString();
                SelectionComptes_VM.idate2 = Fonctions.DateToInt(DFTxt.Text).ToString();

                
                SelectionComptes_VM.cmpts = GrandLivreLogic.get_comptes(cmptdcombo.SelectedItem.ToString(), cmptfcombo.SelectedItem.ToString());
              


            }
            else SelectionComptes_VM.valid = false;



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

        

	}

