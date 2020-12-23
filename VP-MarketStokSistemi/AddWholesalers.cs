using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-2NBD61T\SQLEXPRESS;Integrated Security=True;initial catalog=northwind;");
        private void btnAdd_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("insert into Wholesalers (CompanyName, ContactName, Address, City, Phone, Fax) values(@CompanyName, @ContactName, @Address, @City, @Phone, @Fax)", connect);
            command.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
            command.Parameters.AddWithValue("@ContactName", txtContactName.Text);
            command.Parameters.AddWithValue("@Address", txtAddress.Text);
            command.Parameters.AddWithValue("@City", txtCity.Text);
            command.Parameters.AddWithValue("@Phone", txtPhone.Text);
            command.Parameters.AddWithValue("@Fax", txtFax.Text);
            command.ExecuteNonQuery();
            connect.Close();
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
