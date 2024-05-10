public class Program
{
    public static void Main(string[] args)
    {
        int[] coins = {25,10,5,1};
        int inputCount=0;
        int inputNum=0;
        
        inputCount = int.Parse(Console.ReadLine());
        
        for(int i=0;i<inputCount;++i)
        {
            int[] coinCount = new int[coins.Length];
            inputNum = int.Parse(Console.ReadLine());
            for(int j=0;j<coins.Length;++j)
            {
                coinCount[j] = inputNum/coins[j];
                inputNum = inputNum%coins[j];
            }
            
            foreach(var coin in coinCount)
            {
                Console.Write($"{coin} ");
            }
            Console.WriteLine();
        }
    }
}