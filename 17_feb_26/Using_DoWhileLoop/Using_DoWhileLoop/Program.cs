using System;

class sampledowhile
{
    public static void Main()
    {
        int a = 4;
        do
        {
            Console.WriteLine(a);
        } while (a < 3);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter 3 letters:");
        string input = Console.ReadLine();

        if (input.Length == 3)
        {
            char[] arr = input.ToCharArray();
            Array.Reverse(arr);
            string reversed = new string(arr);

            Console.WriteLine("Reversed letters: " + reversed);
        }
        else
        {
            Console.WriteLine("Please enter exactly 3 letters.");
        }
    }
}