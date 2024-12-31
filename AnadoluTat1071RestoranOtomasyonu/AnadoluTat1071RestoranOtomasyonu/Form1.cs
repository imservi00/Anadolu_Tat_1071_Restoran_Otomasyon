using AnadoluTat1071RestoranOtomasyonu;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestoranOtomasyonu
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;

        public Form1()
        {
            InitializeComponent();
            string connectionString = "Server=DESKTOP-TVLOELV;Database=RestoranDB;Trusted_Connection=True;";
            connection = new SqlConnection(connectionString);
            MasaButonlariniOlustur();
            MasaDurumlariniYukle();
        }

        private void MasaButonlariniOlustur()
        {
            for (int i = 0; i < 10; i++)
            {
                this.masaButonlari[i] = new System.Windows.Forms.Button();
                this.masaButonlari[i].BackColor = System.Drawing.Color.Green; // Başlangıçta boş
                this.masaButonlari[i].Location = new System.Drawing.Point(50 + (i % 5) * 150, 50 + (i / 5) * 150);
                this.masaButonlari[i].Name = "btnMasa" + (i + 1);
                this.masaButonlari[i].Size = new System.Drawing.Size(100, 100);
                this.masaButonlari[i].Text = "Masa " + (i + 1);
                this.masaButonlari[i].UseVisualStyleBackColor = true;
                this.masaButonlari[i].Click += new System.EventHandler(this.MasaButonu_Click);
                this.Controls.Add(this.masaButonlari[i]);
            }
        }

        private void MasaDurumlariniYukle()
        {
            try
            {
                connection.Open();
                string query = "SELECT MasaID, Durum FROM Masalar";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int masaNo = reader.GetInt32(0);
                    string durum = reader.GetString(1);

                    // Button'u bulup duruma göre renk ayarla
                    Button btn = this.Controls.Find("btnMasa" + masaNo, true)[0] as Button;
                    if (durum == "Dolu")
                    {
                        btn.BackColor = System.Drawing.Color.Red;  // Dolu ise kırmızı
                    }
                    else
                    {
                        btn.BackColor = System.Drawing.Color.Green;  // Boş ise yeşil
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void MasaButonu_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int masaNo = int.Parse(clickedButton.Text.Replace("Masa ", ""));
            MasaEkrani masaEkrani = new MasaEkrani(masaNo);
            masaEkrani.ShowDialog();
            MasaDurumlariniYukle();  // Masa durumlarını güncelle
        }

        // Gün sonu raporu butonu
        private void BtnGunSonu_Click(object sender, EventArgs e)
        {
            GunSonuRaporuEkrani gunSonuRaporuEkrani = new GunSonuRaporuEkrani();
            gunSonuRaporuEkrani.ShowDialog();
        }

        public void MasaButonunuGuncelle(int masaNo)
        {
            try
            {
                connection.Open();
                string query = "SELECT Durum FROM Masalar WHERE MasaID = @MasaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MasaID", masaNo);
                string durum = command.ExecuteScalar().ToString();

                Button masaButonu = this.Controls.Find("btnMasa" + masaNo, true)[0] as Button;
                if (masaButonu != null)
                {
                    if (durum == "Dolu")
                    {
                        masaButonu.BackColor = System.Drawing.Color.Red;  // Dolu ise kırmızı
                    }
                    else
                    {
                        masaButonu.BackColor = System.Drawing.Color.Green;  // Boş ise yeşil
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
