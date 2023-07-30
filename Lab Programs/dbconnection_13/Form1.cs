using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbconnection_13
{
    public partial class Form1 : Form

    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\22pca004 C# lab\Lab Programs\dbconnection_13\bin\Debug\Resourses\studentsDB.mdf");
        bool ErrSts = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxrollno.Text == "")
                {
                    addstatus("Please Enter Roll No...");
                    return;
                }
                if (textBoxname.Text == "")
                {
                    addstatus("Please Enter Name...");
                    return;
                }                
                if (textBoxage.Text == "")
                {
                    addstatus("Please Enter age...");
                    return;
                }
                if (radioButtonmale.Checked)
                {
                    students.gender = "Male";
                }
                else if (radioButtonfemale.Checked)
                {
                    students.gender = "Female";
                }
                if (comboBoxcourse.SelectedIndex >= 0 && comboBoxcourse.Text == "Select")
                {
                    addstatus("Please Select Course...");
                    return;
                }
                if (comboBoxsemester.SelectedIndex >= 0 && comboBoxsemester.Text == "Select")
                {
                    addstatus("Please Select Semester...");
                    return;
                }
                if (comboBoxyear.SelectedIndex >= 0 && comboBoxyear.Text == "Select")
                {
                    addstatus("Please Select Year...");
                    return;
                }
                else
                {
                    students.name = textBoxname.Text.ToString();
                    students.rollno = textBoxrollno.Text.ToString();
                    students.age = textBoxage.Text.ToString();
                    students.course = comboBoxcourse.Text.ToString();
                    students.semester = comboBoxsemester.Text.ToString();
                    students.year = comboBoxyear.Text.ToString();

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO StudentDetails VALUES ('" +
                        students.rollno + "','" + students.name + "','" + students.course + "','" + students.gender + "','" +
                        students.age + "','" + students.year + "','" + students.semester + "')", con);

                    con.Open();
                    ///this is used to connection open or close in the database while check completly and give the error message
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show(" Saved Success fully ");
                    //cal clear method to clear all the textbox value in the main document
                }
                clear();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            
        }
        public void addstatus(string Mess)
        {
            MessageBox.Show(Mess);
        }
        public void clear()
        {
            textBoxrollno.Text = "";
            textBoxname.Text = "";
            textBoxage.Text = "";
            radioButtonmale.Checked = true;
            radioButtonfemale.Checked = false;
            comboBoxcourse.SelectedIndex = 0;
            comboBoxsemester.SelectedIndex = 0;
            comboBoxyear.SelectedIndex = 0;
            students.rollno = "";
            students.name = "";
            students.gender = "";
            students.age = "";
            students.year = "";
            students.course = "";
            students.semester = "";

        }

        private void buttonclear_Click(object sender, EventArgs e)
        {

            clear();
        }
    }
}
