using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using RestoranOtomasyonu; // Add this line

namespace AnadoluTat1071RestoranOtomasyonu
{
    public partial class MasaEkrani : Form
    {
        private int masaNo;
        private SqlConnection connection;
        private decimal toplamFiyat;
        private decimal odenenMiktar;

        public MasaEkrani(int masaNo)
        {
            InitializeComponent();
            this.masaNo = masaNo;
            string connectionString = "Server=DESKTOP-TVLOELV;Database=RestoranDB;Trusted_Connection=True;";
            connection = new SqlConnection(connectionString);
            SiparisleriYukle();
        }

        private void SiparisleriYukle()
        {
            try
            {
                connection.Open();
                string query = "SELECT u.ÜrünAdı, s.SiparişZamanı, s.Miktar, s.Fiyat FROM Siparişler s JOIN Ürünler u ON s.ÜrünID = u.ÜrünID WHERE s.MasaID = @MasaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MasaID", masaNo);
                SqlDataReader reader = command.ExecuteReader();

                lvAlinanSiparisler.Columns.Clear();
                lvAlinanSiparisler.Items.Clear();
                lvAlinanSiparisler.Columns.Add("Ürün Adı", 150);
                lvAlinanSiparisler.Columns.Add("Sipariş Zamanı", 150);
                lvAlinanSiparisler.Columns.Add("Miktar", 100);
                lvAlinanSiparisler.Columns.Add("Fiyat", 100);

                toplamFiyat = 0;
                odenenMiktar = 0;

                while (reader.Read())
                {
                    string urunAdi = reader.GetString(0);
                    DateTime siparisZamani = reader.GetDateTime(1);
                    int miktar = reader.GetInt32(2);
                    decimal fiyat = reader.GetDecimal(3);

                    ListViewItem item = new ListViewItem(urunAdi);
                    item.SubItems.Add(siparisZamani.ToString());
                    item.SubItems.Add(miktar.ToString());
                    item.SubItems.Add(fiyat.ToString("C2"));
                    lvAlinanSiparisler.Items.Add(item);

                    toplamFiyat += fiyat;
                }

                reader.Close();
                lblToplamFiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C2");
                lblKalanOdeme.Text = "Kalan Ödeme: " + toplamFiyat.ToString("C2");
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

        private void BtnSiparisEkle_Click(object sender, EventArgs e)
        {
            UrunEkrani urunEkrani = new UrunEkrani(masaNo);
            urunEkrani.ShowDialog();
            SiparisleriYukle(); // Siparişler eklendikten sonra güncelle
            MasaDurumunuGuncelle();
        }

        private void MasaDurumunuGuncelle()
        {
            try
            {
                connection.Open();
                string query = "UPDATE Masalar SET Durum = 'Dolu' WHERE MasaID = @MasaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MasaID", masaNo);
                command.ExecuteNonQuery();
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

        private void BtnNakit_Click(object sender, EventArgs e)
        {
            decimal nakitOdeme = 0;
            if (!decimal.TryParse(txtNakitOdeme.Text, out nakitOdeme))
            {
                MessageBox.Show("Geçerli bir nakit ödeme miktarı girin.");
                return;
            }
            OdemeYap("Nakit", nakitOdeme);
        }

        private void BtnKart_Click(object sender, EventArgs e)
        {
            decimal kartOdeme = 0;
            if (!decimal.TryParse(txtKartOdeme.Text, out kartOdeme))
            {
                MessageBox.Show("Geçerli bir kart ödeme miktarı girin.");
                return;
            }
            OdemeYap("Kart", kartOdeme);
        }

        private void OdemeYap(string odemeTuru, decimal odemeMiktari)
        {
            try
            {
                odenenMiktar += odemeMiktari;
                decimal kalanFiyat = toplamFiyat - odenenMiktar;

                if (kalanFiyat <= 0)
                {
                    using (SqlConnection connection = new SqlConnection("Server=DESKTOP-TVLOELV;Database=RestoranDB;Trusted_Connection=True;"))

                    {
                        connection.Open();

                        // Masanın durumu 'Boş' yapılır
                        string query = "UPDATE Masalar SET Durum = 'Boş' WHERE MasaID = @MasaNo";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@MasaNo", masaNo);
                        command.ExecuteNonQuery();

                        // Siparişleri temizle
                        string deleteQuery = "DELETE FROM Siparişler WHERE MasaID = @MasaNo";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@MasaNo", masaNo);
                        deleteCommand.ExecuteNonQuery();

                        decimal bahsis = Math.Abs(kalanFiyat);
                        if (bahsis > 0)
                        {
                            lblOdemeSonucu.Text = $"Masa ücreti ödendi, {bahsis:C2} lira bahşiş bırakıldı.";
                        }
                        else
                        {
                            lblOdemeSonucu.Text = "Masa ücreti ödendi.";
                        }

                        // GünSonuRaporları tablosuna ekle
                        string raporQuery = "INSERT INTO GünSonuRaporları (MasaID, BaşlangıçZamanı, BitişZamanı, ToplamTutar, ToplamSiparişler) " +
                                            "VALUES (@MasaID, @BaşlangıçZamanı, @BitişZamanı, @ToplamTutar, @ToplamSiparişler)";
                        SqlCommand raporCommand = new SqlCommand(raporQuery, connection);
                        raporCommand.Parameters.AddWithValue("@MasaID", masaNo);
                        raporCommand.Parameters.AddWithValue("@BaşlangıçZamanı", DateTime.Now.AddHours(-1)); // Örnek başlangıç zamanı
                        raporCommand.Parameters.AddWithValue("@BitişZamanı", DateTime.Now);
                        raporCommand.Parameters.AddWithValue("@ToplamTutar", toplamFiyat);
                        raporCommand.Parameters.AddWithValue("@ToplamSiparişler", string.Join(";", lvAlinanSiparisler.Items.Cast<ListViewItem>().Where(item => item.SubItems[3].Text != "0,00 ₺").Select(item => item.Text))); // Correctly join the orders without payment method
                        raporCommand.ExecuteNonQuery();
                    }

                    lvAlinanSiparisler.Items.Clear(); // Ekrandan siparişleri kaldır
                    ((Form1)Application.OpenForms["Form1"]).MasaButonunuGuncelle(masaNo);
                }
                else
                {
                    lblKalanOdeme.Text = "Kalan Ödeme: " + kalanFiyat.ToString("C2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void MasaButonunuGuncelle()
        {
            // Masa butonunun rengini yeşil yapmak için
            Button masaButonu = Application.OpenForms["Form1"].Controls.Find("btnMasa" + masaNo, true)[0] as Button;
            if (masaButonu != null)
            {
                masaButonu.BackColor = System.Drawing.Color.Green;
            }
        }
    }
}
