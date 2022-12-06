using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HesapMakinesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double sonuc = 0, sayi = 0;
        bool IslemDevamEdiyor = false;
        bool SonucGosteriliyor = false;

        private void btnSayi_Click(object sender, EventArgs e)
        {
            if (IslemDevamEdiyor || SonucGosteriliyor)
            {
                tbISLEM.Text = "0";
                IslemDevamEdiyor = false;
                SonucGosteriliyor = false;
            }

            Button s = (Button)sender;

            if (tbISLEM.Text == "0")
                tbISLEM.Text = "";

            tbISLEM.Text += s.Text;
        }

        private void btnVirgul_Click(object sender, EventArgs e)
        {
            if (IslemDevamEdiyor || SonucGosteriliyor)
            {
                tbISLEM.Text = "0";
                IslemDevamEdiyor = false;
                SonucGosteriliyor = false;
            }

            if (tbISLEM.Text.IndexOf(",") < 0)
                tbISLEM.Text += ",";
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            if (IslemDevamEdiyor || SonucGosteriliyor)
            {
                tbISLEM.Text = "0";
                IslemDevamEdiyor = false;
                SonucGosteriliyor = false;
            }

            if (tbISLEM.Text.Length > 0)
            {
                if (tbISLEM.Text != "0")
                {
                    tbISLEM.Text = tbISLEM.Text.Substring(0, (tbISLEM.Text.Length - 1));

                    if (tbISLEM.Text == "")
                        tbISLEM.Text = "0";
                }
            }
        }

        private void frmHesapMakinesi_KeyPress(object sender, KeyPressEventArgs e)
        {
            Keys k = (Keys)e.KeyChar;

            object sbtn = new object();

            if (k == Keys.D0)
                sbtn = (object)btn0;
            else if (k == Keys.D1)
                sbtn = (object)btn1;
            else if (k == Keys.D2)
                sbtn = (object)btn2;
            else if (k == Keys.D3)
                sbtn = (object)btn3;
            else if (k == Keys.D4)
                sbtn = (object)btn4;
            else if (k == Keys.D5)
                sbtn = (object)btn5;
            else if (k == Keys.D6)
                sbtn = (object)btn6;
            else if (k == Keys.D7)
                sbtn = (object)btn7;
            else if (k == Keys.D8)
                sbtn = (object)btn8;
            else if (k == Keys.D9)
                sbtn = (object)btn9;


            if (k == Keys.D0 ||
                k == Keys.D1 ||
                k == Keys.D2 ||
                k == Keys.D3 ||
                k == Keys.D4 ||
                k == Keys.D5 ||
                k == Keys.D6 ||
                k == Keys.D7 ||
                k == Keys.D8 ||
                k == Keys.D9)
            {
                btnSayi_Click(sbtn, new EventArgs());
            }
            else if (e.KeyChar == 44)
            {
                btnVirgul_Click(btnVirgul, new EventArgs());
            }
            else if (k == Keys.Back)
            {
                btnBackSpace_Click(btnBackSpace, new EventArgs());
            }
            else if (e.KeyChar == 43)
            {
                btnArti_Click(btnArti, new EventArgs());
            }
            else if (e.KeyChar == 45)
            {
                btnCikar_Click(btnCikar, new EventArgs());
            }
            else if (e.KeyChar == 42)
            {
                btnCarp_Click(btnCarp, new EventArgs());
            }
            else if (e.KeyChar == 47)
            {
                btnBol_Click(btnBol, new EventArgs());
            }
            else if (e.KeyChar == 13) //eşittir
            {
                btnEsittir_Click(btnEsittir, new EventArgs());
            }
            else if (e.KeyChar == 67 || e.KeyChar == 99) //sıfırla Cc
            {
                btnSifirla_Click(btnSifirla, new EventArgs());
            }
            else if ((Keys)e.KeyChar == Keys.Escape)
            {
                this.Close();
            }
        }

        string Islem = "";

        void IslemiYap(string _Islem)
        {
            sayi = Convert.ToDouble(tbISLEM.Text);

            if (tbISLEM.Text.Length > 0)
            {
                if (SonucGosteriliyor)
                {
                    Islem = _Islem;
                    tbDETAY.Text = tbDETAY.Text.Substring(0, tbDETAY.Text.Length - 3) + " " + Islem + " ";
                }
                else
                {
                    if (sonuc == 0)
                    {
                        Islem = _Islem;
                        sonuc = sayi;
                        tbDETAY.Text += sonuc.ToString() + " " + Islem + " ";
                        IslemDevamEdiyor = true;
                    }
                    else
                    {
                        switch (Islem)
                        {
                            case "+":
                                sonuc = sonuc + sayi;
                                break;
                            case "-":
                                sonuc = sonuc - sayi;
                                break;
                            case "*":
                                sonuc = sonuc * sayi;
                                break;
                            case "/":
                                sonuc = sonuc / sayi;
                                break;
                        }

                        string strN = "n" + tbN.Value.ToString();

                        tbISLEM.Text = sonuc.ToString(strN);

                        Islem = _Islem;

                        if (Islem == "=")
                        {
                            Islem = "";
                            tbDETAY.Text = "";
                            sonuc = 0;
                            sayi = 0;
                            IslemDevamEdiyor = false;
                            SonucGosteriliyor = false;
                        }
                        else
                        {
                            tbDETAY.Text += sayi + " " + Islem + " ";
                            IslemDevamEdiyor = false;
                            SonucGosteriliyor = true;
                        }
                    }
                }
            }
        }

        private void btnArti_Click(object sender, EventArgs e)
        {
            IslemiYap("+");
        }

        private void btnCikar_Click(object sender, EventArgs e)
        {
            IslemiYap("-");
        }

        private void btnCarp_Click(object sender, EventArgs e)
        {
            IslemiYap("*");
        }

        private void btnBol_Click(object sender, EventArgs e)
        {
            IslemiYap("/");
        }

        private void btnEsittir_Click(object sender, EventArgs e)
        {
            IslemiYap("=");
        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            Islem = "";
            tbDETAY.Text = "";
            tbISLEM.Text = "0";
            sonuc = 0;
            sayi = 0;
            IslemDevamEdiyor = false;
            SonucGosteriliyor = false;
        }

        private void tbN_ValueChanged(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }       
    }
}
