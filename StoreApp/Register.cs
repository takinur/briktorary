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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        //SqlConnection Location of Database
        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\#Rage_Limbo\$University of Greenwich\L4DC90\Second-Half\DDOOCP\Application\StoreApp\StoreApp\storeAppDB.mdf; Integrated Security=True");
        SqlCommand cmd;

        //Dragging the form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLgn_Click(object sender, EventArgs e)
        {
            frmLogin logi = new frmLogin();
            logi.Show();
            this.Hide();
            
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearBox();
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void btnSup_Click(object sender, EventArgs e)
        {
            if (Validate())
            {                
                bool exists = false;

                //check if the username  already exists
                cnn.Open();
                cmd = new SqlCommand("select count(*) from Customer where userName = @UserName", cnn);
                {
                    cmd.Parameters.AddWithValue("UserName", txtUname.Text);
                    exists = (int)cmd.ExecuteScalar() > 0;
                    cnn.Close();
                }
                // if exists message error
                if (exists || txtUname.Text == "Admin" || txtUname.Text == "admin")
                {
                    MessageBox.Show( "This username is already taken by another user!","Username Already Exist", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    txtUname.Focus();
                    
                }
                //Add New User
                else
                {
                    try
                    {
                        cnn.Open();
                        cmd = new SqlCommand("insert into customer(firstName, lastName, userName, Password) values(@fName, @lName, @uName, @pass)", cnn);
                        cmd.Parameters.AddWithValue("@fName", txtFname.Text);
                        cmd.Parameters.AddWithValue("@lName", txtLname.Text);
                        cmd.Parameters.AddWithValue("@uName", txtUname.Text);
                        cmd.Parameters.AddWithValue("@pass", txtRePass.Text);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                        clearBox();
                        MessageBox.Show("Sign Up Successfull. You can Login Now!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmLogin logi = new frmLogin();
                        logi.Show();
                        this.Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to Add User!" + ex);
                    }

                }
            }
            
        }
        //Validating User inputs
        private new bool Validate()
        {
            //First Name
            if (string.IsNullOrEmpty(txtFname.Text))
            {
                MessageBox.Show("Please Enter First Name! ", "First Name Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFname.Focus();
                return false;
            }
            //Last Name
            else if (string.IsNullOrEmpty(txtLname.Text))
            {
                MessageBox.Show("Please Enter Last Name! ", "Last Name Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLname.Focus();
                return false;
            }
            //Username
            else if (string.IsNullOrEmpty(txtUname.Text))
            {
                MessageBox.Show("Please Enter a Username! ", "Username Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUname.Focus();
                return false;
            }      
            else if (System.Text.RegularExpressions.Regex.IsMatch(txtUname.Text, "[^a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Username Should  not contain any Special Character ", "Username Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUname.Focus();
                return false;
            }
            //Password
            else if (string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Please Enter Password! ", "Password Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPass.Focus();
                return false;
            }
            //Confirm Password
            else if (string.IsNullOrEmpty(txtRePass.Text))
            {
                MessageBox.Show("Please Confirm Password! ", "Password Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRePass.Focus();
                return false;
            }
            else if(txtPass.Text != txtRePass.Text)
            {
                MessageBox.Show("Confirm Password did Not match! ", "Password confirmation failed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Terms and conditions
            else if (!chkTerms.Checked)
            {
                MessageBox.Show("You must agree to terms and Conditions. ", " Terms Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        //Clear Text Boxes
        private void clearBox()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

    }
}
