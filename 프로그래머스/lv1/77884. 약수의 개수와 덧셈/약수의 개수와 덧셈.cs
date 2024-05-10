using System;

public class Solution {
    public int solution(int left, int right) {
        int answer = 0;
        
        for(int i = left; i<=right;++i)
        {
            int count = GetDivisorCount(i);
            if(count %2 == 0)
                answer += i;
            else
                answer -= i;
        }
        return answer;
    }
    
    public int GetDivisorCount(int target)
    {
        int sqrtTarget = (int)Math.Sqrt(target);
        int count=0;
        for(int i=1;i<=sqrtTarget;++i)
        {
            if(target % i == 0)
            {
                if(i != target/i)
                    ++count;
                ++count;
            }
        }
        
        return count;
    }
}