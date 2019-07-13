using StudentForm.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentForm.Repository.Repository
{
    public class StudentRepository
    {
        string connectionString = @"Server=IT\SQLEXPRESS; Database=StudentDB; Integrated Security=True";
        private SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        

        public int InsertStudent(Student student)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"INSERT INTO Students (Name,RollNo,Address) VALUES ('" +student.Name+ "','"+student.RollNo+"','"+student.Address+"')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            int isExecuted;
            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }

        public DataTable ShowStudents()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"select * from Students";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }

        public int UpdateStudent(Student student)
        {
            commandString = @"UPDATE Students SET Name= '" + student.Name + "' WHERE ID='"+ student.ID +"'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isExecuted;
            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }
        public int DeleteStudent(Student student)
        {
            commandString = @"Delete Students where ID='" + student.ID + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isExecuted;
            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }
    }
}
