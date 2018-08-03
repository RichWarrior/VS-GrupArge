using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PerformanceMonitorApp_V2.View
{
    public partial class Dashboard : Form
    {
        #region Construction
        public Dashboard()
        {
            InitializeComponent();
            total_memory_size = (total_memory_size / 1024) / 1024;
        }
        #endregion
        #region Variables
        private Timer timer;
        private string selected_process_name;
        private PerformanceCounter total_ram, total_cpu; // Genel Kullanımlar
        private PerformanceCounter ram, cpu; //Seçili Kullanımlar
        private double total_memory_size = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
        private double available_bytes = new Microsoft.VisualBasic.Devices.ComputerInfo().AvailablePhysicalMemory;
       
        #endregion
        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Sistemde Çalışan Servis ve Programları Listeleme
            TreeNode main_node = new TreeNode("Process");
            foreach (var item in Process.GetProcesses().OrderBy(x=>x.ProcessName))
            {
                TreeNode sub_node = new TreeNode(item.ProcessName);
                main_node.Nodes.Add(sub_node);
            }
            treeView1.Nodes.Add(main_node);
            treeView1.NodeMouseClick += TreeView1_NodeMouseClick;

            total_cpu = new PerformanceCounter("Processor Information", "% Processor Time","_Total");

            ram_progress.MaxValue = (int)total_memory_size;
            total_ram_progress.MaxValue = (int)total_memory_size;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += Timer_Tick; // Metod Yönlendirme
        }

        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text != "Process")
            {
                selected_process_name = e.Node.Text;
                cpu = new PerformanceCounter("Process", "% Processor Time",selected_process_name);
                ram = new PerformanceCounter("Process", "Working Set - Private", selected_process_name);
           
        
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var total_cpu_value = (int)total_cpu.NextValue();
            total_cpu_progress.Value = total_cpu_value;
            available_bytes = new Microsoft.VisualBasic.Devices.ComputerInfo().AvailablePhysicalMemory;
            available_bytes = (available_bytes / 1024) / 1024;
            var total_ram_value = total_memory_size - available_bytes;
            total_ram_progress.Value = (int)total_ram_value;
            if (cpu!=null)
            {
                var cpu_value = (int)cpu.NextValue()/Environment.ProcessorCount;
                cpu_progress.Value = cpu_value;
                var ram_value = (int)ram.NextValue();
                ram_value = (((int)ram_value / (int)1024) / 1024);
                cpu_label.Text = "Seçili İşlemin Bellek Miktarı="+ram_value+"MB";
                ram_progress.Value = ram_value;
               

            }
        }
    }
}