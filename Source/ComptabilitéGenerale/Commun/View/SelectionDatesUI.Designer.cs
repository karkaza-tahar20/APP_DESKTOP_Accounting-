namespace Compta.Commun
{
    partial class SelectionDatesUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionDatesUI));
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DDTxt = new System.Windows.Forms.TextBox();
            this.DFTxt = new System.Windows.Forms.TextBox();
            this.Valider = new System.Windows.Forms.Button();
            this.Anuller = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date Debut ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date Fin ";
            // 
            // DDTxt
            // 
            this.DDTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DDTxt.Location = new System.Drawing.Point(194, 27);
            this.DDTxt.Name = "DDTxt";
            this.DDTxt.Size = new System.Drawing.Size(100, 21);
            this.DDTxt.TabIndex = 2;
            this.DDTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DDTxt_KeyDown);
            this.DDTxt.Validating += new System.ComponentModel.CancelEventHandler(this.DDTxt_Validating);
            // 
            // DFTxt
            // 
            this.DFTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DFTxt.Location = new System.Drawing.Point(194, 63);
            this.DFTxt.Name = "DFTxt";
            this.DFTxt.Size = new System.Drawing.Size(100, 21);
            this.DFTxt.TabIndex = 3;
            this.DFTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DFTxt_KeyDown);
            this.DFTxt.Validating += new System.ComponentModel.CancelEventHandler(this.DFTxt_Validating);
            // 
            // Valider
            // 
            this.Valider.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Valider.Location = new System.Drawing.Point(67, 117);
            this.Valider.Name = "Valider";
            this.Valider.Size = new System.Drawing.Size(91, 23);
            this.Valider.TabIndex = 4;
            this.Valider.Text = "&Valider";
            this.Valider.UseVisualStyleBackColor = true;
            this.Valider.Click += new System.EventHandler(this.Valider_Click);
            // 
            // Anuller
            // 
            this.Anuller.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Anuller.Location = new System.Drawing.Point(212, 117);
            this.Anuller.Name = "Anuller";
            this.Anuller.Size = new System.Drawing.Size(91, 23);
            this.Anuller.TabIndex = 5;
            this.Anuller.Text = "&Quitter";
            this.Anuller.UseVisualStyleBackColor = true;
            this.Anuller.Click += new System.EventHandler(this.Anuller_Click);
            // 
            // SelectionDatesUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(367, 162);
            this.Controls.Add(this.Anuller);
            this.Controls.Add(this.Valider);
            this.Controls.Add(this.DFTxt);
            this.Controls.Add(this.DDTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectionDatesUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SelectionDatesUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.Button Anuller;
        private System.Windows.Forms.Button Valider;
        private System.Windows.Forms.TextBox DFTxt;
        private System.Windows.Forms.TextBox DDTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}