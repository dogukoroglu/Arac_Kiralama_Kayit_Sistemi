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
    public partial class FrmAraclar : Form
    {
        public FrmAraclar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-GPMKKC5N\\SQLEXPRESS;Initial Catalog=ScooterKiralamaDB;Integrated Security=True");

        void Listele()
        {
            SqlCommand komutlistele = new SqlCommand("Select * From Tbl_Araclar", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komutlistele);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void Temizle()
        {
            txtAracid.Text = "";
            txtAracMarkasi.Text = "";
            txtAracModel.Text = "";
            txtAracYil.Text = "";
            txtYakit.Text = "";
            txtVites.Text = "";
            txtPlaka.Text = "";
            txtGunlukFiyat.Text = "";
            txtAracMarkasi.Focus();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Araclar(AracMarkasi,AracModeli,AracYili,YakitTuru,VitesTuru,Plaka,GunlukFiyat) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAracMarkasi.Text);
            komut.Parameters.AddWithValue("@p2", txtAracModel.Text);
            komut.Parameters.AddWithValue("@p3", txtAracYil.Text);
            komut.Parameters.AddWithValue("@p4", txtYakit.Text);
            komut.Parameters.AddWithValue("@p5", txtVites.Text);
            komut.Parameters.AddWithValue("@p6", txtPlaka.Text);
            komut.Parameters.AddWithValue("@p7", txtGunlukFiyat.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Temizle();
            MessageBox.Show("Araç Bilgisi Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAracid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAracMarkasi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtAracModel.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtAracYil.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtYakit.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtVites.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtPlaka.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            txtGunlukFiyat.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Araclar where AracID = @p1", baglanti);
            komutsil.Parameters.AddWithValue("@p1", txtAracid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Araç Kaydı Başarılı Bir Şekilde Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("update Tbl_Araclar set AracMarkasi=@p1, AracModeli=@p2, AracYili=@p3, YakitTuru=@p4, VitesTuru=@p5, Plaka=@p6, GunlukFiyat=@p7 where AracID=@p8", baglanti);
            komutguncelle.Parameters.AddWithValue("@p1", txtAracMarkasi.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtAracModel.Text);
            komutguncelle.Parameters.AddWithValue("@p3", txtAracYil.Text);
            komutguncelle.Parameters.AddWithValue("@p4", txtYakit.Text);
            komutguncelle.Parameters.AddWithValue("@p5", txtVites.Text);
            komutguncelle.Parameters.AddWithValue("@p6", txtPlaka.Text);
            komutguncelle.Parameters.AddWithValue("@p7", txtGunlukFiyat.Text);
            komutguncelle.Parameters.AddWithValue("@p8", txtAracid.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Araç Bilgileri Başarılı Bir Şekilde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            Listele();
        }

        private void btnAnaMenu_Click(object sender, EventArgs e)
        {
            Frmİslemler frm = new Frmİslemler();
            frm.Show();
            this.Hide();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
