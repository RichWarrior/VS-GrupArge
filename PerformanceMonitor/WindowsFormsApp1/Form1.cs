using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region Variables
        private Timer timer;
        private PerformanceCounter performanceCounter3;
        private PerformanceCounter performanceCounter4;
        private string processName;
        private StreamWriter sw;
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 5000;
            timer.Start();
            timer.Tick += Timer_Tick;
            this.FormClosed += Form1_FormClosed;
            foreach (var item in Process.GetProcesses().OrderBy(x => x.ProcessName))
            {
                listBox1.Items.Add(item.ProcessName);
            }
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
          
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PROCESS VERİLERİNİ TAKİP ETME
            processName = listBox1.SelectedItem.ToString();
            performanceCounter3 = new PerformanceCounter("Process", "% Processor Time", processName);
            performanceCounter4 = new PerformanceCounter("Process", "Working Set - Private", processName);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                //LOG DİZİNİ OLUŞTURMA
                var logPath = Directory.GetCurrentDirectory() + "/log".ToString();
                if (!File.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }
                progressBar1.Value = (int)performanceCounter1.NextValue();
                label1.Text = progressBar1.Value.ToString();
                if (performanceCounter3 != null)
                {
                    //HAM VERİYİ OKUMA
                    var process_ram = performanceCounter4.NextValue(); // Seçili Process Ram Kullanımı
                    var value = performanceCounter3.NextValue() / Environment.ProcessorCount;
                    progressBar2.Value = (int)value;
                    label3.Text = value.ToString();
                    label2.Text = "RAM:" + (((int)process_ram / (int)1024) / 1024).ToString() + "MB";

                    //LOGLAMA
                    sw = new StreamWriter(logPath+"/"+DateTime.Now.ToShortDateString()+".txt",true);
                    sw.WriteLine("TOTAL CPU USAGE:%"+(int)performanceCounter1.NextValue());
                    sw.WriteLine(processName+" CPU USAGE:%"+value);
                    sw.WriteLine(processName+" RAM USAGE:"+ (((int)process_ram / (int)1024) / 1024).ToString() + "MB");
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                (sender as Timer).Dispose();
            }
            
        }

      
    }
}
