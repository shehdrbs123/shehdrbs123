using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    public int solution(int k, int[] tangerine) {
        int answer = 0;
        Dictionary<int,int> tangerineCount = new Dictionary<int,int>();
        
        for(int i=0;i<tangerine.Length;++i)
        {
            int count = 0;
            if(tangerineCount.TryGetValue(tangerine[i],out count))
            {
                count+=1;
                tangerineCount[tangerine[i]] = count;
            }else
            {
                tangerineCount.Add(tangerine[i],1);
            }
        }
        
        var list = tangerineCount.Values.OrderByDescending(x => x).ToArray();
        int sum = 0;
        answer = 1;
        foreach(var val in list)
        {
            //Console.WriteLine(val);
            if(k > sum + val)
            {
                sum += val;
                answer++;
            }
            else
                break;
        }
        
        return answer;
    }
}