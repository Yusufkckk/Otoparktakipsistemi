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
    public partial class Form1: Form
    {

        string connectionString = @"Server=.\SQLEXPRESS;Database=OtoparkDB;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VerileriYukle();
            lblTarihSaatt.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            timer1.Start();
        }

        private void VerileriYukle()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT ID, Plaka, AracSahibi, GirisSaati, Durum FROM ParkYerleri";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvParkDurumu.DataSource = dt;

                    // Otopark doluluk oranını hesapla
                    int doluYerSayisi = dt.AsEnumerable().Count(row => row["Durum"].ToString() == "DOLU");
                    int toplamYerSayisi = dt.Rows.Count;
                    lblDolulukk.Text = $"Dolu: {doluYerSayisi} / Boş: {toplamYerSayisi - doluYerSayisi}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarihSaat.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }

        public void AracListesiniYenile()
        {
            // DataGridView'i yeniden doldur
            // Park yerlerini ve doluluk durumunu güncelle
        }

        private void btnAracGirisi_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void btnAracCikisi_Click(object sender, EventArgs e)
        {
            Form3 aracCikisForm = new Form3();
            aracCikisForm.ShowDialog();
        }

        /*
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            DolulukOraniniGuncelle(); // Form1'de tanımlamıştık!
        }
        */
    }
}
