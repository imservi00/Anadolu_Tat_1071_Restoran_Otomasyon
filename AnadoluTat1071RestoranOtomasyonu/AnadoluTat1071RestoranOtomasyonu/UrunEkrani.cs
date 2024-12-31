using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AnadoluTat1071RestoranOtomasyonu
{
    public partial class UrunEkrani : Form
    {
        private int masaNo;
        private SqlConnection connection;
        private decimal toplamFiyat; // Define toplamFiyat as a class-level variable

        public UrunEkrani(int masaNo)
        {
            InitializeComponent();
            this.masaNo = masaNo;
            string connectionString = "Server=DESKTOP-TVLOELV;Database=RestoranDB;Trusted_Connection=True;";
            connection = new SqlConnection(connectionString);
            UrunleriYukle();
        }

        private void UrunleriYukle()
        {
            try
            {
                connection.Open();

                // İçecekler
                string queryIcecekler = "SELECT ÜrünID, ÜrünAdı, Fiyat FROM Ürünler WHERE ÜrünTürü = 'İçecek'";
                SqlCommand commandIcecekler = new SqlCommand(queryIcecekler, connection);
                SqlDataReader readerIcecekler = commandIcecekler.ExecuteReader();

                while (readerIcecekler.Read())
                {
                    int urunID = readerIcecekler.GetInt32(0);
                    string urunAdi = readerIcecekler.GetString(1);
                    decimal fiyat = readerIcecekler.GetDecimal(2);

                    // Ürün butonu
                    Button btn = new Button();
                    btn.Name = "btnIcecek" + urunID;
                    btn.Text = $"{urunAdi} - {fiyat:C2}";
                    btn.Size = new System.Drawing.Size(150, 50);
                    btn.Click += new EventHandler(UrunButonu_Click);

                    // Panelin içine ürün butonu ekleme
                    flpIcecekler.Controls.Add(btn);
                }
                readerIcecekler.Close();

                // Yemekler
                string queryYemekler = "SELECT ÜrünID, ÜrünAdı, Fiyat FROM Ürünler WHERE ÜrünTürü = 'Yemek'";
                SqlCommand commandYemekler = new SqlCommand(queryYemekler, connection);
                SqlDataReader readerYemekler = commandYemekler.ExecuteReader();

                while (readerYemekler.Read())
                {
                    int urunID = readerYemekler.GetInt32(0);
                    string urunAdi = readerYemekler.GetString(1);
                    decimal fiyat = readerYemekler.GetDecimal(2);

                    // Ürün butonu
                    Button btn = new Button();
                    btn.Name = "btnYemek" + urunID;
                    btn.Text = $"{urunAdi} - {fiyat:C2}";
                    btn.Size = new System.Drawing.Size(150, 50);
                    btn.Click += new EventHandler(UrunButonu_Click);

                    // Panelin içine ürün butonu ekleme
                    flpYemekler.Controls.Add(btn);
                }
                readerYemekler.Close();
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

        private void UrunButonu_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            lstSiparisListesi.Items.Add(clickedButton.Text); // Siparişi listeye ekleme
            lblUrunFiyati.Text = clickedButton.Text.Split('-')[1].Trim(); // Ürün fiyatını göster
            ToplamFiyatHesapla();
        }

        private void ToplamFiyatHesapla()
        {
            toplamFiyat = 0; // Initialize toplamFiyat
            foreach (var item in lstSiparisListesi.Items)
            {
                string fiyatStr = item.ToString().Split('-')[1].Trim().Replace("₺", "").Trim();
                decimal fiyat = decimal.Parse(fiyatStr);
                toplamFiyat += fiyat;
            }
            lblToplamFiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C2");
        }

        private void BtnSiparisTamamla_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                foreach (var item in lstSiparisListesi.Items)
                {
                    string urunAdi = item.ToString().Split('-')[0].Trim();
                    string query = "INSERT INTO Siparişler (MasaID, ÜrünID, SiparişZamanı, Miktar, ÖdemeYöntemi, Fiyat) " +
                                   "VALUES (@MasaID, (SELECT ÜrünID FROM Ürünler WHERE ÜrünAdı = @ÜrünAdı), @SiparişZamanı, 1, @ÖdemeYöntemi, (SELECT Fiyat FROM Ürünler WHERE ÜrünAdı = @ÜrünAdı))";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MasaID", masaNo);
                    command.Parameters.AddWithValue("@ÜrünAdı", urunAdi);
                    command.Parameters.AddWithValue("@SiparişZamanı", DateTime.Now);
                    command.Parameters.AddWithValue("@ÖdemeYöntemi", "Nakit");
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Sipariş tamamlandı!");
                this.Close();
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
