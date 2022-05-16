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
	/// Description résumée de cagence.
	/// </summary>
    public class SelectionJournalUI : System.Windows.Forms.Form
	{
        public System.Windows.Forms.Form parent;
		private System.Windows.Forms.Label label1;	
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label l2;
		private System.Windows.Forms.Label l1;
	
        public System.Windows.Forms.TextBox DFTxt;
		public System.Windows.Forms.TextBox DDTxt;
        public System.Windows.Forms.TextBox nj;

		private System.Windows.Forms.ComboBox idcombo;

		private System.Windows.Forms.ErrorProvider ep;

		private System.Windows.Forms.Button submit;
		private System.Windows.Forms.Button cancel;
	    
        public string idj;
        private IContainer components;

        public SelectionJournalVM SelectionJournal_VM;
        public AffichageJournauxLogic JournauxLogic;
              
        public string an;

		public SelectionJournalUI()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionJournalUI));
            this.label1 = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.DFTxt = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.Label();
            this.DDTxt = new System.Windows.Forms.TextBox();
            this.l1 = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.cancel = new System.Windows.Forms.Button();
            this.idcombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nj = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(36, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code Journal ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.submit.Location = new System.Drawing.Point(112, 151);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(96, 24);
            this.submit.TabIndex = 2;
            this.submit.Text = "&Valider";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.Valider_Click);
            // 
            // DFTxt
            // 
            this.DFTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DFTxt.Location = new System.Drawing.Point(268, 95);
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
            this.l2.Location = new System.Drawing.Point(156, 95);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(80, 24);
            this.l2.TabIndex = 6;
            this.l2.Text = "Date Fin      ";
            this.l2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DDTxt
            // 
            this.DDTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DDTxt.Location = new System.Drawing.Point(268, 63);
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
            this.l1.Location = new System.Drawing.Point(156, 63);
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
            this.cancel.Location = new System.Drawing.Point(288, 151);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(104, 24);
            this.cancel.TabIndex = 8;
            this.cancel.Text = "&Annuler";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.Anuller_Click);
            // 
            // idcombo
            // 
            this.idcombo.Location = new System.Drawing.Point(148, 15);
            this.idcombo.Name = "idcombo";
            this.idcombo.Size = new System.Drawing.Size(60, 21);
            this.idcombo.TabIndex = 9;
            this.idcombo.SelectedIndexChanged += new System.EventHandler(this.idcombo_SelectedIndexChanged);
            this.idcombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.idcombo_KeyDown);
            this.idcombo.Validating += new System.ComponentModel.CancelEventHandler(this.idcombo_Validating);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(240, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "Intitulé ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nj
            // 
            this.nj.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nj.Location = new System.Drawing.Point(324, 15);
            this.nj.MaxLength = 10;
            this.nj.Name = "nj";
            this.nj.ReadOnly = true;
            this.nj.Size = new System.Drawing.Size(144, 20);
            this.nj.TabIndex = 17;
            // 
            // SelectionJournalUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.LightBlue;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(504, 190);
            this.Controls.Add(this.nj);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.idcombo);
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
            this.Name = "SelectionJournalUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SelectionJournalUI_Closing);
            this.Load += new System.EventHandler(this.SelectionJournalUI_Loaded);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


        private void SelectionJournalUI_Loaded(object sender, System.EventArgs e)
		{
            string[] codes = JournauxLogic.get_codes_journaux();

            for (int i = 0; i < codes.Length; i++ )
                idcombo.Items.Add(codes[i]);

            idcombo.Select();
            nj.Text = "";
            
		
		}

        private void SelectionJournalUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		} 
        
        private void idcombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            string idj = idcombo.SelectedItem.ToString();
            nj.Text = JournauxLogic.get_journal_intitule(idj);
        
		}
        
        private void idcombo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyData == Keys.Enter) DDTxt.Focus();
		}
        private void DDTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) DFTxt.Focus();
			if (e.KeyData == Keys.Up) idcombo.Focus();
		}
        private void DFTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if ((e.KeyData == Keys.Down)||(e.KeyData == Keys.Enter)) submit.Focus();;
            if (e.KeyData == Keys.Up) DDTxt.Focus();
		}
		
		private void idcombo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (idcombo.Text != "")
            {
                if (idcombo.Items.IndexOf(idcombo.Text) != -1)
                    idcombo.SelectedIndex = idcombo.Items.IndexOf(idcombo.Text);
                idcombo.ForeColor = Color.Black;
                ep.SetError( idcombo, "" );
            }
            else
            {
                idcombo.ForeColor = Color.Red;
                ep.SetError( idcombo,"le code journal auxilliaire n'est pas sélectionné");

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
            if (SelectionJournal_VM.valid == true)
            {
                Close();
            }
		}
	
        private void Anuller_Click(object sender, System.EventArgs e)
		{
            SelectionJournal_VM.valid = false;
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

            if (idcombo.SelectedIndex == -1)
            {
                idcombo.ForeColor = Color.Red;
                ep.SetError(idcombo, "le code journal auxilliaire n'est pas sélectionné");
                b = false;

            }
            else
            {
                idcombo.ForeColor = Color.Black;
                ep.SetError(idcombo,"");
            }

            if (b == true)
            {
                SelectionJournal_VM.valid = true;
                SelectionJournal_VM.idj = idcombo.SelectedItem.ToString();
                SelectionJournal_VM.nj = nj.Text;
                SelectionJournal_VM.date1 = DDTxt.Text;
                SelectionJournal_VM.date2 = DFTxt.Text;
                SelectionJournal_VM.idate1 = Fonctions.DateToInt(DDTxt.Text).ToString();
                SelectionJournal_VM.idate2 = Fonctions.DateToInt(DFTxt.Text).ToString();
            }
            else SelectionJournal_VM.valid = false;



        }

       

	
		
	}
}
