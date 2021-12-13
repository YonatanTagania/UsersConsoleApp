using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp
{
    public class Student:User
    {
        private string className;
        public Student(string className,string firstName,string lastName,int yearOfBirth,string email) : base(firstName, lastName, yearOfBirth, email)
        {
            this.className = className;
        }
        public string StudentInfo()
        {
            return $"{base.UserInfo()} class {this.className}";
        }
    }
}
