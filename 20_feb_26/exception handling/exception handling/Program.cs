//using System;
//class ExcDemo1
//{
//    public static void Main()
//    {
//        int[] nums = new int[4];
//        try
//        {
//            Console.WriteLine("Before exception is generated.");
//            for (int i = 0; i < 10; i++)
//            {
//                nums[i] = i;
//                Console.WriteLine("nums[{0}] = {1}", i, nums[i]);
//            }
//            Console.WriteLine("This won't be displayed.");

//        }
//        catch (IndexOutOfRangeException)
//        {
//            Console.WriteLine("Index out-of-bounds!");
//        }
//        Console.WriteLine("After catch Statement");
//    }
//}


//-----------using multiple catch staements-----------------

using System;
class ExcDemo4
{
    public static void Main()
    {
        int[] number = { 4, 8, 16, 32, 64, 128, 256, 512 };
        int[] denum = { 2, 0, 4, 8, 0 };
        for (int i = 0; i < number.Length; i++)
        {
            try
            {
                Console.WriteLine(number[i] + " / " + denum[i] + " is " + number[i] / denum[i]);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Can't divide by Zero!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No matching element found.");
            }
        }
    }

}