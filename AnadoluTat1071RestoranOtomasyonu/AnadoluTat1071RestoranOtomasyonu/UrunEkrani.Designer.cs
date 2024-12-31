namespace AnadoluTat1071RestoranOtomasyonu
{
    partial class UrunEkrani
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flpIcecekler;
        private System.Windows.Forms.FlowLayoutPanel flpYemekler;
        private System.Windows.Forms.Button btnSiparisTamamla;
        private System.Windows.Forms.ListBox lstSiparisListesi;
        private System.Windows.Forms.Label lblUrunFiyati;
        private System.Windows.Forms.Label lblIcecekler;
        private System.Windows.Forms.Label lblYemekler;
        private System.Windows.Forms.Label lblToplamFiyat;

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
            flpIcecekler = new FlowLayoutPanel();
            flpYemekler = new FlowLayoutPanel();
            btnSiparisTamamla = new Button();
            lstSiparisListesi = new ListBox();
            lblUrunFiyati = new Label();
            lblIcecekler = new Label();
            lblYemekler = new Label();
            lblToplamFiyat = new Label();
            SuspendLayout();
            // 
            // flpIcecekler
            // 
            flpIcecekler.AutoScroll = true;
            flpIcecekler.Location = new Point(10, 38);
            flpIcecekler.Name = "flpIcecekler";
            flpIcecekler.Size = new Size(332, 536);
            flpIcecekler.TabIndex = 0;
            // 
            // flpYemekler
            // 
            flpYemekler.AutoScroll = true;
            flpYemekler.Location = new Point(350, 38);
            flpYemekler.Name = "flpYemekler";
            flpYemekler.Size = new Size(332, 536);
            flpYemekler.TabIndex = 1;
            // 
            // btnSiparisTamamla
            // 
            btnSiparisTamamla.Location = new Point(10, 581);
            btnSiparisTamamla.Name = "btnSiparisTamamla";
            btnSiparisTamamla.Size = new Size(672, 47);
            btnSiparisTamamla.TabIndex = 2;
            btnSiparisTamamla.Text = "Siparişi Tamamla";
            btnSiparisTamamla.UseVisualStyleBackColor = true;
            btnSiparisTamamla.Click += BtnSiparisTamamla_Click;
            // 
            // lstSiparisListesi
            // 
            lstSiparisListesi.FormattingEnabled = true;
            lstSiparisListesi.ItemHeight = 15;
            lstSiparisListesi.Location = new Point(10, 638);
            lstSiparisListesi.Name = "lstSiparisListesi";
            lstSiparisListesi.Size = new Size(672, 154);
            lstSiparisListesi.TabIndex = 3;
            // 
            // lblUrunFiyati
            // 
            lblUrunFiyati.AutoSize = true;
            lblUrunFiyati.Location = new Point(10, 797);
            lblUrunFiyati.Name = "lblUrunFiyati";
            lblUrunFiyati.Size = new Size(0, 15);
            lblUrunFiyati.TabIndex = 4;
            // 
            // lblIcecekler
            // 
            lblIcecekler.AutoSize = true;
            lblIcecekler.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIcecekler.Location = new Point(10, 11);
            lblIcecekler.Name = "lblIcecekler";
            lblIcecekler.Size = new Size(83, 17);
            lblIcecekler.TabIndex = 5;
            lblIcecekler.Text = "İÇECEKLER";
            // 
            // lblYemekler
            // 
            lblYemekler.AutoSize = true;
            lblYemekler.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblYemekler.Location = new Point(350, 11);
            lblYemekler.Name = "lblYemekler";
            lblYemekler.Size = new Size(82, 17);
            lblYemekler.TabIndex = 6;
            lblYemekler.Text = "YEMEKLER";
            // 
            // lblToplamFiyat
            // 
            lblToplamFiyat.AutoSize = true;
            lblToplamFiyat.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblToplamFiyat.Location = new Point(10, 797);
            lblToplamFiyat.Name = "lblToplamFiyat";
            lblToplamFiyat.Size = new Size(0, 17);
            lblToplamFiyat.TabIndex = 7;
            // 
            // UrunEkrani
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(695, 806);
            Controls.Add(lblIcecekler);
            Controls.Add(lblYemekler);
            Controls.Add(lblToplamFiyat);
            Controls.Add(lblUrunFiyati);
            Controls.Add(lstSiparisListesi);
            Controls.Add(btnSiparisTamamla);
            Controls.Add(flpYemekler);
            Controls.Add(flpIcecekler);
            Name = "UrunEkrani";
            Text = "Ürün Ekranı";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
