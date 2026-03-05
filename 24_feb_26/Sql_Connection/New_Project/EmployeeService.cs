using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace New_Project
{
    internal class EmployeeService
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Employee_Info;Integrated Security=True ";

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====Employee Management System====");
                Console.WriteLine("1. View all Employee");
                Console.WriteLine("2. Insert Employee");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Search by Employee ID");
                Console.WriteLine("6. Search by Department Name");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ViewAllEmployees();
                        break;
                    case 2:
                        InsertEmployee();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        SearchByEmployeeID();
                        break;
                    case 6:
                        SearchByEmployeeName();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\n Press any key to continue...");
                Console.ReadLine();
            }
        }
        public void ViewAllEmployees()
        {
            // Code to retrieve and display all employees from the database
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "SELECT Id, Name, Department, Salary FROM Emp_Attributes";
            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("\n ----- Employee List-----");

            while(reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}" +
                    $"| {reader.GetString(1)}" +
                    $"| {reader.GetString(2)}" +
                    $"| {reader.GetInt32(3)}");
            }

        }
        public void InsertEmployee()
        {
            // Code to insert a new employee into the database
            Employee_Model emp = new Employee_Model();
            Console.WriteLine("Enter Employee Name: ");
            emp.Name = Console.ReadLine();
            Console.WriteLine("Enter Employee Department: ");
            emp.Department = Console.ReadLine();
            Console.WriteLine("Enter Employee Salary: ");
            emp.Salary = Convert.ToInt32(Console.ReadLine());

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO Emp_Attributes" +
                "(Name,Department,Salary)VALUES(@Name,@Department,@Salary)";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Inserted Successful");
        }   

        public void DeleteEmployee()
        {
            // Code to delete an employee from the database
            Console.WriteLine("Enter Employee ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "DELETE FROM Emp_Attributes WHERE Id = @Id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            int rows = cmd.ExecuteNonQuery();   
            Console.WriteLine(rows > 0 ? "Deleted Successfully" : "Employee not found");

        }   

        public void UpdateEmployee()
        {
            // Code to update an existing employee's information in the database
            Console.WriteLine("Enter Employee ID to update: ");
            Employee_Model emp = new Employee_Model();
            emp.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name: ");
            emp.Name = Console.ReadLine();
            Console.WriteLine("Enter Employee Department: ");
            emp.Department = Console.ReadLine();
            Console.WriteLine("Enter Employee Salary: ");
            emp.Salary = Convert.ToInt32(Console.ReadLine());

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "UPDATE Emp_Attributes SET Name = @Name, Department = @Department, Salary = @Salary WHERE Id = @Id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Updated Successfully" : "Employee not found");

        }

        public void SearchByEmployeeID()
        {
            // Code to search for an employee by their ID and display their information
            Console.WriteLine("Enter Employee ID to search: ");
            Employee_Model emp = new Employee_Model();
            emp.Id = Convert.ToInt32(Console.ReadLine());
            using SqlConnection conn = new SqlConnection(connectionString); 
            conn.Open();
            string query = "SELECT Id, Name, Department, Salary FROM Emp_Attributes WHERE Id = @Id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                emp.Id = reader.GetInt32(0);
                emp.Name = reader.GetString(1);
                emp.Department  = reader.GetString(2);
                emp.Salary = reader.GetInt32(3);
                Console.WriteLine($"ID: {emp.Id} | Name: {emp.Name} | Department: {emp.Department} | Salary: {emp.Salary}");
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
            
        }

        public void SearchByEmployeeName()
        {
            Console.WriteLine("Enter Employee Name to search: ");
            Employee_Model emp = new Employee_Model();
            emp.Name = Console.ReadLine();
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "SELECT Id, Name, Department, Salary FROM Emp_Attributes WHERE Name LIKE @Name";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", $"%{emp.Name}%");
            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                emp.Id = reader.GetInt32(0);
                emp.Name = reader.GetString(1);
                emp.Department = reader.GetString(2);
                emp.Salary = reader.GetInt32(3);
                Console.WriteLine($"ID: {emp.Id} | Name: {emp.Name} | Department: {emp.Department} | Salary: {emp.Salary}");
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }

    }
}
