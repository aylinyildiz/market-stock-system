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
    public partial class btnWholesalers : Form
    {
        public btnWholesalers()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;initial catalog=northwind;");
        DataSet daset = new DataSet();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct add = new AddProduct();
            add.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string constr = (@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;initial catalog=northwind;");
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT CategoryID, CategoryName FROM Categories", con))
                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Insert the Default Item to DataTable.
                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    row[1] = "Please select";
                    dt.Rows.InsertAt(row, 0);

                    //Assign DataTable as DataSource.
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "CategoryName";
                    comboBox1.ValueMember = "CategoryID";
                }
            }
            ListProduct();
        }
        private void ListProduct()
        {
            connect.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select ProductID,ProductName,CategoryID,UnitPrice,UnitsInStock,QuantityPerUnit from Products", connect);
            adtr.Fill(daset, "Products");
            dataGridView1.DataSource = daset.Tables["Products"];
            connect.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateProduct updateProduct = new UpdateProduct();
            updateProduct.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UpdateProduct updateProduct = new UpdateProduct();
            updateProduct.ShowDialog();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            DescendingProducts descendingProducts = new DescendingProducts();
            descendingProducts.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Wholesalers wholesalers = new Wholesalers();
            wholesalers.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductName.Text = dataGridView1.CurrentRow.Cells["ProductName"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["CategoryID"].Value.ToString();
            txtUnitPrice.Text = dataGridView1.CurrentRow.Cells["UnitPrice"].Value.ToString();
            txtUnitInStock.Text = dataGridView1.CurrentRow.Cells["UnitsInStock"].Value.ToString();
            txtQuantity.Text = dataGridView1.CurrentRow.Cells["QuantityPerUnit"].Value.ToString();
        }
    }
}
