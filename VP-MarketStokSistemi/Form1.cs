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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connect = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
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
            using (SqlConnection con = new SqlConnection(connect))
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
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select ProductID,ProductName,CategoryID,UnitPrice,UnitsInStock,QuantityPerUnit from Products", con);
                adtr.Fill(daset, "Products");
                dataGridView1.DataSource = daset.Tables["Products"];
                con.Close();
            }
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                DataTable table = new DataTable();
                con.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select ProductID,ProductName,CategoryID,UnitPrice,UnitsInStock,QuantityPerUnit from Products where ProductName like '%" + txtSearch.Text + "%'", con);
                adtr.Fill(table);
                dataGridView1.DataSource = table;
                con.Close();
            }
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
