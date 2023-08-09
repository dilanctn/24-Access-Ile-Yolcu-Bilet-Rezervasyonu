using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FormDersleri27AccessYolcuBiletRezervasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Monster\\Desktop\\Mydağ\\access tabloları\\YolcuBilgileri.mdb");
        OleDbCommand komut = new OleDbCommand();
        private void verilerigöster()
        {
            listView1.Items.Clear();
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglantı;
            komut.CommandText = "select *from YolcuBilgileri";
            OleDbDataReader oku = komut.ExecuteReader();
            
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["seferno"].ToString();
                ekle.SubItems.Add(oku["tarih"].ToString());
                ekle.SubItems.Add(oku["saat"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["koltukno"].ToString());
                ekle.SubItems.Add(oku["ücret"].ToString());
                ekle.SubItems.Add(oku["cinsiyet"].ToString());
                ekle.SubItems.Add(oku["biniş"].ToString());

                listView1.Items.Add(ekle);
            }
            baglantı.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand("insert into YolcuBilgileri (seferno,tarih,saat,adsoyad,telefon,koltukno,ücret,cinsiyet,biniş) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "')", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
            verilerigöster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            comboBox1.Text = "";
            comboBox2.Text="";

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox6.Text = "1";
            button4.Enabled = false;
            button4.BackColor = Color.Green;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox6.Text = "2";
            button5.Enabled = false;
            button5.BackColor = Color.Green;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox6.Text = "3";
            button6.Enabled = false;
            button6.BackColor = Color.Green;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox6.Text = "4";
            button7.Enabled = false;
            button7.BackColor = Color.Green;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox6.Text = "5";
            button8.Enabled = false;
            button8.BackColor = Color.Green;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox6.Text = "6";
            button9.Enabled = false;
            button9.BackColor = Color.Green;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox6.Text = "7";
            button10.Enabled = false;
            button10.BackColor = Color.Green;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox6.Text = "0";
            button3.Enabled = false;
            button3.BackColor = Color.Green;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            komut.Connection = baglantı;
            komut.CommandText="delete from YolcuBilgileri where adsoyad='"+textBox8.Text + "'";
            komut.ExecuteNonQuery();
            baglantı.Close();
            verilerigöster();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            komut.Connection = baglantı;
            komut.CommandText = ("update YolcuBilgileri set seferno='" + textBox1.Text + "',tarih='" + textBox2.Text + "',saat='" + textBox3.Text + "',telefon='" + textBox5.Text + "',koltukno='" + textBox6.Text + "',ücret='" + textBox7.Text + "',cinsiyet='" + comboBox1.Text + "',biniş='" + comboBox2.Text + "' where adsoyad='"+textBox4.Text+"'");
            //koltukno ya göre güncelleme yapıyoruz
            komut.ExecuteNonQuery();
            baglantı.Close();
            verilerigöster();


        }
    }
}
