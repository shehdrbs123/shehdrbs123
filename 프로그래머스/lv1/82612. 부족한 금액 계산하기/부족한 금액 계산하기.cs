using System;

class Solution
{
    public long solution(int price, int money, int count)
    {
        long result=0;
        long needMoney=0;
        
        for(int i=1;i<=count;++i)
        {
            needMoney += price*i;
        }
        
        result = money-needMoney;
        if(result < 0)
            result *= -1;
        else
            result = 0;
        return result;
    }
}