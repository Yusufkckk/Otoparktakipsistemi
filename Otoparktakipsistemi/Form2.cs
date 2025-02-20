using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Otoparktakipsistemi
{
    public partial class Form2: Form
    {

        string connectionString = @"Server=.\SQLEXPRESS;Database=OtoparkDB;Integrated Security=True;";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ParkYeriDoldur();
        }
        private void ParkYeriDoldur()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT ParkNo FROM ParkYerleri WHERE Durum = 'Boş'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    cmbParkYeri.Items.Clear();

                    while (dr.Read())
                    {
                        cmbParkYeri.Items.Add(dr["ParkNo"].ToString());
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Park yerleri yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlaka.Text) || string.IsNullOrWhiteSpace(txtAracSahibi.Text) || cmbParkYeri.SelectedItem == null)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"UPDATE ParkYerleri 
                             SET Plaka = @Plaka, AracSahibi = @AracSahibi, GirisSaati = GETDATE(), Durum = 'DOLU' 
                             WHERE ParkYerNumarasi = @ParkYeri";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Plaka", txtPlaka.Text);
                    cmd.Parameters.AddWithValue("@AracSahibi", txtAracSahibi.Text);
                    cmd.Parameters.AddWithValue("@ParkYeri", cmbParkYeri.SelectedItem.ToString());

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Araç park yerine başarıyla kaydedildi!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt başarısız!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message);
            }
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 mainForm = (Form1)Application.OpenForms["Form1"];
            mainForm.AracListesiniYenile();
        }
    }
}
