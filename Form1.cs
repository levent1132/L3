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
    
    public partial class Form1 : Form
    {



        MySqlConnection Bagla = new MySqlConnection("server=localhost; database=luttop; user=root; password=; pooling = false; convert zero datetime=True");
            MySqlDataAdapter Adaptor;
            DataSet Ds;
        
    

        
            
      
        public Form1()
        {
            InitializeComponent();
     
           
        }

        public string id;
        public string k_mail;
        private void button1_Click(object sender, EventArgs e)
        { 
            
            try
            {
                
                button1.Enabled = true;
                string k_sifre = textBox2.Text;
                k_mail = textBox1.Text;
                Adaptor = new MySqlDataAdapter("select * from personel where p_mail='" + k_mail + "' and p_sifre = " + k_sifre + "", Bagla);
                Bagla.Open();
                Ds = new DataSet();
                Ds.Clear();
                Adaptor.Fill(Ds, "veri");

                if (Ds.Tables[0].Rows.Count == 1)
                {
                    string adı = Ds.Tables[0].Rows[0]["m_ad"].ToString();
                    string password = Ds.Tables[0].Rows[0]["m_sifre"].ToString();
                    string soyad = Ds.Tables[0].Rows[0]["m_soyad"].ToString();
                    id = Ds.Tables[0].Rows[0]["m_ID"].ToString();

                    MessageBox.Show("Giriş Yapıldı..  Hoş Geldiniz  :" + adı + " " +soyad , "Hoş geldiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Form2 frm2 = new Form2();
                       this.Hide();
                       frm2.label2.Text = k_mail;
                       frm2.label1.Text = id;
                    frm2.Show();
                    
                    Bagla.Close();
                }
                else
                {
                   
                    MessageBox.Show("E-mail adresi :" + " " + textBox1.Text + " - şifre : " + textBox2.Text + "  Gözden Geçiriniz", "Hatalı Giriş!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.DataBindings.Clear();
                    textBox2.DataBindings.Clear();
                }
            }

            catch (Exception)
            {
                MessageBox.Show("lann");
                
            }
            
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
    }
}
