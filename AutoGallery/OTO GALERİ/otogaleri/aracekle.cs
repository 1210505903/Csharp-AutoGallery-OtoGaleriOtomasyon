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

namespace otogaleri
{
    public partial class aracekle : Form
    {
        public aracekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "\\otogaleri.accdb");
        //OleDbDataReader dr;
        OleDbCommand komut;
        
        private void aracekle_Load(object sender, EventArgs e)
        {
            //baglanti.Open();
            //OleDbCommand cmd = new OleDbCommand("select * from tbl_renk");
            //cmd.Connection = baglanti;
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    combo_renk.Items.Add(dr["renk"]);
            //}
            //baglanti.Close();
            ///////////////////////////////////////////////////////////////
            baglanti.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from tbl_kasa ORDER BY k_ID ASC",baglanti);
            da.Fill(dt);
            combo_kasa.ValueMember = "k_ID";
            combo_kasa.DisplayMember = "kasa_tipi";
            combo_kasa.DataSource = dt;
            baglanti.Close();
            //////////////////////////////////////////////////////////////
            baglanti.Open();
            DataTable dtrenk = new DataTable();
            OleDbDataAdapter darenk = new OleDbDataAdapter("select * from tbl_renk", baglanti);
            darenk.Fill(dtrenk);
            combo_renk.ValueMember = "r_ID";
            combo_renk.DisplayMember = "renk";
            combo_renk.DataSource = dtrenk;
            baglanti.Close();
        }

        private void combo_kasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_kasa.SelectedIndex !=-1)
            {
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from tbl_araclar where a_kasatip="+combo_kasa.SelectedValue,baglanti);
                da.Fill(dt);
                combo_marka.ValueMember="a_id";
                combo_marka.DisplayMember="a_marka";
                combo_marka.DataSource = dt;
            }
        }

        private void button_kaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();      
            komut = new OleDbCommand();
            komut.Parameters.AddWithValue("@marka", combo_marka.SelectedValue);
            komut.Parameters.AddWithValue("@seri", text_seri.Text);
            komut.Parameters.AddWithValue("@kasa", combo_kasa.SelectedValue);
            komut.Parameters.AddWithValue("@yıl", text_model.Text);
            komut.Parameters.AddWithValue("@km", text_km.Text);
            komut.Parameters.AddWithValue("@vites", text_vıtes.Text);
            komut.Parameters.AddWithValue("@renk", combo_renk.SelectedValue);
            komut.Parameters.AddWithValue("@fiyat", text_fıyat.Text);
            komut.Parameters.AddWithValue("@tarih", date_alıstarihi.Text);
            komut.Parameters.AddWithValue("@acıklama", text_acıklama.Text);
            komut.Parameters.AddWithValue("@plaka", text_plaka.Text);
            komut.CommandText = "insert into tbl_arac(a_marka,a_seri,a_kasa,a_yıl,a_km,a_vites,a_renk,a_fiyat,a_yüklemetarihi,a_acıklama,plaka) values(@marka,@seri,@kasa,@yıl,@km,@vites,@renk,@fiyat,@tarih,@acıklama,@plaka)";
            komut.Connection = baglanti;
            try
            {
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt İşlemi Başarı ile gerçekleşmiştir.");
                baglanti.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Herhangi bir nedenle Kaydedilmedi. ");              
            }
            
            //////////////////////////////////////////////////////////////////////////////    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu arac = new menu();
            arac.Show();
        }

        private void araçDüzenleVeSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aracduzenle arac = new aracduzenle();
            arac.Show();
            this.Hide();
        }

        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hesapmakinesi arac = new hesapmakinesi();
            arac.Show();
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //aracekle arac = new aracekle();
            //arac.Show();
        }

        private void hakkımdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           hakkımda arac = new hakkımda();
            arac.Show();
        }

        private void menüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu arac = new menu();
            arac.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misin ?","", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                menu aracc = new menu();
                aracc.Show();
                this.Hide();
            }
            else
            {                
            }
        }
    }
}
