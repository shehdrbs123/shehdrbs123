public class Program
{
    public static void Main(string[] args)
    {
        int x;
        int y;
        string[] inputString;
        int[,] result;
        
        inputString = Console.ReadLine().Split();
        
        x = int.Parse(inputString[0]);
        y = int.Parse(inputString[1]);

        result = new int[x, y];
        
        for(int i=0;i<x;++i)
        {
            inputString = Console.ReadLine().Split();
            for(int j=0;j<y;j++)
            {
                result[i,j] = int.Parse(inputString[j]);    
            }
        }
        
        for(int i=0;i<x;++i)
        {
            inputString = Console.ReadLine().Split();
            for(int j=0;j<y;j++)
            {
                result[i,j] += int.Parse(inputString[j]);    
            }
        }
        
        for(int i=0;i<x;++i)
        {
            for(int j=0;j<y;j++)
            {
                Console.Write($"{result[i,j]} ");
            }
            Console.WriteLine();
        }
    }
}