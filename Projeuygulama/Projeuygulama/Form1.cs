using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Projeuygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=MobilyaMagazasi; user ID=postgres; password=meryem54");
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select*from \"SatisDanismani\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        { baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into \"SatisDanismani\"(\"adi\",\"soyadi\",\"maas\",\"danismanNo\",\"basladigiTarih\") " +
                "values(@p1,@p2,@p3,@p4,@p5)",baglanti );
            komut1.Parameters.AddWithValue("@p1", TxtAdi.Text);
            komut1.Parameters.AddWithValue("@p2", TxtSoyadi.Text);
            komut1.Parameters.AddWithValue("@p3", int.Parse(TxtMaas.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(TxtNo.Text));
            komut1.Parameters.AddWithValue("@p5", tarih.Text);
           
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Satış danışmanı ekleme işlemi tamamlandı.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2=new NpgsqlCommand("Delete From \"SatisDanismani\" where adi=@p1 and soyadi=@p2",baglanti);
            komut2.Parameters.AddWithValue("@p1", TxtAdi.Text);
            komut2.Parameters.AddWithValue("@p2", TxtSoyadi.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme işlemi başarılı.");
        
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3=new NpgsqlCommand("update \"SatisDanismani\" set maas=@p3 where adi=@p1 ",baglanti);
            komut3.Parameters.AddWithValue("@p1", TxtAdi.Text);
            komut3.Parameters.AddWithValue("@p3", int.Parse(TxtMaas.Text));
            komut3.ExecuteNonQuery();
            MessageBox.Show("Güncelleme işlemi tamamlandı.");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(1) +
            textBox1.Text.Substring(0, 1);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.Hour.ToString();
            label6.Text = DateTime.Now.Minute.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tarih_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
