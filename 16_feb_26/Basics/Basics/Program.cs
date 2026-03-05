using System;
class ArrayProgramm
{
    static void Main(string[] args)
    {
        int[] arr = new int[6] { 5, 3, 8, 9, 0, 7 };
        Array.Sort(arr);
        foreach (int i in arr)
            Console.Write(i + " ");
    }
}
