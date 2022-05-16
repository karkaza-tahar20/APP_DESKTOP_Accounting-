namespace CoucheAcceeDonnees
{
    partial class DossierUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DossierUI));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RaisonSocialTxt = new System.Windows.Forms.TextBox();
            this.AnneeTxt = new System.Windows.Forms.TextBox();
            this.ModifierButton = new System.Windows.Forms.Button();
            this.warn = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AdresseTxt = new System.Windows.Forms.TextBox();
            this.VilleTxt = new System.Windows.Forms.TextBox();
            this.EmailTxt = new System.Windows.Forms.TextBox();
            this.TeleTxt = new System.Windows.Forms.TextBox();
            this.NomSocieteTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Raison Social ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(228, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Annee ";
            // 
            // RaisonSocialTxt
            // 
            this.RaisonSocialTxt.Location = new System.Drawing.Point(114, 73);
            this.RaisonSocialTxt.Name = "RaisonSocialTxt";
            this.RaisonSocialTxt.Size = new System.Drawing.Size(170, 20);
            this.RaisonSocialTxt.TabIndex = 2;
            this.RaisonSocialTxt.TextChanged += new System.EventHandler(this.RaisonSocialTxt_TextChanged);
            this.RaisonSocialTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RaisonSocialTxt_KeyDown);
            this.RaisonSocialTxt.Validating += new System.ComponentModel.CancelEventHandler(this.RaisonSocialTxt_Validating);
            // 
            // AnneeTxt
            // 
            this.AnneeTxt.Location = new System.Drawing.Point(311, 12);
            this.AnneeTxt.MaxLength = 4;
            this.AnneeTxt.Name = "AnneeTxt";
            this.AnneeTxt.Size = new System.Drawing.Size(49, 20);
            this.AnneeTxt.TabIndex = 3;
            this.AnneeTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AnneeTxt_KeyDown);
            this.AnneeTxt.Validating += new System.ComponentModel.CancelEventHandler(this.AnneeTxt_Validating);
            // 
            // ModifierButton
            // 
            this.ModifierButton.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.ModifierButton.Location = new System.Drawing.Point(352, 224);
            this.ModifierButton.Name = "ModifierButton";
            this.ModifierButton.Size = new System.Drawing.Size(75, 25);
            this.ModifierButton.TabIndex = 4;
            this.ModifierButton.Text = "&Modifier";
            this.ModifierButton.UseVisualStyleBackColor = true;
            this.ModifierButton.Click += new System.EventHandler(this.ModifierButton_Click);
            // 
            // warn
            // 
            this.warn.AutoSize = true;
            this.warn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.warn.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warn.ForeColor = System.Drawing.Color.Green;
            this.warn.Location = new System.Drawing.Point(6, 15);
            this.warn.Name = "warn";
            this.warn.Size = new System.Drawing.Size(0, 16);
            this.warn.TabIndex = 33;
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(455, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 34;
            this.button1.Text = "&Quitter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(303, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 19);
            this.label5.TabIndex = 35;
            this.label5.Text = "Nom Société";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 19);
            this.label3.TabIndex = 36;
            this.label3.Text = "Ville";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(307, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 19);
            this.label6.TabIndex = 37;
            this.label6.Text = "Telephone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 38;
            this.label4.Text = "Adresse";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(307, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 19);
            this.label7.TabIndex = 39;
            this.label7.Text = "Email";
            // 
            // AdresseTxt
            // 
            this.AdresseTxt.Location = new System.Drawing.Point(114, 150);
            this.AdresseTxt.Name = "AdresseTxt";
            this.AdresseTxt.Size = new System.Drawing.Size(170, 20);
            this.AdresseTxt.TabIndex = 41;
            // 
            // VilleTxt
            // 
            this.VilleTxt.Location = new System.Drawing.Point(114, 112);
            this.VilleTxt.Name = "VilleTxt";
            this.VilleTxt.Size = new System.Drawing.Size(170, 20);
            this.VilleTxt.TabIndex = 42;
            // 
            // EmailTxt
            // 
            this.EmailTxt.Location = new System.Drawing.Point(402, 150);
            this.EmailTxt.Name = "EmailTxt";
            this.EmailTxt.Size = new System.Drawing.Size(179, 20);
            this.EmailTxt.TabIndex = 43;
            // 
            // TeleTxt
            // 
            this.TeleTxt.Location = new System.Drawing.Point(402, 112);
            this.TeleTxt.Name = "TeleTxt";
            this.TeleTxt.Size = new System.Drawing.Size(179, 20);
            this.TeleTxt.TabIndex = 44;
            // 
            // NomSocieteTxt
            // 
            this.NomSocieteTxt.Location = new System.Drawing.Point(402, 73);
            this.NomSocieteTxt.Name = "NomSocieteTxt";
            this.NomSocieteTxt.Size = new System.Drawing.Size(179, 20);
            this.NomSocieteTxt.TabIndex = 45;
            this.NomSocieteTxt.TextChanged += new System.EventHandler(this.NomSocieteTxt_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(586, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 277);
            this.panel1.TabIndex = 46;
            // 
            // DossierUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(873, 273);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.NomSocieteTxt);
            this.Controls.Add(this.TeleTxt);
            this.Controls.Add(this.EmailTxt);
            this.Controls.Add(this.VilleTxt);
            this.Controls.Add(this.AdresseTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.warn);
            this.Controls.Add(this.ModifierButton);
            this.Controls.Add(this.AnneeTxt);
            this.Controls.Add(this.RaisonSocialTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DossierUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informations Société";
            this.Load += new System.EventHandler(this.DossierUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox RaisonSocialTxt;
        public System.Windows.Forms.TextBox AnneeTxt;
        private System.Windows.Forms.Button ModifierButton;
        private System.Windows.Forms.Label warn;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox NomSocieteTxt;
        public System.Windows.Forms.TextBox TeleTxt;
        public System.Windows.Forms.TextBox EmailTxt;
        public System.Windows.Forms.TextBox VilleTxt;
        public System.Windows.Forms.TextBox AdresseTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}