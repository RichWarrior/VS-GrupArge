using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityApp.DbSet
{
    public class BLL
    {
        private DLL.Classroom classroom;
        private DLL.Exam_Date exam_date;
        private DLL.Lesson lesson;
        private DLL.Student student;
        private DLL.Teacher teacher;

        public DLL.Classroom Classroom()
        {
            if (classroom == null)
                classroom = new DLL.Classroom();
            return classroom;
        }
        public DLL.Exam_Date Exam_Date()
        {
            if (exam_date == null)
                exam_date = new DLL.Exam_Date();
            return exam_date;
        }
        public DLL.Lesson Lesson()
        {
            if (lesson == null)
                lesson = new DLL.Lesson();
            return lesson;
        }
        public DLL.Student Student()
        {
            if (student == null)
                student = new DLL.Student();
            return student;
        }
        public DLL.Teacher Teacher()
        {
            if (teacher == null)
                teacher = new DLL.Teacher();
            return teacher;
        }
    }
}
