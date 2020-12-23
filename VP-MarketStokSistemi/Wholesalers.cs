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
    public partial class Wholesalers : Form
    {
        public Wholesalers()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-2NBD61T\SQLEXPRESS;Integrated Security=True;initial catalog=northwind;");
        DataSet daset = new DataSet();
        private void Wholesalers_Load(object sender, EventArgs e)
        {
            ListWholesalers();
        }
        private void ListWholesalers()
        {
            connect.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select ID, CompanyName, ContactName, Address, City, Phone, Fax from Wholesalers", connect);
            adtr.Fill(daset, "Wholesalers");
            dgwWholesalers.DataSource = daset.Tables["Wholesalers"];
            connect.Close();
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
            ListWholesalers();
        }
    }
}
