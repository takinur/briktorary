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
    public partial class frmMng_Product : Form
    {
        public frmMng_Product()
        {
            InitializeComponent();
        }
        //SqlConnection Location of Database
        //SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\storeAppDB.mdf; Integrated Security=True");
        string con = System.Configuration.ConfigurationManager.ConnectionStrings["storeApp"].ConnectionString;
        SqlConnection cnn; 
        SqlCommand cmd;

        //Share value between forms
        public static string slRowID = "";
        private void frmMng_Product_Load(object sender, EventArgs e)
        {
            cnn =  new SqlConnection(con);
            alldata();
        }
        //Opening  only one sub form at a time
        private Form activeForm = null;
        private void openForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            openForm(new frmModify());
            
        }
        
        //All data in gridview
        public void alldata()
        {
            
            cnn.Open();
            cmd = new SqlCommand("select productID, ProductName, catName, quantity, price from product inner join category on product.catID = category.catID", cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);            
            table.AutoGenerateColumns = false;
         
            table.Columns[0].DataPropertyName = "productID";
            table.Columns[1].DataPropertyName = "ProductName";
            table.Columns[2].DataPropertyName = "catName";
            table.Columns[3].DataPropertyName = "Quantity";
            table.Columns[4].DataPropertyName = "Price";
            table.Columns[5].HeaderText = "Action";
            table.Columns[6].HeaderText = "Action";
            
            table.DataSource = dt;                  
            cnn.Close();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            txtSearch.Text = "";
            alldata();

        }
        
        

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==5) //edit
            {
                if (table.SelectedCells.Count > 0)
                {
                    try
                    {
                        slRowID = table.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                        table.CurrentRow.Selected = true;

                        frmModify mod = new frmModify();
                        mod.Show();
                        mod.frmupdt();
                        if (activeForm != null) activeForm.Close();
                        activeForm = mod;
                                               
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                
            }
            if (e.ColumnIndex == 6) //Delete
            {

                if (table.SelectedCells.Count > 0)
                {
                    try
                    {
                        string rowId = table.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                        string rowPName = table.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                        table.CurrentRow.Selected = true;
                        //Confirmation before Deleting
                        DialogResult dialogResult = MessageBox.Show("Deleting Product: " + rowPName + " are you sure?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            cnn.Open();
                            cmd = new SqlCommand("DELETE FROM product WHERE productID = @proId ", cnn);
                            cmd.Parameters.AddWithValue("proId", rowId);
                            cmd.ExecuteNonQuery();
                            btnDelete.UseColumnTextForButtonValue = true;
                            cnn.Close();
                            alldata();
                            MessageBox.Show("Product Deleted Successfully! ", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            //Do nothing
                            alldata();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                
                    
            }
            
        }   
    }
}
