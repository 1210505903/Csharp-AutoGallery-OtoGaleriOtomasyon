using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace otogaleri
{
    public partial class aracsil : Form
    {
        public aracsil()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "\\otogaleri.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adaptor = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        private void griddoldur()
        {
            OleDbDataAdapter da;
            DataSet ds;
            DataTable dt;
            baglanti.Open();
            da = new OleDbDataAdapter("SELECT tbl_arac.a_fiyat, tbl_arac.plaka, tbl_araclar.a_marka, tbl_arac.a_seri, tbl_kasa.kasa_tipi, tbl_arac.a_yıl, tbl_arac.a_km, tbl_arac.a_vites, tbl_renk.renk, tbl_arac.a_yüklemetarihi, tbl_arac.a_acıklama FROM tbl_arac,tbl_araclar,tbl_kasa,tbl_renk where tbl_arac.a_kasa=tbl_kasa.k_ID and tbl_araclar.a_id=tbl_arac.a_marka and tbl_arac.a_renk=tbl_renk.r_ID", baglanti);            

            ds = new DataSet();
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();
        }
        private void araçSilVeDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aracduzenle duz = new aracduzenle();
            duz.Show();
            this.Hide();
        }

        private void aracsil_Load(object sender, EventArgs e)
        {
            griddoldur();


        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = false;
                
                comboBox1.Enabled = false;
                
            }

        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                textBox2.Enabled = true;
                textBox1.Enabled = false;
                
                comboBox1.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                comboBox1.Enabled = false;
                radioButton4.Enabled = true;
                radioButton5.Enabled = true;
                radioButton6.Enabled = true;
                radioButton7.Enabled = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu Yeni = new menu();
            Yeni.Show();
            this.Hide();        
        }

        private void araçEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aracekle aracc = new aracekle();
            aracc.Show();
            this.Hide();
        }

        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hesapmakinesi makine = new hesapmakinesi();
            makine.Show();
        }


        private void hakkımdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hakkımda yardım = new hakkımda();
            yardım.Show();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.tbl_aracTableAdapter1.FillBy(this.otogaleriDataSet1.tbl_arac);
            //}
            //catch (System.Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            DataTable tbl = new DataTable();
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            ds.Clear();
            adaptor = new OleDbDataAdapter("Select * from araclar where plaka Like'" + textBox1.Text + "%'", baglanti);
            adaptor.Fill(ds, "plakalar");
            dataGridView1.DataSource = ds.Tables["plakalar"];
            baglanti.Close();
            
            
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            DataTable tbl = new DataTable();
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            ds.Clear();
            adaptor = new OleDbDataAdapter("Select * from araclar where a_yıl Like'" + textBox2.Text + "%'", baglanti);
            adaptor.Fill(ds, "modeller");
            dataGridView1.DataSource = ds.Tables["modeller"];
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            baglanti.Open();
            DataTable tbl = new DataTable();
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            ds.Clear();
            adaptor = new OleDbDataAdapter("SELECT tbl_arac.a_fiyat, tbl_arac.plaka, tbl_araclar.a_marka, tbl_arac.a_seri, tbl_kasa.kasa_tipi, tbl_arac.a_yıl, tbl_arac.a_km, tbl_arac.a_vites, tbl_renk.renk, tbl_arac.a_yüklemetarihi, tbl_arac.a_acıklama FROM tbl_arac,tbl_araclar,tbl_kasa,tbl_renk where tbl_arac.a_kasa=tbl_kasa.k_ID and tbl_araclar.a_id=tbl_arac.a_marka and tbl_arac.a_renk=tbl_renk.r_ID and tbl_araclar.a_marka='" + comboBox1.Text + "'", baglanti);

            adaptor.Fill(ds, "markalar");
            dataGridView1.DataSource = ds.Tables["markalar"];
            baglanti.Close();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton4.Checked == true)
            {
                comboBox1.Items.Clear();
                comboBox1.Enabled = true;
                comboBox1.Text = "";
            }
            comboBox1.Items.Clear();

            baglanti.Open();
            OleDbDataReader oku;
            komut.Connection = baglanti;
            komut.CommandText = "Select a_marka from tbl_araclar where a_kasatip=1";
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[0]);
                comboBox1.ValueMember=oku[0].ToString();
            }
            baglanti.Close();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                comboBox1.Items.Clear();
                comboBox1.Enabled = true;
                comboBox1.Text = "";
            }
            baglanti.Open();
            OleDbDataReader oku;
            komut.Connection = baglanti;
            komut.CommandText = "Select a_marka from tbl_araclar where a_kasatip=4";
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[0]);
            }
            baglanti.Close();
            
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                comboBox1.Items.Clear();
                comboBox1.Enabled = true;
                comboBox1.Text = "";
            }
            baglanti.Open();
            OleDbDataReader oku;
            komut.Connection = baglanti;
            komut.CommandText = "Select a_marka from tbl_araclar where a_kasatip=2";
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[0]);
            }
            baglanti.Close();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                comboBox1.Items.Clear();
                comboBox1.Enabled = true;
                comboBox1.Text = "";
            }
            baglanti.Open();
            OleDbDataReader oku;
            komut.Connection = baglanti;
            komut.CommandText = "Select a_marka from tbl_araclar where a_kasatip=3";
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[0]);
            }
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel_marka_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yardım arac = new yardım();
            arac.Show();
            this.Hide();
        }
 
    }
}
