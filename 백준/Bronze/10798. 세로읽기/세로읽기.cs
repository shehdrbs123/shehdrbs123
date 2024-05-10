using System.Text;
public class Program
{
    public static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        sb.Capacity = 5*15;
        string[] strings = new string[5];
        int maxLength = int.MinValue;
        for(int i=0;i<5;++i)
        {
            strings[i] = Console.ReadLine();
            maxLength = Math.Max(maxLength, strings[i].Length);
        }

        int j = 0;
        for(int i=0;i<maxLength;++i)
        {
            for(j=0;j<5;j++)
            {
                if(strings[j].Length > i)
                    sb.Append(strings[j][i]);
            }
        }
        Console.WriteLine(sb.ToString());
    }
}