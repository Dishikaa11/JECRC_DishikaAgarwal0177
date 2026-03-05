using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptionExampleCode
{
    class MyException : Exception
    {
        public MyException(string message) : base(message) { }
        public MyException() { }
        public MyException(string message, Exception inner) : base(message, inner) { }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int a = 50;
            int b = 10;
            int k = a / b;
            try
            {
                if (k < 10)
                {
                    throw new MyException("value of k is less than 10");
                }
            }
            catch (MyException e)
            {
                Console.WriteLine($"Caught MyException: {e.Message}");
            }
            Console.ReadLine();
        }
    }
}