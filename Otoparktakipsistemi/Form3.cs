using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Otoparktakipsistemi
{
    public partial class Form3: Form
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=OtoparkDB;Integrated Security=True;";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnAracBul_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"SELECT ParkYerNumarasi, GirisSaati 
                                     FROM ParkYerleri 
                                     WHERE Plaka = @Plaka AND Durum = 'DOLU'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Plaka", txtPlakaAra.Text);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblParkYeri.Text = reader["ParkYerNumarasi"].ToString();
                        lblGirisSaati.Text = Convert.ToDateTime(reader["GirisSaati"]).ToString("dd/MM/yyyy HH:mm");
                        lblCikisSaati.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm"); // Şu anki zaman çıkış saati
                    }
                    else
                    {
                        MessageBox.Show("Bu plakaya ait dolu bir park kaydı bulunamadı!");
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Araç bilgileri yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void btnAracCikis_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime girisSaati = Convert.ToDateTime(lblGirisSaati.Text);
                DateTime cikisSaati = DateTime.Now;
                TimeSpan toplamSure = cikisSaati - girisSaati;

                // Süreyi saat cinsine çeviriyoruz
                double toplamSaat = toplamSure.TotalHours;

                double ucret = 0;

                // Ücretlendirme tarifesi
                if (toplamSaat <= 1)
                    ucret = 100;
                else if (toplamSaat <= 3)
                    ucret = 130;
                else if (toplamSaat <= 6)
                    ucret = 220;
                else if (toplamSaat <= 9)
                    ucret = 275;
                else if (toplamSaat <= 12)
                    ucret = 350;
                else
                    ucret = 500;

                lblToplamSure.Text = toplamSaat.ToString("0.00") + " saat";
                lblUcret.Text = ucret.ToString("0.00") + " ₺";

                // Veritabanında çıkış saatini güncelle
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string updateQuery = @"UPDATE ParkYerleri 
                                   SET CikisSaati = @CikisSaati, Durum = 'BOS' 
                                   WHERE Plaka = @Plaka";

                    SqlCommand cmd = new SqlCommand(updateQuery, con);
                    cmd.Parameters.AddWithValue("@CikisSaati", cikisSaati);
                    cmd.Parameters.AddWithValue("@Plaka", txtPlakaAra.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Araç çıkışı başarıyla tamamlandı!\nÜcret: " + ucret.ToString("0.00") + " ₺");

                    // Temizleme işlemi
                    lblParkYeri.Text = "-";
                    lblGirisSaati.Text = "-";
                    lblCikisSaati.Text = "-";
                    lblToplamSure.Text = "-";
                    lblUcret.Text = "-";
                    txtPlakaAra.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Araç çıkışı sırasında hata oluştu: " + ex.Message);
            }
        }
    }
}
