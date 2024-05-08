using System;
public class Solution {
    public long solution(long n) {
        long answer = 0;
        
        
        //제곱근 판별 방법
        long data = (long)Math.Sqrt(n);
        
        if(data*data == n)
        {
            data+=1;
            answer = data*data;
        }else
            answer = -1;
            
        
        return answer;
    }
}