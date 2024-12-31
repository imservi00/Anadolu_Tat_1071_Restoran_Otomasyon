namespace RestoranOtomasyonu
{
    partial class GunSonuRaporuEkrani
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView lvRapor;
        private System.Windows.Forms.Label lblCiro;
        private System.Windows.Forms.Button btnGunSonuKaydet;

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
            lvRapor = new ListView();
            lblCiro = new Label();
            btnGunSonuKaydet = new Button();
            SuspendLayout();
            // 
            // lvRapor
            // 
            lvRapor.Location = new Point(10, 11);
            lvRapor.Name = "lvRapor";
            lvRapor.Size = new Size(1030, 528);
            lvRapor.TabIndex = 0;
            lvRapor.UseCompatibleStateImageBehavior = false;
            lvRapor.View = View.Details;
            // 
            // lblCiro
            // 
            lblCiro.AutoSize = true;
            lblCiro.Location = new Point(10, 545);
            lblCiro.Name = "lblCiro";
            lblCiro.Size = new Size(0, 15);
            lblCiro.TabIndex = 1;
            // 
            // btnGunSonuKaydet
            // 
            btnGunSonuKaydet.Location = new Point(929, 545);
            btnGunSonuKaydet.Name = "btnGunSonuKaydet";
            btnGunSonuKaydet.Size = new Size(98, 22);
            btnGunSonuKaydet.TabIndex = 2;
            btnGunSonuKaydet.Text = "Günü Sonlandır";
            btnGunSonuKaydet.UseVisualStyleBackColor = true;
            btnGunSonuKaydet.Click += BtnGunSonuKaydet_Click;
            // 
            // GunSonuRaporuEkrani
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 579);
            Controls.Add(lblCiro);
            Controls.Add(lvRapor);
            Controls.Add(btnGunSonuKaydet);
            Name = "GunSonuRaporuEkrani";
            Text = "GunSonuRaporuEkrani";
            Load += GunSonuRaporuEkrani_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
