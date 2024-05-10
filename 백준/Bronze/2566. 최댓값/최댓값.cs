public class Program
{
    public static void Main(string[] args)
    {
        int maxNum = int.MinValue;
        int x=0, y=0;
        string[] inputString;

        for(int i=0;i<9;++i)
        {
            inputString = Console.ReadLine().Split();
            for (int j = 0; j < 9; ++j)
            {
                int val = int.Parse(inputString[j]);
                if(val > maxNum)
                {
                    x = i;
                    y = j;
                    maxNum = val;
                }
            }
        }
        Console.WriteLine(maxNum);
        Console.WriteLine($"{x+1} {y+1}");
    }
}