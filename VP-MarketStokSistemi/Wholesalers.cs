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
    public partial class Wholesalers : Form
    {
        public Wholesalers()
        {
            InitializeComponent();
        }
        string connect = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        DataSet daset = new DataSet();
        private void Wholesalers_Load(object sender, EventArgs e)
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
        private void dgwWholesalers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddWholesalers addWholesalers = new AddWholesalers();
            addWholesalers.ShowDialog();
            dgwWholesalers.Refresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateWholesalers updateWholesalers = new UpdateWholesalers();
            updateWholesalers.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand command = new SqlCommand("delete from Wholesalers where ID = " + dgwWholesalers.CurrentRow.Cells
                ["ID"].Value.ToString(), con);
                command.ExecuteNonQuery();
                con.Close();
            }
            daset.Tables["Wholesalers"].Clear();
            ListWholesalers();
            MessageBox.Show("Whosaler deleted");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select ID, CompanyName, ContactName, Address, City, Phone, Fax from Wholesalers where CompanyName like '%" + txtSearch.Text + "%'", con);
                adtr.Fill(table);
                dgwWholesalers.DataSource = table;
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
