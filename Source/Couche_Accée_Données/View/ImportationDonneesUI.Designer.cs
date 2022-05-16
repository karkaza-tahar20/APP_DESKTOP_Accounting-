namespace CoucheAcceeDonnees
{
    partial class ImportationDonneesUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportationDonneesUI));
            this.radioButton_importer_donnees = new System.Windows.Forms.RadioButton();
            this.radioButton_importer_donnees_anouveaux = new System.Windows.Forms.RadioButton();
            this.radioButton_raz_donnees = new System.Windows.Forms.RadioButton();
            this.Warn = new System.Windows.Forms.Label();
            this.Executer_Button = new System.Windows.Forms.Button();
            this.Quitter_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButton_importer_donnees
            // 
            this.radioButton_importer_donnees.AutoSize = true;
            this.radioButton_importer_donnees.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioButton_importer_donnees.Location = new System.Drawing.Point(90, 76);
            this.radioButton_importer_donnees.Name = "radioButton_importer_donnees";
            this.radioButton_importer_donnees.Size = new System.Drawing.Size(203, 19);
            this.radioButton_importer_donnees.TabIndex = 0;
            this.radioButton_importer_donnees.TabStop = true;
            this.radioButton_importer_donnees.Text = "Importation des données ";
            this.radioButton_importer_donnees.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton_importer_donnees.UseVisualStyleBackColor = true;
            // 
            // radioButton_importer_donnees_anouveaux
            // 
            this.radioButton_importer_donnees_anouveaux.AutoSize = true;
            this.radioButton_importer_donnees_anouveaux.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioButton_importer_donnees_anouveaux.Location = new System.Drawing.Point(90, 116);
            this.radioButton_importer_donnees_anouveaux.Name = "radioButton_importer_donnees_anouveaux";
            this.radioButton_importer_donnees_anouveaux.Size = new System.Drawing.Size(316, 19);
            this.radioButton_importer_donnees_anouveaux.TabIndex = 1;
            this.radioButton_importer_donnees_anouveaux.TabStop = true;
            this.radioButton_importer_donnees_anouveaux.Text = "Importation des données avec a nouveaux";
            this.radioButton_importer_donnees_anouveaux.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton_importer_donnees_anouveaux.UseVisualStyleBackColor = true;
            // 
            // radioButton_raz_donnees
            // 
            this.radioButton_raz_donnees.AutoSize = true;
            this.radioButton_raz_donnees.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioButton_raz_donnees.Location = new System.Drawing.Point(90, 157);
            this.radioButton_raz_donnees.Name = "radioButton_raz_donnees";
            this.radioButton_raz_donnees.Size = new System.Drawing.Size(212, 19);
            this.radioButton_raz_donnees.TabIndex = 2;
            this.radioButton_raz_donnees.TabStop = true;
            this.radioButton_raz_donnees.Text = "Remise a zero des données";
            this.radioButton_raz_donnees.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton_raz_donnees.UseVisualStyleBackColor = true;
            // 
            // Warn
            // 
            this.Warn.AutoSize = true;
            this.Warn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Warn.ForeColor = System.Drawing.Color.Red;
            this.Warn.Location = new System.Drawing.Point(72, 28);
            this.Warn.Name = "Warn";
            this.Warn.Size = new System.Drawing.Size(0, 18);
            this.Warn.TabIndex = 3;
            // 
            // Executer_Button
            // 
            this.Executer_Button.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Executer_Button.Location = new System.Drawing.Point(212, 227);
            this.Executer_Button.Name = "Executer_Button";
            this.Executer_Button.Size = new System.Drawing.Size(108, 25);
            this.Executer_Button.TabIndex = 4;
            this.Executer_Button.Text = "&Executer";
            this.Executer_Button.UseVisualStyleBackColor = true;
            this.Executer_Button.Click += new System.EventHandler(this.Executer_Button_Click);
            // 
            // Quitter_Button
            // 
            this.Quitter_Button.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Quitter_Button.Location = new System.Drawing.Point(360, 227);
            this.Quitter_Button.Name = "Quitter_Button";
            this.Quitter_Button.Size = new System.Drawing.Size(87, 25);
            this.Quitter_Button.TabIndex = 5;
            this.Quitter_Button.Text = "&Quitter";
            this.Quitter_Button.UseVisualStyleBackColor = true;
            this.Quitter_Button.Click += new System.EventHandler(this.Quitter_Button_Click);
            // 
            // ImportationDonneesUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(507, 273);
            this.Controls.Add(this.Quitter_Button);
            this.Controls.Add(this.Executer_Button);
            this.Controls.Add(this.Warn);
            this.Controls.Add(this.radioButton_raz_donnees);
            this.Controls.Add(this.radioButton_importer_donnees_anouveaux);
            this.Controls.Add(this.radioButton_importer_donnees);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportationDonneesUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importation";
            this.Load += new System.EventHandler(this.Importation_Données_UI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_importer_donnees;
        private System.Windows.Forms.RadioButton radioButton_importer_donnees_anouveaux;
        private System.Windows.Forms.RadioButton radioButton_raz_donnees;
        private System.Windows.Forms.Label Warn;
        private System.Windows.Forms.Button Executer_Button;
        private System.Windows.Forms.Button Quitter_Button;
    }
}