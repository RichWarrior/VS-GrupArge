using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityApp
{
    public partial class Main : Form
    {
        private EntityApp.DbSet.BLL bll = new DbSet.BLL();
        private List<EntityApp.DbSet.Entities.Class> class_list;
        private List<EntityApp.DbSet.Entities.Lesson> lesson_list;
        private List<EntityApp.DbSet.Entities.Teacher> teacher_list;
       
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            class_list = bll.Classroom().Listele();
            lesson_list = bll.Lesson().Listele();
            teacher_list = bll.Teacher().Listele();
            comboBox1.Items.AddRange(class_list.Select(x => x.classroom).ToArray());
            comboBox2.Items.AddRange(lesson_list.Select(x => x.name).ToArray());
            comboBox3.Items.AddRange(teacher_list.Select(x=>x.name_surname).ToArray());
            retrieve();
            dataStudent.Columns["id"].Visible = false;
            dataTeacher.Columns["id"].Visible = false;
            dataClass.Columns["id"].Visible = false;
            dataTime.Columns["id"].Visible = false;
            dataStudent.Columns[1].HeaderText = "Öğrenci Adı";
            dataStudent.Columns[2].HeaderText = "Numarası";
            dataStudent.Columns[3].HeaderText = "Sınıf";
            dataTeacher.Columns[1].HeaderText = "Öğretmen Adı";
            dataTeacher.Columns[2].HeaderText = "Ders";
            dataClass.Columns[1].HeaderText = "Sınıf";
            dataTime.Columns[1].HeaderText = "Öğretmen Adı";
            dataTime.Columns[2].HeaderText = "Ders Adı";
            dataTime.Columns[3].HeaderText = "Tarih";
        }
        private void retrieve()
        {
            try
            {
                dataStudent.DataSource = null;
                dataStudent.DataSource = bll.Student().Listele().Select(x => new
                {
                    x.id,
                    x.name_surname,
                    x.number,
                    x.Class.classroom
                }).ToList();
                dataTeacher.DataSource = bll.Teacher().Listele().Select(x => new
                {
                    x.id,
                    x.name_surname,
                    x.Lesson.name
                }).ToList();
                dataClass.DataSource = bll.Classroom().Listele().Select(x => new
                {
                    x.id,
                    x.classroom
                }).ToList();
                dataTime.DataSource = bll.Exam_Date().Listele().Select(x => new
                {
                    x.id,
                    x.Teacher.name_surname,
                    x.Teacher.Lesson.name,
                    x.exam_date1
                }).ToList();
            }
            catch (Exception) { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (bll.Student().Ekle(new DbSet.Entities.Student
            {
                name_surname = textBox1.Text,
                number = textBox2.Text,
                classroom = class_list.Where(x => x.classroom == comboBox1.Text).Select(x => x.id).First()
            }))
            {
                MessageBox.Show("Öğrenci Eklendi!");
                retrieve();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataStudent.SelectedRows.Count > 0)
            {
                if (bll.Student().Sil(Convert.ToInt32(dataStudent.CurrentRow.Cells[0].Value.ToString())))
                {
                    MessageBox.Show("Öğrenci Başarıyla Silindi!");
                    retrieve();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataStudent.SelectedRows.Count > 0)
            {
                if (bll.Student().Güncelle(Convert.ToInt32(dataStudent.CurrentRow.Cells[0].Value.ToString()), new DbSet.Entities.Student
                {
                    name_surname = textBox1.Text,
                    number = textBox2.Text,
                    classroom = class_list.FirstOrDefault(x => x.classroom == comboBox1.Text).id
                }))
                {
                    MessageBox.Show("Güncelleme Başarıyla Yapıldı");
                    retrieve();
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (bll.Teacher().Ekle(new DbSet.Entities.Teacher
            {
                name_surname = textBox6.Text,
                lesson_id = lesson_list.First(x => x.name == comboBox2.Text).id
            }))
            {
                MessageBox.Show("Öğretmen Eklendi!");
                retrieve();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (dataTeacher.SelectedRows.Count > 0)
            {
                if (bll.Teacher().Sil(Convert.ToInt32(dataTeacher.CurrentRow.Cells[0].Value.ToString())))
                {
                    MessageBox.Show("Öğretmen Başarıyla silindi");
                    retrieve();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bll.Teacher().Güncelle(Convert.ToInt32(dataTeacher.CurrentRow.Cells[0].Value.ToString()),new DbSet.Entities.Teacher
            {
                name_surname=textBox6.Text,
                lesson_id = lesson_list.FirstOrDefault(x=>x.name == comboBox2.Text).id
            }))
            {
                MessageBox.Show("Güncelleme Başarıyla Yapıldı");
                retrieve();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(bll.Classroom().Ekle(new DbSet.Entities.Class
            {
                classroom=textBox9.Text,
            }))
            {
                MessageBox.Show("Sınıf Başarıyla Eklendi");
                retrieve();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(dataClass.SelectedRows.Count>0)
            {
                if (bll.Classroom().Sil(Convert.ToInt32(dataClass.CurrentRow.Cells[0].Value.ToString())))
                {
                    MessageBox.Show("Sınıf Başarıyla Silindi");
                    retrieve();
                }
            }       
        }

        private void button7_Click(object sender, EventArgs e)
        {
        
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(bll.Exam_Date().Ekle(new DbSet.Entities.Exam_Date
            {
               teacher_id = teacher_list.FirstOrDefault(x=>x.name_surname == comboBox3.Text).id,
                exam_date1 = dateTimePicker1.Value
            }))
            {
                MessageBox.Show("Sınav Tarihi Başarıyla Eklendi!");
                retrieve();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataTime.SelectedRows.Count > 0)
            {
                //List<int> index = new List<int>();
                //for (int i = 0; i < dataTime.SelectedRows.Count; i++)
                //{
                //    index.Add(Convert.ToInt32(dataTime.SelectedRows[i].Cells[0].Value));
                //}
                //if (bll.Exam_Date().SilRange(index))
                //{
                //    MessageBox.Show("Başarıyla Silindi!");
                //    retrieve();
                //}
                if (bll.Exam_Date().Sil(Convert.ToInt32(dataTime.CurrentRow.Cells[0].Value.ToString())))
                {
                    MessageBox.Show("Başarıyla Silindi!");
                    retrieve();
                }
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if(dataTime.SelectedRows.Count>0)
            {
                if(bll.Exam_Date().Güncelle(Convert.ToInt32(dataTime.CurrentRow.Cells[0].Value),new DbSet.Entities.Exam_Date {
                     exam_date1 = dateTimePicker1.Value
                }))
                {
                    MessageBox.Show("Güncellendi!");
                    retrieve();
                }
            }
        }
    }
}
