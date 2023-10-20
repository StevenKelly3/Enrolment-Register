using System;
using System.Collections.Generic;

namespace Enrolment_Register
{
    static class e_Data
    {
        // List structure for storing list (array) or Students
        public static List<Student> s_List = new List<Student>();

        // Global variables for storing course details
        public static string courseName, courseLecturer;
        public static double coursePCF, coursePCM, coursePCO, coursePCFT, coursePCPT; //percent of pupils
        public static string studentName, studentGender, studentCourseType, studentDOB;
        public static string studentYear, studentModulesTaken, studentModuleCost;

     

        public static string overallAdd; //add.cs

        

        public static int index = 0, maxPupils = 20;
    }
}
