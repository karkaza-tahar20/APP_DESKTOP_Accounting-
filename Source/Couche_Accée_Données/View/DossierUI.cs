using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilitaire;

namespace CoucheAcceeDonnees
{
    public partial class DossierUI : Form
    {
        CAD db;

        public DossierLogic Logic;
        DossierModel model;
        bool model_ok;

        public DossierUI()
        {
            InitializeComponent();
        }

        public DossierUI(CAD db1)
        {
            InitializeComponent();

            db = db1;
            Logic = new DossierLogic(db);

        }
        
        private void DossierUI_Load(object sender, EventArgs e)
        {
            
            model = new DossierModel();
            model.IDDossier = "1";
            Logic.Consulter(ref model);
            RaisonSocialTxt.Text = model.RaisonSocial;
            Console.WriteLine("Informations Recuperees !!!");
            Console.WriteLine(model.RaisonSocial);
            AnneeTxt.Text = model.Annee;
            Console.WriteLine("Informations Recuperees !!!");
            Console.WriteLine(model.NomSociete);
            NomSocieteTxt.Text = model.NomSociete;
            Console.WriteLine("Informations Recuperees !!!");
            Console.WriteLine(model.Ville);
            VilleTxt.Text = model.Ville;
            Console.WriteLine("Informations Recuperees !!!");
            Console.WriteLine(model.Adresse);
            AdresseTxt.Text = model.Adresse;
            Console.WriteLine("Informations Recuperees !!!");
            Console.WriteLine(model.Telephone);
            TeleTxt.Text = model.Telephone;
            Console.WriteLine("Informations Recuperees !!!");
            Console.WriteLine(model.Email);
            EmailTxt.Text = model.Email;
            model_ok = true;

            RaisonSocialTxt.Focus();
            RaisonSocialTxt.SelectAll();

        }

        private void RaisonSocialTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Down) || (e.KeyData == Keys.Enter))
            {
                AnneeTxt.Focus();
                AnneeTxt.SelectAll();

            }


        }

        private void AnneeTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Down) || (e.KeyData == Keys.Enter)) ModifierButton.Focus();
            if (e.KeyData == Keys.Up) RaisonSocialTxt.Focus();

        }

        private void RaisonSocialTxt_Validating(object sender, CancelEventArgs e)
        {
            model.RaisonSocial = RaisonSocialTxt.Text;

        }

        private void AnneeTxt_Validating(object sender, CancelEventArgs e)
        {
            model.Annee = AnneeTxt.Text;
            bool b = Validator.valide_N(AnneeTxt.Text);
            if (b == false)
            {
                AnneeTxt.ForeColor = Color.Red;
                ep.SetError(AnneeTxt, "Format numerique invalide");
                warn.Text = ""; 
                model_ok = false;
            }
            else
            {
                AnneeTxt.ForeColor = Color.Black;
                ep.SetError(AnneeTxt, "");
                warn.Text = ""; 
                model_ok = true;
            }

        }

        private void ModifierButton_Click(object sender, EventArgs e)
        {
            if (model_ok == true)
            {
                DossierModel  model1 = new DossierModel();
                model1.Annee = AnneeTxt.Text; model1.NomSociete = NomSocieteTxt.Text; model1.Telephone = TeleTxt.Text;
                model1.RaisonSocial = RaisonSocialTxt.Text; model1.Ville = VilleTxt.Text; model1.IDDossier = "1";
                model1.Adresse = AdresseTxt.Text; model1.Email = EmailTxt.Text;
                Console.WriteLine(model1.Adresse);

                if (Logic.Modifier(model1)==1) warn.Text ="Modifier == 1";
                if (Logic.Modifier(model1) == 0) warn.Text = "Données Societé modifié avec succee "; 
            }
            else warn.Text = "Données saisies invalides"; 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RaisonSocialTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void NomSocieteTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
