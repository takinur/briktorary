using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;

namespace StoreApp
{
    public partial class frmModify : Form
    {
        public frmModify()
        {
            InitializeComponent();
            lblTitle.Text = "Add Product";
            pnlError.Visible = false;
            lblProID.Visible = false;

        }
        //SqlConnection Location of Database
        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\#Rage_Limbo\$University of Greenwich\L4DC90\Second-Half\DDOOCP\Application\StoreApp\StoreApp\storeAppDB.mdf; Integrated Security=True");
        SqlCommand cmd;
        //Collecting value from from parent form
        readonly string rowID = frmMng_Product.slRowID;

        //Dragging the form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // Update form 
        public void frmupdt()
        {
            btnSave.Text = "Update";
            btnDelete.Visible = true;
            lblTitle.Text = "Update Product";
            cmbCat.Visible = false;
            lblCCat.Visible = false;
            lblProID.Visible = true;
            lblProID.Text = rowID;
            lblIDName.Visible = true;
        }
        
        //Error panel
        void showError(String text)
        {
            lblError.Text = text;
            pnlError.Visible = true;
            tmrError.Start();
        }

        private void frmModify_Load(object sender, EventArgs e)
        {

            comboValue();

               

        }
        //Combo Box items 
        private void comboValue()
        {
            
            cmbCat.DisplayMember = "Text";
            cmbCat.ValueMember = "Value";

            var items = new[]
            {
            new { Text = "Concrete Brick", Value = "1" },
            new { Text = "Engineering Brick", Value = "2" },
            new { Text = "Mortar/Cement", Value = "3" },

            };
            cmbCat.DataSource = items;
        }
        // Timer
        private void tmrError_Tick(object sender, EventArgs e)
        {
            tmrError.Stop();
            pnlError.Visible = false;

        }
        //////Saving Data to Server
        private void SaveData()
        {
            cnn.Open();            
            cmd = new SqlCommand("INSERT INTO product(productName, quantity, price, catID) values(@proN, @quan, @price, @cat)", cnn);
            cmd.Parameters.AddWithValue("@proN", txtProName.Text);
            cmd.Parameters.AddWithValue("@quan", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@cat", cmbCat.SelectedValue);

            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        //Update Previous data
        
        private void UpdateData()
        {
            cnn.Open();
            cmd = new SqlCommand("Update product Set productName=@Name, price=@price, quantity=@quan where productID=@id", cnn);

            cmd.Parameters.AddWithValue("@Name", txtProName.Text);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@quan", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@id", rowID);

            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
          
   
            if (lblTitle.Text == "Add Product") //Save new product
            {

                if (Validate())
                {
                    SaveData();                   
                   
                    
                    MessageBox.Show("Product Saved Successfully", "Product Added", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ClearBox();
                    showError("Click refresh to view added Products!");
                }
                else
                { 
                    //Errors
                }

               
            }
            else //Edit Previous Product
            {
                if (Validate())
                {
                    DialogResult dialogResult = MessageBox.Show("Updating Product, are you Sure ?", "Product Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        UpdateData();
                        MessageBox.Show("Product Updated Successfully! ", "Product Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }

                    else if (dialogResult == DialogResult.No)
                    {
                        showError("Product Update Failed!");
                        ClearBox();
                    }

                }
                
            }




        }
        //Validating Textboxs
        private new bool Validate()
        {   //Product Name
            if (string.IsNullOrEmpty(txtProName.Text))
            {
                showError("Please Enter Product Name!");
                return false;
            }//Price
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                showError("Please Enter Product Price!");
                return false;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(txtPrice.Text, "[^0-9.0-9]+$"))
            {
                showError("Price Should be in Number only!"); 
                txtPrice.Text = "";
                return false;
            }//Quantity
            else if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                showError("Please Enter Product Quantity!");
                return false;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(txtQuantity.Text, "[^0-9]"))
            {
                showError("Quantity Should be in Number only!");
                txtQuantity.Text = "";
                return false;
            }

            return true;
        }

        private void cmbCat_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private void ClearBox()
        {
            
            txtProName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
        }
        //Delete Button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Confirmation 
            DialogResult dialogResult = MessageBox.Show("Are Sure to permanantly delete the Product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                //Delete execute
                cnn.Open();
                cmd = new SqlCommand("DELETE FROM product where productID = @proId ", cnn);
                cmd.Parameters.AddWithValue("proId", rowID);
                cmd.ExecuteNonQuery();
                cnn.Close();
                
                MessageBox.Show("Product Deleted Successfully! ", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                showError("Product removal Failed");
            }


            
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
                    
        }

        private void frmModify_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
