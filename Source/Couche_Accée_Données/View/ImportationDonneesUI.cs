using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CoucheAcceeDonnees
{
    public partial class ImportationDonneesUI : Form
    {
        
        ImportationDonneeslogic Logic;

        public ImportationDonneesUI()
        {
            InitializeComponent();
        }

        public ImportationDonneesUI(CoucheAcceeDonnees.CAD db)
        {
            InitializeComponent();
            Logic = new ImportationDonneeslogic(db);
        }
        
        private void Importation_Données_UI_Load(object sender, EventArgs e)
        {

        }

        private void Executer_Button_Click(object sender, EventArgs e)
        {
            Warn.Text = "Veuillez patienter SVP";
            this.Refresh();

            if (radioButton_importer_donnees.Checked == true) Logic.importer_donnees();
            if (radioButton_importer_donnees_anouveaux.Checked == true) Logic.importer_donnees_anouveaux();
            if (radioButton_raz_donnees.Checked == true) Logic.raz_donnees();

            Warn.Text = "";
        }

        private void Quitter_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
