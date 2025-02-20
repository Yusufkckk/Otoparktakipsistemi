using System;
using System.Windows.Forms;

namespace Otoparktakipsistemi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvParkDurumu = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plaka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AracSahibi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GirisSaati = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Durum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAracCikisi = new System.Windows.Forms.Button();
            this.btnAracGirisi = new System.Windows.Forms.Button();
            this.lblDoluluk = new System.Windows.Forms.Label();
            this.lblTarihSaat = new System.Windows.Forms.Label();
            this.lblDolulukk = new System.Windows.Forms.Label();
            this.lblTarihSaatt = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkDurumu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvParkDurumu
            // 
            this.dgvParkDurumu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParkDurumu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Plaka,
            this.AracSahibi,
            this.GirisSaati,
            this.Durum});
            this.dgvParkDurumu.Location = new System.Drawing.Point(34, 12);
            this.dgvParkDurumu.Name = "dgvParkDurumu";
            this.dgvParkDurumu.Size = new System.Drawing.Size(542, 150);
            this.dgvParkDurumu.TabIndex = 0;
            this.dgvParkDurumu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ParkNo";
            this.ID.Name = "ID";
            // 
            // Plaka
            // 
            this.Plaka.HeaderText = "Plaka";
            this.Plaka.Name = "Plaka";
            // 
            // AracSahibi
            // 
            this.AracSahibi.HeaderText = "AracSahibi";
            this.AracSahibi.Name = "AracSahibi";
            // 
            // GirisSaati
            // 
            this.GirisSaati.HeaderText = "GirisSaati";
            this.GirisSaati.Name = "GirisSaati";
            // 
            // Durum
            // 
            this.Durum.HeaderText = "Durum";
            this.Durum.Name = "Durum";
            // 
            // btnAracCikisi
            // 
            this.btnAracCikisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAracCikisi.Location = new System.Drawing.Point(662, 357);
            this.btnAracCikisi.Name = "btnAracCikisi";
            this.btnAracCikisi.Size = new System.Drawing.Size(99, 48);
            this.btnAracCikisi.TabIndex = 1;
            this.btnAracCikisi.Text = "Arac Cikisi";
            this.btnAracCikisi.UseVisualStyleBackColor = true;
            this.btnAracCikisi.Click += new System.EventHandler(this.btnAracCikisi_Click);
            // 
            // btnAracGirisi
            // 
            this.btnAracGirisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAracGirisi.Location = new System.Drawing.Point(34, 357);
            this.btnAracGirisi.Name = "btnAracGirisi";
            this.btnAracGirisi.Size = new System.Drawing.Size(99, 48);
            this.btnAracGirisi.TabIndex = 2;
            this.btnAracGirisi.Text = "Arac Girisi";
            this.btnAracGirisi.UseVisualStyleBackColor = true;
            this.btnAracGirisi.Click += new System.EventHandler(this.btnAracGirisi_Click);
            // 
            // lblDoluluk
            // 
            this.lblDoluluk.AutoSize = true;
            this.lblDoluluk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDoluluk.Location = new System.Drawing.Point(30, 209);
            this.lblDoluluk.Name = "lblDoluluk";
            this.lblDoluluk.Size = new System.Drawing.Size(0, 24);
            this.lblDoluluk.TabIndex = 3;
            // 
            // lblTarihSaat
            // 
            this.lblTarihSaat.AutoSize = true;
            this.lblTarihSaat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTarihSaat.Location = new System.Drawing.Point(699, 12);
            this.lblTarihSaat.Name = "lblTarihSaat";
            this.lblTarihSaat.Size = new System.Drawing.Size(0, 24);
            this.lblTarihSaat.TabIndex = 4;
            // 
            // lblDolulukk
            // 
            this.lblDolulukk.AutoSize = true;
            this.lblDolulukk.Location = new System.Drawing.Point(49, 209);
            this.lblDolulukk.Name = "lblDolulukk";
            this.lblDolulukk.Size = new System.Drawing.Size(35, 13);
            this.lblDolulukk.TabIndex = 5;
            this.lblDolulukk.Text = "label1";
            // 
            // lblTarihSaatt
            // 
            this.lblTarihSaatt.AutoSize = true;
            this.lblTarihSaatt.Location = new System.Drawing.Point(684, 23);
            this.lblTarihSaatt.Name = "lblTarihSaatt";
            this.lblTarihSaatt.Size = new System.Drawing.Size(0, 13);
            this.lblTarihSaatt.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTarihSaatt);
            this.Controls.Add(this.lblDolulukk);
            this.Controls.Add(this.lblTarihSaat);
            this.Controls.Add(this.lblDoluluk);
            this.Controls.Add(this.btnAracGirisi);
            this.Controls.Add(this.btnAracCikisi);
            this.Controls.Add(this.dgvParkDurumu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkDurumu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvParkDurumu;
        private System.Windows.Forms.Button btnAracCikisi;
        private System.Windows.Forms.Button btnAracGirisi;
        private System.Windows.Forms.Label lblDoluluk;
        private System.Windows.Forms.Label lblTarihSaat;
        private Label lblDolulukk;
        private Label lblTarihSaatt;
        public Timer timer1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Plaka;
        private DataGridViewTextBoxColumn AracSahibi;
        private DataGridViewTextBoxColumn GirisSaati;
        private DataGridViewTextBoxColumn Durum;
    }
}

