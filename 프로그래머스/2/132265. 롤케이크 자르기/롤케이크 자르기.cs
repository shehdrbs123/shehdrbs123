using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] topping) {
        int answer = 0;
        Dictionary<int,int> leftCounter = new Dictionary<int,int>();
        Dictionary<int,int> rightCounter = new Dictionary<int,int>();
        
        for(int i=0;i<topping.Length;++i)
        {
            if(rightCounter.TryGetValue(topping[i],out int value))
            {
                rightCounter[topping[i]] = value+1;
            }else
            {
                rightCounter.Add(topping[i],1);
            }
        }
        
        for(int i=0;i<topping.Length;++i)
        {
            if(leftCounter.TryGetValue(topping[i],out int value))
            {
                leftCounter[topping[i]] = value+1;
            }else
            {
                leftCounter.Add(topping[i],1);
            }
            
            int num = rightCounter[topping[i]];
            num -= 1;
            if(num == 0)
                rightCounter.Remove(topping[i]);
            else
                rightCounter[topping[i]] = num;
            
            
            if(leftCounter.Count == rightCounter.Count)
            {
                answer++;
            }
                
        }
        
        return answer;
    }
}