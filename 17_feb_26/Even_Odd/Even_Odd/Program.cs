using System;
class Program
{
    static bool CheckEvenOdd(int a, int b)
    {
        if ((a % 2 == 0 && b % 2 == 0) ||
            (a % 2 != 0 && b % 2 != 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static void Main()
    {
        Console.WriteLine("Enter first number:");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        int num2 = Convert.ToInt32(Console.ReadLine());

        bool result = CheckEvenOdd(num1, num2);

        Console.WriteLine(result);
        Console.ReadLine();
    }
}