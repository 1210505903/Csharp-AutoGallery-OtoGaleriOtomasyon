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
    public partial class kaydol : Form
    {
        public kaydol()
        {
            InitializeComponent();
        }
        OleDbConnection sehirbaglanti = new OleDbConnection("Provider= Microsoft.Jet.Oledb.4.0;Data Source=" + Application.StartupPath + "//sehirler.mdb");
        OleDbConnection eczanebaglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "//otogaleri.accdb");  
        private void kaydol_Load(object sender, EventArgs e)
        {
            sehirbaglanti.Open();
            OleDbCommand illistele = new OleDbCommand("Select* from sehir", sehirbaglanti);
            OleDbDataReader ilokuyucu = illistele.ExecuteReader();
            while(ilokuyucu.Read())
            {
                combo_il.Items.Add(ilokuyucu[1].ToString());
            }
            sehirbaglanti.Close();
            

            combo_tel.Text = "SEÇ";
            for (int i = 500; i <= 550; i++)
            {
                combo_tel.Items.Add(i);
            }

        }

        private void combo_il_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_ilce.Items.Clear();
            sehirbaglanti.Open();
            OleDbCommand ilcelistele = new OleDbCommand();
            ilcelistele.Connection = sehirbaglanti;
            ilcelistele.Parameters.AddWithValue("@il_id", combo_il.SelectedIndex + 1);
            ilcelistele.CommandText = ("select * from ilceler where ilno=@il_id");
            OleDbDataReader ilceokuyucu = ilcelistele.ExecuteReader();
            while (ilceokuyucu.Read())
            {
                combo_ilce.Items.Add(ilceokuyucu[2].ToString());
            }
            sehirbaglanti.Close();
        }

        private void button_kaydet_Click(object sender, EventArgs e)
        {
            string txt = text_mail.Text;
            bool kontrol = false;
            if ((text_tc.Text.Length != 11) || (text_sifre.Text != text_sifretekrar.Text) || (text_tel.Text.Length != 7) || (kontrol == false))
            {
                if (text_tc.Text.Length != 11)
                {
                    MessageBox.Show("Tc Kimlik numarasını kontrol ederek tekrar giriş yapınız.");
                    text_tc.Focus();
                }
                if (text_sifre.Text != text_sifretekrar.Text)
                {
                    MessageBox.Show("Şifre ile tekrarı uyuşmamaktadır.");
                    text_sifre.Focus();
                }
                if (text_tel.Text.Length != 7)
                {
                    MessageBox.Show("Telefon Numarasını Kontrol Ediniz.");
                    text_tel.Focus();
                }

                for (int a = 0; a < txt.Length; a++)
                {
                    if (txt[a].ToString() == "@")
                    {
                        kontrol = true;
                    }
                }
                if (kontrol == false)
                {
                    MessageBox.Show("Geçerli bir mail adresi yazınız.");
                }
            }
            if ((text_tc.Text.Length == 11) && (text_sifre.Text == text_sifretekrar.Text) && (text_tel.Text.Length == 7) && (kontrol == true))
            {
                bool gidencinsiyet = false;
                string kno = "0";
                if (radio_bayan.Checked)
                    gidencinsiyet = true;
                else
                    gidencinsiyet = false;
                eczanebaglanti.Open();
                OleDbCommand kullanicikaydet = new OleDbCommand();
                OleDbCommand sifrelistele = new OleDbCommand("select * from tbl_kullanici", eczanebaglanti);
                OleDbCommand sifrekaydet = new OleDbCommand();
                OleDbDataReader okuyucu = sifrelistele.ExecuteReader();
                while (okuyucu.Read())
                {
                    kno = okuyucu[0].ToString();
                }
                okuyucu.Close();
                string dyer = combo_il.SelectedItem.ToString() + "/" + combo_ilce.SelectedItem.ToString();
                string telefon = combo_tel.SelectedItem.ToString() + text_tel.Text;
                kullanicikaydet.Parameters.AddWithValue("@kuladi", text_adi.Text);
                kullanicikaydet.Parameters.AddWithValue("@kulsadi", text_sadi.Text);
                kullanicikaydet.Parameters.AddWithValue("@kulcins", gidencinsiyet);
                kullanicikaydet.Parameters.AddWithValue("@mail", text_mail.Text);
                kullanicikaydet.Parameters.AddWithValue("@kultel", telefon);
                kullanicikaydet.Parameters.AddWithValue("@kuldogtar", date_dtarihi.Text);
                kullanicikaydet.Parameters.AddWithValue("@kuldogyer", dyer);
                kullanicikaydet.Parameters.AddWithValue("@kultc", text_tc.Text);
                kullanicikaydet.Parameters.AddWithValue("@kullanicino", int.Parse(kno) + 1);
                kullanicikaydet.CommandText = "insert into tbl_kulkimlik(ki_adi,ki_sadi,ki_cinsiyet,ki_mail,ki_tel,ki_dtarihi,ki_dyeri,ki_tcno,kullanici_no) values(@kuladi,@kulsadi,@kulcins,@mail,@kultel,@kuldogtar,@kuldogyer,@kultc,@kullanicino)";
                sifrekaydet.Parameters.AddWithValue("@kullaniciadi", text_kadi.Text);
                sifrekaydet.Parameters.AddWithValue("@sifre", text_sifre.Text);
                sifrekaydet.CommandText = "insert into tbl_kullanici(k_adi,k_sifre) values(@kullaniciadi,@sifre)";
                kullanicikaydet.Connection = eczanebaglanti;
                sifrekaydet.Connection = eczanebaglanti;
                kullanicikaydet.ExecuteNonQuery();
                sifrekaydet.ExecuteNonQuery();
                eczanebaglanti.Close();

                Form1 Yeni = new Form1();
                Yeni.Show();
                this.Hide(); 
            }  
        }

        private void button_vazgec_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Vazgeçmke İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {
            }
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void combo_tel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
