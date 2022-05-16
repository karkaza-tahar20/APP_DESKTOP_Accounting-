using System;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Printing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using CoucheAcceeDonnees;
using Impression;
using Excel;
using Export.Commun;
using Compta.Commun;



namespace EditionCompta
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class ListingPlanComptableUI : System.Windows.Forms.Form
	{
        public System.Windows.Forms.Form parent;

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem Menu_Afficher;
        private System.Windows.Forms.MenuItem Menu_Imprimer;
		private System.Windows.Forms.MenuItem Menu_Excel;
		private System.Windows.Forms.MenuItem Menu_Quitter;
        
        private System.Windows.Forms.Label Title1;
        private System.Windows.Forms.Label Title2;

		private System.Windows.Forms.Button Imprimer_Button; 
        private System.Windows.Forms.Button Excel_Button;  
        
        private IContainer components;
        
        public string Font_Path;
        public string RaisonSocial;

        private System.Windows.Forms.SaveFileDialog Sfd;
       
        private System.Windows.Forms.DataGrid dg;
        ListingPlanComptableVM view_model;

        private MenuItem Menu_Export;

        ListingPlanComptableLogic Logic;

        public ListingPlanComptableUI()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

        public ListingPlanComptableUI(CAD db)
        {
            //
            // Requis pour la prise en charge du Concepteur Windows Forms
            //
            InitializeComponent();
            Logic = new ListingPlanComptableLogic(db);
            
        }



		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListingPlanComptableUI));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.Menu_Afficher = new System.Windows.Forms.MenuItem();
            this.Menu_Export = new System.Windows.Forms.MenuItem();
            this.Menu_Imprimer = new System.Windows.Forms.MenuItem();
            this.Menu_Excel = new System.Windows.Forms.MenuItem();
            this.Menu_Quitter = new System.Windows.Forms.MenuItem();
            this.dg = new System.Windows.Forms.DataGrid();
            this.Imprimer_Button = new System.Windows.Forms.Button();
            this.Title1 = new System.Windows.Forms.Label();
            this.Sfd = new System.Windows.Forms.SaveFileDialog();
            this.Excel_Button = new System.Windows.Forms.Button();
            this.Title2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.Menu_Export,
            this.Menu_Quitter});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_Afficher});
            this.menuItem1.Text = "Menu A&ffichage";
            // 
            // Menu_Afficher
            // 
            this.Menu_Afficher.Index = 0;
            this.Menu_Afficher.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.Menu_Afficher.Text = "&Afficher";
            this.Menu_Afficher.Click += new System.EventHandler(this.Menu_Afficher_Click);
            // 
            // Menu_Export
            // 
            this.Menu_Export.Index = 1;
            this.Menu_Export.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_Imprimer,
            this.Menu_Excel});
            this.Menu_Export.Text = "Menu &Export";
            // 
            // Menu_Imprimer
            // 
            this.Menu_Imprimer.Index = 0;
            this.Menu_Imprimer.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
            this.Menu_Imprimer.Text = "&Imprimer";
            this.Menu_Imprimer.Click += new System.EventHandler(this.Menu_Imprimer_Click);
            // 
            // Menu_Excel
            // 
            this.Menu_Excel.Index = 1;
            this.Menu_Excel.Text = "E&xcel";
            this.Menu_Excel.Click += new System.EventHandler(this.Menu_Excel_Click);
            // 
            // Menu_Quitter
            // 
            this.Menu_Quitter.Index = 2;
            this.Menu_Quitter.Text = "&Quitter";
            this.Menu_Quitter.Click += new System.EventHandler(this.Menu_Quitter_Click);
            // 
            // dg
            // 
            this.dg.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dg.CaptionVisible = false;
            this.dg.DataMember = "";
            this.dg.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dg.Location = new System.Drawing.Point(8, 78);
            this.dg.Name = "dg";
            this.dg.RowHeaderWidth = 0;
            this.dg.Size = new System.Drawing.Size(376, 314);
            this.dg.TabIndex = 0;
            // 
            // Imprimer_Button
            // 
            this.Imprimer_Button.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Imprimer_Button.Location = new System.Drawing.Point(160, 416);
            this.Imprimer_Button.Name = "Imprimer_Button";
            this.Imprimer_Button.Size = new System.Drawing.Size(88, 25);
            this.Imprimer_Button.TabIndex = 1;
            this.Imprimer_Button.Text = "&Imprimer";
            this.Imprimer_Button.UseVisualStyleBackColor = true;
            this.Imprimer_Button.Click += new System.EventHandler(this.Imprimer_Button_Click);
            // 
            // Title1
            // 
            this.Title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title1.Location = new System.Drawing.Point(12, 18);
            this.Title1.Name = "Title1";
            this.Title1.Size = new System.Drawing.Size(368, 23);
            this.Title1.TabIndex = 2;
            this.Title1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Sfd
            // 
            this.Sfd.FileName = "doc1";
            this.Sfd.FileOk += new System.ComponentModel.CancelEventHandler(this.Sfd_FileOk);
            // 
            // Excel_Button
            // 
            this.Excel_Button.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Excel_Button.Location = new System.Drawing.Point(15, 416);
            this.Excel_Button.Name = "Excel_Button";
            this.Excel_Button.Size = new System.Drawing.Size(88, 25);
            this.Excel_Button.TabIndex = 46;
            this.Excel_Button.Text = "E&xcel";
            this.Excel_Button.UseVisualStyleBackColor = true;
            this.Excel_Button.Click += new System.EventHandler(this.Excel_Button_Click);
            // 
            // Title2
            // 
            this.Title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title2.Location = new System.Drawing.Point(12, 52);
            this.Title2.Name = "Title2";
            this.Title2.Size = new System.Drawing.Size(368, 23);
            this.Title2.TabIndex = 47;
            this.Title2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListingPlanComptableUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(392, 457);
            this.Controls.Add(this.Title2);
            this.Controls.Add(this.Excel_Button);
            this.Controls.Add(this.Title1);
            this.Controls.Add(this.Imprimer_Button);
            this.Controls.Add(this.dg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.Name = "ListingPlanComptableUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plan Comptable";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.AffichagePlan_Closing);
            this.Load += new System.EventHandler(this.AffichagePlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		//[STAThread]
		

		private void AffichagePlan_Load(object sender, System.EventArgs e)
		{
            buildDataStyle(dg);
					
		}

		private void AffichagePlan_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		}

	    private void Menu_Afficher_Click(object sender, EventArgs e)
        {
            dg.DataSource = null;
            Title1.Text = "";
            Title2.Text = "";

            SelectionCompteVM select_comptes = new SelectionCompteVM();
            SelectionCompteUI Select = new SelectionCompteUI();
            Select.select_comptes = select_comptes;
            Select.ShowDialog();

            Title1.Text = select_comptes.title1;
            Title2.Text = select_comptes.title2;
            string selection = select_comptes.selection;
            string tri = select_comptes.tri;
            bool valid = select_comptes.valid; 
            this.Refresh();
            if (valid == true)
            {
                view_model = Logic.get_plan(selection, tri);
                view_model.title1 = Title1.Text;
                view_model.title2 = Title2.Text;
                dg.DataSource = view_model.Lignes;
            }
             
        }

        void print()
        {
            if (view_model.Lignes.Count > 0)
            {
                Impression.Imprimeur printer = new Impression.Imprimeur();
                printer.Lignes = view_model.Lignes;
                printer.BuildDocument();
                Pre_print(printer);
                printer.print_preview();
                //printer.print();
            }
        }
        
        private void Imprimer_Button_Click(object sender, EventArgs e)
        {
            print();
        }

		private void Menu_Imprimer_Click(object sender, System.EventArgs e)
		{
            print();
			
		}

        private void Menu_Excel_Click(object sender, System.EventArgs e)
		{
            if (view_model.Lignes.Count > 0)
            {
                Sfd.FileName = "";
                Sfd.ShowDialog();
            }
		
		}
        
        private void Excel_Button_Click(object sender, EventArgs e)
        {
            if (view_model.Lignes.Count > 0)
            {
                Sfd.FileName = "";
                Sfd.ShowDialog();
            }

        }

        private void Sfd_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
            string filename = ((SaveFileDialog)sender).FileName;
            DialogResult drs = MessageBox.Show("Voulez vraiment utiliser ce fichier \n" + filename + " \n" + "comme fichier d'export de données vers Excel ?", "", MessageBoxButtons.YesNo);
            if (DialogResult.No == drs)
            {
                MessageBox.Show("Opération annulée");
                return;
            }
            SVP svp = new SVP();
            svp.Show();
            svp.Refresh();

            ExcelBuilder excel = new ExcelBuilder();
            bool b = excel.set_execl_app();
            if (b == false)
            {
                MessageBox.Show("Excel n'est proprement installé !!");
                return;
            }


            excel.filename = filename;

            Phrase[] Header = new Phrase[3];
            Header[0] = new Phrase();
            Header[0].Words = new String[] { RaisonSocial };
            Header[0].Spaces = new int[] { 5 , 10 };
            Header[0].length = 1;
            Header[0].Align = Alignment.left;
            Header[0].build();
            Header[1] = new Phrase();
            Header[1].Words = new String[] { Title1.Text};
            Header[1].Spaces = new int[] { 10, 0, 10 };
            Header[1].length = 2;
            Header[1].Align = Alignment.center;
            Header[1].build();
            Header[2] = new Phrase();
            Header[2].Words = new String[] { Title2.Text };
            Header[2].Spaces = new int[] { 10, 0, 10 };
            Header[2].length = 2;
            Header[2].Align = Alignment.center;
            Header[2].build();
                
            excel.filename = filename;
            excel.Header = Header;
            excel.TableHeader = new String[] { "Compte", "Intitulé" };
            excel.RowHight = 15;
            excel.Lignes = view_model.Lignes;
            excel.TableColumnStyle = new Excel.ColumnStyle[2];
            excel.TableColumnStyle[0] = new Excel.ColumnStyle();
            excel.TableColumnStyle[0].Align = Alignment.left;
            excel.TableColumnStyle[0].ColumnWidth = 10;
            excel.TableColumnStyle[0].Format = "";
            excel.TableColumnStyle[1] = new Excel.ColumnStyle();
            excel.TableColumnStyle[1].Align = Alignment.left;
            excel.TableColumnStyle[1].ColumnWidth = 45;
            excel.TableColumnStyle[1].Format = "";

            excel.set_sheet("Plan Comptable",1,false);
            excel.WriteDoc();
            excel.save();

            svp.Hide();
            svp.Close();

            MessageBox.Show("Le fichier excel : " + filename + " a eté crée \n");

           
		
		}

        private void Menu_Quitter_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		

		
			
		private void buildDataStyle ( DataGrid dg )
		{
			DataGridTableStyle style = new DataGridTableStyle();
			style.MappingName = "ArrayList";
			//style.AlternatingBackColor = System.Drawing.Color.Bisque;
			DataGridTextBoxColumn Code= new DataGridTextBoxColumn();
			Code.HeaderText = "N°Compte";
            Code.MappingName = "Compte";
			Code.Width = 80;
			DataGridTextBoxColumn Ncode = new DataGridTextBoxColumn();
			Ncode.HeaderText = "Intitulé";
            Ncode.MappingName = "Intitule";
			Ncode.Width = 260;
			style.GridColumnStyles.AddRange( new DataGridColumnStyle[] {Code,  Ncode});
			dg.TableStyles.Add(style);
            dg.Enabled = true;
            dg.AllowDrop = false;
            dg.ReadOnly = true;
		}

        public void Pre_print(Impression.Imprimeur printer)
        {
            buildcaptions(printer);
            buildtableau(printer);

        }

        private void buildcaptions(Impression.Imprimeur printer)
        {
            FontFamily ffm = new FontFamily("Arial");
            Font fnt1 = new Font(ffm, 9);
            Font fnt2 = new Font(ffm, 11, FontStyle.Bold);


            printer.Captions = new List<Caption>();

            Caption caption1 = new Caption();
            caption1.Text = RaisonSocial;
            caption1.rec = new RectangleF(10, 15, 100, 20);
            caption1.fnt = fnt2;
            printer.Captions.Add(caption1);
           
            Caption caption2 = new Caption();
            caption2.Text = Title1.Text;
            caption2.rec = new RectangleF(280, 40, 300, 20);
            caption2.fnt = fnt2;
            printer.Captions.Add(caption2);

            Caption caption3 = new Caption();
            caption3.Text = Title2.Text;
            caption3.rec = new RectangleF(192, 65, 500, 20);
            caption3.fnt = fnt2;
            printer.Captions.Add(caption3);

            Caption caption4 = new Caption();
            DateTime dt = DateTime.Now;
            caption4.Text = dt.ToShortDateString();
            caption4.rec = new RectangleF(710, 15, 100, 20);
            caption4.fnt = fnt1;
            printer.Captions.Add(caption4);
            
            Caption caption5 = new Caption();
            caption5.Text = "Page : ";
            caption5.rec = new RectangleF(310, 1025, 100, 20);
            caption5.fnt = fnt1;
            printer.Captions.Add(caption5);

        }

        private void buildtableau(Impression.Imprimeur printer)
        {
            FontFamily ffm = new FontFamily("Arial");

            Font fnt9 = new Font(ffm, 9);
            Font Bfnt9 = new Font(ffm, 9, FontStyle.Bold);
            printer.tbl = new Tableau(Bfnt9,2);
            printer.tbl.Lignes = view_model.Lignes;
            printer.tbl.Header_Font = Bfnt9;
            printer.tbl.Header_alignment = Alignment.center;
            printer.tbl.Header_height = 2.2f;
            printer.tbl.Header_margin = 0.5f;
            printer.tbl.Cell_height = 1.5f;
            printer.tbl.LinesInPage = 40;
            printer.num_pages = printer.tbl.Lignes.Count / printer.tbl.LinesInPage;
            if (printer.tbl.Lignes.Count % printer.tbl.LinesInPage != 0) printer.num_pages++;
            printer.tbl.posX = 100;
            printer.tbl.posY = 120;

            Tableau.colonne tblc0 = new Tableau.colonne();
            tblc0.title = "NUMERO" + "\n" + "COMPTE";
            tblc0.width = 6;
            tblc0.mapping = "Compte";
            tblc0.Zeropadding = 8;
            tblc0.Column_Font = fnt9;
            tblc0.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc0);
            Tableau.colonne tblc1 = new Tableau.colonne();
            tblc1.title = "INTITULE";
            tblc1.width = 40;
            tblc1.Column_Font = fnt9;
            tblc1.mapping = "Intitule";
            tblc1.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc1);

        }

      

        
	
		

		

    

		

       



		
	

	
		
		



		
	}
}
