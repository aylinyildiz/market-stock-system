using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace VP_MarketStokSistemi
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        string connect = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;

        private void AddProduct_Load(object sender, EventArgs e)
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                SqlCommand command = new SqlCommand("insert into Products (ProductName, CategoryID, UnitPrice,UnitsInStock,QuantityPerUnit) values(@ProductName, @CategoryID, @UnitPrice,@UnitsInStock,@QuantityPerUnit)", con);
                con.Open();
                command.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                command.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(comboBox1.SelectedValue));
                command.Parameters.AddWithValue("@UnitPrice", txtUnitPrice.Text);
                command.Parameters.AddWithValue("@UnitsInStock", txtUnitInStock.Text);
                command.Parameters.AddWithValue("@QuantityPerUnit", txtQuantity.Text);
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Product added!");
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
        }
    }
}
