using System;

public class Solution {
    public int solution(int[] citations)
    {
        int answer = 0;
        Array.Sort(citations, (x,y) => y - x);
        for(int i=0;i<citations.Length;++i)
        {
            if(citations[i] <= answer)
                break;
            answer++;                
        }
        return answer;
    }
    //이전 풀이
    public int solution1(int[] citations) {
        int answer = 0;
        int h = 0;
        Array.Sort(citations,(s1,s2) => s2 - s1);
        
        for(int i=0;i<citations.Length;++i)
        {
            if(citations[i] <= answer)
                break;
            answer++;
        }
        
        
        return answer;
    }
}