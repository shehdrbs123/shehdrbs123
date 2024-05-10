public class Program
{
    public static void Main(string[] args)
    {
        int startNum = 1;
        int roomCount = 0;
        int input=0;
        int gap = 6;
        bool find = false;
        input = int.Parse(Console.ReadLine());

        while(!find)
        {
            ++roomCount;
            if(input <= startNum)
                find = true;
            startNum += gap;
            gap += 6;     
        }

        Console.WriteLine(roomCount);
    }
}