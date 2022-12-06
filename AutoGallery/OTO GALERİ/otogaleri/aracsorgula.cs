using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otogaleri
{
    public partial class aracsorgula : Form
    {
        public aracsorgula()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.turkiye.gov.tr/emniyet-adima-tescilli-arac-sorgulama");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel_internet.Enabled = true;
            panel_sms.Enabled = false;
            panel1.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel_sms.Enabled = true;
            panel_internet.Enabled = false;
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu arac = new menu();
            arac.Show();
            this.Hide();
        }

        private void aracsorgula_Load(object sender, EventArgs e)
        {
            panel_sms.Enabled = false;
            panel_internet.Enabled = false;
            panel1.Visible = false;
        }
    }
}
