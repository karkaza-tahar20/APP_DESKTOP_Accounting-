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
	/// Description résumée de jmdebutfin.
	/// </summary>
	public class SelectionJournauxUI : System.Windows.Forms.Form
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
		
		public System.Windows.Forms.TextBox njd;
		public System.Windows.Forms.TextBox njf;

		public System.Windows.Forms.ComboBox idjdcombo;
		public System.Windows.Forms.ComboBox idjfcombo;
		
        
		private System.Windows.Forms.ErrorProvider ep;
		public string idjd,idjf;

        public SelectionJournauxVM SelectionJournaux_VM;
        public AffichageJournauxLogic JournauxLogic;
                
        public string an;
        private IContainer components;

        public SelectionJournauxUI()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionJournauxUI));
            this.njd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.idjdcombo = new System.Windows.Forms.ComboBox();
            this.cancel = new System.Windows.Forms.Button();
            this.DFTxt = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.Label();
            this.DDTxt = new System.Windows.Forms.TextBox();
            this.l1 = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.njf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idjfcombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // njd
            // 
            this.njd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.njd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.njd.Location = new System.Drawing.Point(384, 32);
            this.njd.MaxLength = 10;
            this.njd.Name = "njd";
            this.njd.ReadOnly = true;
            this.njd.Size = new System.Drawing.Size(144, 20);
            this.njd.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(290, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 23);
            this.label6.TabIndex = 26;
            this.label6.Text = "Intitulé ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // idjdcombo
            // 
            this.idjdcombo.Location = new System.Drawing.Point(163, 32);
            this.idjdcombo.Name = "idjdcombo";
            this.idjdcombo.Size = new System.Drawing.Size(60, 21);
            this.idjdcombo.TabIndex = 25;
            this.idjdcombo.SelectedIndexChanged += new System.EventHandler(this.idjdcombo_SelectedIndexChanged);
            this.idjdcombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.idjdcombo_KeyDown);
            this.idjdcombo.Validating += new System.ComponentModel.CancelEventHandler(this.idjdcombo_Validating);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.cancel.Location = new System.Drawing.Point(312, 160);
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
            this.DFTxt.Location = new System.Drawing.Point(384, 112);
            this.DFTxt.MaxLength = 10;
            this.DFTxt.Name = "DFTxt";
            this.DFTxt.Size = new System.Drawing.Size(80, 20);
            this.DFTxt.TabIndex = 23;
            this.DFTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DFTxt_KeyDown);
            this.DFTxt.Validating += new System.ComponentModel.CancelEventHandler(this.DFTxt_Validating);
            // 
            // l2
            // 
            this.l2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l2.Location = new System.Drawing.Point(300, 108);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(64, 24);
            this.l2.TabIndex = 22;
            this.l2.Text = "Date Fin  ";
            this.l2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DDTxt
            // 
            this.DDTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DDTxt.Location = new System.Drawing.Point(163, 112);
            this.DDTxt.MaxLength = 10;
            this.DDTxt.Name = "DDTxt";
            this.DDTxt.Size = new System.Drawing.Size(80, 20);
            this.DDTxt.TabIndex = 21;
            this.DDTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DDTxt_KeyDown);
            this.DDTxt.Validating += new System.ComponentModel.CancelEventHandler(this.DDTxt_Validating);
            // 
            // l1
            // 
            this.l1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l1.Location = new System.Drawing.Point(57, 112);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(75, 24);
            this.l1.TabIndex = 20;
            this.l1.Text = "Date Debut  ";
            this.l1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.submit.Location = new System.Drawing.Point(152, 160);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(96, 25);
            this.submit.TabIndex = 19;
            this.submit.Text = "&Valider";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.Valider_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Code Journal Debut :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // njf
            // 
            this.njf.BackColor = System.Drawing.SystemColors.HighlightText;
            this.njf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.njf.Location = new System.Drawing.Point(384, 72);
            this.njf.MaxLength = 10;
            this.njf.Name = "njf";
            this.njf.ReadOnly = true;
            this.njf.Size = new System.Drawing.Size(144, 20);
            this.njf.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(290, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "Intitulé ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // idjfcombo
            // 
            this.idjfcombo.Location = new System.Drawing.Point(163, 72);
            this.idjfcombo.Name = "idjfcombo";
            this.idjfcombo.Size = new System.Drawing.Size(60, 21);
            this.idjfcombo.TabIndex = 29;
            this.idjfcombo.SelectedIndexChanged += new System.EventHandler(this.idjfcombo_SelectedIndexChanged);
            this.idjfcombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.idjfcombo_KeyDown);
            this.idjfcombo.Validating += new System.ComponentModel.CancelEventHandler(this.idjfcombo_Validating);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 24);
            this.label3.TabIndex = 28;
            this.label3.Text = "Code Journal Fin ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            this.ep.DataMember = "";
            // 
            // SelectionJournauxUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(568, 206);
            this.Controls.Add(this.njf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idjfcombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.njd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.idjdcombo);
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
            this.Name = "SelectionJournauxUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selection Journaux";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SelectionJournauxUI_Closing);
            this.Load += new System.EventHandler(this.SelectionJournauxUI_Loaded);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void SelectionJournauxUI_Loaded(object sender, System.EventArgs e)
		{
            string[] codes = JournauxLogic.get_codes_journaux();
            for (int i = 0; i < codes.Length; i++ )
            {
                idjdcombo.Items.Add(codes[i]);
                idjfcombo.Items.Add(codes[i]);
            }

            njd.Text = "";
            njf.Text = "";
            idjdcombo.Select();
		}

        private void SelectionJournauxUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			     	
		}
        
        private void idjdcombo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter) idjfcombo.Focus();
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
            string idjd = idjdcombo.SelectedItem.ToString();
            njd.Text = JournauxLogic.get_journal_intitule(idjd);
            
		
		}
        
        private void idjfcombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            string idjf = idjfcombo.SelectedItem.ToString();
            njf.Text = JournauxLogic.get_journal_intitule(idjf);
		
		}
        
		private void idjdcombo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (idjdcombo.Text != "")
            {
                if (idjdcombo.Items.IndexOf(idjdcombo.Text) != -1)
                    idjdcombo.SelectedIndex = idjdcombo.Items.IndexOf(idjdcombo.Text);
                idjdcombo.ForeColor = Color.Black;
                ep.SetError(idjdcombo, "");
            }
            else
            {
                idjdcombo.ForeColor = Color.Red;
                ep.SetError(idjdcombo, "le code journal auxilliaire debut n'est pas sélectionné");

            }
		
		}

		private void idjfcombo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (idjfcombo.Text != "")
            {
                if (idjfcombo.Items.IndexOf(idjdcombo.Text) != -1)
                    idjfcombo.SelectedIndex = idjdcombo.Items.IndexOf(idjfcombo.Text);
                idjfcombo.ForeColor = Color.Black;
                ep.SetError(idjfcombo, "");
            }
            else
            {
                idjfcombo.ForeColor = Color.Red;
                ep.SetError(idjfcombo, "le code journal auxilliaire debut n'est pas sélectionné");

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
            if (SelectionJournaux_VM.valid == true) this.Close();
		
		}
		
		private void Annuler_Click(object sender, System.EventArgs e)
		{
            SelectionJournaux_VM.valid = false;
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

            if (idjdcombo.SelectedIndex == -1)
            {
                idjdcombo.ForeColor = Color.Red;
                ep.SetError(idjdcombo, "le code journal auxilliaire debut n'est pas sélectionné");
                b = false;

            }
            else
            {
                idjdcombo.ForeColor = Color.Black;
                ep.SetError(idjdcombo, "");
            }

            if (idjfcombo.SelectedIndex == -1)
            {
                idjfcombo.ForeColor = Color.Red;
                ep.SetError(idjfcombo,"le code journal fin auxilliaire n'est pas sélectionné");
                b = false;

            }
            else
            {
                idjfcombo.ForeColor = Color.Black;
                ep.SetError(idjfcombo, "");
            }

            if ((idjdcombo.SelectedIndex != -1) && (idjfcombo.SelectedIndex != -1))
            {
                if (Int32.Parse(idjdcombo.SelectedItem.ToString()) > Int32.Parse(idjfcombo.SelectedItem.ToString()))
                {
                    idjdcombo.ForeColor = Color.Red;
                    ep.SetError(idjdcombo, "Code Journal Debut superieur a Code Journal Fin");
                    idjfcombo.ForeColor = Color.Red;
                    ep.SetError(idjfcombo, "Code Journal Fin inferieur a Code Journal debut");
                    b = false;

                }
                else
                {
                    idjdcombo.ForeColor = Color.Black;
                    ep.SetError(idjdcombo, "");
                    idjfcombo.ForeColor = Color.Black;
                    ep.SetError(idjfcombo,"");

                }


            }


            if (b == true)
            {
                SelectionJournaux_VM.valid = true;

                SelectionJournaux_VM.njd = njd.Text;
                SelectionJournaux_VM.njf = njf.Text;
                SelectionJournaux_VM.date1 = DDTxt.Text;
                SelectionJournaux_VM.date2 = DFTxt.Text;
                SelectionJournaux_VM.idate1 = Fonctions.DateToInt(DDTxt.Text).ToString();
                SelectionJournaux_VM.idate2 = Fonctions.DateToInt(DFTxt.Text).ToString();

              

                string[] codes = JournauxLogic.get_codes_journaux(idjdcombo.SelectedItem.ToString(), idjfcombo.SelectedItem.ToString());
                SelectionJournaux_VM.idjs = new String[codes.Length];
                for (int i = 0; i < codes.Length; i++)
                    SelectionJournaux_VM.idjs[i] = codes[i];


            }
            else SelectionJournaux_VM.valid = false;



        }

        

       
        }

        

	}

