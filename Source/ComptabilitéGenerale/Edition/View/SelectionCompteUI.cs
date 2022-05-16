using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilitaire;

namespace EditionCompta
{
    public partial class SelectionCompteUI : Form
    {
        
        public SelectionCompteVM select_comptes;

        public System.Windows.Forms.Form parent;

        public SelectionCompteUI()
        {
            InitializeComponent();
        }

        private void Selection_Compte_Load(object sender, EventArgs e)
        {
            GlobalButton.Checked = true;
            select_comptes.valid = false;
            select_comptes.selection = "";

        }

        private void GlobalButton_CheckedChanged(object sender, EventArgs e)
        {
            if (GlobalButton.Checked == true)
            {
                CompteDebutTxt.BackColor = Color.Gray;
                CompteFinTxt.BackColor = Color.Gray;
                CompteDebutTxt.Enabled = false;
                CompteFinTxt.Enabled = false; 
                Anuller_Button.Focus();
                
            }
            else
            {
                CompteDebutTxt.BackColor = Color.White;
                CompteFinTxt.BackColor = Color.White;
                warn.Text = "";
                CompteDebutTxt.Enabled = true;
                CompteFinTxt.Enabled = true;
                CompteDebutTxt.Focus();
              
            }
        }
        
        private void CompteDebutTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) CompteFinTxt.Focus();

        }

        private void CompteFinTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) Valider_Button.Focus();

        }

        private void CompteDebutTxt_Validating(object sender, CancelEventArgs e)
        {
            int ret = Validator.valide_cmptTxt(CompteDebutTxt.Text);
            if (ret == 0)
            {
                if ((CompteFinTxt.Text != "") && (Validator.valide_cmptTxt(CompteFinTxt.Text) == 0))
                {
                    if (Int32.Parse(CompteFinTxt.Text) < Int32.Parse(CompteDebutTxt.Text))
                    {
                        warn.Text = "Compte debut est Superieur a compte Fin ";
                        ep.SetError(CompteDebutTxt, "Compte debut est Superieur a compte Fin ");
                        CompteDebutTxt.ForeColor = Color.Red;
                        ep.SetError(CompteFinTxt, "Compte debut est Superieur a compte Fin ");
                        CompteFinTxt.ForeColor = Color.Red;
                    }
                    else
                    {
                        
                        CompteDebutTxt.ForeColor = Color.Black;
                        ep.SetError(CompteDebutTxt, "");
                        CompteFinTxt.ForeColor = Color.Black;
                        ep.SetError(CompteFinTxt, "");
                        warn.Text = "";
                    }
                }
            }
            else
            {
                CompteDebutTxt.ForeColor = Color.Red;
                ep.SetError(CompteDebutTxt, "Format Compte invalide");
                if (ret == 1) warn.Text = "Format Compte invalide";
                if (ret == 2) warn.Text = "Le champs compte debut est laissé vide";
            }

        }
        
        private void CompteFinTxt_Validating(object sender, CancelEventArgs e)
        {
            int ret = Validator.valide_cmptTxt(CompteFinTxt.Text);
            if (ret == 0)
            {
                if ((CompteDebutTxt.Text != "") && (Validator.valide_cmptTxt(CompteDebutTxt.Text) == 0))
                {
                    if (Int32.Parse(CompteFinTxt.Text) < Int32.Parse(CompteDebutTxt.Text))
                    {
                        warn.Text = "Compte debut est Superieur a compte Fin ";
                        ep.SetError(CompteDebutTxt, "Compte debut est Superieur a compte Fin ");
                        CompteDebutTxt.ForeColor = Color.Red;
                        ep.SetError(CompteFinTxt, "Compte debut est Superieur a compte Fin ");
                        CompteFinTxt.ForeColor = Color.Red;
                    }
                    else
                    {
                        CompteDebutTxt.ForeColor = Color.Black;
                        ep.SetError(CompteDebutTxt, "");
                        CompteFinTxt.ForeColor = Color.Black;
                        ep.SetError(CompteFinTxt, "");
                        warn.Text = "";
                    }


                }
            }
            else
            {
                CompteFinTxt.ForeColor = Color.Red;
                ep.SetError(CompteFinTxt, "Format Compte invalide");
                if (ret == 1) warn.Text = "Format Compte invalide";
                if (ret == 2) warn.Text = "Le champ compte Fin est laissé vide";
            }
        }

        void valide()
        {
            if (GlobalButton.Checked == true)
            {
                select_comptes.valid = true;
                select_comptes.selection = "";
                if (TriParCompteButton.Checked == true) select_comptes.tri = "Compte,Intitule";
                else select_comptes.tri = "Intitule,Compte";
                select_comptes.title1 = "Listing global du plan Comptable";
                select_comptes.title2 = "";
                return;
            }

            int ret = Validator.valide_cmptTxt(CompteDebutTxt.Text);
            if (ret == 0)
            {
                if ((CompteFinTxt.Text != "") && (Validator.valide_cmptTxt(CompteFinTxt.Text) == 0))
                {
                    if (Int32.Parse(CompteFinTxt.Text) < Int32.Parse(CompteDebutTxt.Text))
                    {
                        warn.Text = "Compte debut est Superieur a compte Fin ";
                        ep.SetError(CompteDebutTxt, "Compte debut est Superieur a compte Fin ");
                        CompteDebutTxt.ForeColor = Color.Red;
                        ep.SetError(CompteFinTxt, "Compte debut est Superieur a compte Fin ");
                        CompteFinTxt.ForeColor = Color.Red;
                        select_comptes.valid = false;
                        return;
                    }
                }
                else
                {
                    CompteDebutTxt.ForeColor = Color.Red;
                    ep.SetError(CompteDebutTxt, "Format Compte invalide");
                    warn.Text = "Format Compte invalide";
                }
            }
            int ret1 = Validator.valide_cmptTxt(CompteFinTxt.Text);
            if (ret1 == 0)
            {
                if ((CompteDebutTxt.Text != "") && (Validator.valide_cmptTxt(CompteDebutTxt.Text) == 0))
                {
                    if (Int32.Parse(CompteFinTxt.Text) < Int32.Parse(CompteDebutTxt.Text))
                    {
                        warn.Text = "Compte debut est Superieur a compte Fin ";
                        ep.SetError(CompteDebutTxt, "Compte debut est Superieur a compte Fin ");
                        CompteDebutTxt.ForeColor = Color.Red;
                        ep.SetError(CompteFinTxt, "Compte debut est Superieur a compte Fin ");
                        CompteFinTxt.ForeColor = Color.Red;
                        select_comptes.valid = false;
                        return;
                    }
                }
                else
                {
                    CompteFinTxt.ForeColor = Color.Red;
                    ep.SetError(CompteFinTxt, "Format Compte invalide");
                    warn.Text = "Format Compte invalide";
                }
            }

            if ((ret == 0) && (ret1 == 0))
            {
                select_comptes.valid = true;
                select_comptes.selection = "Compte <=" + CompteFinTxt.Text + "and Compte >=" + CompteDebutTxt.Text;
                if (TriParCompteButton.Checked == true) select_comptes.tri = "Compte,Intitule";
                else select_comptes.tri = "Intitule,Compte";
                select_comptes.title1 = "Listing partiel du plan Comptable ";
                select_comptes.title2 = "Compte Debut : " + CompteDebutTxt.Text + "     " + "Compte Fin : " + CompteFinTxt.Text;
            }
        }

        private void Valider_Button_Click(object sender, EventArgs e)
        {
            valide();
            if (select_comptes.valid == true) this.Close(); 
        }

        private void Anuller_Button_Click(object sender, EventArgs e)
        {
            select_comptes.valid = false;
            this.Close();
        }

       






    }


}