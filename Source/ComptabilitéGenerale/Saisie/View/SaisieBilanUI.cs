using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Configuration;
using Utilitaire;
using CoucheAcceeDonnees;
using Compta.Commun;
using ComptabiliteGenerale;
using SaisieCompta;
using ComptabiliteGenerale.Saisie.Logic;

namespace ComptabiliteGenerale.Saisie.View
{
    public partial class SaisieBilanUI : Form
    {
        CAD db;
        SaisieBilanLogic Logic;
        Saisie.ViewModel.SaisieBilanVM view_model;

        DbProviderFactory factory;
        string provider;
        string connectionString;

        private ErrorProvider ep;
        int liblength;
        string mlibel;
        string an;
        public string dDate;
        public string fDate;
        string djour;
        string fjour;
        int idDt;
        int ifDt;
        bool form_ok = true;

       
        public SaisieBilanUI()
        {
            InitializeComponent();
            /*this.Load += new System.EventHandler(this.SaisieOpUI_Load);

            this.CmpActifTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmpActifTxt_KeyDown);
            this.CmpActifTxt.Validating += new System.ComponentModel.CancelEventHandler(this.CmpActifTxt_Validating);

            this.CmpPassifTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmpPassifTxt_KeyDown);
            this.CmpPassifTxt.Validating += new System.ComponentModel.CancelEventHandler(this.CmpPassifTxt_Validating);

            this.LibelleActifTxt.Validating += new System.ComponentModel.CancelEventHandler(this.LibelleActifTxt_Validating);
            this.LibellePassifTxt.Validating += new System.ComponentModel.CancelEventHandler(this.LibellePassifTxt_Validating);

            this.SoldeActifTxt.Validating += new System.ComponentModel.CancelEventHandler(this.SoldeActifTxt_Validating);
            this.SoldePassifTxt.Validating += new System.ComponentModel.CancelEventHandler(this.SoldePassifTxt_Validating);
            */
        }

        public SaisieBilanUI(CAD db1)
        {
            InitializeComponent();

            db = db1;
            Logic = new SaisieBilanLogic(db);
            //view_model = new Saisie.ViewModel.SaisieBilanVM();
            //dgbilan.DataSource = view_model.Lignes;
            dgbilan.DataSource = GetAll();
            buildDataStyle(dgbilan);
            

        }

      
        public SaisieBilanUI(CAD db1, string an1)
        {
            Console.WriteLine("Le constructeur du view billan");
            InitializeComponent();
            
            an = an1;
            dDate = "01/01/" + an;
            fDate = "31/12/" + an;
            db = db1;
           
            Logic = new SaisieBilanLogic(db);
            
            //view_model = new Saisie.ViewModel.SaisieBilanVM();
           
           // dgbilan.DataSource = view_model.Lignes;

           // dgbilan.DataSource = GetAll();
            //dgbilan.DataSource = null;
           
            //buildDataStyle(dgbilan);
            

            //provider = ConfigurationSettings.AppSettings['providerName'];
            provider = "System.Data.SqlClient";
          
            // connectionString = ConfigurationSettings.AppSettings['SqlServer_ConnectionString'];
            connectionString = "Data Source=DESKTOP-RGPDGSP;Initial Catalog=Compta;Integrated Security=True";
            
            factory = DbProviderFactories.GetFactory(provider);
            


        }
        private void SaisieOpUI_Load(object sender, System.EventArgs e)
        {
            //Mois = "";
            Console.WriteLine("111 SaisieOpUI_LOAD ERROOOOE !!!!!!");
            AnneeTxt.Text = an;
            Console.WriteLine("222 SaisieBilanUI_LOAD ERROOOOE !!!!!!");
            //Lim_Dates();
            CmpActifTxt.Focus();
            Console.WriteLine("3333 SaisieBilanUI_LOAD ERROOOOE !!!!!!");

        }

        

        private void dgbilan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SaisieBilanUI_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'comptaDataSet2.Billan'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.billanTableAdapter2.Fill(this.comptaDataSet2.Billan);
            // TODO: cette ligne de code charge les données dans la table 'comptaDataSet1.Billan'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.billanTableAdapter1.Fill(this.comptaDataSet1.Billan);
            // TODO: cette ligne de code charge les données dans la table 'comptaDataSet.Billan'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            Console.WriteLine("111 SaisieBilanUI_LOAD ERROOOOE !!!!!!");
            this.billanTableAdapter.Fill(this.comptaDataSet.Billan);
            Console.WriteLine("222 SaisieBilanUI_LOAD ERROOOOE !!!!!!");
            AnneeTxt.Text = an;
            CmpActifTxt.Focus();
            double t = 00.00,tt=00.00;
            for (int i =0; i< dgbilan.Rows.Count; i++)
            {
                t = t + double.Parse(dgbilan.Rows[i].Cells[2].Value.ToString());
            }

            TotaleActifTxt.Text = t.ToString();
            for (int i = 0; i < dgbilan.Rows.Count; i++)
            {
                tt = tt + double.Parse(dgbilan.Rows[i].Cells[5].Value.ToString());
            }
            TotalePassifTxt.Text = tt.ToString();

        }

        private void CmpActifTxt_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void button_Enregistrer_Click(object sender, EventArgs e)
        {
            if (!CmpActifTxt.Text.Equals(" ") && !CmpPassifTxt.Text.Equals(" ") && !LibelleActifTxt.Text.Equals(" ") && !LibellePassifTxt.Text.Equals(" "))
            {
                double totaleactif = 00.00;
                double totalepassif = 00.00;

                //Console.WriteLine(TotaleActifTxt.Text.Replace('.', ','));
                //Console.WriteLine(TotaleActifTxt.Text.Replace('.', ',').GetType());
                //   Console.WriteLine(Fonctions.format1(TotaleActifTxt.Text.Replace('.', ',')));
                //Console.WriteLine(Fonctions.format1(TotaleActifTxt.Text.Replace('.', ',')).GetType());
                Console.WriteLine(double.Parse(Fonctions.format1(TotaleActifTxt.Text.Replace('.', ','))));
                //Console.WriteLine(double.Parse(Fonctions.format1(TotaleActifTxt.Text.Replace('.', ','))).GetType());
                // Console.WriteLine(double.Parse(Fonctions.format1(TotaleActifTxt.Text.Replace('.', ',')), (NumberStyles)32));
                //Console.WriteLine(double.Parse(Fonctions.format1(TotaleActifTxt.Text.Replace('.', ',')), (NumberStyles)32).GetType());
                //totaleactif = double.Parse(TotaleActifTxt.Text.Replace('.', ',') + SoldeActifTxt.Text.Replace('.', ','));
                totaleactif = double.Parse(Fonctions.format1(TotaleActifTxt.Text.Replace('.', ','))) + double.Parse(Fonctions.format1(SoldeActifTxt.Text.Replace('.', ',')));
                Console.WriteLine(totaleactif);
   
                totalepassif = double.Parse(Fonctions.format1(TotalePassifTxt.Text.Replace('.', ','))) + double.Parse(Fonctions.format1(SoldePassifTxt.Text.Replace('.', ',')));
                Console.WriteLine(totalepassif);
                double soldeactif = double.Parse(SoldeActifTxt.Text.Replace('.', ','));
                double soldepassif = double.Parse(SoldePassifTxt.Text.Replace('.', ','));
   
                using (var connection = factory.CreateConnection())
                {
     
                    //connection.ConnectionString = connectionString;
                    connection.ConnectionString = "Data Source=DESKTOP-RGPDGSP;Initial Catalog=Compta;Integrated Security=True";
                    connection.Open();
                    var command = factory.CreateCommand();
                    command.Connection = connection;

                    command.CommandText = $"Insert into Billan (CompteActif,LibelleActif,SoldeActif,TotaleActif,ComptePassif,LibellePassif,SoldePassif,TotalePassif) Values ('{CmpActifTxt.Text}','{ LibelleActifTxt.Text}','{soldeactif}','{totaleactif}','{CmpPassifTxt.Text}','{LibellePassifTxt.Text}','{soldepassif}','{totalepassif}')";

                    command.ExecuteNonQuery();
                }

                //Enregistrer();
                TotaleActifTxt.Text = Fonctions.format1(totaleactif.ToString());
                TotalePassifTxt.Text = Fonctions.format1(totalepassif.ToString());
                this.Refresh();
                //this.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vérifier les données saisies !!!! ");
            }
            
           
        }

        public List<BilanModel> GetAll()
        {
            var bilans = new List<BilanModel>();
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source=DESKTOP-RGPDGSP;Initial Catalog=Compta;Integrated Security=True";
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "Select * From Billan ;";
                using (DbDataReader reader = command.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        bilans.Add(new BilanModel
                        {
                            CompteActif = (string)reader["CompteActif"],
                            LibelleActif = (string)reader["LibelleActif"],
                            SoldeActif = (string)reader["SoldeActif"],
                            TotaleActif = (string)reader["TotaleActif"],
                            
                            ComptePassif = (string)reader["ComptePassif"],
                            LibellePassif = (string)reader["LibellePassif"],
                            SoldePassif = (string)reader["SoldePassif"],
                            TotalePassif = (string)reader["TotalePassif"]
                            
                        });
                    }
                }
                TotaleActifTxt.Text = bilans[bilans.Count].TotaleActif;
                TotalePassifTxt.Text = bilans[bilans.Count].TotalePassif;
            }

            return bilans;
        }

       /* void Enregistrer()
        {


            form_ok = true;
            valide_form();
            if (form_ok == true)
            {
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-RGPDGSP;Initial Catalog=Compta;Integrated Security=True");
                String query = "INSERT INTO Billan(CompteActif,LibelleActif,SoldeActif,TotaleActif,ComptePassif,LibellePassif,SoldePassif,TotalePassif) " +
                    " values('{CmpActifTxt.Text}','{ LibelleActifTxt.Text}','{SoldeActifTxt.Text.Replace('.', ',')}','{TotaleActifTxt.Text.Replace('.', ',') + SoldeActifTxt.Text.Replace('.', ',')}','{CmpPassifTxt.Text}','{LibellePassifTxt.Text}','{SoldePassifTxt.Text.Replace('.', ',')}','{TotalePassifTxt.Text.Replace('.', ',') + SoldePassifTxt.Text.Replace('.', ',')}') ";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
                Console.WriteLine("Apres DataAdapter !!!!!!!!!!!!!!!1 ");
               // DataTable dataTable = new DataTable();
                //dataAdapter.Fill(dataTable);
                /*
                BilanModel bilan = new BilanModel();


                bilan.Annee = "2021";
                //Console.WriteLine(MoisTxt.Text + "/" + AnneeTxt.Text);

                //ecriture.iDate = Fonctions.DateToInt(JourMoisTxt.Text + "/" + AnneeTxt.Text).ToString();

                bilan.CompteActif = CmpActifTxt.Text;
                bilan.LibelleActif = LibelleActifTxt.Text;
                bilan.SoldeActif = SoldeActifTxt.Text.Replace('.', ',');
                bilan.TotaleActif = TotaleActifTxt.Text.Replace('.', ',') + SoldeActifTxt.Text.Replace('.', ',');

                bilan.ComptePassif = CmpPassifTxt.Text;
                bilan.LibellePassif = LibellePassifTxt.Text;
                bilan.SoldePassif = SoldePassifTxt.Text.Replace('.', ',');
                bilan.TotalePassif = TotalePassifTxt.Text.Replace('.', ',') + SoldePassifTxt.Text.Replace('.', ',');
                
                /*if (STxt.Text == "D")
                {
                    ecriture.Debit = true;
                    compte1.AnouveauDebit = ecriture.Montant;
                    compte1.AnouveauCredit = "00.00";
                    compte2.AnouveauCredit = ecriture.Montant;
                    compte2.AnouveauDebit = "00.00";
                }
                if (STxt.Text == "C")
                {
                    ecriture.Debit = false;
                    compte1.AnouveauCredit = ecriture.Montant;
                    compte1.AnouveauDebit = "00.00";
                    compte2.AnouveauDebit = ecriture.Montant;
                    compte2.AnouveauCredit = "00.00";

                }
                bool arg = false;
                if (cpabutton.Checked == true) arg = true;

                int mess = Logic.Enregister(ref view_model,bilan);

                if (mess == 0)
                {
                    //warn.Text = "Operation enregistrée avec succée";
                    dgbilan.DataSource = null;
                    dgbilan.DataSource = view_model.Lignes;
                    buildDataStyle(dgbilan);
                    dgbilan.FirstDisplayedScrollingRowIndex = dgbilan.Rows.Count - 1;
                    RefreshPied();

                }
                if (mess == 1) warn.Text = "Echec de l'enregistrement Saisie Bilan";
                if (mess == 2) warn.Text = "Echec de l'enregistrement Saisie Bilan";
                */

           /*     CmpActifTxt.Focus();
                CmpActifTxt.SelectAll();



            }


        }*/


        /*void valide_form()
        {

            //form_ok = valide_CdeTxt(form_ok);
            //form_ok = valide_MoisTxt(form_ok);
            form_ok = valide_CmpActifTxt(form_ok);
            form_ok = valide_CmpPassifTxt(form_ok);
            form_ok = valide_LibelleActifTxt(form_ok);
            form_ok = valide_LibellePassifTxt(form_ok);
            
            form_ok = valide_SoldeActifTxt(form_ok);
            form_ok = valide_SoldePassifTxt(form_ok);
            
            //form_ok = valide_STxt(form_ok);
            //form_ok = valide_MntTxt(form_ok);

        }*/
       /* bool valide_CmpActifTxt(bool b)
        {
            if (Validator.valide_N(CmpActifTxt.Text) == false)
            {
                b = false;
                CmpActifTxt.ForeColor = Color.Red;
                ep.SetError(CmpActifTxt, "Le Format du compte est invalide");
                warn.Text = "Le Format du compte est invalide";
                //Contre_Partie = CpartTxt.Text;
            }
            else
            {
                int ret = Logic.get_libelle_intitule1(ref view_model, CmpActifTxt.Text);
                if (ret == 0)
                {
                    CmpActifTxt.ForeColor = Color.Black;
                    //warn.Text = view_model.compte_intitule;
                    // LibelTxt2.Text = view_model.compte_intitule + " ";
                    warn.Text = view_model.LibelleActif;
                    LibelleActifTxt.Text = view_model.LibelleActif + " ";
                    liblength = LibelleActifTxt.Text.Length;
                    //LibelTxt2.Text += mlibel;
                    ep.SetError(CmpActifTxt, "");

                }
                else
                {
                    CmpActifTxt.ForeColor = Color.Red;
                    warn.Text = "Compte Inexistant";
                    ep.SetError(CmpActifTxt, "Compte Inexistant");

                }

            }
            return b;

        }
        bool valide_CmpPassifTxt(bool b)
        {
            if (Validator.valide_N(CmpPassifTxt.Text) == false)
            {
                b = false;
                CmpPassifTxt.ForeColor = Color.Red;
                ep.SetError(CmpPassifTxt, "Le Format du compte est invalide");
                warn.Text = "Le Format du compte est invalide";
                //Contre_Partie = CpartTxt.Text;
            }
            else
            {
                int ret = Logic.get_libelle_intitule2(ref view_model, CmpPassifTxt.Text);
                if (ret == 0)
                {
                    CmpPassifTxt.ForeColor = Color.Black;
                    //warn.Text = view_model.compte_intitule;
                    // LibelTxt2.Text = view_model.compte_intitule + " ";
                    warn.Text = view_model.LibellePassif;
                    LibellePassifTxt.Text = view_model.LibellePassif + " ";
                    liblength = LibellePassifTxt.Text.Length;
                    //LibelTxt2.Text += mlibel;
                    ep.SetError(CmpPassifTxt, "");

                }
                else
                {
                    CmpPassifTxt.ForeColor = Color.Red;
                    warn.Text = "Compte Inexistant";
                    ep.SetError(CmpPassifTxt, "Compte Inexistant");

                }

            }
            return b;

        }*/
        /*bool valide_CmpActifTxt(bool b)
        {

            if (Validator.valide_N(CmpActifTxt.Text) == false)
            {
                b = false;
                CmpActifTxt.ForeColor = Color.Red;
                warn.Text = "Le Format du compte est invalide";
                ep.SetError(CmpActifTxt, "Le Format du compte est invalide");
            }
            else
            {
                Console.WriteLine(" Avant get_CompteActif Apel !!!!");

                int ret = Logic.get_compte_intituleActif(ref view_model, CmpActifTxt.Text.ToString());
                int ret2 = Logic.get_compte_SoldeActif(ref view_model, CmpActifTxt.Text.ToString());
                if (ret2==0)
                {

                    CmpActifTxt.ForeColor = Color.Black;
                    warn.Text = view_model.LibelleActif;
                    LibelleActifTxt.Text = view_model.LibelleActif + " ";
                    liblength = LibelleActifTxt.Text.Length;
                    
                    SoldeActifTxt.Text = view_model.SoldeActif.ToString();
                    ep.SetError(CmpActifTxt, "");

                }
                else
                {
                    CmpActifTxt.ForeColor = Color.Red;
                    warn.Text = "Compte Inexistant";
                    ep.SetError(CmpActifTxt, "Compte Inexistant");

                }
            
            }

            return b;
        }*/

        /*bool valide_CmpPassifTxt(bool b)
        {

            if (Validator.valide_N(CmpPassifTxt.Text) == false)
            {
                b = false;
                CmpPassifTxt.ForeColor = Color.Red;
                warn.Text = "Le Format du compte est invalide";
                ep.SetError(CmpPassifTxt, "Le Format du compte est invalide");
            }
            else
            {
                int ret = Logic.get_compte_intitulePassif(ref view_model, CmpPassifTxt.Text.ToString());
                int ret2 = Logic.get_compte_SoldePassif(ref view_model, CmpPassifTxt.Text.ToString());
                if (ret == 0 && ret2==0)
                {

                    CmpPassifTxt.ForeColor = Color.Black;
                    warn.Text = view_model.LibellePassif;

                    LibellePassifTxt.Text = view_model.LibellePassif + " ";
                    liblength = LibellePassifTxt.Text.Length;
                    SoldePassifTxt.Text = view_model.SoldePassif.ToString();
                    ep.SetError(CmpPassifTxt, "");

                }
                else
                {
                    CmpPassifTxt.ForeColor = Color.Red;
                    warn.Text = "Compte Inexistant";
                    ep.SetError(CmpPassifTxt, "Compte Inexistant");

                }

            }

            return b;
        }*/

        /*bool valide_LibellePassifTxt(bool b)
        {
            if (LibellePassifTxt.Text == "")
            {
                b = false;
                LibellePassifTxt.ForeColor = Color.Red;
                ep.SetError(LibellePassifTxt, "Code libellé Inexistant");
                warn.Text = "Libellé automatique inspecifié";

            }
            else
            {

                if (LibellePassifTxt.Text.Length > liblength) mlibel = LibellePassifTxt.Text.Substring(liblength, LibellePassifTxt.Text.Length - liblength);
                else mlibel = "";
                LibellePassifTxt.ForeColor = Color.Black;
                ep.SetError(LibellePassifTxt, "");
                warn.Text = "";
            }
            return b;

        }*/
        /*bool valide_LibelleActifTxt(bool b)
        {
            if (LibelleActifTxt.Text == "")
            {
                b = false;
                LibelleActifTxt.ForeColor = Color.Red;
                ep.SetError(LibelleActifTxt, "Code libellé Inexistant");
                warn.Text = "Libellé automatique inspecifié";

            }
            else
            {
                if (LibelleActifTxt.Text.Length > liblength) mlibel = LibelleActifTxt.Text.Substring(liblength, LibelleActifTxt.Text.Length - liblength);
                else mlibel = "";
                LibelleActifTxt.ForeColor = Color.Black;
                ep.SetError(LibelleActifTxt, "");
                warn.Text = "";
            }
            return b;

        }*/

        /*bool valide_SoldeActifTxt(bool b)
        {
            SoldeActifTxt.Text = SoldeActifTxt.Text.Replace(".", ",");
            if (Validator.valide_F(SoldeActifTxt.Text) == false)
            {
                b = false;
                SoldeActifTxt.ForeColor = Color.Red;
                ep.SetError(SoldeActifTxt, "Format montant invalide");
                warn.Text = "Format montant invalide";
            }
            else
            {
                SoldeActifTxt.ForeColor = Color.Black;
                ep.SetError(SoldeActifTxt, "");
                warn.Text = "";

            }
            return b;
        }*/
        /*bool valide_SoldePassifTxt(bool b)
        {
            SoldePassifTxt.Text = SoldePassifTxt.Text.Replace(".", ",");
            if (Validator.valide_F(SoldePassifTxt.Text) == false)
            {
                b = false;
                SoldePassifTxt.ForeColor = Color.Red;
                ep.SetError(SoldePassifTxt, "Format montant invalide");
                warn.Text = "Format montant invalide";
            }
            else
            {
                SoldePassifTxt.ForeColor = Color.Black;
                ep.SetError(SoldePassifTxt, "");
                warn.Text = "";

            }
            return b;
        }*/

        #region KeyDown
        /*private void CmpActifTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                LibelleActifTxt.Focus();
                LibelleActifTxt.SelectAll();
            }
        }*/
        /*private void CmpPassifTxt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                LibellePassifTxt.Focus();
                LibellePassifTxt.SelectAll();
            }
        }*/

        #endregion

        #region Validating
           /* private void CmpActifTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                valide_CmpActifTxt(true);
            }
            private void CmpPassifTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                valide_CmpPassifTxt(true);
            }


            private void LibelleActifTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                valide_LibelleActifTxt(true);
            }
            private void LibellePassifTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                valide_LibellePassifTxt(true);
            }

            private void SoldeActifTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                valide_SoldeActifTxt(true);
            }

            private void SoldePassifTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                valide_SoldePassifTxt(true);
            }*/
        #endregion

        /* bool valide_MoisTxt(bool b)
         {

             if (Validator.valide_N(MoisTxt.Text) == false)
             {
                 b = false;
                 MoisTxt.ForeColor = Color.Red;
                 warn.Text = "Format numerique invalide";
                 ep.SetError(MoisTxt, "Format numerique invalide");
             }
             else
             {
                 int mois = Int32.Parse(MoisTxt.Text);
                 if ((0 < mois) && (mois < 13))
                 {
                     string ddat = djour + "/" + MoisTxt.Text + "/" + AnneeTxt.Text;
                     string fdat = fjour + "/" + MoisTxt.Text + "/" + AnneeTxt.Text;
                     if ((Fonctions.DateToInt(ddat) < idDt) || (Fonctions.DateToInt(fdat) > ifDt))
                     {
                         b = false;
                         MoisTxt.ForeColor = Color.Red;
                         warn.Text = "Date non incluse dans l'exercice courant";
                         ep.SetError(MoisTxt, "Date non incluse dans l'exercice courant");

                     }
                     else
                     {

                         MoisTxt.ForeColor = Color.Black;
                         warn.Text = "";
                         ep.SetError(MoisTxt, "");

                     }
                 }

             }
             return b;
         }*/

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        /*public void RefreshPied()
        {
            /*MDebTxt.Text = Fonctions.format1(view_model.mouvements_debit.ToString());
            MCredTxt.Text = Fonctions.format1(view_model.mouvements_credit.ToString());
            double diff = view_model.mouvements_credit - view_model.mouvements_debit;
            MDiffTxt.Text = Fonctions.format1(diff.ToString());
            if (view_model.mouvements_debit > view_model.mouvements_credit) MDiffTxt.ForeColor = Color.Red;
            else if (view_model.mouvements_debit < view_model.mouvements_credit) MDiffTxt.ForeColor = Color.Blue;
            else MDiffTxt.ForeColor = Color.Black;*/

          /*  TotaleActifTxt.Text = Fonctions.format1(view_model.TotaleActif.ToString());
            TotalePassifTxt.Text = Fonctions.format1(view_model.TotalePassif.ToString());
            //double diff = view_model.TotaleActif - view_model.TotalePassif;
            //CDiffTxt.Text = Fonctions.format1(diff.ToString());
            //if (view_model.cumul_debit > view_model.cumul_credit) CDiffTxt.ForeColor = Color.Red;
            //else if (view_model.cumul_debit < view_model.cumul_credit) CDiffTxt.ForeColor = Color.Blue;
            //else CDiffTxt.ForeColor = Color.Black;



        }*/
        private void buildDataStyle(DataGridView dg)
        {

            dg.Columns[0].Width = 57;
           // dg.Columns[0].HeaderText = "jj/mm";

            dg.Columns[1].Width = 144;

            dg.Columns[2].Width = 66;

            dg.Columns[3].Width = 57;


            dg.Columns[4].Width = 144;
            dg.Columns[5].Width = 66;
           // dg.Columns[6].Width = 64;
            //dg.Columns[7].Width = 168;
            dg.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CmpActifTxt.Text = ""; CmpPassifTxt.Text = "";
            LibelleActifTxt.Text = ""; LibellePassifTxt.Text = "";
            SoldeActifTxt.Text = ""; SoldePassifTxt.Text = "";
            TotaleActifTxt.Text = ""; TotalePassifTxt.Text = "";
            dgbilan.DataSource = "";
        }

        private void LibelleActifTxt_TextChanged(object sender, EventArgs e)
        {
            
                var bil = new List<BilanModel>();
                using (var connection = factory.CreateConnection())
                {
                    connection.ConnectionString = "Data Source=DESKTOP-RGPDGSP;Initial Catalog=Compta;Integrated Security=True";
                    connection.Open();
                    var command = factory.CreateCommand();
                    command.Connection = connection;
                    command.CommandText = $"Select Intitule,MouvementDebit,MouvementCredit From Comptes where Compte='{int.Parse(CmpActifTxt.Text)}' ;";

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
     
                            bil.Add(new BilanModel
                            {
                                LibelleActif = (string)reader["Intitule"],
                                TotaleActif = Fonctions.format1(reader["MouvementDebit"].ToString()),
                                TotalePassif = Fonctions.format1(reader["MouvementCredit"].ToString())
                            });
                            
                        }
                    }
                    
                }
                
            if (!CmpActifTxt.Text.Equals(" ") && !(bil[0].LibelleActif).Equals(" "))
            {
                LibelleActifTxt.Text = bil[0].LibelleActif;
                SoldeActifTxt.Text = Fonctions.format1((double.Parse(bil[0].TotaleActif) - double.Parse(bil[0].TotalePassif)).ToString());
            }
            else
            {
                MessageBox.Show("le Compte n'existe pas !!!");
            }
        }

        private void LibellePassifTxt_TextChanged(object sender, EventArgs e)
        {
            
                Console.WriteLine("aaaaaaa");
                var bil = new List<BilanModel>();
                using (var connection = factory.CreateConnection())
                {
                    Console.WriteLine("bbbbbbbbbbb");
                    connection.ConnectionString = "Data Source=DESKTOP-RGPDGSP;Initial Catalog=Compta;Integrated Security=True";
                    connection.Open();
                    var command = factory.CreateCommand();
                    command.Connection = connection;
                    command.CommandText = $"Select Intitule,MouvementDebit,MouvementCredit From Comptes where Compte='{int.Parse(CmpPassifTxt.Text)}' ;";
                    Console.WriteLine("cccccccccc");
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("dddddddddd");
                        while (reader.Read())
                        {
                            Console.WriteLine("eeeeeeeeeeee");
                            bil.Add(new BilanModel
                            {
                                LibelleActif = (string)reader["Intitule"],
                                TotaleActif = Fonctions.format1(reader["MouvementDebit"].ToString()),
                                TotalePassif = Fonctions.format1(reader["MouvementCredit"].ToString())
                            });

                        }
                    }

                }
            if (!CmpPassifTxt.Text.Equals("") && !(bil[0].LibelleActif).Equals(""))
            {
                LibellePassifTxt.Text = bil[0].LibelleActif;
                SoldePassifTxt.Text = Fonctions.format1((double.Parse(bil[0].TotalePassif) - double.Parse(bil[0].TotaleActif)).ToString());

            }
            else
            {
                MessageBox.Show("le Compte n'existe pas !!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgbilan.Rows.Count > 0)
            {
                
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);
                
                for (int i = 1; i < dgbilan.Columns.Count+1; i++)
                {
                    
                    Console.WriteLine(dgbilan.Columns[i-1].HeaderText);
                    xcelApp.Cells[1, i] = dgbilan.Columns[i-1].HeaderText;
                    
                }

                for (int i =0; i< dgbilan.Rows.Count; i++)
                {
                    for (int j =0; j< dgbilan.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = dgbilan.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }
    }
}
