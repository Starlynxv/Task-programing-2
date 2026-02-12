using System;
using System.Collections.Generic;
using System.Text;

namespace task_1
{
    
    public class CommunityMember
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }


    public class Employee : CommunityMember
    {
        public decimal Salary { get; set; }
    }

    public class Student : CommunityMember
    {
        public string Major { get; set; }
    }

    public class Alumnus : CommunityMember
    {
        public int GraduationYear { get; set; }
    }

   
    public class Faculty : Employee
    {
        public string AcademicArea { get; set; }
    }

    public class Administrative : Employee
    {
        public string Department { get; set; }
    }

   
    public class Administrator : Faculty
    {
        public string Position { get; set; }
    }

    public class Teacher : Faculty
    {
        public string Subject { get; set; }
    }
} 