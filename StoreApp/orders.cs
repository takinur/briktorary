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
    public partial class frmOrders : Form
    {
        public frmOrders()
        {
            InitializeComponent();
        }

        //SqlConnection Location of Database
        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\#Rage_Limbo\$University of Greenwich\L4DC90\Second-Half\DDOOCP\Application\StoreApp\StoreApp\storeAppDB.mdf; Integrated Security=True");
        SqlCommand cmd;

        private void frmOrders_Load(object sender, EventArgs e)
        {
            allOrders();
        }
        //View All orders
        private void allOrders()
        {
            cnn.Open();
            cmd = new SqlCommand("SELECT tblorDetails.orDetailsid, tblorder.dateTime, tblorder.orderId, customer.firstName," +
                " product.productName, category.catName, tblorDetails.Qyta, tblorder.totalPay  FROM tblorder INNER JOIN " +
                " tblorDetails ON tblorDetails.orderId = tblorder.orderId INNER JOIN " +
                " product ON tblorDetails.productId = product.productId INNER JOIN " +
                " category ON product.catID = category.catID INNER JOIN customer ON " +
                " customer.customerId= tblorder.customerId ", cnn);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            table.AutoGenerateColumns = false;

            table.Columns[0].DataPropertyName = "dateTime";
            table.Columns[1].DataPropertyName = "orderId";
            table.Columns[2].DataPropertyName = "firstName";
            table.Columns[3].DataPropertyName = "productName";
            table.Columns[4].DataPropertyName = "catName";
            table.Columns[5].DataPropertyName = "Qyta";
            table.Columns[6].DataPropertyName = "totalPay";
            table.Columns[7].HeaderText = "Action";

            table.DataSource = dt;
            cnn.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            allOrders();
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7) //Delete the order
            {

                if (table.SelectedCells.Count > 0)
                {
                    try
                    {
                        string ordId = table.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                        table.CurrentRow.Selected = true;
                        //Confirmation before Deleting
                        DialogResult dialogResult = MessageBox.Show("Cancelling Order Number: " + ordId + ", are you sure?", "Cancel Order", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            cnn.Open();
                            //First delete from Order Details Table
                            cmd = new SqlCommand("DELETE FROM tblorDetails WHERE orderId = @orderId", cnn);
                            cmd.Parameters.AddWithValue("orderId", ordId);
                            cmd.ExecuteNonQuery();
                            //Delete form Order Table
                            cmd = new SqlCommand("DELETE FROM tblorder WHERE orderId = @orderId ", cnn);
                            cmd.Parameters.AddWithValue("orderId", ordId);
                            cmd.ExecuteNonQuery();                            
                            cnn.Close();
                            allOrders();
                            MessageBox.Show("Order Cancelled Successfully! ", "Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            //Do nothing
                            allOrders();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
        }   }
    }
}
