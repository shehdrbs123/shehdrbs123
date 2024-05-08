using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string[,] clothes)
    {
        int answer = 1;
        Dictionary<string,int> dicCount = new Dictionary<string,int>();
        for(int i=0;i<clothes.GetLength(0);++i)
        {
            if(dicCount.TryGetValue(clothes[i,1],out int num))
            {
                num += 1;
                dicCount[clothes[i,1]] = num;
            }else
            {
                dicCount.Add(clothes[i,1],1);
            }
        }
        
        // 각각의 없는 경우를 하나씩 추가한 후 
        // 곱하게 되면 모든 경우의 수가 나오게됨.
        // 거기서 아무것도 입지 않는 공집합을 빼면
        // 입는 모든 경우가 나오는것임
        foreach(int a in dicCount.Values)
        {
            answer *= a+1;
        }
        answer -= 1;
        
        
        return answer;
    }
    
    
    //이전 풀이
    public int solution1(string[,] clothes) {
        int answer = 1;
        Dictionary<string,int> clothesDic = new Dictionary<string,int>();

        for(int i=0;i<clothes.Length/2;++i)
        {
            if(!clothesDic.ContainsKey(clothes[i,1]))
            {
                clothesDic.Add(clothes[i,1],0);
            }            
            ++clothesDic[clothes[i,1]];
        }
        
        foreach(var val in clothesDic.Values)
        {
            answer *= val+1;
        }
        answer -= 1;
        
        return answer;
    }
    
}