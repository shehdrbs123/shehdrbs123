public class Program
{
    public static void Main(string[] args)
    {
        string inputStr;
        while(true)
        {
            string[] splitString;
            int src=0,dst=0;
            inputStr = Console.ReadLine();
            if(inputStr =="0 0")
                break;
            
            splitString = inputStr.Split();
            
            src = int.Parse(splitString[0]);
            dst = int.Parse(splitString[1]);
            
            if(src%dst == 0)
                Console.WriteLine("multiple");
            else if(dst % src == 0)
                Console.WriteLine("factor");
            else
                Console.WriteLine("neither");
        }
    }
}