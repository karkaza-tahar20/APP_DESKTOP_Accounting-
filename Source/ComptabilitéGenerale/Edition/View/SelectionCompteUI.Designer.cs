namespace EditionCompta
{
    partial class SelectionCompteUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionCompteUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PartielButton = new System.Windows.Forms.RadioButton();
            this.GlobalButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.TriParCompteButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.CompteDebutTxt = new System.Windows.Forms.TextBox();
            this.CompteFinTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.warn = new System.Windows.Forms.Label();
            this.Valider_Button = new System.Windows.Forms.Button();
            this.Anuller_Button = new System.Windows.Forms.Button();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.PartielButton);
            this.groupBox1.Controls.Add(this.GlobalButton);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection";
            // 
            // PartielButton
            // 
            this.PartielButton.AutoSize = true;
            this.PartielButton.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.PartielButton.Location = new System.Drawing.Point(240, 22);
            this.PartielButton.Name = "PartielButton";
            this.PartielButton.Size = new System.Drawing.Size(67, 19);
            this.PartielButton.TabIndex = 2;
            this.PartielButton.TabStop = true;
            this.PartielButton.Text = "Partiel";
            this.PartielButton.UseVisualStyleBackColor = true;
            // 
            // GlobalButton
            // 
            this.GlobalButton.AutoSize = true;
            this.GlobalButton.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.GlobalButton.Location = new System.Drawing.Point(29, 22);
            this.GlobalButton.Name = "GlobalButton";
            this.GlobalButton.Size = new System.Drawing.Size(68, 19);
            this.GlobalButton.TabIndex = 0;
            this.GlobalButton.TabStop = true;
            this.GlobalButton.Text = "Global";
            this.GlobalButton.UseVisualStyleBackColor = true;
            this.GlobalButton.CheckedChanged += new System.EventHandler(this.GlobalButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.TriParCompteButton);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(16, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 50);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tri";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioButton4.Location = new System.Drawing.Point(238, 19);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(121, 19);
            this.radioButton4.TabIndex = 2;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Tri Par Intitulé";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // TriParCompteButton
            // 
            this.TriParCompteButton.AutoSize = true;
            this.TriParCompteButton.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.TriParCompteButton.Location = new System.Drawing.Point(27, 19);
            this.TriParCompteButton.Name = "TriParCompteButton";
            this.TriParCompteButton.Size = new System.Drawing.Size(103, 19);
            this.TriParCompteButton.TabIndex = 2;
            this.TriParCompteButton.TabStop = true;
            this.TriParCompteButton.Text = "Par Compte";
            this.TriParCompteButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(66, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Compte Debut :";
            // 
            // CompteDebutTxt
            // 
            this.CompteDebutTxt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CompteDebutTxt.Enabled = false;
            this.CompteDebutTxt.Location = new System.Drawing.Point(190, 156);
            this.CompteDebutTxt.MaxLength = 8;
            this.CompteDebutTxt.Name = "CompteDebutTxt";
            this.CompteDebutTxt.Size = new System.Drawing.Size(116, 20);
            this.CompteDebutTxt.TabIndex = 3;
            this.CompteDebutTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompteDebutTxt_KeyDown);
            this.CompteDebutTxt.Validating += new System.ComponentModel.CancelEventHandler(this.CompteDebutTxt_Validating);
            // 
            // CompteFinTxt
            // 
            this.CompteFinTxt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CompteFinTxt.Enabled = false;
            this.CompteFinTxt.Location = new System.Drawing.Point(190, 197);
            this.CompteFinTxt.MaxLength = 8;
            this.CompteFinTxt.Name = "CompteFinTxt";
            this.CompteFinTxt.Size = new System.Drawing.Size(116, 20);
            this.CompteFinTxt.TabIndex = 5;
            this.CompteFinTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompteFinTxt_KeyDown);
            this.CompteFinTxt.Validating += new System.ComponentModel.CancelEventHandler(this.CompteFinTxt_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(66, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Compte Fin :";
            // 
            // warn
            // 
            this.warn.AutoSize = true;
            this.warn.ForeColor = System.Drawing.Color.Red;
            this.warn.Location = new System.Drawing.Point(134, 131);
            this.warn.Name = "warn";
            this.warn.Size = new System.Drawing.Size(0, 13);
            this.warn.TabIndex = 6;
            // 
            // Valider_Button
            // 
            this.Valider_Button.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Valider_Button.Location = new System.Drawing.Point(41, 246);
            this.Valider_Button.Name = "Valider_Button";
            this.Valider_Button.Size = new System.Drawing.Size(87, 25);
            this.Valider_Button.TabIndex = 7;
            this.Valider_Button.Text = "&Valider";
            this.Valider_Button.UseVisualStyleBackColor = true;
            this.Valider_Button.Click += new System.EventHandler(this.Valider_Button_Click);
            // 
            // Anuller_Button
            // 
            this.Anuller_Button.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Anuller_Button.Location = new System.Drawing.Point(254, 246);
            this.Anuller_Button.Name = "Anuller_Button";
            this.Anuller_Button.Size = new System.Drawing.Size(87, 25);
            this.Anuller_Button.TabIndex = 8;
            this.Anuller_Button.Text = "&Annuler";
            this.Anuller_Button.UseVisualStyleBackColor = true;
            this.Anuller_Button.Click += new System.EventHandler(this.Anuller_Button_Click);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // SelectionCompteUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(393, 291);
            this.Controls.Add(this.Anuller_Button);
            this.Controls.Add(this.Valider_Button);
            this.Controls.Add(this.warn);
            this.Controls.Add(this.CompteFinTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CompteDebutTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectionCompteUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selection Compte";
            this.Load += new System.EventHandler(this.Selection_Compte_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton PartielButton;
        private System.Windows.Forms.RadioButton GlobalButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton TriParCompteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CompteDebutTxt;
        private System.Windows.Forms.TextBox CompteFinTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label warn;
        private System.Windows.Forms.Button Valider_Button;
        private System.Windows.Forms.Button Anuller_Button;
        private System.Windows.Forms.ErrorProvider ep;
    }
}