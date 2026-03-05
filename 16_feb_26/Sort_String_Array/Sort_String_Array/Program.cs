using System;
class Sort_String_array
{
    public static void Main()
    {
        string[] StringArray = new string[5] { "Csharp", "ASP.net", "entity", "ADO.net", "WCF" };
        Array.Sort(StringArray);

        foreach (string str in StringArray)
        {
            Console.Write(str + " ");
        }
        Console.ReadLine();
    }

}