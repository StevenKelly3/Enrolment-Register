using System;
using System.Globalization;
using System.Windows.Forms;

namespace Enrolment_Register
{
    public partial class Add : Form
    {

        public Add()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // This "directive" is needed for proper mamagement of date strings
            CultureInfo provider = CultureInfo.InvariantCulture;
            Student student = new Student();
            DateTime checkDate;

            // Assemble student record from Form input and add to List structure

            if (e_Data.s_List.Count < e_Data.maxPupils)
            {

                // Using try-catch to handle incorrect date format
                try
                {
                    checkDate = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", provider);

                    // Check for input values - if any field is blank display error message
                    // Replace false with the input checks
                    if (false)
                    {
                        MessageBox.Show("Record cannot be saved unless all values supplied");
                    }
                    else
                    {
                        if (cboMode.Text == "FT")
                        {
                            e_Data.studentName = txtName.Text;
                            e_Data.studentDOB = txtDOB.Text;
                            e_Data.studentGender = cboGender.Text;
                            e_Data.studentCourseType = cboMode.Text;
                            e_Data.studentYear = cboYear.Text;
                            e_Data.studentModulesTaken = cboNumModules.Text;
                            if (cboYear.Text == "3") //year 3
                            {
                                e_Data.studentModuleCost = "2500".ToString(); 
                            }
                            else
                            {
                                e_Data.studentModuleCost = "5000".ToString();
                            }

                            addStudent(student);
                            e_Data.s_List.Add(student);
                            this.Close();
                        }
                        else
                        {
                            // Calculate part-time fee
                            int PTFee;
                            int i = 0;



                            e_Data.studentName = txtName.Text;
                            e_Data.studentDOB = txtDOB.Text;
                            e_Data.studentGender = cboGender.Text;
                            e_Data.studentCourseType = cboMode.Text;
                            e_Data.studentYear = cboYear.Text;
                            e_Data.studentModulesTaken = cboNumModules.Text;

                            //if statements for each module taken to calculate total fee for PT
                            
                            if (cboNumModules.Text == "1") 
                            {
                                e_Data.studentModuleCost = "750".ToString();
                            }
                            else if (cboNumModules.Text == "2")
                            {
                                PTFee = 750 * 2;
                                e_Data.studentModuleCost = PTFee.ToString();
                            }
                            else if (cboNumModules.Text == "3")
                            {
                                PTFee = 750 * 3;
                                e_Data.studentModuleCost = PTFee.ToString();
                            }
                            else if (cboNumModules.Text == "4")
                            {
                                PTFee = 750 * 4;
                                e_Data.studentModuleCost = PTFee.ToString();
                            }
                            else if (cboNumModules.Text == "5")
                            {
                                PTFee = 750 * 5;
                                e_Data.studentModuleCost = PTFee.ToString();
                            }
                            else if (cboNumModules.Text == "6")
                            {
                                PTFee = 750 * 6;
                                e_Data.studentModuleCost = PTFee.ToString();
                            }

                            addStudent(student);
                            e_Data.s_List.Add(student);
                            this.Close();

                        }

                        // Create instance of Student and populate properties with input data

                        // Add new student to List Structure
                        // e_Data.s_List.Add(s);
                    }

                }




                catch (Exception)
                {
                    MessageBox.Show("Invalid date format in Student file");
                    this.Close();
                }
            }
        }

        private void addStudent(Student student)
        {
            student.name = e_Data.studentName;
            student.DOB = e_Data.studentDOB;
            student.gender = e_Data.studentGender;
            student.mode = e_Data.studentCourseType;
            student.year = e_Data.studentYear;
            student.numModules = e_Data.studentModulesTaken;
            student.totalFee = e_Data.studentModuleCost;

       
        }
    }
}
