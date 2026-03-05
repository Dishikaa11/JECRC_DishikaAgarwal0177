using System;

namespace OrderProcessingDemo
{
    
    abstract class OrderProcessor
    {
        
        public int OrderId { get; set; }
        public double Amount { get; set; }

        
        public abstract void ProcessPayment();
        public abstract void GenerateInvoice();
        public abstract void SendNotification();

        
        public void DisplayOrderDetails()
        {
            Console.WriteLine("Order Details:");
            Console.WriteLine("Order ID: " + OrderId);
            Console.WriteLine("Amount: " + Amount);
        }
    }

    
    class OnlineOrder : OrderProcessor
    {
        

        public override void ProcessPayment()
        {
            Console.WriteLine("Processing online payment...");
            Console.WriteLine("Payment Successful via Credit/Debit Card.");
        }

        public override void GenerateInvoice()
        {
            Console.WriteLine("Generating digital invoice (PDF).");
        }

        public override void SendNotification()
        {
            Console.WriteLine("Sending confirmation email to customer.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            OrderProcessor order = new OnlineOrder();

            
            order.OrderId = 101;
            order.Amount = 2500.75;

            
            order.DisplayOrderDetails();
            order.ProcessPayment();
            order.GenerateInvoice();
            order.SendNotification();

            Console.ReadLine();
        }
    }
}
