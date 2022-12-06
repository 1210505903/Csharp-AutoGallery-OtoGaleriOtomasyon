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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "\\otogaleri.accdb");
        bool durum = false;
        private void button_giris_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            baglanti.Open();
            OleDbCommand tablosecimi = new OleDbCommand("select * from tbl_kullanici", baglanti);
            OleDbDataReader okuyucu = tablosecimi.ExecuteReader();
            while (okuyucu.Read())
            {
                if ((okuyucu[1].ToString() == text_kuladi.Text) && (text_sifre.Text == okuyucu[2].ToString()))
                {
                    durum = true;
                    this.Hide();
                    menu f = new menu();
                    f.Show();
                    break;
                }
               
            }
            if (durum==false)
                MessageBox.Show("Kullanıcı Adınız veya Şifreniz Yanlış");
                    
               
            okuyucu.Close();
            baglanti.Close();
 
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kaydol k = new kaydol();
            k.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
