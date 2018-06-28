using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportExcel
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private string hostname = Properties.Settings.Default.Hostname;
        private string dbName = Properties.Settings.Default.DbName;
        private string username = Properties.Settings.Default.UserId;
        private string password = Properties.Settings.Default.Password;
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter adapter;
        private DataTable dt;
        private ArrayList columnsRows = new ArrayList()
        {
            "A","B","C","D","E","F","G","H","J","K","L","M","N","O","P","R","S","T","U","V","W"
        };
        private SaveFileDialog saveFileDialog;

        private void Form2_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source="+hostname+";Initial Catalog="+dbName+";User Id="+username+";Password="+password);
            getAllTables();
        }

        private void getAllTables()
        {
            try
            {
                con.Open();
                dt =con.GetSchema("Tables");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listBox1.Items.Add(dt.Rows[i].ItemArray[2].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void writeData(string sheetPath, string query, string workSheet)
        {
            try
            {
                if (File.Exists(sheetPath))
                {
                    MessageBox.Show("Bu Dosya Zaten Mevcut!");
                }
                else
                {
                    FileInfo fileInfo = new FileInfo(sheetPath);
                    ExcelPackage excel = new ExcelPackage(fileInfo);

                    using (adapter = new SqlDataAdapter(query, con))
                    {
                        dt = new DataTable();
                        adapter.Fill(dt);
                    }
                    var WorkSheet = excel.Workbook.Worksheets.Add(workSheet);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int k = 0; k < dt.Columns.Count; k++)
                        {
                            if(columnsRows.Count>dt.Columns.Count)
                            {
                                if (i == 0)
                                {
                                    WorkSheet.Cells[columnsRows[k] + (i + 1).ToString()].Value = dt.Columns[k].ColumnName.ToString();
                                    WorkSheet.Cells[columnsRows[k] + (i + 2).ToString()].Value = dt.Rows[i].ItemArray[k].ToString();
                                }
                                else
                                {
                                    WorkSheet.Cells[columnsRows[k] + (i + 1).ToString()].Value = dt.Rows[i].ItemArray[k].ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Excel'de Bulunan Kolon Sayısı Veritabanında ki Kolon Sayısından Küçük!");
                                break;
                            }
                        }
                    }

                    excel.Save();
                    MessageBox.Show("Başarılı");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtQuery.Text)&&!String.IsNullOrEmpty(txtWorkSheetName.Text))
            {
                string path = null;
                using (saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter="Excel Files(*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Kaydedilecek Dosyayı Oluşturun!";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        path = saveFileDialog.FileName;
                        writeData(path,txtQuery.Text,txtWorkSheetName.Text);
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Bir Dizin Seçiniz!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen İlgili Yerleri Doldurunuz!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Hostname = null;
            Properties.Settings.Default.DbName = null;
            Properties.Settings.Default.UserId = null;
            Properties.Settings.Default.Password = null;
            Properties.Settings.Default.Save();
            Form x = new Form1();
            this.Hide();
            x.Show();
        }
    }
}
