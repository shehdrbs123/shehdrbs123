using System;

class Solution
{
    public int solution(int[] nums)
    {
        int answer = 0;
        int length = nums.Length;

        for(int i=0;i<length-2;++i)
        {
            for(int j=i+1;j<length-1;++j)
            {
                for(int k=j+1;k<length;++k)
                {
                    int checkNum = nums[i]+nums[j]+nums[k];
                    if(isPrime(checkNum))
                    {
                        answer+=1;
                    }
                }
            }
        }

        return answer;
    }
    
    private bool isPrime(int num)
    {
        double targetNum = Math.Sqrt(num);
        for(int i=2;i<=targetNum;++i)
        {
            if(num %i == 0)
                return false;
        }
        return true;
    }
}