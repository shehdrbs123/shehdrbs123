using System;
using System.Collections.Generic;
public class Solution {
    public int solution(int n, int k) {
        int answer = 0;
        int temp = n;
        List<int> changed = new List<int>(100);
        List<int> numberChecker = new List<int>(20);
        long decima =0;
        //진법 가공
        while(temp>=1)
        {
            int rest = temp % k;
            temp = temp / k;
            changed.Add(rest);
        }
        
        changed.Reverse();
        //changed.ForEach(x=>Console.Write(x));
        //Console.WriteLine();
        // 숫자 리스트 추가
        
        
        for(int i=0;i<changed.Count;++i)
        {
            if(changed[i] == 0)
            {
                decima = GetBaseNum(10,numberChecker);
                //Console.WriteLine(decima);
                
                if(isPrime(decima))
                    ++answer;
                numberChecker.Clear();
            }
            else
            {
                 numberChecker.Add(changed[i]);
            }
        }

        decima = GetBaseNum(10,numberChecker);
        if(isPrime(decima))
            ++answer;   

        
        return answer;
    }
    
    private long GetBaseNum(long k, List<int> numberChecker)
    {
        long decima=0;
        long numCount=0;
        for(int j=numberChecker.Count-1; j>=0; --j)
        {
            decima += numberChecker[j]*(long)Math.Pow(k,numCount);
            numCount+=1;
        }
        return decima;
    }
    
    private bool isPrime(long num)
    {
        if(num <=1)
            return false;
        long targetNum = (int)Math.Sqrt(num);
        long b = 2;
        
        while(b<=targetNum)
        {
            if(num%b == 0)
                return false;
            b++;
        }
        return true;
    }
    
}