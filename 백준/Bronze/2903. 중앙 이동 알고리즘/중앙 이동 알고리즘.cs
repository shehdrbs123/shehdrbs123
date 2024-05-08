using System;
public class Program
{
    public static void Main(string[] args)
    {
        uint input;
        uint result=0;
        
        input = uint.Parse(Console.ReadLine());
        
        result = (uint)Math.Pow(Math.Pow(2,input)+1,2);
        Console.Write(result);
    }
}