using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using business_Layer;
using Shared;
namespace Dentist_Clinic.Views
{
    public partial class frmConsumption: Form
    {
        public frmConsumption()
        {
            InitializeComponent();
        }
        private void refreshConsumptionGrigView() => dGVConsumption.DataSource = BussConsumption.GetConsumption();
        private void refreshTotalCount()
        {
            refreshConsumptionGrigView();
            lblCountConsumption.Text = BussConsumption.GetTotalPatients().ToString();
            lblPayed.Text = BussConsumption.GetTotalPayed().ToString() + " " + "USD";
            lblRemaining.Text = BussConsumption.GetTotalRemind().ToString() +" "+ "USD";
        }
        private void frmConsumption_Load(object sender, EventArgs e)
        {
            refreshTotalCount();
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPatents_Click(object sender, EventArgs e)
        {

        }

        private void btnShowSpending_Click(object sender, EventArgs e)
        {
            frmSpending1 spending = new frmSpending1();
            spending.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            { dGVConsumption.Sort(dGVConsumption.Columns[1], ListSortDirection.Descending); }
            else
            { dGVConsumption.Sort(dGVConsumption.Columns[1], ListSortDirection.Ascending); }
        }

    }
}
