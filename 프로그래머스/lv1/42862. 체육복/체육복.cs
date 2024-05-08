using System;
using System.Collections.Generic;
public class Solution {
    public int solution(int n, int[] lost, int[] reserve) {
        int answer = 0;
        int lostCount = 0;
        HashSet<int> reserves = new HashSet<int>();
        HashSet<int> losts = new HashSet<int>();
        for(int i=0;i<reserve.Length;++i)
        {
            reserves.Add(reserve[i]);
        }
        
        foreach(var a in lost)
        {
            losts.Add(a);
        }
        Array.Sort(lost);
        for(int i=0;i<lost.Length;++i)
        {
            int num = lost[i];
            if(reserves.Contains(num))
            {
                reserves.Remove(num);
                losts.Remove(num);
            }else if(reserves.Contains(num-1)&& !losts.Contains(num-1))
            {
                reserves.Remove(num-1);
                losts.Remove(num-1);
            }else if(reserves.Contains(num+1) && !losts.Contains(num+1))
            {
                reserves.Remove(num+1);
                losts.Remove(num+1);
            }else
            {
                ++lostCount;
            }
        }
        
        answer = n-lostCount;
    
        return answer;
    }
}