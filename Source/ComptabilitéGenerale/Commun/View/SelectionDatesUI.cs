using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilitaire;

namespace Compta.Commun
{
    public partial class SelectionDatesUI : Form
    {
        
        public System.Windows.Forms.Form parent;
        public SelectionDatesVM SelectionDates_VM;
        public string an;

        public SelectionDatesUI()
        {
            InitializeComponent();
        }

        private void SelectionDatesUI_Load(object sender, EventArgs e)
        {
            DDTxt.Focus();
        }

        #region curseur+validation

        private void DDTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if  (e.KeyData == Keys.Enter) DFTxt.Focus();
        }

        private void DFTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) Valider.Focus();
        }

        private void DDTxt_Validating(object sender, CancelEventArgs e)
        {
            int ret = Validator.valide_DT(DDTxt.Text, an);
            if (ret != 0)
            {
                DDTxt.ForeColor = Color.Red;
                ep.SetError(DDTxt, "Format Date invalide");
            }
            else
            {
                DDTxt.ForeColor = Color.Black;
                ep.SetError(DDTxt, "");
            }

        }

        private void DFTxt_Validating(object sender, CancelEventArgs e)
        {
            int ret = Validator.valide_DT(DFTxt.Text, an);
            if (ret != 0)
            {
                DFTxt.ForeColor = Color.Red;
                ep.SetError(DFTxt, "Format Date invalide");
            }
            else
            {
                DFTxt.ForeColor = Color.Black;
                ep.SetError(DFTxt,"");
            }

        }

        #endregion

        private void Valider_Click(object sender, EventArgs e)
        {
            valide();
            if (SelectionDates_VM.valid == true) this.Close();

        }

        private void Anuller_Click(object sender, EventArgs e)
        {
            SelectionDates_VM.valid = false;
            Close();

        }

        private void valide()
        {
            bool b = true;

            int ret0 = Validator.valide_DT(DDTxt.Text, an);
            if (ret0 != 0)
            {
                DDTxt.ForeColor= Color.Red;
                ep.SetError(DDTxt,"Format Date invalide");
                b = false;

            }
            else
            {
                DDTxt.ForeColor = Color.Black;
                ep.SetError(DDTxt, "");

            }
            int ret1 = Validator.valide_DT(DFTxt.Text, an);
            if (ret1 != 0)
            {
                DFTxt.ForeColor = Color.Red;
                ep.SetError(DFTxt, "Format Date invalide");
                b = false;

            }
            else
            {
                DFTxt.ForeColor = Color.Black;
                ep.SetError(DFTxt, "");

            }

            if ((ret0 == 0) && (ret1 == 0))
            {
                if (Fonctions.DateToInt(DDTxt.Text) > Fonctions.DateToInt(DFTxt.Text))
                {
                    DDTxt.ForeColor = Color.Red;
                    ep.SetError(DDTxt,"Date Debut inferieure a Date Fin");
                    DFTxt.ForeColor = Color.Red;
                    ep.SetError(DFTxt, "Date Fin inferieure a Date Debut");
                    b = false;

                }
                else
                {
                    DDTxt.ForeColor = Color.Black;
                    ep.SetError(DDTxt, "");
                    DFTxt.ForeColor = Color.Black;
                    ep.SetError(DFTxt, "");

                }

            }


            if (b == true)
            {
                SelectionDates_VM.valid = true;
                SelectionDates_VM.date1 = DDTxt.Text;
                SelectionDates_VM.date2 = DFTxt.Text;
                SelectionDates_VM.idate1 = Fonctions.DateToInt(DDTxt.Text).ToString();
                SelectionDates_VM.idate2 = Fonctions.DateToInt(DFTxt.Text).ToString();
            }
            else SelectionDates_VM.valid = false;



        }






    }
}
