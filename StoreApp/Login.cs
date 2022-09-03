using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace StoreApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        //SqlConnection Location of Database
        //SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\#Rage_Limbo\$University of Greenwich\L4DC90\Second-Half\DDOOCP\Application\StoreApp\StoreApp\storeAppDB.mdf; Integrated Security=True");
        SqlCommand cmd;
        string con = System.Configuration.ConfigurationManager.ConnectionStrings["storeApp"].ConnectionString;
        SqlConnection cnn;

        public static int currUsrid = 0;
        int attempt = 1;

        //Dragging the form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(con);
            //Load
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {//Login Authentication
            string uName = txtUname.Text;
            string pass = txtPass.Text;
            if (Validate())
            {
                try
                {
                    cnn.Open();
                    cmd = new SqlCommand("SELECT customerID, userName, Password FROM Customer WHERE userName=@uName AND Password=@uPass", cnn);
                    cmd.Parameters.AddWithValue("uName", txtUname.Text);
                    cmd.Parameters.AddWithValue("uPass", txtPass.Text);
                   
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    //Admin Login
                    if ((uName == "Admin" || uName == "admin") && (pass == "Admin" || pass == "admin"))
                    {
                        frmIndexAd adm = new frmIndexAd();
                        adm.Show();
                        this.Hide();
                        
                    }
                    //User Login/Customer
                    else if (dt.Rows.Count > 0)
                    {
                        currUsrid = Convert.ToInt32(dt.Rows[0]["customerID"].ToString().Trim());
                        this.Hide();
                        frmIndexCus cust = new frmIndexCus();
                        cust.Show();
                    }
                    //Error of attempt
                    else
                    {
                        MessageBox.Show("Username or Password not found! You have used " + attempt + " out of 4 Attempt!", " User Not found!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        attempt++;
                        txtPass.Text = "";
         
                    }
                    //Attempt exceed
                    if (attempt == 5)
                    {
                        txtUname.Enabled = false;
                        txtPass.Enabled = false;
                        btnLogin.Enabled = false;
                    }
                    //Close the connection 
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnReg_Click(object sender, EventArgs e)
        {
           //Opening Register Form
             frmRegister Reg = new frmRegister();
             Reg.Show();
             this.Hide();
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnMinmz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Validating Textboxs
        private new bool Validate()
        {
            if (string.IsNullOrEmpty(txtUname.Text))
            {
                MessageBox.Show("Please Enter a Username! ", "Username Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUname.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Please Enter Password! ", "Password Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPass.Focus();
                return false;
            }
                      
            return true;
        }
    }
}
