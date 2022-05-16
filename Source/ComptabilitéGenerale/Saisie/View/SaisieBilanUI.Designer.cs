
namespace ComptabiliteGenerale.Saisie.View
{
    partial class SaisieBilanUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaisieBilanUI));
            this.panel1 = new System.Windows.Forms.Panel();
            this.SoldeActifTxt = new System.Windows.Forms.TextBox();
            this.LibelleActifTxt = new System.Windows.Forms.TextBox();
            this.CmpActifTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SoldePassifTxt = new System.Windows.Forms.TextBox();
            this.LibellePassifTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmpPassifTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgbilan = new System.Windows.Forms.DataGridView();
            this.compteActifDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.libelleActifDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soldeActifDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comptePassifDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.libellePassifDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soldePassifDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billanBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.comptaDataSet2 = new ComptabiliteGenerale.ComptaDataSet2();
            this.billanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comptaDataSet = new ComptabiliteGenerale.ComptaDataSet();
            this.billanTableAdapter = new ComptabiliteGenerale.ComptaDataSetTableAdapters.BillanTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TotaleActifTxt = new System.Windows.Forms.TextBox();
            this.TotalePassifTxt = new System.Windows.Forms.TextBox();
            this.warn = new System.Windows.Forms.Label();
            this.AnneeTxt = new System.Windows.Forms.Label();
            this.comptaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comptaDataSet1 = new ComptabiliteGenerale.ComptaDataSet1();
            this.billanBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.billanTableAdapter1 = new ComptabiliteGenerale.ComptaDataSet1TableAdapters.BillanTableAdapter();
            this.billanTableAdapter2 = new ComptabiliteGenerale.ComptaDataSet2TableAdapters.BillanTableAdapter();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbilan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billanBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comptaDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comptaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comptaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comptaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billanBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SoldeActifTxt);
            this.panel1.Controls.Add(this.LibelleActifTxt);
            this.panel1.Controls.Add(this.CmpActifTxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(3, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 95);
            this.panel1.TabIndex = 0;
            // 
            // SoldeActifTxt
            // 
            this.SoldeActifTxt.Location = new System.Drawing.Point(298, 67);
            this.SoldeActifTxt.Name = "SoldeActifTxt";
            this.SoldeActifTxt.Size = new System.Drawing.Size(97, 20);
            this.SoldeActifTxt.TabIndex = 8;
            // 
            // LibelleActifTxt
            // 
            this.LibelleActifTxt.Location = new System.Drawing.Point(106, 67);
            this.LibelleActifTxt.Name = "LibelleActifTxt";
            this.LibelleActifTxt.Size = new System.Drawing.Size(194, 20);
            this.LibelleActifTxt.TabIndex = 7;
            this.LibelleActifTxt.TextChanged += new System.EventHandler(this.LibelleActifTxt_TextChanged);
            // 
            // CmpActifTxt
            // 
            this.CmpActifTxt.Location = new System.Drawing.Point(11, 67);
            this.CmpActifTxt.Name = "CmpActifTxt";
            this.CmpActifTxt.Size = new System.Drawing.Size(96, 20);
            this.CmpActifTxt.TabIndex = 5;
            this.CmpActifTxt.TextChanged += new System.EventHandler(this.CmpActifTxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(144, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Actif";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SoldePassifTxt);
            this.panel2.Controls.Add(this.LibellePassifTxt);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.CmpPassifTxt);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(408, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 95);
            this.panel2.TabIndex = 1;
            // 
            // SoldePassifTxt
            // 
            this.SoldePassifTxt.Location = new System.Drawing.Point(290, 67);
            this.SoldePassifTxt.Name = "SoldePassifTxt";
            this.SoldePassifTxt.Size = new System.Drawing.Size(97, 20);
            this.SoldePassifTxt.TabIndex = 11;
            // 
            // LibellePassifTxt
            // 
            this.LibellePassifTxt.Location = new System.Drawing.Point(99, 67);
            this.LibellePassifTxt.Name = "LibellePassifTxt";
            this.LibellePassifTxt.Size = new System.Drawing.Size(194, 20);
            this.LibellePassifTxt.TabIndex = 10;
            this.LibellePassifTxt.TextChanged += new System.EventHandler(this.LibellePassifTxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(148, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Passif";
            // 
            // CmpPassifTxt
            // 
            this.CmpPassifTxt.Location = new System.Drawing.Point(4, 67);
            this.CmpPassifTxt.Name = "CmpPassifTxt";
            this.CmpPassifTxt.Size = new System.Drawing.Size(96, 20);
            this.CmpPassifTxt.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(332, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bilan au ";
            // 
            // dgbilan
            // 
            this.dgbilan.AllowDrop = true;
            this.dgbilan.AllowUserToAddRows = false;
            this.dgbilan.AllowUserToResizeColumns = false;
            this.dgbilan.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgbilan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgbilan.AutoGenerateColumns = false;
            this.dgbilan.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgbilan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgbilan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgbilan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgbilan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgbilan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.compteActifDataGridViewTextBoxColumn,
            this.libelleActifDataGridViewTextBoxColumn,
            this.soldeActifDataGridViewTextBoxColumn,
            this.comptePassifDataGridViewTextBoxColumn,
            this.libellePassifDataGridViewTextBoxColumn,
            this.soldePassifDataGridViewTextBoxColumn});
            this.dgbilan.DataBindings.Add(new System.Windows.Forms.Binding("RowHeadersWidth", global::ComptabiliteGenerale.Properties.Settings.Default, "Cmp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dgbilan.DataBindings.Add(new System.Windows.Forms.Binding("Margin", global::ComptabiliteGenerale.Properties.Settings.Default, "dix", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dgbilan.DataSource = this.billanBindingSource2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgbilan.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgbilan.Location = new System.Drawing.Point(3, 142);
            this.dgbilan.Margin = global::ComptabiliteGenerale.Properties.Settings.Default.dix;
            this.dgbilan.Name = "dgbilan";
            this.dgbilan.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgbilan.RowHeadersVisible = false;
            this.dgbilan.RowHeadersWidth = global::ComptabiliteGenerale.Properties.Settings.Default.Cmp;
            this.dgbilan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgbilan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgbilan.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Transparent;
            this.dgbilan.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgbilan.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgbilan.RowTemplate.ReadOnly = true;
            this.dgbilan.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgbilan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgbilan.Size = new System.Drawing.Size(804, 259);
            this.dgbilan.StandardTab = true;
            this.dgbilan.TabIndex = 5;
            this.dgbilan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgbilan_CellContentClick);
            // 
            // compteActifDataGridViewTextBoxColumn
            // 
            this.compteActifDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.compteActifDataGridViewTextBoxColumn.DataPropertyName = "CompteActif";
            this.compteActifDataGridViewTextBoxColumn.HeaderText = "CompteActif";
            this.compteActifDataGridViewTextBoxColumn.Name = "compteActifDataGridViewTextBoxColumn";
            this.compteActifDataGridViewTextBoxColumn.ReadOnly = true;
            this.compteActifDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.compteActifDataGridViewTextBoxColumn.Width = 109;
            // 
            // libelleActifDataGridViewTextBoxColumn
            // 
            this.libelleActifDataGridViewTextBoxColumn.DataPropertyName = "LibelleActif";
            this.libelleActifDataGridViewTextBoxColumn.HeaderText = "LibelleActif";
            this.libelleActifDataGridViewTextBoxColumn.Name = "libelleActifDataGridViewTextBoxColumn";
            this.libelleActifDataGridViewTextBoxColumn.Width = 192;
            // 
            // soldeActifDataGridViewTextBoxColumn
            // 
            this.soldeActifDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.soldeActifDataGridViewTextBoxColumn.DataPropertyName = "SoldeActif";
            this.soldeActifDataGridViewTextBoxColumn.HeaderText = "SoldeActif";
            this.soldeActifDataGridViewTextBoxColumn.Name = "soldeActifDataGridViewTextBoxColumn";
            this.soldeActifDataGridViewTextBoxColumn.ReadOnly = true;
            this.soldeActifDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.soldeActifDataGridViewTextBoxColumn.Width = 99;
            // 
            // comptePassifDataGridViewTextBoxColumn
            // 
            this.comptePassifDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.comptePassifDataGridViewTextBoxColumn.DataPropertyName = "ComptePassif";
            this.comptePassifDataGridViewTextBoxColumn.HeaderText = "ComptePassif";
            this.comptePassifDataGridViewTextBoxColumn.Name = "comptePassifDataGridViewTextBoxColumn";
            this.comptePassifDataGridViewTextBoxColumn.ReadOnly = true;
            this.comptePassifDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.comptePassifDataGridViewTextBoxColumn.Width = 109;
            // 
            // libellePassifDataGridViewTextBoxColumn
            // 
            this.libellePassifDataGridViewTextBoxColumn.DataPropertyName = "LibellePassif";
            this.libellePassifDataGridViewTextBoxColumn.HeaderText = "LibellePassif";
            this.libellePassifDataGridViewTextBoxColumn.Name = "libellePassifDataGridViewTextBoxColumn";
            this.libellePassifDataGridViewTextBoxColumn.Width = 192;
            // 
            // soldePassifDataGridViewTextBoxColumn
            // 
            this.soldePassifDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.soldePassifDataGridViewTextBoxColumn.DataPropertyName = "SoldePassif";
            this.soldePassifDataGridViewTextBoxColumn.HeaderText = "SoldePassif";
            this.soldePassifDataGridViewTextBoxColumn.Name = "soldePassifDataGridViewTextBoxColumn";
            this.soldePassifDataGridViewTextBoxColumn.ReadOnly = true;
            this.soldePassifDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.soldePassifDataGridViewTextBoxColumn.Width = 99;
            // 
            // billanBindingSource2
            // 
            this.billanBindingSource2.DataMember = "Billan";
            this.billanBindingSource2.DataSource = this.comptaDataSet2;
            // 
            // comptaDataSet2
            // 
            this.comptaDataSet2.DataSetName = "ComptaDataSet2";
            this.comptaDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // billanBindingSource
            // 
            this.billanBindingSource.DataMember = "Billan";
            this.billanBindingSource.DataSource = this.comptaDataSet;
            // 
            // comptaDataSet
            // 
            this.comptaDataSet.DataSetName = "ComptaDataSet";
            this.comptaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // billanTableAdapter
            // 
            this.billanTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(670, 463);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "Enregistrer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_Enregistrer_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(528, 463);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 25);
            this.button2.TabIndex = 7;
            this.button2.Text = "Effacer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Montant Total Actif";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(433, 421);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Montant Total Passif";
            // 
            // TotaleActifTxt
            // 
            this.TotaleActifTxt.Location = new System.Drawing.Point(198, 421);
            this.TotaleActifTxt.Name = "TotaleActifTxt";
            this.TotaleActifTxt.Size = new System.Drawing.Size(157, 20);
            this.TotaleActifTxt.TabIndex = 10;
            // 
            // TotalePassifTxt
            // 
            this.TotalePassifTxt.Location = new System.Drawing.Point(613, 420);
            this.TotalePassifTxt.Name = "TotalePassifTxt";
            this.TotalePassifTxt.Size = new System.Drawing.Size(157, 20);
            this.TotalePassifTxt.TabIndex = 11;
            this.TotalePassifTxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // warn
            // 
            this.warn.AutoSize = true;
            this.warn.Location = new System.Drawing.Point(504, 10);
            this.warn.Name = "warn";
            this.warn.Size = new System.Drawing.Size(0, 13);
            this.warn.TabIndex = 12;
            // 
            // AnneeTxt
            // 
            this.AnneeTxt.AutoSize = true;
            this.AnneeTxt.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnneeTxt.Location = new System.Drawing.Point(418, 9);
            this.AnneeTxt.Name = "AnneeTxt";
            this.AnneeTxt.Size = new System.Drawing.Size(0, 13);
            this.AnneeTxt.TabIndex = 13;
            // 
            // comptaDataSetBindingSource
            // 
            this.comptaDataSetBindingSource.DataSource = this.comptaDataSet;
            this.comptaDataSetBindingSource.Position = 0;
            // 
            // comptaDataSet1
            // 
            this.comptaDataSet1.DataSetName = "ComptaDataSet1";
            this.comptaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // billanBindingSource1
            // 
            this.billanBindingSource1.DataMember = "Billan";
            this.billanBindingSource1.DataSource = this.comptaDataSet1;
            // 
            // billanTableAdapter1
            // 
            this.billanTableAdapter1.ClearBeforeFill = true;
            // 
            // billanTableAdapter2
            // 
            this.billanTableAdapter2.ClearBeforeFill = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(73, 463);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 25);
            this.button3.TabIndex = 14;
            this.button3.Text = "Exporter";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SaisieBilanUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(817, 496);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.AnneeTxt);
            this.Controls.Add(this.warn);
            this.Controls.Add(this.TotalePassifTxt);
            this.Controls.Add(this.TotaleActifTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgbilan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaisieBilanUI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saisie Bilan";
            this.Load += new System.EventHandler(this.SaisieBilanUI_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbilan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billanBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comptaDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comptaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comptaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comptaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billanBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox SoldeActifTxt;
        private System.Windows.Forms.TextBox LibelleActifTxt;
        private System.Windows.Forms.TextBox CmpActifTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SoldePassifTxt;
        private System.Windows.Forms.TextBox LibellePassifTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CmpPassifTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgbilan;
        private ComptaDataSet comptaDataSet;
        private System.Windows.Forms.BindingSource billanBindingSource;
        private ComptaDataSetTableAdapters.BillanTableAdapter billanTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TotaleActifTxt;
        private System.Windows.Forms.TextBox TotalePassifTxt;
        private System.Windows.Forms.Label warn;
        private System.Windows.Forms.Label AnneeTxt;
        private System.Windows.Forms.BindingSource comptaDataSetBindingSource;
        private ComptaDataSet1 comptaDataSet1;
        private System.Windows.Forms.BindingSource billanBindingSource1;
        private ComptaDataSet1TableAdapters.BillanTableAdapter billanTableAdapter1;
        private ComptaDataSet2 comptaDataSet2;
        private System.Windows.Forms.BindingSource billanBindingSource2;
        private ComptaDataSet2TableAdapters.BillanTableAdapter billanTableAdapter2;
        private System.Windows.Forms.DataGridViewTextBoxColumn compteActifDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn libelleActifDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soldeActifDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comptePassifDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn libellePassifDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soldePassifDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button3;
    }
}