using System;

namespace Agreegate
{
    class AgreegateData
    {
        public void Addition(int a, int b)
        {
            int c = a + b;
            Console.WriteLine("Addition: " + c);
        }

        public void Subtraction(int a, int b)
        {
            int c = a - b;
            Console.WriteLine("Subtraction: " + c);
        }

        public void Multiplication(int a, int b)
        {
            int c = a * b;
            Console.WriteLine("Multiplication: " + c);
        }

        public void Division(int a, int b)
        {
            if (b != 0)
            {
                int c = a / b;
                Console.WriteLine("Division: " + c);
            }
            else
            {
                Console.WriteLine("Cannot divide by zero");
            }
        }
    }

    class ODLExercise
    {
        public static void Main()
        {
            Console.WriteLine("Enter first number: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number: ");
            int b = Convert.ToInt32(Console.ReadLine());

            AgreegateData data = new AgreegateData();

            data.Addition(a, b);
            data.Subtraction(a, b);
            data.Multiplication(a, b);
            data.Division(a, b);

            Console.ReadLine();
        }
    }
}



