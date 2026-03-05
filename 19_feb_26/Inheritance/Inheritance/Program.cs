using System;
using System.Xml.Linq;
namespace InheritanceDemo
{
    public class Person
    {
        private string name;
        private int age;

        public void GetInformation()
        {
            Console.WriteLine("Enter your name: ");
            name = Console.ReadLine();
            age = int.Parse(Console.ReadLine());
        }

        public void DisplayInformation()
        {
            Console.WriteLine("Welcome to Training Mr/Ms {0}, and your age is {1}", name, age);

        }
    }

    public class Employee : Person
    {
        private string Companyname;
        private int EmployeeID;
        private int EmployeeScore;


        public int GetEmployeeInformation()
        {
            Console.WriteLine("Enter your Company Name: ");
            Companyname = Console.ReadLine();
            EmployeeID = int.Parse(Console.ReadLine());
            EmployeeScore = int.Parse(Console.ReadLine());
            return EmployeeScore;

        }

        public void DisplayEmployeeInformation()
        {
            Console.WriteLine("Welcome to this Company {0}," +
                "your Employee ID is {1} and your Score is {2}", Companyname, EmployeeID, EmployeeScore);


        }
    }

    //hybrid k liye sirf interface use krenge
    interface IDepartment
    {
        string DepartmentName { get; set; }
        void DisplayDepartmentDetails();
    }
    public class EmployeeGradeLevel : Employee, IDepartment
    {
        public string DepartmentName { get; set; }


        public void CheckEligible()
        {
            Console.WriteLine("Every employee should have above 150");
            if (this.GetEmployeeInformation() > 150)
            {
                Console.WriteLine("Congratulations, you are eligible");
            }
            else
            {
                Console.WriteLine("oops! you are not eligible");
            }
        }

        public void DisplayDepartmentDetails()
        {
            Console.WriteLine("Department Name: {0}", DepartmentName);
        }
    }
    public class TestProgram
    {
        static void Main(string[] args)
        {

            EmployeeGradeLevel Cap = new EmployeeGradeLevel();
            Cap.GetInformation();
            Cap.DisplayInformation();
            // Cap.GetEmployeeInformation();
            Cap.DepartmentName = "IT";
            Cap.CheckEligible();
            Cap.DisplayEmployeeInformation();
            Cap.DisplayDepartmentDetails();
            Console.ReadLine();

        }

    }
}