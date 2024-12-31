namespace RestoranOtomasyonu
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button[] masaButonlari;
        private System.Windows.Forms.Button btnGunSonu;

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
            this.masaButonlari = new System.Windows.Forms.Button[10]; // 10 masa
            this.btnGunSonu = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Name = "Form1";
            this.Text = "Restoran Otomasyonu";

            // Gün Sonu butonu
            this.btnGunSonu.Location = new System.Drawing.Point(650, 600);
            this.btnGunSonu.Name = "btnGunSonu";
            this.btnGunSonu.Size = new System.Drawing.Size(100, 50);
            this.btnGunSonu.TabIndex = 10;
            this.btnGunSonu.Text = "Gün Sonu Raporu";
            this.btnGunSonu.UseVisualStyleBackColor = true;
            this.btnGunSonu.Click += new System.EventHandler(this.BtnGunSonu_Click);
            this.Controls.Add(this.btnGunSonu);

            this.ResumeLayout(false);
        }
    }
}