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

namespace Scooter_Kayit_Sistemi
{


    public partial class FrmMusteri : Form
    {

        public FrmMusteri()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-GPMKKC5N\\SQLEXPRESS;Initial Catalog=ScooterKiralamaDB;Integrated Security=True");

        void Listele()
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Musteri", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void Temizle()
        {
            txtMusteriID.Text = "";
            txtIsim.Text = "";
            txtSoyisim.Text = "";
            mskdTCno.Text = "";
            txtEhliyetSuresi.Text = "";
            txtIsim.Focus();
        }

        
        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKayıtEt_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutekle = new SqlCommand("insert into Tbl_Musteri(Ad,Soyad,TcNo,EhliyetSuresi) values (@p1,@p2,@p3,@p4)", baglanti);
            komutekle.Parameters.AddWithValue("@p1", txtIsim.Text);
            komutekle.Parameters.AddWithValue("@p2", txtSoyisim.Text);
            komutekle.Parameters.AddWithValue("@p3", mskdTCno.Text);
            komutekle.Parameters.AddWithValue("@p4", txtEhliyetSuresi.Text);
            komutekle.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Müşteri Bilgisi Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtMusteriID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtIsim.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyisim.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            mskdTCno.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtEhliyetSuresi.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Musteri where MusteriID = @p1", baglanti);
            komutsil.Parameters.AddWithValue("@p1", txtMusteriID.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Müşteri Kaydı Başarılı Bir Şekilde Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Musteri set Ad=@p1, Soyad=@p2, TcNo=@p3,EhliyetSuresi=@p4 where MusteriID=@p5", baglanti);
            komutguncelle.Parameters.AddWithValue("@p1", txtIsim.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtSoyisim.Text);
            komutguncelle.Parameters.AddWithValue("@p3", mskdTCno.Text);
            komutguncelle.Parameters.AddWithValue("@p4", txtEhliyetSuresi.Text);
            komutguncelle.Parameters.AddWithValue("@p5", txtMusteriID.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Müşteri Bilgileri Başarılı Bir Şekilde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAnaMenu_Click(object sender, EventArgs e)
        {
            Frmİslemler frm = new Frmİslemler();
            frm.Show();
            this.Hide();
        }
    }
}
