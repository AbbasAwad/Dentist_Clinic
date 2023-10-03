using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentist_Clinic.Views
{
    public partial class frmBackUP : Form
    {
        public frmBackUP()
        {
            InitializeComponent();
        }

        private void btnBrowes_Click(object sender, EventArgs e)
        {
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.Filter = "Backup Files (*,*) | *.* ";
            saveFileDialog1.ShowDialog();
            txtBackUP.Text = saveFileDialog1.FileName;
        }

        private void btnSaveBackUP_Click(object sender, EventArgs e)
        {
            My_Classes.DB_General obj = new My_Classes.DB_General();
            obj.general_query("backup database DentistClinicDB to disk='" + txtBackUP.Text + "'");
            MessageBox.Show("Backup Done Successfuly");

        }

        private void btnBrowesRestor_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Restore Files (*,bak) | *.bak ";
            openFileDialog1.ShowDialog();
            txtRestor.Text = openFileDialog1.FileName;
        }

        private void btnSaveRestor_Click(object sender, EventArgs e)
        {
            My_Classes.DB_General obj = new My_Classes.DB_General();
            obj.general_query("use master; Restore database DentistClinicDB to disk='" + txtRestor.Text + "'");
            MessageBox.Show("Restore Done Successfuly");
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
