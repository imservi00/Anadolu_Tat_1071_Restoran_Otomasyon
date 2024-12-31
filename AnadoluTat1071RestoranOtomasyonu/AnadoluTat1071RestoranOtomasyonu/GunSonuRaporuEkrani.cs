using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace RestoranOtomasyonu
{
    public partial class GunSonuRaporuEkrani : Form
    {
        private SqlConnection connection;

        public GunSonuRaporuEkrani()
        {
            InitializeComponent();
            string connectionString = "Server=DESKTOP-TVLOELV;Database=RestoranDB;Trusted_Connection=True;";

            connection = new SqlConnection(connectionString);
        }

        private void GunSonuRaporuEkrani_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "SELECT MasaID, BaşlangıçZamanı, BitişZamanı, ToplamTutar, ToplamSiparişler FROM GünSonuRaporları";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                lvRapor.Columns.Clear();
                lvRapor.Items.Clear();
                lvRapor.Columns.Add("Masa ID", 100);
                lvRapor.Columns.Add("Başlangıç Zamanı", 150);
                lvRapor.Columns.Add("Bitiş Zamanı", 150);
                lvRapor.Columns.Add("Toplam Tutar", 100);
                lvRapor.Columns.Add("Toplam Siparişler", 300);

                decimal toplamCiro = 0;
                int toplamSiparisAdedi = 0;

                while (reader.Read())
                {
                    int masaID = reader.GetInt32(0);
                    DateTime başlangıçZamanı = reader.GetDateTime(1);
                    DateTime bitişZamanı = reader.GetDateTime(2);
                    decimal toplamTutar = reader.GetDecimal(3);
                    string toplamSiparişler = reader.IsDBNull(4) ? "" : reader.GetString(4);

                    ListViewItem item = new ListViewItem(masaID.ToString());
                    item.SubItems.Add(başlangıçZamanı.ToString());
                    item.SubItems.Add(bitişZamanı.ToString());
                    item.SubItems.Add(toplamTutar.ToString("C2"));
                    item.SubItems.Add(toplamSiparişler);
                    lvRapor.Items.Add(item);

                    toplamCiro += toplamTutar;

                    // Siparişleri hesapla
                    string[] siparisler = toplamSiparişler?.Split(';') ?? Array.Empty<string>();
                    foreach (string siparis in siparisler)
                    {
                        string[] parts = siparis.Split('-');
                        if (parts.Length == 2 && decimal.TryParse(parts[1].Trim().Replace("₺", ""), out decimal tutar))
                        {
                            toplamSiparisAdedi++;
                        }
                    }
                }

                reader.Close();

                lblCiro.Text = "Toplam Ciro: " + toplamCiro.ToString("C2");

                // Özet bilgiyi ekle
                ListViewItem summaryItem = new ListViewItem("Genel Toplam");
                summaryItem.SubItems.Add("");
                summaryItem.SubItems.Add("");
                summaryItem.SubItems.Add("");
                summaryItem.SubItems.Add($"Toplam Sipariş Adedi: {toplamSiparisAdedi}");
                lvRapor.Items.Add(summaryItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void BtnGunSonuKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Text Files (*.txt)|*.txt",
                    Title = "Gün Sonu Raporunu Kaydet",
                    FileName = $"GunSonuRaporu_{DateTime.Now:yyyyMMdd}.txt"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine("Gün Sonu Raporu");
                        writer.WriteLine("---------------");
                        foreach (ListViewItem item in lvRapor.Items)
                        {
                            writer.WriteLine($"{item.Text}\t{item.SubItems[1].Text}\t{item.SubItems[2].Text}\t{item.SubItems[3].Text}\t{item.SubItems[4].Text}");
                        }
                        writer.WriteLine(lblCiro.Text);
                    }

                    MessageBox.Show($"Gün sonu raporu {saveFileDialog.FileName} olarak kaydedildi.");

                    // GünSonuRaporları tablosunu temizle
                    connection.Open();
                    string query = "DELETE FROM GünSonuRaporları";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();

                    // ListView ve etiketleri temizle
                    lvRapor.Items.Clear();
                    lblCiro.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}
