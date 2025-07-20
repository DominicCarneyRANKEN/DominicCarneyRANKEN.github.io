using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj8
{
    public class Person : Object
    {
        //Create an AGE isntance fields, with accessor and mutator methods
        //Add age to the constructor

        //Mmebers
        //Fields (data)
        //Methods

        //Instance Fields (data_ It's all about the Instance Fields
        //All instance fields have defautl values when an object is created
        //Strings are null or empty
        //Int's are 0
        //Booleans are false
        //Flatoing point numbers are 0.0


        private string? _firstName; //Datta hiding is good because the fields are private and only be access by public methods
        private string? _lastName;

        private int _age;

        //Constructor - Method that has the same name as the class? no return type
        //Used to initialize the object with other than the default values

        public Person(string fn, string ln, int age) //2 param constructor
        {
            _firstName = fn;
            _lastName = ln;
            _age = age;
        }

        //Accessor and Mutator Methods

        //Accessor Method

        public string GetFirstName()
        {
            return _firstName;
        }

        public int getAge()
        {
            return Convert.ToInt32(_age);
        }

        //Mutator Method

        public void SetAge(int age)
        {
            _age = age;
        }

        public void SetFirstName(string firstName)
        {
            _firstName = firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public void SetLastName(string lastName)
        {
            _lastName = lastName;
        }

        public int CalcDaysOld()
        {
            return _age * 365;
        }


        //Tostring is an accessor for MULTIPLE Methods?
   
    }
}
