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
    public partial class UpdateWholesalers : Form
    {
        public UpdateWholesalers()
        {
            InitializeComponent();
        }

        string connect = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        DataSet daset = new DataSet();
       
        private void UpdateWholesalers_Load(object sender, EventArgs e)
        {
            ListWholesalers();
        }
        private void ListWholesalers()
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select ID, CompanyName, ContactName, Address, City, Phone, Fax from Wholesalers", con);
                adtr.Fill(daset, "Wholesalers");
                dgwWholesalers.DataSource = daset.Tables["Wholesalers"];
                con.Close();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand command = new SqlCommand("Update Wholesalers set CompanyName=@CompanyName,ContactName=@ContactName,Address=@Address,Phone=@Phone,Fax=@Fax where ID = '" + Convert.ToInt32(dgwWholesalers.CurrentRow.Cells[0].Value) + "'", con);
                command.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                command.Parameters.AddWithValue("@ContactName", txtContactName.Text);
                command.Parameters.AddWithValue("@Address", txtAddress.Text);
                command.Parameters.AddWithValue("@City", txtCity.Text);
                command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                command.Parameters.AddWithValue("@Fax", txtFax.Text);
                command.ExecuteNonQuery();
                con.Close();
            }
            daset.Tables["Wholesalers"].Clear();
            ListWholesalers();
            MessageBox.Show("Wholesaler updated!");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void dgwWholesalers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgwWholesalers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCompanyName.Text = dgwWholesalers.CurrentRow.Cells["CompanyName"].Value.ToString();
            txtContactName.Text = dgwWholesalers.CurrentRow.Cells["ContactName"].Value.ToString();
            txtAddress.Text = dgwWholesalers.CurrentRow.Cells["Address"].Value.ToString();
            txtCity.Text = dgwWholesalers.CurrentRow.Cells["City"].Value.ToString();
            txtPhone.Text = dgwWholesalers.CurrentRow.Cells["Phone"].Value.ToString();
            txtFax.Text = dgwWholesalers.CurrentRow.Cells["Fax"].Value.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            connect.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select ID, CompanyName, ContactName, Address, City, Phone, Fax from Wholesalers where CompanyName like '%" + txtSearch.Text + "%'", connect);
            adtr.Fill(table);
            dgwWholesalers.DataSource = table;
            connect.Close();
        }
    }
}
