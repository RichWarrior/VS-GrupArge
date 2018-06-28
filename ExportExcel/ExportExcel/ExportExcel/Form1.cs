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

namespace ExportExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private SqlConnection con;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtHost.Text)&&!String.IsNullOrEmpty(txtDbName.Text)&&!String.IsNullOrEmpty(txtUserId.Text)&&!String.IsNullOrEmpty(txtPassword.Text))
            {
                try
                {
                    con = new SqlConnection("Data Source=" + txtHost.Text + ";Initial Catalog=" + txtDbName.Text + ";User Id=" + txtUserId.Text + ";Password=" + txtPassword.Text);
                    con.Open();
                    Properties.Settings.Default.Hostname = txtHost.Text;
                    Properties.Settings.Default.DbName = txtDbName.Text;
                    Properties.Settings.Default.UserId = txtUserId.Text;
                    Properties.Settings.Default.Password = txtPassword.Text;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Başarıyla Bağlantı Kuruldu!");
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    con.Close();
                    Form x = new Form2();
                    x.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bağlantı Hatası!\n"+ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Tüm Verileri Eksiksiz Doldurunuz!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Hostname))
            {  
                Form x = new Form2();
                x.Show();
                timer1.Interval = 100;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Stop();
        }
    }
}
