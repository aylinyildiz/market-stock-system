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
    public partial class UpdateProduct : Form
    {
        public UpdateProduct()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;initial catalog=northwind;");
        DataSet daset = new DataSet();
        DataSet daset2 = new DataSet();
        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            ListProduct();
            ListCategories();
        }
        private void ListProduct()
        {
            connect.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select ProductID,ProductName,CategoryID,UnitPrice,UnitsInStock,QuantityPerUnit from Products", connect);
            adtr.Fill(daset, "Products");
            dgwProduct.DataSource = daset.Tables["Products"];
            connect.Close();
        }
        private void ListCategories()
        {
            connect.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select CategoryID from Categories", connect);
            adtr.Fill(daset2, "Categories");
            comboBox1.DataSource = daset2.Tables["Categories"];
            connect.Close();
        }

        private void dgwProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //var row = dgwProduct.CurrentRow;
            //txtProductName.Text = row.Cells[2].Value.ToString();
            //comboBox1.SelectedValue = row.Cells[1].ToString();
            //txtUnitPrice.Text = row.Cells[3].Value.ToString();
            //txtUnitInStock.Text = row.Cells[4].Value.ToString();
            //txtQuantity.Text = row.Cells[5].Value.ToString();

            txtProductName.Text = dgwProduct.CurrentRow.Cells["ProductName"].Value.ToString();
            comboBox1.Text = dgwProduct.CurrentRow.Cells["CategoryID"].Value.ToString();
            txtUnitPrice.Text = dgwProduct.CurrentRow.Cells["UnitPrice"].Value.ToString();
            txtUnitInStock.Text = dgwProduct.CurrentRow.Cells["UnitsInStock"].Value.ToString();
            txtQuantity.Text = dgwProduct.CurrentRow.Cells["QuantityPerUnit"].Value.ToString();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("Update Products set ProductName=@ProductName,CategoryID=@CategoryID,UnitPrice=@UnitPrice,UnitsInStock=@UnitsInStock,QuantityPerUnit=@QuantityPerUnit",connect);
            command.Parameters.AddWithValue("@ProductName", txtProductName.Text);
            command.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(comboBox1.SelectedValue));
            command.Parameters.AddWithValue("@UnitPrice", txtUnitPrice.Text);
            command.Parameters.AddWithValue("@UnitsInStock", txtUnitInStock.Text);
            command.Parameters.AddWithValue("@QuantityPerUnit", txtQuantity.Text);
            command.ExecuteNonQuery();
            connect.Close();
            daset.Tables["Products"].Clear();
            ListProduct();
            MessageBox.Show("Product updated!");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("delete from Products where ProductID = " + dgwProduct.CurrentRow.Cells
                ["ProductID"].Value.ToString(),connect);
            command.ExecuteNonQuery();
            connect.Close();
            daset.Tables["Products"].Clear();
            ListProduct();
            MessageBox.Show("Product deleted");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            connect.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select ProductID,ProductName,CategoryID,UnitPrice,UnitsInStock,QuantityPerUnit from Products where ProductName like '%" + textBox1.Text+"%'",connect);
            adtr.Fill(table);
            dgwProduct.DataSource = table;
            connect.Close();
        }
    }
}
