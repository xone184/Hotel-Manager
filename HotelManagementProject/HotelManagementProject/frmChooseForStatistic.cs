using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementProject
{
    public partial class frmChooseForStatistic : Form
    {
        public frmChooseForStatistic()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.mainForm.Visible = false;
            this.Visible = false;
            Program.billStatisticsForm = new frmBillStatistics();
            Program.billStatisticsForm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.mainForm.Visible = false;
            this.Visible = false;
            Program.billStatisticsServiceForm = new frmBillStatisticsService();
            Program.billStatisticsServiceForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.mainForm.Visible = false;
            this.Visible = false;
            Program.billStatisticsDeviceForm = new frmBillStatisticsDevice();
            Program.billStatisticsDeviceForm.Show();
        }
    }
}
