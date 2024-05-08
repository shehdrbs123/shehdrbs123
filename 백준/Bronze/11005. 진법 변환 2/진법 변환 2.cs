using System;
using System.Text;
public class Program
{
    public static void Main(string[] args)
    {
        int arithmetic;
        int startNum;
        string[] inputString;
        StringBuilder sb = new StringBuilder();
        string isSign = "";
        sb.Capacity = 100;
        
        
        inputString = Console.ReadLine().Split();
        
        startNum = int.Parse(inputString[0]);
        arithmetic = int.Parse(inputString[1]);
        
        if(startNum<0)
        {
            isSign = "-";
        }
        
        while(startNum >= 1)
        {
            int digitNum = startNum % arithmetic;
            startNum = startNum/arithmetic;
            char charNum;
            if(digitNum >= 10)
            {
                charNum = (char)(digitNum +'A'-10);
            }else
            {
                charNum = (char)(digitNum + '0');
            }
            sb.Append(charNum);
        }
        
        char[] result = sb.ToString().ToCharArray();
        Array.Reverse(result);
        Console.WriteLine(new String(result));
    }
}