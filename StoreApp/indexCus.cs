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
using System.Runtime.InteropServices;

namespace StoreApp
{
    public partial class frmIndexCus : Form
    {
        public frmIndexCus()
        {
            InitializeComponent();
        }
        //Dragging the form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //Submenu------------------------------
        private void hideSubMenu()
        {
            pnlSub.Visible = false;

        }
        private void showSubMenu( Panel pnlsub)
        {
            if (pnlsub.Visible == false)
            {
                hideSubMenu();
                pnlsub.Visible = true;
            }
            else
                pnlsub.Visible = false;
        }
        private void frmIndexCus_Load(object sender, EventArgs e)
        {

            openChildForm(new frmCusHome());
            hideSubMenu();
            pnlTagHom.Visible = true;
            pnlTagPro.Visible = false;
            pnlTagCat.Visible = false;
            

        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSub);
            pnlTagPro.Visible = false;
            pnlTagCat.Visible = true;
            pnlTagHom.Visible = false;
        }
        //Opening other child forms 
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(childForm);
            pnlContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
           
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new frmProduct());
            pnlTagPro.Visible = true;
            pnlTagCat.Visible = false;
            pnlTagHom.Visible = false;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Close Application?", "Application Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            openChildForm(new frmHelp());
        }



        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmLogin logi = new frmLogin();
            logi.Show();
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCusHome());
            pnlTagPro.Visible = false;
            pnlTagCat.Visible = false;
            pnlTagHom.Visible = true;
        }
        
        private void btnCat1_Click(object sender, EventArgs e)
        {
            frmCatPro catf = openChildCat();
            catf.catCon();
        }


        private void btnCat2_Click(object sender, EventArgs e)
        {
            frmCatPro catf = openChildCat();
            catf.catEngi();
            
        }

        private void brnCat3_Click(object sender, EventArgs e)
        {
            frmCatPro catf = openChildCat();
            catf.catMor();
        }

        //Child Forms for Catergory Tab
        private frmCatPro openChildCat()
        {
            frmCatPro catf = new frmCatPro();
            if (activeForm != null) activeForm.Close();
            activeForm = catf;
            catf.TopLevel = false;
            catf.FormBorderStyle = FormBorderStyle.None;
            catf.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(catf);
            pnlContainer.Tag = catf;
            catf.BringToFront();
            catf.Show();
            return catf;
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pnlMain_MouseDown(object sender, MouseEventArgs e)
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

        private void btnMinmz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_Cart());
        }
    }
}
