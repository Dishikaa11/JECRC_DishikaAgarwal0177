using System;

class SwitchSelect
{

    public static void Main()
    {
        string myInput;
        int myInt;

    begin:

        Console.Write("Eneter the nu. bw 1 to 3 : ");
        myInput = Console.ReadLine();
        myInt = Int32.Parse(myInput);

        switch (myInt)
        {

            case 1:
                Console.WriteLine("Your number is {0}.", myInt);
                break;

            case 2:
                Console.WriteLine("Your number is {0}.", myInt);
                break;

            case 3:
                Console.WriteLine("Your number is {0}.", myInt);
                break;

            default:
                Console.WriteLine("Your number is {0} is not bw 1 and 3.", myInt);
                break;

        }

    }
}