using System;
//inheritance example, to understand the definition and how to apply it
namespace Tutlane
{
    public class User
    {
       public string Name;
       private string Location;
       public User()
       {
          Console.WriteLine("Base Class Constructor");
       }
       public void GetUserInfo(string loc)
       {
          Location = loc;
          Console.WriteLine("Name: {0}", Name);
          Console.WriteLine("Location: {0}", Location);
       }
    }
    public class Details: User
    {
       public int Age;
       public Details()
       {
          Console.WriteLine("Child Class Constructor");
       }
       public void GetAge()
       {
          Console.WriteLine("Age: {0}", Age);
       }
    }
    class Program
    {
       static void Main(string[] args)
       {
          Details d = new Details();
          d.Name = "Suresh Dasari";
          
          
          d.Age = 32;
          d.GetUserInfo("Hyderabad");
          d.GetAge();
          Console.WriteLine("\nPress Any Key to Exit..");
          Console.ReadLine();
       }
    }
}