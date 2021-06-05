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


namespace WindowsFormsApp21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=METE; Initial Catalog=randevu; Integrated Security=SSPI");

        void temizle()
        {
            txtid.Text = "";
            txtid.Text = "";
            label1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox1.Text = "";
            txtid.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'randevuDataSet2.Hasta' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.hastaTableAdapter.Fill(this.randevuDataSet2.Hasta);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Hasta (HastaAd,HastaAsı,HastaDoz,HastaIl,HastaMerkez,HastaTarih,HastaTelefon) values(@1,@2,@3,@4,@5,@6,@7)", baglanti);
            
            komut.Parameters.AddWithValue("@1", textBox1.Text);
            komut.Parameters.AddWithValue("@2", label1.Text);
            komut.Parameters.AddWithValue("@3", comboBox1.Text);
            komut.Parameters.AddWithValue("@4", comboBox2.Text);
            komut.Parameters.AddWithValue("@5", comboBox3.Text);
            komut.Parameters.AddWithValue("@6", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@7", textBox2.Text);
            komut.Parameters.AddWithValue("@8", txtid.Text);




            komut.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("HASTA EKLENDİ...");


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.hastaTableAdapter.Fill(this.randevuDataSet2.Hasta);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete From Hasta Where HastaID=@p1", baglanti);
            sil.Parameters.AddWithValue("@p1", txtid.Text);
            sil.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("KAYIT SİLİNDİ...");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update Hasta Set HastaAd=@p1,HastaAsı=@p2,HastaDoz=@p3,HastaIl=@p4,HastaMerkez=@p5,HastaTarih=@p6,HastaTelefon=@p7 where HastaID=@p8", baglanti);

            guncelle.Parameters.AddWithValue("@p1", textBox1.Text);
            guncelle.Parameters.AddWithValue("@p2", label1.Text);
            guncelle.Parameters.AddWithValue("@p3", comboBox1.Text);
            guncelle.Parameters.AddWithValue("@p4", comboBox2.Text);
            guncelle.Parameters.AddWithValue("@p5", comboBox3.Text);
            guncelle.Parameters.AddWithValue("@p6", dateTimePicker1.Value);
            guncelle.Parameters.AddWithValue("@p7", textBox1.Text);
            guncelle.Parameters.AddWithValue("@p8", txtid.Text);

            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("HASTA GÜNCELLENDİ...");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            label1.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[7].Value.ToString();
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_TextChanged(object sender, EventArgs e)
        {
            if (label1.Text == "True")
            {
                radioButton1.Checked = true;

            }
            if (label1.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                label1.Text = "BİONTECH";
            label14.Text = "İlk Dozdan 5-6 Hafta Sonra";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                label1.Text = "SİNOVAC";
                label14.Text = "İlk Dozdan 3-4 Hafta Sonra";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.aa.com.tr/tr/p/covid-19-asi");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://covid19asi.saglik.gov.tr/TR-77707/asi-uygulanacak-grup-siralamasi.html");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://covid19asi.saglik.gov.tr/TR-77715/covid-19-asisi-sonrasi-yan-etkiler.html");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://covid19asi.saglik.gov.tr/Eklenti/40457/0/8adimdanasilasiolurumafis50x70cmpdf.pdf?_tag1=91A6ACDDAB290ECAAA57A927362AB87B4C090400");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

