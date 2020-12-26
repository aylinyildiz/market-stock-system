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
    public partial class DescendingProducts : Form
    {
        public DescendingProducts()
        {
            InitializeComponent();
        }
        string connect = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        DataSet daset = new DataSet();
        private void DescendingProducts_Load(object sender, EventArgs e)
        {
            ListProduct();
        }
        private void ListProduct()
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select ProductID,ProductName,CategoryID,UnitPrice,UnitsInStock,QuantityPerUnit from Products where UnitsInStock<=10", con);
                adtr.Fill(daset, "Products");
                dgwDecreasingProduct.DataSource = daset.Tables["Products"];
                con.Close();
            }
        }

        private void dgwDecreasingProduct_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateProduct updateProduct = new UpdateProduct();
            updateProduct.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
