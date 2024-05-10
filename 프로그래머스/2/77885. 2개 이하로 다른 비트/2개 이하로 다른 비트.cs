using System;
using System.Collections.Generic;
public class Solution {
    public long[] solution(long[] numbers) {
        long[] answer = new long[numbers.Length];
        
        for(int i=0;i<numbers.Length;++i)
        {
            if(numbers[i]%2 == 0)
            {
                answer[i] = numbers[i]+1;
            }
            else
            {
                int count = 0;
                long num = numbers[i];
                long defaultNum =  numbers[i];
                while(num >=1)
                {
                    long rest = num % 2;
                    if(rest == 0)
                        break;
                    num /= 2;
                    count++;
                }
                defaultNum -=(long)Math.Pow(2,count-1);
                defaultNum +=(long)Math.Pow(2,count);
                
                answer[i] = defaultNum;
            }
        }
        
        return answer;
    }
}