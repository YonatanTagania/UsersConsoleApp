using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp
{
    public class User : IComparable
    {
        private string firstName;
        private string lastName;
        private int yearOfBirth;
        private string email;
        public User(string firstName, string lastName, int yearOfBirth, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.yearOfBirth = yearOfBirth;
            this.email = email;
        }
        public string UserInfo()
        {
            return $" first name: {this.firstName} last name: {this.lastName} birth year: {this.yearOfBirth} email: {this.email}";
        }
        public  string GetFirstName()
        {
            return this.firstName;
        }
        public int CompareTo(object obj)
        {
            User user = (User)obj;
            if (user.yearOfBirth < this.yearOfBirth) return -1;
            if (user.yearOfBirth > this.yearOfBirth) return 1;
            return 0;
        }
    }
}
