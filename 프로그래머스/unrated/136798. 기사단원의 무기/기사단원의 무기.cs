using System;

public class Solution {
    public int solution(int number, int limit, int power) {
        int answer = 0;
        
        for(int i=1;i<=number;++i)
        {
            int weapon = GetCommonCount(i);
            if(weapon > limit)
                weapon = power;
            answer += weapon;
        }
        return answer;
    }
    
    public int GetCommonCount(int num)
    {
        int tmp = (int)Math.Sqrt(num);
        int count = 0;
        for(int i=1;i<=tmp;++i)
        {
            if(num%i == 0)
            {
                count++;
                if(i!=num/i)
                    count++;
            }
        }
        return count;
    }
}