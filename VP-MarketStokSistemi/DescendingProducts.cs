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
    public partial class DescendingProducts : Form
    {
        public DescendingProducts()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-2NBD61T\SQLEXPRESS;Integrated Security=True;initial catalog=northwind;");
        DataSet daset = new DataSet();
        private void DescendingProducts_Load(object sender, EventArgs e)
        {
            ListProduct();
        }
        private void ListProduct()
        {
            connect.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select ProductID,ProductName,CategoryID,UnitPrice,UnitsInStock,QuantityPerUnit from Products where UnitsInStock<=10", connect);
            adtr.Fill(daset, "Products");
            dgwDecreasingProduct.DataSource = daset.Tables["Products"];
            connect.Close();
        }

        private void dgwDecreasingProduct_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateProduct updateProduct = new UpdateProduct();
            updateProduct.ShowDialog();
        }
    }
}
