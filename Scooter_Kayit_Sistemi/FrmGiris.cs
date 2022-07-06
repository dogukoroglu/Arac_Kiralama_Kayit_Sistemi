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
    public partial class Araç_Kiralama_Sistemi_Kullanıcı_Giriş_Paneli : Form
    {
        public Araç_Kiralama_Sistemi_Kullanıcı_Giriş_Paneli()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-GPMKKC5N\\SQLEXPRESS;Initial Catalog=ScooterKiralamaDB;Integrated Security=True");

        void Temizle()
        {
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
            txtKullaniciAdi.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_SistemGiris where KullaniciAdi=@p1 and Sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Frmİslemler frm = new Frmİslemler();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış! Lütfen tekrar deneyiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Temizle();
            }
            baglanti.Close();
        }
    }
}
