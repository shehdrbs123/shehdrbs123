public class Program
{
    public static void Main(string[] args)
    {
        int[,] board;
        int inputCount;
        string[] inputString;
        
        board = new int[100,100];
        inputCount = int.Parse(Console.ReadLine());
        
        for(int i=0;i<inputCount;++i)
        {
            int left;
            int bottom;
            
            inputString = Console.ReadLine().Split();
            left = int.Parse(inputString[0]);
            bottom = int.Parse(inputString[1]);
            
            for(int j=left;j<left+10;++j)
            {
                for(int k=bottom;k<bottom+10;++k)
                {
                    board[j,k] = 1;
                }
            }
            
        }

        int result = 0;
        foreach (var i in board)
        {
            result += i;
        }
        Console.WriteLine(result);
    }
}