namespace otogaleri
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.text_sifre = new System.Windows.Forms.TextBox();
            this.text_kuladi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_giris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkLabel1.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(247, 270);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(92, 23);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "KAYDOL";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Purple;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // text_sifre
            // 
            this.text_sifre.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_sifre.Location = new System.Drawing.Point(204, 153);
            this.text_sifre.Name = "text_sifre";
            this.text_sifre.PasswordChar = '*';
            this.text_sifre.Size = new System.Drawing.Size(126, 28);
            this.text_sifre.TabIndex = 9;
            this.text_sifre.UseSystemPasswordChar = true;
            // 
            // text_kuladi
            // 
            this.text_kuladi.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_kuladi.Location = new System.Drawing.Point(204, 104);
            this.text_kuladi.Name = "text_kuladi";
            this.text_kuladi.Size = new System.Drawing.Size(126, 28);
            this.text_kuladi.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(111, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "ŞIFRE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(22, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "KULLANICI ADI:";
            // 
            // button_giris
            // 
            this.button_giris.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_giris.Location = new System.Drawing.Point(141, 203);
            this.button_giris.Name = "button_giris";
            this.button_giris.Size = new System.Drawing.Size(103, 44);
            this.button_giris.TabIndex = 12;
            this.button_giris.Text = "Giriş";
            this.button_giris.UseVisualStyleBackColor = true;
            this.button_giris.Click += new System.EventHandler(this.button_giris_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::otogaleri.Properties.Resources.otomasyongaleri;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(391, 323);
            this.Controls.Add(this.button_giris);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.text_sifre);
            this.Controls.Add(this.text_kuladi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox text_sifre;
        private System.Windows.Forms.TextBox text_kuladi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_giris;
    }
}

