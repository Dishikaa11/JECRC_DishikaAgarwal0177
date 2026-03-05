using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Product_Management
{
    internal class Product_Service
    {
        private readonly string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Product;Integrated Security=True";
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Search by Product ID");
                Console.WriteLine("6. Search by product Name");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    Console.ReadKey();
                    continue;
                }
                switch (input)
                {
                    case 1:
                        AddProduct();
                        break;
                    case 2:
                        ViewProducts();
                        break;
                    case 3:
                        UpdateProduct();
                        break;
                    case 4:
                        DeleteProduct();
                        break;
                    case 5:
                        SearchProductById();
                        break;
                    case 6:
                        SearchProductByName();
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
                Console.WriteLine("\n Press any key to continue...");
                Console.ReadLine();
            }

        }

        public void AddProduct()
        {
            Console.WriteLine("Enter product name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product category: ");
            string category = Console.ReadLine();
            Console.WriteLine("Enter product price: ");
            if (!float.TryParse(Console.ReadLine(), out float price))
            {
                Console.WriteLine("Invalid price! Please enter a valid number.");
                return;
            }
            Console.Write("Is the product in stock? (yes/no): ");
            string inStockInput = Console.ReadLine().ToLower();
            bool inStock = inStockInput == "yes" || inStockInput == "y";
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string query = "INSERT INTO Prod_Attributes (Name, Category, Price, InStock) VALUES (@Name, @Category, @Price, @InStock)";
            using SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Category", category);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@InStock", inStock);
            cmd.ExecuteNonQuery();


            Console.WriteLine("Product added successfully!");
        }

        public void ViewProducts()
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string query = "SELECT Id, Name, Category, Price, InStock FROM Prod_Attributes";
            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("ID\tName\tCategory\tPrice\tIn Stock");
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Id"]}\t{reader["Name"]}\t{reader["Category"]}\t{reader["Price"]}\t{reader["InStock"]}");
            }
        }

        public void UpdateProduct()
        {
            // Implementation for updating a product
            Console.WriteLine("Update product functionality is not implemented yet.");
            Product_Model mod = new Product_Model();
            mod.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter product Name: ");
            mod.Name = Console.ReadLine();
            Console.WriteLine("Enter product Category: ");
            mod.Category = Console.ReadLine();
            Console.WriteLine("Enter Product Price: ");
            mod.Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("is prouct is in stock ");
            mod.InStock = Convert.ToBoolean(Console.ReadLine());

            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string query = "UPDATE Prod_Attributes SET Name = @Name, Category = @Category, Price = @Price, InStock = @InStock WHERE Id = @Id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", mod.Id);
            cmd.Parameters.AddWithValue("@Name", mod.Name);
            cmd.Parameters.AddWithValue("@Category", mod.Category);
            cmd.Parameters.AddWithValue("@Price", mod.Price);
            cmd.Parameters.AddWithValue("@InStock", mod.InStock);
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Updated Successfully" : "Product not found");
        }

        public void DeleteProduct()
        {
            // Implementation for deleting a product
            Console.WriteLine("Delete product functionality is not implemented yet.");
            int id = Convert.ToInt32(Console.ReadLine());
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string query = "DELETE FROM Prod_Attributes WHERE Id = @Id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Deleted Successfully" : "Product not found");
        }

        public void SearchProductById()
        {
            // Implementation for searching products
            Console.WriteLine("enter id of the product");
            Product_Model mod = new Product_Model();
            mod.Id = Convert.ToInt32(Console.ReadLine());
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string query = "SELECT Id, Name, Category, Price, InStock FROM Prod_Attributes WHERE Id = @Id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", mod.Id);
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                mod.Id = reader.GetInt32(0);
                mod.Name = reader.GetString(1);
                mod.Category = reader.GetString(2);
                mod.Price = (float)reader.GetDouble(3);
                mod.InStock = reader.GetBoolean(4);
                Console.WriteLine($"ID: {mod.Id}, Name: {mod.Name}, Category: {mod.Category}, Price: {mod.Price}, In Stock: {mod.InStock}");

            }
            else
            {
                Console.WriteLine("Product not found.");
            }

        }

        public void SearchProductByName()
        {
            // Implementation for searching products by name
            Console.WriteLine("Enter the name of the product to search:");
            string name = Console.ReadLine();
            Product_Model mod = new Product_Model();
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string query = "SELECT Id, Name, Category, Price, InStock FROM Prod_Attributes WHERE Name LIKE @Name";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", $"%{name}%");
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                mod.Id = reader.GetInt32(0);
                mod.Name = reader.GetString(1);
                mod.Category = reader.GetString(2);
                mod.Price = (float)reader.GetDouble(3);
                mod.InStock = reader.GetBoolean(4);
                Console.WriteLine($"{reader["Id"]}\t{reader["Name"]}\t{reader["Category"]}\t{reader["Price"]}\t{reader["InStock"]}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }
}
