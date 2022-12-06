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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aracekle arac = new aracekle();
            arac.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            aracsil sil = new aracsil();
            sil.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            aracduzenle duzenle=new aracduzenle();
            duzenle.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://reservation.tuvturk.com.tr/web.ui/Index.aspx");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            borcode borc = new borcode();
            borc.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {
            }
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hesapmakinesi hesap = new hesapmakinesi();
            hesap.Show();           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            aracsorgula arac = new aracsorgula();
            arac.Show();
            this.Hide();

        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yardım arac = new yardım();
            arac.Show();           
        }

        private void hakkımdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hakkımda arac = new hakkımda();
            arac.Show();            
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            //button2.BackgroundImage = Properties.Resources.bitmap;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
           // button2.BackgroundImage = Properties.Resources.bitmap2;
        }


    }
}
