using System;
//example of polymorphism, to understand the definition and how to apply it
namespace RealTimeMethodOverriding
{
    public class User
    {
        public virtual void UserLogin(string uname, string password, string role)
        {
            if (role == "user" && (uname == "user" && password == "user@123"))
            {
                Console.WriteLine("{0} is valid and Loged sucessfully.........", role);
            }
            else
            {
                Console.WriteLine("Invalid User Name or Password!");
            }
        }
    }

    public class Admin : User
    {
        public override void UserLogin(string uname, string password, string role)
        {
            if (role == "Admin" && (uname == "Admin" && password == "admin@123"))
            {
                Console.WriteLine("{0} is valid and Loged sucessfully.........", role);
            }
            else
            {
                Console.WriteLine("Invalid User Name or Password!");
            }
        }

    }
    public class SuperAdmin : User
    {
        public override void UserLogin(string uname, string password, string role)
        {
            if (role == "SuperAdmin" && (uname == "SuperAdmin" && password == "admin@123"))
            {
                Console.WriteLine("{0} is valid and Loged sucessfully.........", role);
            }
            else
            {
                Console.WriteLine("Invalid User Name or Password!");
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            User user;
            user = new Admin();
            user.UserLogin("Admin", "admin@123", "Admin");
            user = new SuperAdmin();
            user.UserLogin("SuperAdmin", "admin@123", "SuperAdmin");            
            Console.ReadLine();
        }
    }
}