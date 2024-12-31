namespace AnadoluTat1071RestoranOtomasyonu
{
    partial class MasaEkrani
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView lvAlinanSiparisler;
        private System.Windows.Forms.GroupBox gbOdemeYontemleri;
        private System.Windows.Forms.Button btnNakit;
        private System.Windows.Forms.Button btnKart;
        private System.Windows.Forms.Button btnSiparisEkle;
        private System.Windows.Forms.Label lblToplamFiyat;
        private System.Windows.Forms.TextBox txtNakitOdeme;
        private System.Windows.Forms.TextBox txtKartOdeme;
        private System.Windows.Forms.Label lblOdemeSonucu;
        private System.Windows.Forms.Label lblKalanOdeme;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lvAlinanSiparisler = new ListView();
            gbOdemeYontemleri = new GroupBox();
            btnNakit = new Button();
            txtNakitOdeme = new TextBox();
            btnKart = new Button();
            txtKartOdeme = new TextBox();
            btnSiparisEkle = new Button();
            lblToplamFiyat = new Label();
            lblOdemeSonucu = new Label();
            lblKalanOdeme = new Label();
            gbOdemeYontemleri.SuspendLayout();
            SuspendLayout();
            // 
            // lvAlinanSiparisler
            // 
            lvAlinanSiparisler.Location = new Point(12, 15);
            lvAlinanSiparisler.Margin = new Padding(3, 4, 3, 4);
            lvAlinanSiparisler.Name = "lvAlinanSiparisler";
            lvAlinanSiparisler.Size = new Size(600, 749);
            lvAlinanSiparisler.TabIndex = 0;
            lvAlinanSiparisler.UseCompatibleStateImageBehavior = false;
            lvAlinanSiparisler.View = View.Details;
            // 
            // gbOdemeYontemleri
            // 
            gbOdemeYontemleri.Controls.Add(btnNakit);
            gbOdemeYontemleri.Controls.Add(txtNakitOdeme);
            gbOdemeYontemleri.Controls.Add(btnKart);
            gbOdemeYontemleri.Controls.Add(txtKartOdeme);
            gbOdemeYontemleri.Location = new Point(620, 15);
            gbOdemeYontemleri.Margin = new Padding(3, 4, 3, 4);
            gbOdemeYontemleri.Name = "gbOdemeYontemleri";
            gbOdemeYontemleri.Padding = new Padding(3, 4, 3, 4);
            gbOdemeYontemleri.Size = new Size(200, 250);
            gbOdemeYontemleri.TabIndex = 1;
            gbOdemeYontemleri.TabStop = false;
            gbOdemeYontemleri.Text = "Ödeme Yöntemleri";
            // 
            // btnNakit
            // 
            btnNakit.Location = new Point(6, 38);
            btnNakit.Margin = new Padding(3, 4, 3, 4);
            btnNakit.Name = "btnNakit";
            btnNakit.Size = new Size(188, 62);
            btnNakit.TabIndex = 0;
            btnNakit.Text = "Nakit";
            btnNakit.UseVisualStyleBackColor = true;
            btnNakit.Click += BtnNakit_Click;
            // 
            // txtNakitOdeme
            // 
            txtNakitOdeme.Location = new Point(6, 112);
            txtNakitOdeme.Margin = new Padding(3, 4, 3, 4);
            txtNakitOdeme.Name = "txtNakitOdeme";
            txtNakitOdeme.Size = new Size(188, 27);
            txtNakitOdeme.TabIndex = 4;
            // 
            // btnKart
            // 
            btnKart.Location = new Point(6, 150);
            btnKart.Margin = new Padding(3, 4, 3, 4);
            btnKart.Name = "btnKart";
            btnKart.Size = new Size(188, 62);
            btnKart.TabIndex = 1;
            btnKart.Text = "Kart";
            btnKart.UseVisualStyleBackColor = true;
            btnKart.Click += BtnKart_Click;
            // 
            // txtKartOdeme
            // 
            txtKartOdeme.Location = new Point(6, 225);
            txtKartOdeme.Margin = new Padding(3, 4, 3, 4);
            txtKartOdeme.Name = "txtKartOdeme";
            txtKartOdeme.Size = new Size(188, 27);
            txtKartOdeme.TabIndex = 5;
            // 
            // btnSiparisEkle
            // 
            btnSiparisEkle.Location = new Point(620, 275);
            btnSiparisEkle.Margin = new Padding(3, 4, 3, 4);
            btnSiparisEkle.Name = "btnSiparisEkle";
            btnSiparisEkle.Size = new Size(200, 62);
            btnSiparisEkle.TabIndex = 2;
            btnSiparisEkle.Text = "Sipariş Ekle";
            btnSiparisEkle.UseVisualStyleBackColor = true;
            btnSiparisEkle.Click += BtnSiparisEkle_Click;
            // 
            // lblToplamFiyat
            // 
            lblToplamFiyat.AutoSize = true;
            lblToplamFiyat.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblToplamFiyat.Location = new Point(620, 350);
            lblToplamFiyat.Name = "lblToplamFiyat";
            lblToplamFiyat.Size = new Size(0, 20);
            lblToplamFiyat.TabIndex = 3;
            // 
            // lblOdemeSonucu
            // 
            lblOdemeSonucu.AutoSize = true;
            lblOdemeSonucu.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOdemeSonucu.Location = new Point(620, 388);
            lblOdemeSonucu.Name = "lblOdemeSonucu";
            lblOdemeSonucu.Size = new Size(0, 20);
            lblOdemeSonucu.TabIndex = 6;
            // 
            // lblKalanOdeme
            // 
            lblKalanOdeme.AutoSize = true;
            lblKalanOdeme.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKalanOdeme.Location = new Point(620, 425);
            lblKalanOdeme.Name = "lblKalanOdeme";
            lblKalanOdeme.Size = new Size(0, 20);
            lblKalanOdeme.TabIndex = 7;
            // 
            // MasaEkrani
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 875);
            Controls.Add(lblToplamFiyat);
            Controls.Add(lblOdemeSonucu);
            Controls.Add(lblKalanOdeme);
            Controls.Add(btnSiparisEkle);
            Controls.Add(gbOdemeYontemleri);
            Controls.Add(lvAlinanSiparisler);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MasaEkrani";
            Text = "MasaEkrani";
            gbOdemeYontemleri.ResumeLayout(false);
            gbOdemeYontemleri.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}