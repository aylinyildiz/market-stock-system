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
    public partial class AddWholesalers : Form
    {
        public AddWholesalers()
        {
            InitializeComponent();
        }
        string connect = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand command = new SqlCommand("insert into Wholesalers (CompanyName, ContactName, Address, City, Phone, Fax) values(@CompanyName, @ContactName, @Address, @City, @Phone, @Fax)", con);
                command.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                command.Parameters.AddWithValue("@ContactName", txtContactName.Text);
                command.Parameters.AddWithValue("@Address", txtAddress.Text);
                command.Parameters.AddWithValue("@City", txtCity.Text);
                command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                command.Parameters.AddWithValue("@Fax", txtFax.Text);
                command.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Wholesalers added!");
            
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void txtWID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void AddWholesalers_Load(object sender, EventArgs e)
        {

        }
    }
}
