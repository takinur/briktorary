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
using System.Globalization;
using System.Collections;

namespace StoreApp
{
    public partial class frm_Cart : Form
    {
        public frm_Cart()
        {
            InitializeComponent();
        }
        //SqlConnection Location of Database
        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\#Rage_Limbo\$University of Greenwich\L4DC90\Second-Half\DDOOCP\Application\StoreApp\StoreApp\storeAppDB.mdf; Integrated Security=True");
        SqlCommand cmd;
        //Current Customer ID
        int cuser = frmLogin.currUsrid;
        //Calculating
        Double subtotal = 0;
        Double discount = 0;
        Double total = 0;

        private void frm_Cart_Load(object sender, EventArgs e)
        {
            txtSub.Enabled = false;
            txtDiscount.Enabled = false;
            txtTotal.Enabled = false;
            alldata();
            calcu();
        }
        //All data in gridview
        private void alldata()
        {
            cnn.Open();
            cmd = new SqlCommand("SELECT product.productId, ProductName, catName, price, cquantity, totprice, cartID  FROM tblCart INNER JOIN product ON" +
                " tblCart.productID=product.productID  INNER JOIN category on product.catID=category.catID WHERE customerID=@cusid", cnn);
            cmd.Parameters.AddWithValue("@cusid", cuser);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            table.AutoGenerateColumns = false;
            table.Columns[0].DataPropertyName = "productId"; // Hidden Column
            table.Columns[1].DataPropertyName = "ProductName";
            table.Columns[2].DataPropertyName = "catName";
            table.Columns[3].DataPropertyName = "Price";
            table.Columns[4].DataPropertyName = "cquantity";
            table.Columns[5].DataPropertyName = "totprice"; 
            table.Columns[6].HeaderText = "Action";
            table.Columns[7].DataPropertyName = "cartID";//Hidden Colmun
            table.DataSource = dt;
            cnn.Close();
        }


        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6) //Delete Cart Product
            {

                if (table.SelectedCells.Count > 0)
                {
                    try
                    {
                        string cartID = table.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                        table.CurrentRow.Selected = true;
                        cnn.Open();
                        cmd = new SqlCommand("DELETE FROM tblCart WHERE cartID = @cId AND customerID=@cusid", cnn);
                        cmd.Parameters.AddWithValue("cId", cartID);
                        cmd.Parameters.AddWithValue("cusid", cuser);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                        subtotal = 0;
                        alldata();
                        calcu();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
        }
       
        private void btnOrder_Click(object sender, EventArgs e)
        {   
            if(txtSub.Text == "")
            {
                MessageBox.Show("Add Products To Cart/Shopping Basket First.", "Basket/Cart Empty!",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                try
                {
                    string ordID;
                    string datime = DateTime.Now.ToString();
                    cnn.Open();
                    //Inserting Data to Order Table
                    cmd = new SqlCommand("INSERT INTO tblorder(customerID, totalPay, dateTime) VALUES(@custid, @totPay, @date)", cnn);
                    cmd.Parameters.AddWithValue("@custid", cuser);
                    cmd.Parameters.AddWithValue("@totPay", txtTotal.Text);
                    cmd.Parameters.AddWithValue("@date", datime);
                    cmd.ExecuteNonQuery();

                    //Retriving Latest Order ID
                    cmd = new SqlCommand("SELECT TOP(1) orderId FROM tblorder ORDER BY 1 DESC", cnn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    ordID =dt.Rows[0]["orderId"].ToString();

                    //Inserting Data to Order Details 
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        cmd = new SqlCommand("INSERT INTO tblorDetails VALUES(@orderid, @proid, @qta, @suPrice)", cnn);
                        cmd.Parameters.AddWithValue("@orderid", ordID);
                        cmd.Parameters.AddWithValue("@proid", table.Rows[i].Cells[0].Value);
                        cmd.Parameters.AddWithValue("@qta", table.Rows[i].Cells[4].Value);
                        cmd.Parameters.AddWithValue("@suPrice", table.Rows[i].Cells[5].Value);
                        cmd.ExecuteNonQuery();
                    }
                    cnn.Close();
                    MessageBox.Show("Order Placed! Thanks For Purcharsing.", "Order Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clrtextbox();
                    clrCart();
                    alldata();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }
        private void clrtextbox()
        {
            txtSub.Text = null;
            txtDiscount.Text = null;
            txtTotal.Text = null;
        }

        //Clear cart
        private void clrCart()
        {
            try
            {
                cnn.Open();
                cmd = new SqlCommand("DELETE FROM tblCart WHERE customerID=@cusid", cnn);
                cmd.Parameters.AddWithValue("cusid", cuser);
                cmd.ExecuteNonQuery();
                cnn.Close();
                subtotal = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Calculations
        private void calcu()
        {
            int disPerc = 0;

           //Sub Total
            for(int i=0; i<table.Rows.Count ; i++)
            {
                subtotal = (subtotal + Convert.ToDouble(table.Rows[i].Cells[5].Value.ToString()));
                txtSub.Text = Convert.ToString(subtotal);
            }
            //Seting-Up discount percentage
            if (subtotal >= 10000 && subtotal <= 30000)
            {
                disPerc = 15;
            }
            else if (subtotal >= 7000 && subtotal <10000)
            {
                disPerc = 10;
            }
            else if (subtotal >= 5000 && subtotal <7000 )
            {
                disPerc = 7;
            }
            else if (subtotal >= 3500 && subtotal < 5000)
            {
                disPerc = 5;
            } 
            else if (subtotal >= 2500 && subtotal < 3500)
            {
                disPerc = 2;
            }
            else
            {
                disPerc = 0;
            }
            //Discount
            discount = (subtotal * disPerc) / 100;
            txtDiscount.Text = Convert.ToString(discount);
           
            //Tottal amount
            total = subtotal - discount;
            txtTotal.Text = Convert.ToString(total);
            
        }

    }
}
