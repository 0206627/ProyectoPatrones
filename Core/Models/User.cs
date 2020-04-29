using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class User
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string pwd { get; set; }
        public string gender { get; set; }
        public DateTime birthday { get; set; }
        public DateTime dateJoined { get; set; }
        public string profilePicture { get; set; }
        public List<User> friends { get; set; }

        public User() { }
        public User(int ID, string firstName, string lastName, string email, string pwd, string gender, DateTime birthday, DateTime dateJoined, string profilePicture)
        {
            this.ID = ID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.pwd = pwd;
            this.gender = gender;
            this.birthday = birthday;
            this.dateJoined = dateJoined;
            this.profilePicture = profilePicture;
        }

        public void printUser()
        {
            Console.WriteLine("userID: " + this.ID);
            Console.WriteLine("firstName: " + this.firstName);
            Console.WriteLine("lastName: " + this.lastName);
            Console.WriteLine("email: " + this.email);
            Console.WriteLine("pwd: " + this.pwd);
            Console.WriteLine("gender: " + this.gender);
            Console.WriteLine("birthday: " + this.birthday.ToString());
            Console.WriteLine("dateJoined: " + this.dateJoined.ToString());
        }

    }
}
