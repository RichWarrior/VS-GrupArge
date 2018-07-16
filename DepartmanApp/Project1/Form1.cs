using Project1.Controller;
using Project1.Model;
using Project1.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DepartmanController departmanController = new DepartmanController();
        MeslekController meslekController = new MeslekController();
        PersonelController personelController = new PersonelController();
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.FullRowSelect = true;
            listView2.FullRowSelect = true;
            listView3.FullRowSelect = true;
            listView1.MultiSelect = false;
            listView2.MultiSelect = false;
            ListViewTitle(new Personeller { },listView1);
            ListViewTitle(new Departman { }, listView2);
            ListViewTitle(new Meslek { }, listView3);
            ComboBoxFill();           
        }
        private void ComboBoxFill()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox1.Items.AddRange(meslekController.Listele().Select(a => a.meslek).ToArray());
            comboBox2.Items.AddRange(departmanController.Listele().Select(a => a.departman).ToArray());
        }
        private void ListViewTitle(object obj,ListView l)
        {
            IList<PropertyInfo> props = new List<PropertyInfo>(obj.GetType().GetProperties());
            foreach (PropertyInfo item in props)
            {
                l.Columns.Add(item.Name.ToUpper(),l.Width/props.Count);
            }
        }
        private void ListViewFill(object obj,ListView l)
        {
            IList<PropertyInfo> props = new List<PropertyInfo>(obj.GetType().GetProperties());
            List<object> list = new List<object>();
            foreach (PropertyInfo item in props)
            {
                list.Add(item.GetValue(obj,null));
            }
            ListViewItem x = new ListViewItem();
            x.Text = list[0].ToString();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                }else
                {
                    x.SubItems.Add(list[i].ToString());
                }
            }
            l.Items.Add(x);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count>0)
            {
                DialogResult result = MessageBox.Show(listView1.SelectedItems[0].Text+" Silinsin Mi?","Emin Misin?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    personelController.Sil(listView1.SelectedItems[0].Index);
                    listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var meslek_id = meslekController.Listele().Where(x => x.meslek == comboBox1.Text).Select(x => x.kod).Single();
            Personeller personel = new Personeller() { Ad = textBox1.Text, Soyad = textBox2.Text, Meslek=meslek_id.ToString(), Departman = comboBox2.Text };
            personelController.Ekle(personel);
            personel.Meslek = meslekController.Listele().Where(x => x.kod == meslek_id).Select(x => x.meslek).Single();
            ListViewFill(personel,listView1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            departmanController.Ekle(new Departman { departman=textBox3.Text });
            ListViewFill(new Departman { departman=textBox3.Text },listView2);
            ComboBoxFill();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count>0)
            {
                departmanController.Sil(listView2.SelectedItems[0].Index);
                listView2.Items.RemoveAt(listView2.SelectedItems[0].Index);
                ComboBoxFill();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            var key = Guid.NewGuid().ToString();
            meslekController.Ekle(new Meslek { kod =key,meslek=textBox5.Text });
            ListViewFill(new Meslek { kod=key,meslek=textBox5.Text },listView3);
            ComboBoxFill();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count>0)
            {
                var index = listView3.SelectedItems[0].Index;
                meslekController.Sil(index);
                ComboBoxFill();
                listView3.Items.RemoveAt(index);
            }
        }
    }
}
