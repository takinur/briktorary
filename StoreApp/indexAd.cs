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

namespace StoreApp
{
    public partial class frmIndexAd : Form
    {
        public frmIndexAd()
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
        private void showSubMenu(Panel pnlsub)
        {
            if (pnlsub.Visible == false)
            {
                hideSubMenu();
                pnlsub.Visible = true;
            }
            else
                pnlsub.Visible = false;
        }
        

        private void btnCat_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSub);
        }
         //Opening other forms Within This form
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
        private void btnprdct_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSub);
            pnlTagHom.Visible = false;
            pnlTagOrde.Visible = false;
            pnlTagPro.Visible = true;
        }

        private void frmIndexAd_Load(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new frmAdHome());
            pnlTagPro.Visible = false;
            pnlTagOrde.Visible = false;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new frmOrders());
            pnlTagOrde.Visible = true;
            pnlTagHom.Visible = false;
            pnlTagPro.Visible = false;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            openChildForm(new frmHelp());
        }

        private void btnAllProduct_Click(object sender, EventArgs e)
        {
            frmModify mod = new frmModify();
            mod.Show();
            if (activeForm != null) activeForm.Close();
            activeForm = mod;
            pnlTagOrde.Visible = false;
            pnlTagHom.Visible = false;
            pnlTagPro.Visible = true;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Closing Application!", "Application Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
            
        }

        private void brnMngProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new frmMng_Product());
            pnlTagOrde.Visible = false;
            pnlTagHom.Visible = false;
            pnlTagPro.Visible = true;
        }

        private void pnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pnlTopBar_MouseDown(object sender, MouseEventArgs e)
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmLogin logi = new frmLogin();
            logi.Show();
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdHome());
            pnlTagPro.Visible = false;
            pnlTagOrde.Visible = false;
            pnlTagHom.Visible = true;
        }
    }
}
