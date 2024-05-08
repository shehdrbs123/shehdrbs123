using System;

class Solution
{
    public int solution(int n, int a, int b)
    {
        int answer = 1;
        while(n>1)
        {
            if(a%2 != 0)
            {
                if(a+1 == b)
                    break;
                a = (a+1)/2;    
            }
            else
            {
                if(a-1 == b)
                    break;
                a /= 2;
            }
            
            if(b%2 != 0)
            {
                b = (b+1)/2;
            }                
            else
            {
                b /= 2;
            }
            
            ++answer;
            n/=2;
        }

        return answer;
    }
}