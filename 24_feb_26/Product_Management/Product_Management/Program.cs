using Product_Management;
using System;

namespace Product_Management
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product_Service service = new Product_Service();
            service.Run();
        }
    }
}
