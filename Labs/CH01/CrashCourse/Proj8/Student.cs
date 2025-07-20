//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Proj8
//{

//    //Animal >> Dog >> Poodle
//    public class Student : Person, ICourseAction //Single Inheritance in C sharp means you can only have one parent
//    {
//        //However you can implement multiple interfaces

//        //Instance field
//        private double _gpa;
//        //Student will inherit the non private fields and methods of Person
//        public Student() { }

//        public Student(string fn, string ln, int age, double gpa) : base(fn, ln, age)
//        {
//            _gpa = gpa;
//        }

//        public double GetGPA()
//        {
//            return _gpa;
//        }

//        public void StartCourse()
//        {
//            throw new NotImplementedException();
//        }

//        public void StopCourse()
//        {
//            throw new NotImplementedException();
//        }

//        public override string ToString()
//        {
//            return base.ToString() + " THEIR GPA IS " + _gpa;
//        }
//    }
//}
