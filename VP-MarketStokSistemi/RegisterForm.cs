using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_MarketStokSistemi
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }
        string connect = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand command = new SqlCommand("insert into Users (UserName, Password) values(@UserName, @Password)", con);
                command.Parameters.AddWithValue("@UserName", txtUsername.Text);
                command.Parameters.AddWithValue("@Password", txtPassword.Text);
                command.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("New user added!");
            this.Close();
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void lblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();

        }
    }
}
