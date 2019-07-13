using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentForm.Models.Models;
using StudentForm.BLL.BLL;

namespace StudentForm
{
    public partial class StudentUi : Form
    {
        StudentManager _studentManager = new StudentManager();
        private Student student;
        public StudentUi()
        {
            InitializeComponent();
            student = new Student();
        }

        private void StudentUi_Load(object sender, EventArgs e)
        {
            ShowDataGridView.DataSource = _studentManager.ShowStudents();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {

                student.Name = nameTextBox.Text;
                student.RollNo = rollTextBox.Text;
                student.Address = addressTextBox.Text;

                int isExecuted;

                isExecuted = _studentManager.InsertStudent(student);   ///*********Look***

                if (isExecuted > 0)
                {
                    MessageBox.Show("Saved");

                }
                else
                {
                    MessageBox.Show("Not Saved!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ShowDataGridView.DataSource = _studentManager.ShowStudents();
        }

        private void DataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.ShowDataGridView.Rows[e.RowIndex].Cells["SL"].Value = (e.RowIndex + 0).ToString();
        }

        private void ShowDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            student.Name = ShowDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            nameTextBox.Text = ShowDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            student.Name = nameTextBox.Text;
            //rollTextBox.Text = ShowDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString(); //id value show
            student.ID = Convert.ToInt32(ShowDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
            int isExecuted = _studentManager.UpdateStudent(student);
            if (isExecuted > 0)
            {
                MessageBox.Show("Update");

            }
            else
            {
                MessageBox.Show("Not Update!!");
            }
        }

        private void ShowDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            student.ID = Convert.ToInt32(ShowDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
            DialogResult result = MessageBox.Show("Do You Want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                int isExecuted = _studentManager.DeleteStudent(student);
                if (isExecuted > 0)
                {
                    MessageBox.Show("Delete");
                    ShowDataGridView.DataSource = _studentManager.ShowStudents();
                }
            }
            else
            {

            }
           
            
        }
    }
}
