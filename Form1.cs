using business_Layer;
using Dentist_Clinic.Views;
using Guna.UI.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Shared;

namespace Dentist_Clinic
{
    public partial class Form1 : Form
    {
        Shared.User User;
        int loginFailedAttempts = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void _ReastLoginForm()
        {
            txtPassword.Clear();
            txtUserName.Clear();
            loginFailedAttempts = 0;
            lblMessError1.ResetText();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            CenterToScreen();
            txtUserName.Focus();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }
   
        private void btnLogeIn_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "" && txtPassword.Text != "")
            {
                if (BussUsers.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim()))
                {
                    User = BussUsers.GetUser(txtUserName.Text.Trim());
                    frmMain Main = new frmMain();
                    _ReastLoginForm();
                      Main.Show();
                     this.Hide();
                }
                else
                {
                    lblMessError1.Text = "Inavlid User Name Or Password!! \n You have "
                                        + (2 - loginFailedAttempts) + " attempts before lock your account";
                    loginFailedAttempts++;
                    if (loginFailedAttempts == 3)
                    {
                        btnLogeIn.Enabled = false;
                        lblMessError1.Text = "You Are Locked after 3 Faild Trails!!" +
                                               " \n Contact System Administrators to Unlock Your Account";
                        return;
                    }
                }
            }
            else
            { MessageBox.Show("Please , Fill In All Fields"); }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkShow_CheckedChanged(object sender, EventArgs e)
        {
            if(checkShow.Checked)
            {
                pictureHide.Visible = false;
                pictureShow.Visible = true;
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                pictureHide.Visible = true;
                pictureShow.Visible = false;
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
