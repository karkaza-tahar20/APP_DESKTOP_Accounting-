using System;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Printing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
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
	public class ListingJournauxUI : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem Menu_Affichage;
        private System.Windows.Forms.MenuItem Menu_Quitter;
		private System.Windows.Forms.Button Imprimer_Button;
        private System.Windows.Forms.Button Excel_Button;
		private System.Windows.Forms.MenuItem Menu_Excel;
		private System.Windows.Forms.MenuItem Menu_Imprimer;
        private System.Windows.Forms.MenuItem Menu_Afficher;

		private System.Windows.Forms.SaveFileDialog Sfd;
		
        public System.Windows.Forms.Form parent;
        public string Font_Path;
        public string RaisonSocial;

        ListingJournauxLogic Logic;
        ListingJournauxVM view_model;

        private DataGrid dg;
        private MenuItem Menu_Export;

        private IContainer components;

        public ListingJournauxUI()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

        public ListingJournauxUI(CAD db)
        {
            InitializeComponent();
            Logic = new ListingJournauxLogic(db);
            
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListingJournauxUI));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.Menu_Affichage = new System.Windows.Forms.MenuItem();
            this.Menu_Afficher = new System.Windows.Forms.MenuItem();
            this.Menu_Export = new System.Windows.Forms.MenuItem();
            this.Menu_Imprimer = new System.Windows.Forms.MenuItem();
            this.Menu_Excel = new System.Windows.Forms.MenuItem();
            this.Menu_Quitter = new System.Windows.Forms.MenuItem();
            this.Imprimer_Button = new System.Windows.Forms.Button();
            this.Excel_Button = new System.Windows.Forms.Button();
            this.Sfd = new System.Windows.Forms.SaveFileDialog();
            this.dg = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_Affichage,
            this.Menu_Export,
            this.Menu_Quitter});
            // 
            // Menu_Affichage
            // 
            this.Menu_Affichage.Index = 0;
            this.Menu_Affichage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Menu_Afficher});
            this.Menu_Affichage.Text = "Menu &Affichage";
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
            this.Menu_Excel.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.Menu_Excel.Text = "&Excel";
            this.Menu_Excel.Click += new System.EventHandler(this.Menu_Excel_Click);
            // 
            // Menu_Quitter
            // 
            this.Menu_Quitter.Index = 2;
            this.Menu_Quitter.Shortcut = System.Windows.Forms.Shortcut.CtrlQ;
            this.Menu_Quitter.Text = "&Quitter";
            this.Menu_Quitter.Click += new System.EventHandler(this.Menu_Quitter_Click);
            // 
            // Imprimer_Button
            // 
            this.Imprimer_Button.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Imprimer_Button.Location = new System.Drawing.Point(183, 304);
            this.Imprimer_Button.Name = "Imprimer_Button";
            this.Imprimer_Button.Size = new System.Drawing.Size(88, 25);
            this.Imprimer_Button.TabIndex = 1;
            this.Imprimer_Button.Text = "&Imprimer";
            this.Imprimer_Button.UseVisualStyleBackColor = true;
            this.Imprimer_Button.Click += new System.EventHandler(this.print_Click);
            // 
            // Excel_Button
            // 
            this.Excel_Button.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.Excel_Button.Location = new System.Drawing.Point(49, 304);
            this.Excel_Button.Name = "Excel_Button";
            this.Excel_Button.Size = new System.Drawing.Size(88, 25);
            this.Excel_Button.TabIndex = 47;
            this.Excel_Button.Text = "&Excel";
            this.Excel_Button.UseVisualStyleBackColor = true;
            this.Excel_Button.Click += new System.EventHandler(this.Excel_Button_Click);
            // 
            // Sfd
            // 
            this.Sfd.FileOk += new System.ComponentModel.CancelEventHandler(this.Sfd_FileOk);
            // 
            // dg
            // 
            this.dg.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dg.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dg.CaptionVisible = false;
            this.dg.DataMember = "";
            this.dg.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dg.Location = new System.Drawing.Point(8, 12);
            this.dg.Name = "dg";
            this.dg.RowHeaderWidth = 4;
            this.dg.Size = new System.Drawing.Size(328, 274);
            this.dg.TabIndex = 0;
            // 
            // ListingJournauxUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(344, 321);
            this.Controls.Add(this.Excel_Button);
            this.Controls.Add(this.Imprimer_Button);
            this.Controls.Add(this.dg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.Name = "ListingJournauxUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Affichage Journaux auxiliaires";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.AffichageJaux_Closing);
            this.Load += new System.EventHandler(this.AffichageJaux_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		
		private void AffichageJaux_Load(object sender, System.EventArgs e)
		{
            buildDataStyle(dg);
		}

		private void AffichageJaux_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
        } 
        
        private void Menu_Afficher_Click(object sender, EventArgs e)
        {
            dg.DataSource = null;

            view_model = Logic.get_journaux("", "");

            dg.DataSource = view_model.Lignes;

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
 
        public void Pre_print(Impression.Imprimeur printer)
        {
            buildcaptions(printer);
            buildtableau(printer);

        }

		private void Menu_Imprimer_Click(object sender, EventArgs e)
        {
            print();
            

        }
        
        private void print_Click(object sender, System.EventArgs e)
		{
            print();
			
		
		}	
      
        private void Menu_Excel_Click(object sender, EventArgs e)
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

        private void Sfd_FileOk(object sender, CancelEventArgs e)
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

            Phrase[] Header = new Phrase[2];
            Header[0] = new Phrase();
            Header[0].Words = new String[] { RaisonSocial };
            Header[0].Spaces = new int[] { 5, 10 };
            Header[0].length = 2;
            Header[0].Align = Alignment.left;
            Header[0].build();
            Header[1] = new Phrase();
            Header[1].Words = new String[] { "Listing", "Journaux" };
            Header[1].Align = Alignment.center;
            Header[1].Spaces = new int[] { 10, 5, 10 };
            Header[1].length = 2;
            Header[1].build();

            excel.Header = Header;
            excel.TableHeader = new String[] { "Code", "Intitulé" };
            excel.RowHight = 15;
            excel.Lignes = view_model.Lignes;
            excel.TableColumnStyle = new Excel.ColumnStyle[2];
            excel.TableColumnStyle[0] = new Excel.ColumnStyle();
            excel.TableColumnStyle[0].Align = Alignment.left;
            excel.TableColumnStyle[0].ColumnWidth = 10;
            excel.TableColumnStyle[0].Format = "";
            excel.TableColumnStyle[1] = new Excel.ColumnStyle();
            excel.TableColumnStyle[1].Align = Alignment.left;
            excel.TableColumnStyle[1].ColumnWidth = 40;
            excel.TableColumnStyle[1].Format = "";

            excel.set_sheet("Listing Journaux",1, false);

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

		private void buildDataStyle (DataGrid dg )
		{
			DataGridTableStyle style = new DataGridTableStyle();
			style.MappingName = "ArrayList";
			//style.AlternatingBackColor = System.Drawing.Color.Bisque;
			DataGridTextBoxColumn Code= new DataGridTextBoxColumn();
			Code.HeaderText = "Code Journal";
			Code.MappingName = "Code";
			Code.Width = 80;
			DataGridTextBoxColumn Intitulé = new DataGridTextBoxColumn();
			Intitulé.HeaderText = "Intitulé";
			Intitulé.MappingName = "Intitule";
			Intitulé.Width = 210;
			style.GridColumnStyles.AddRange( new DataGridColumnStyle[] {Code,  Intitulé});
			dg.TableStyles.Add(style);
            dg.Enabled = true;
			dg.AllowDrop = false;
            dg.ReadOnly = true;
			
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
            DateTime dt = DateTime.Now;
            caption2.Text = dt.ToShortDateString();
            caption2.rec = new RectangleF(710, 15, 100, 20);
            caption2.fnt = fnt1;
            printer.Captions.Add(caption2);

            Caption caption3 = new Caption();
            caption3.Text = this.Text;
            caption3.rec = new RectangleF(260, 60, 300, 20);
            caption3.fnt = fnt2;
            printer.Captions.Add(caption3);

            Caption caption4 = new Caption();
            caption4.Text = "Page : ";
            caption4.rec = new RectangleF(310, 1025, 100, 20);
            caption4.fnt = fnt1;
            printer.Captions.Add(caption4);  
            
           

        }

        private void buildtableau(Impression.Imprimeur printer)
        {
            FontFamily ffm = new FontFamily(GenericFontFamilies.Serif);
                       
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
            printer.num_pages = view_model.Lignes.Count / printer.tbl.LinesInPage;
            if (view_model.Lignes.Count % printer.tbl.LinesInPage != 0) printer.num_pages++;
            printer.tbl.posX = 212;
            printer.tbl.posY = 120;

            Tableau.colonne tblc0 = new Tableau.colonne();
            tblc0.title = "Code" + "\n" + "Journal";
            tblc0.width = 4;
            tblc0.Column_Font = fnt9;
            tblc0.mapping = "Code";
            tblc0.Zeropadding = 4;
            tblc0.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc0);
            Tableau.colonne tblc1 = new Tableau.colonne();
            tblc1.title = "INTITULE";
            tblc1.width = 22;
            tblc1.Column_Font = fnt9;
            tblc1.mapping = "Intitule";
            tblc1.Cell_alignAlignment = Alignment.left;
            printer.tbl.PutColInContainer(tblc1);

        }

       

      

        
				
        
       

       

		

     

        

       

	

	

	

		
		
		
		



		
	}
}
