using New_Project;
using System;

namespace New_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeService service = new EmployeeService();
            service.Run();
        }
    }
}