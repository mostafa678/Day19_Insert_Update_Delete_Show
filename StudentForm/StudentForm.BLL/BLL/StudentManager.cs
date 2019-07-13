using StudentForm.Models.Models;
using StudentForm.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentForm.BLL.BLL
{
    public class StudentManager
    {
        StudentRepository _studentRepository = new StudentRepository();
        public int InsertStudent(Student student)
        {
            return _studentRepository.InsertStudent(student);
        }

        public DataTable ShowStudents()
        {
            return _studentRepository.ShowStudents();
        }
        public int UpdateStudent(Student student)
        {
            return _studentRepository.UpdateStudent(student);
        }
        public int DeleteStudent(Student student)
        {
            return _studentRepository.DeleteStudent(student);
        }
    }
}
