using System;

public class Solution {
    public int[] solution(int[] sequence, int k) {
        int[] answer = new int[2]{0,sequence.Length};
        int start=0;
        int end=0;
        int sum = sequence[0];
        while(end < sequence.Length && start<sequence.Length)
        {
            //Console.WriteLine($"{sum} {start} {end}");
            if(sum == k)
            {
                //Console.WriteLine("gotcha");
                if(answer[1] - answer[0] > end - start)
                {
                    answer[1] = end;
                    answer[0] = start;
                }
                sum -= sequence[start];
                ++start;
                ++end;
                if(end < sequence.Length)
                    sum += sequence[end];
                else
                    break;
            }else if (sum < k)
            {
                ++end;
                if(end < sequence.Length)
                    sum += sequence[end];
                else
                    break;
                
            }else
            {
                sum -= sequence[start];
                ++start;
            }
        }
        
        while(start<end)
        {
            //Console.WriteLine($"{sum} {start} {end}");
            if(sum == k)
            {
                Console.WriteLine("gotcha");
                if(answer[1] - answer[0] > end - start)
                {
                    answer[1] = end;
                    answer[0] = start;
                }
            }
            sum -= sequence[start];
            ++start;
        }
        
        return answer;
    }
}