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

namespace StoreApp
{
    public partial class frmCatPro : Form
    {
        public frmCatPro()
        {
            InitializeComponent();
        }
        //SqlConnection Location of Database
        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\#Rage_Limbo\$University of Greenwich\L4DC90\Second-Half\DDOOCP\Application\StoreApp\StoreApp\storeAppDB.mdf; Integrated Security=True");
        SqlCommand cmd;
        string prodId = "";
        string unitprice = "";
        int currentCid = frmLogin.currUsrid;

        private void frmCatPro_Load(object sender, EventArgs e)
        {

           
        }

        public void catCon()
        {

            lblCatName.Text = "Concrete Bricks";
            alldataCat();
        }
        public void catEngi()
        {
            lblCatName.Text = "Engineering Bricks";
            alldataCat();
        }
        public void catMor()
        {

            lblCatName.Text = "Mortar/Cements";
            alldataCat();

        }
        //Search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                (table.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            else
            {

                (table.DataSource as DataTable).DefaultView.RowFilter = string.Format("ProductName LIKE '{0}%'", txtSearch.Text);
            }
        }
        //All product based on Category
        private void alldataCat()
        {

            cnn.Open();
            //first category
            if (lblCatName.Text == "Concrete Bricks")
            {
                cmd = new SqlCommand("SELECT productID, ProductName, catName, price FROM product INNER JOIN category ON product.catID = category.catID WHERE category.catID = 1", cnn);
            }//Second Category
            else if (lblCatName.Text == "Engineering Bricks")
            {
                cmd = new SqlCommand("SELECT productID, ProductName, catName, price FROM product INNER JOIN category ON product.catID = category.catID WHERE category.catID = 2", cnn);
            }//Third Category
            else
            {
                cmd = new SqlCommand("SELECT productID, ProductName, catName, price FROM product INNER JOIN category ON product.catID = category.catID WHERE category.catID = 3", cnn);
            }

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            table.AutoGenerateColumns = false;
            table.Columns[0].DataPropertyName = "productID";
            table.Columns[1].DataPropertyName = "ProductName";
            table.Columns[2].DataPropertyName = "catName";
            table.Columns[3].DataPropertyName = "Price";
            table.Columns[4].HeaderText = "Action";
            table.DataSource = dt;
            cnn.Close();
        }
        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) //Buy now_--Ask for quantity
            {

                if (table.SelectedCells.Count > 0)
                {
                    try
                    {
                        prodId = table.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                        unitprice = table.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                        table.CurrentRow.Selected = true;
                        txtQuanti.Text = "1";
                        txtQuanti.Visible = true;
                        lblQuant.Visible = true;
                        btnAdcart.Visible = true;
                        txtQuanti.Focus();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
        }
        //Add to cart
        private void btnAdcart_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                try
                {
                    int quantit = Convert.ToInt32(txtQuanti.Text);
                    float unitPri = (float)Convert.ToDouble(unitprice);
                    float totprice = unitPri * quantit;
                    cnn.Open();
                    cmd = new SqlCommand("INSERT INTO tblCart(productID, customerID, cquantity, totprice) VALUES(@proid, @cusid, @quan, @price)", cnn);
                    cmd.Parameters.AddWithValue("@proid", prodId);
                    cmd.Parameters.AddWithValue("@cusid", currentCid);
                    cmd.Parameters.AddWithValue("@quan", quantit);
                    cmd.Parameters.AddWithValue("@price", totprice);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("Product Added to Cart! View cart to Confirm Order. ", "Buy Product ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    txtQuanti.Visible = false;
                    lblQuant.Visible = false;
                    btnAdcart.Visible = false;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Validating Quantity
        private new bool Validate()
        {
            if (string.IsNullOrEmpty(txtQuanti.Text))
            {
                MessageBox.Show("Please Enter Quantity !", "Quantity Error! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(txtQuanti.Text, "[^0-9]"))
            {
                MessageBox.Show("Quantity Should be in Number only!", "Quantity Error! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuanti.Text = "";
                txtQuanti.Focus();
                return false;
            }
            return true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            alldataCat();
        }
      
    }
}
