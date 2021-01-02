using System;

public static class HelperClass
{
    public static void PrintAllLines(string[] lines)
    {
        foreach(string line in lines) 
        {
            Console.WriteLine(line);
        }
    }
}
