using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Luttop_Musteri
{
    public partial class Form2 : Form
    {


        Form1 frm1 = new Form1();
        MySqlConnection Bagla = new MySqlConnection("server=localhost; database=luttop; user=root; password=");
        MySqlDataAdapter Adaptor;
        MySqlCommand komut;
        DataSet Ds;
        BindingSource Bs;


        int id;
        string mail;
        public Form2()
        {
            
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
       
           
            id = Convert.ToInt32(label1.Text);
            mail = label2.Text;
            
            Bagla.Open();
               
           
            Adaptor = new MySqlDataAdapter("SELECT * FROM `siparis_durum` where m_ID='" + id + "' ", Bagla);
           
            Ds = new DataSet();
            Bs = new BindingSource();
            Adaptor.Fill(Ds,"veri");
            Bs.DataSource=Ds.Tables["veri"];
            dataGridView1.DataSource = Bs;
            Bagla.Close();
            
            Bagla.Open();
            Adaptor = new MySqlDataAdapter("SELECT `m_ad`, `m_soyad`, `m_gsm`, `m_adres`, `m_mail`, `m_sirket` , m_sifre FROM `musteri` where m_mail='"+ mail +"' ",Bagla);
            Ds = new DataSet();
            Bs = new BindingSource();
            Adaptor.Fill(Ds, "veri2");
            Bs.DataSource=Ds.Tables["veri2"];
            dataGridView2.DataSource = Bs;
            Bagla.Close();
            dataGridView1.Columns[0].HeaderText = "Sipariş NO";
            dataGridView1.Columns[1].HeaderText = "Müşteri NO";
            dataGridView1.Columns[2].HeaderText = "Personel NO";
            dataGridView1.Columns[3].HeaderText = "Ürün NO";
            dataGridView1.Columns[4].HeaderText = "Durum";
            dataGridView1.Columns[5].HeaderText = "Teslim Tarihi";
            dataGridView1.Columns[6].HeaderText = "Çıkış Tariihi";


            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 85;
            dataGridView1.Columns[5].Width = 85;
            dataGridView1.Columns[6].Width = 75;







            dataGridView2.Columns[0].HeaderText = "Ad";
            dataGridView2.Columns[1].HeaderText = "Soyad";
            dataGridView2.Columns[2].HeaderText = "GSM";
            dataGridView2.Columns[3].HeaderText = "Adres";
            dataGridView2.Columns[4].HeaderText = "E-Mail";
            dataGridView2.Columns[5].HeaderText = "Şirket";
            dataGridView2.Columns[6].HeaderText = "Şifre";

            dataGridView2.Columns[0].Width = 75;
            dataGridView2.Columns[1].Width = 90;
            dataGridView2.Columns[2].Width = 90;
            dataGridView2.Columns[3].Width = 215;
            dataGridView2.Columns[4].Width = 150;
            dataGridView2.Columns[5].Width = 80;
            dataGridView2.Columns[6].Width = 75;




            textguncelle();
             
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Çıkış yapmak istiyor musunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bagla.Open();



            komut = new MySqlCommand(" UPDATE `musteri` SET `m_ad` = '" + mus_adbox.Text + "', `m_soyad` = '"
                + mus_soyadbox.Text + "', `m_mail` = '" + mus_epostabox.Text + "', `m_gsm` = '"
                + mus_gsmbox.Text + "', `m_adres` = '" + mus_adresbox.Text + "', `m_sirket` = '"
                + mus_sirketbox.Text + "',  `m_sifre` = '" + mus_sifrebox.Text + "' WHERE `m_ID` = '"
                + id + "'", Bagla);



            komut.ExecuteNonQuery();

            Bagla.Close();

            MessageBox.Show("Başarlı bir şekilde güncellemeniz tamamlandı " + mus_adbox.Text );

            dataguncelle();
            textguncelle();

        }
        public void dataguncelle()
        {

            Bagla.Open();
            Adaptor = new MySqlDataAdapter("SELECT `m_ad`, `m_soyad`, `m_gsm`, `m_adres`, `m_mail`, `m_sirket` , m_sifre FROM `musteri` where m_mail='" + mail + "' ", Bagla);
            Ds = new DataSet();
            Bs = new BindingSource();
            Adaptor.Fill(Ds, "veri2");
            Bs.DataSource = Ds.Tables["veri2"];
            dataGridView2.DataSource = Bs;
            Bagla.Close();


        }
        public void textguncelle()
        {


            
            mus_adbox.Text = Ds.Tables[0].Rows[0]["m_ad"].ToString();
            mus_soyadbox.Text = Ds.Tables[0].Rows[0]["m_soyad"].ToString();
            mus_epostabox.Text = Ds.Tables[0].Rows[0]["m_mail"].ToString();
            mus_gsmbox.Text = Ds.Tables[0].Rows[0]["m_gsm"].ToString();
            mus_adresbox.Text = Ds.Tables[0].Rows[0]["m_adres"].ToString();
            mus_sirketbox.Text = Ds.Tables[0].Rows[0]["m_sirket"].ToString();
            mus_sifrebox.Text = Ds.Tables[0].Rows[0]["m_sifre"].ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (groupBox3.Visible == false)
            {
                groupBox3.Visible = true;
            }
            else
            {
                groupBox3.Visible = false;
            }
        }

        
    }
   
}
