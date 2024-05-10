public class Program
{
    public static void Main(string[] args)
    {
        string[] inputString;
        int arithmetic;
        long result=0;
        string target;
        int isSign= 1;
        int digit = 0;

        inputString = Console.ReadLine().Split();
        target = inputString[0];
        arithmetic = int.Parse(inputString[1]);
        // ㅈ
        for(int i=target.Length-1;i>=0;--i)
        {
            if (target[i] == '-')
            {
                isSign = -1;
                continue;
            }
                
            int num=0;
            if('0'<=target[i] && target[i] <= '9')
            {
                num = target[i]-'0';
            }else
            {
                num = target[i]-'A'+10;
            }
            result += num*(int)Math.Pow(arithmetic,digit);
            ++digit;
        }

        result *= isSign;
        Console.WriteLine(result);
    }
}