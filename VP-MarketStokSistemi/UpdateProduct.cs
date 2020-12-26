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
        //Veritabanı bağlantısını değiştirdim
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;initial catalog=northwind;");
        DataSet daset = new DataSet();
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

        //Kategorileri alıp listeledim
        private void ListCategories()
        {
            connect.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adtr = new SqlDataAdapter("select CategoryID,CategoryName from Categories", connect);
            adtr.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                comboBox1.DisplayMember = "CategoryName";
                comboBox1.ValueMember = "CategoryID";
                comboBox1.DataSource = dt;
            }
            else
            {
                comboBox1.Text = "";
            }
            connect.Close();
        }
        private void dgwProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connect.Open();
            //sorguya hangi product olduğunu belirtmek için product id girdim.
            SqlCommand command = new SqlCommand("Update Products set  ProductName=@ProductName,CategoryID=@CategoryID,UnitPrice=@UnitPrice,UnitsInStock=@UnitsInStock,QuantityPerUnit=@QuantityPerUnit where ProductID='" + Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value) + "'", connect);
            command.Parameters.AddWithValue("@ProductName", txtProductName.Text);
            //convert kullandım çünkü tipleri veri tababnında böyle
            command.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(comboBox1.SelectedValue));
            command.Parameters.AddWithValue("@UnitPrice", Convert.ToDecimal(txtUnitPrice.Text));
            command.Parameters.AddWithValue("@UnitsInStock", Convert.ToInt16(txtUnitInStock.Text));
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
                ["ProductID"].Value.ToString(), connect);
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
            SqlDataAdapter adtr = new SqlDataAdapter("select ProductID,ProductName,CategoryID,UnitPrice,UnitsInStock,QuantityPerUnit from Products where ProductName like '%" + textBox1.Text + "%'", connect);
            adtr.Fill(table);
            dgwProduct.DataSource = table;
            connect.Close();
        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgwProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductName.Text = dgwProduct.CurrentRow.Cells["ProductName"].Value.ToString();
            comboBox1.SelectedValue = dgwProduct.CurrentRow.Cells["CategoryID"].Value.ToString(); //selected value
            txtUnitPrice.Text = dgwProduct.CurrentRow.Cells["UnitPrice"].Value.ToString();
            txtUnitInStock.Text = dgwProduct.CurrentRow.Cells["UnitsInStock"].Value.ToString();
            txtQuantity.Text = dgwProduct.CurrentRow.Cells["QuantityPerUnit"].Value.ToString();
        }
    }
}
