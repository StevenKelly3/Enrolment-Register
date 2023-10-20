using System;
using System.IO;
using System.Windows.Forms;

namespace Enrolment_Register
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // On form load, course details are read.
            // List structure AND listbox populated with student details.

            // Read course data
            string courseRec, studentRec;
            string[] studentRecArray, courseRecArray;

            StreamReader CourseFile, StudentFile;
            if ((File.Exists(@"..\..\temp\CourseDetails.txt") && (File.Exists(@"..\..\temp\StudentDetails.txt")))) //For finding both files
            {
                CourseFile = File.OpenText(@"..\..\temp\CourseDetails.txt");

                while (CourseFile.EndOfStream == false) //Course File
                {
                    courseRec = CourseFile.ReadLine();
                    courseRecArray = courseRec.Split(',');
                    e_Data.courseName = courseRecArray[0];
                    e_Data.courseLecturer = courseRecArray[1];
                }

                CourseFile.Close();

                StudentFile = File.OpenText(@"..\..\temp\StudentDetails.txt");// Read Student file


                while (StudentFile.EndOfStream == false) //Student File
                {
                    
                    Student student = new Student(); //create instance of student
                    studentRec = StudentFile.ReadLine();
                    studentRecArray = studentRec.Split(',');
                    e_Data.studentName = studentRecArray[0];
                    e_Data.studentDOB = studentRecArray[1];
                    e_Data.studentGender = studentRecArray[2];
                    e_Data.studentCourseType = studentRecArray[3];
                    e_Data.studentYear = studentRecArray[4];
                    e_Data.studentModulesTaken = studentRecArray[5];
                    e_Data.studentModuleCost = studentRecArray[6];
                    addStudent(student); //Refers to method student where the values are linked to student
                    e_Data.s_List.Add(student); //Adds student to the list structure
                }

                
                
                
                StudentFile.Close();


                RefreshListBox(); //Refereshes listbox and adds student's details to list box

                
            }


            // Create instance of Student and add to List structure
            // Refresh Listbox.
            // ...



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

        private void RefreshListBox()
        {
            string row;


            lstStudents.Items.Clear(); // Clear the listbox

            foreach (Student student in e_Data.s_List)
            {

                row = student.name + "-" + student.DOB + "-" + student.gender + "-" + student.mode + "-" + student.year + "-" +
                    student.numModules + "-" + student.totalFee;

                lstStudents.Items.Add(row); //adds row to list box
                
                //lstStudents.Items.Add(e_Data.s_List.Count); //temp line, needs removed, used to count students to ensure it recognises each person


            }


            // Iterate over the List structure and add each student to listbox
            // ...



        }
        //COMPLETED

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add myAddForm = new Add();
            myAddForm.ShowDialog();
            RefreshListBox();
        }
        //COMPLETED

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sRec, remove;
            string[] sRecArray;

            

            if (lstStudents.SelectedIndex == -1)
            {
                MessageBox.Show("Please select student to delete");
            }
            else
            {
                sRec = lstStudents.Items[lstStudents.SelectedIndex].ToString();
                sRecArray = sRec.Split('-');
                remove = sRecArray[0];
                DialogResult result = MessageBox.Show("Delete student: " + sRecArray[0], "Confirm", MessageBoxButtons.YesNoCancel);
                // If the user clicks Yes, remove the student from the List structure and refresh the listbox.
                if (result == DialogResult.Yes)
                {
                    foreach (Student student in e_Data.s_List)
                    {
                        if (student.name == sRecArray[0])
                        {

                            e_Data.s_List.Remove(student); //removes student details
                            break;
                        }
                        
                    }
                }
                // ...
                RefreshListBox();
            }
        }
        //COMPLETED
        

        private void btnSave_Click(object sender, EventArgs e)
        {
           

            StreamWriter studentFile, courseOverview, courseFile;
            

            // Open the Student Details and the Course Details files
            courseFile = File.CreateText(@"..\..\temp\CourseDetails.txt");
            courseOverview = File.CreateText(@"..\..\temp\CourseOverview.txt");
            studentFile = File.CreateText(@"..\..\temp\StudentDetails.txt");

            // Write student data to file from the List structure
            // ...
            foreach(Student student in e_Data.s_List)
            {
                studentFile.WriteLine(student.name + "," + student.DOB + ',' + student.gender + "," +
                    student.mode + "," + student.year + "," + student.numModules + "," + student.totalFee);
            }

            // Write course report data to file from variables
            // ...
            courseOverview.WriteLine(e_Data.courseLecturer + e_Data.courseName + "\n" +
                "Male: " + e_Data.coursePCM.ToString("p") + "\n" + "Female: " + e_Data.coursePCF.ToString("p") + "\n" +
                "Other: " + e_Data.coursePCO.ToString("p") + "\n" + "Full Time: " + e_Data.coursePCFT.ToString("p") + "\n" +
                "Part Time: " + e_Data.coursePCPT.ToString("p"));

            // Write course report data to file (CourseDetails) from variables
            courseFile.WriteLine(e_Data.courseName + ',' + e_Data.courseLecturer + ',' +
                e_Data.coursePCM.ToString() + ',' + e_Data.coursePCF.ToString() +
                ',' + e_Data.coursePCO.ToString() + ',' + e_Data.coursePCFT.ToString() +
                ',' + e_Data.coursePCPT.ToString());

            studentFile.Close();
            courseFile.Close();
            courseOverview.Close();
            this.Close();

        }
        //COMPLETED

        private void btnReport_Click(object sender, EventArgs e)
        {
            // Iterate over list structure, counting data as required.
            // ...
            Student student = new Student();

            int studentCounter = 0, maleCounter = 0, femaleCounter = 0, otherCounter = 0,
                fullTime = 0, partTime = 0, totalFee = 0;

            int i = 0;
            


            while (i < e_Data.s_List.Count)
            {

                //studentCounter++;//counts pupils

                //Count each gender
                if (student.gender == "Male")
                {
                    maleCounter++;
                }

                else if (student.gender == "Female")
                {
                    femaleCounter++;
                }

                else if (student.gender == "Other")
                {
                    otherCounter++;
                }
                
                

                //Count each mode

                if (student.mode == "FT" || student.mode == "ft")
                {
                    fullTime++;
                }
                else if (student.mode == "PT" || student.mode == "pt") 
                {
                    partTime++;
                }

                //Count total fee
                totalFee = int.Parse(totalFee + student.totalFee);

                i++;
            }



            e_Data.coursePCM = (maleCounter / i) * 100;
            e_Data.coursePCF = (int)femaleCounter / (int)i * 100;
            e_Data.coursePCO = (int)otherCounter / (int)i * 100;
            //e_Data.coursePCFT = (int)studentCounter / (int)fullTime * 100;
            //e_Data.coursePCPT = (int)studentCounter / (int)partTime * 100;

            lblOutput.Text = e_Data.courseLecturer.ToString() + " - " + e_Data.courseName.ToString() + '\n' +
                "Male: " + e_Data.coursePCM.ToString("P") + '\n' +
                "Female: " + e_Data.coursePCF.ToString("p") + '\n' +
                "Other: " + e_Data.coursePCO.ToString("p") +"\n" +
                "Full Time: " + e_Data.coursePCFT.ToString("p") + "\n" +
                "Part Time: " + e_Data.coursePCPT.ToString("p") +maleCounter.ToString();

            //Counters aren't counting, student.gender is returning as null!

            

            // Display data to output label area
            // ...

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search mySearchForm = new Search();
            mySearchForm.ShowDialog();
        }
        //COMPLETED
    }
}