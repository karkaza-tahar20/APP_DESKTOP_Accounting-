using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using CoucheAcceeDonnees;
using SharpCompta;

namespace ComptabiliteGenerale.Saisie.View
{
    public partial class Authentification : Form
    {
        private CAD db;
        //private ComptabiliteGenerale.Saisie;

        public Authentification(CAD db1)
        {
            db = db1;
            InitializeComponent();
            loginTxt.Focus();
        }
        public Authentification()
        {
            InitializeComponent();
            loginTxt.Focus();
        }

        private void login_Click(object sender, EventArgs e)
        {

        }

        private void Authentification_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!passwordTxt.Text.Equals("") && !loginTxt.Text.Equals(""))
            {
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-RGPDGSP;Initial Catalog=Compta;Integrated Security=True");
                String query = "select * FROM Users where login ='"+loginTxt.Text.Trim()+"' and password = '"+passwordTxt.Text.Trim()+"' ";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count==1)
                {
                    Console.WriteLine("VALIDER !!!!");
                    //Error.Text = "Authentification Succee ";
                    //ComptabiliteGenerale.Saisie.View.Ajout_Societe f = new ComptabiliteGenerale.Saisie.View.Ajout_Societe();
                    SharpComptaUI f = new SharpComptaUI();
                   
                    f.ShowDialog();
                   
                }
                else
                {
                    label2.Visible = true;
                    MessageBox.Show("please enter your usernaem and pasword.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    loginTxt.Focus();
                    return;
                    //MessageBox.Show("Verifiez votre username ou password !!!");
                }
                this.Close();

            }
            else
            {
                Error.Text = "Ereur de saisie !!!!";
            }
            

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) passwordTxt.UseSystemPasswordChar = false;
            else passwordTxt.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            passwordTxt.Text = ""; loginTxt.Text = ""; checkBox1.Checked = false;
            Error.Text = ""; label2.Visible = false;
        }
        private int Valider(ComptabiliteGenerale.UserModel userModel)
        {
            int a = 0;
            try
            {

                DataRow[] drs = db.Ds.Tables["Users"].Select();
                //IList<EcritureModel> ecritures = new List<EcritureModel>();
                if (drs.Length > 0)
                {
                    foreach (DataRow dr in drs)
                    {
                        //EcritureModel ecriture_model = new EcritureModel();
                        if (dr["login"].ToString() == userModel.login && dr["password"].ToString() == userModel.password)
                        {
                            a = 1;
                            break;
                        }


                    }
                    if (a == 1) return 1;
                    else return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
    }
}
