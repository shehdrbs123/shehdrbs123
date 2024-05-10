using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int n, int m, int[] section) {
        int answer = 1;
        
        int start = section[0];
        int end = start+m;
        
        for(int i=0;i<section.Length;++i)
        {
            if(start>section[i] || section[i] < end)
                continue;
            else
            {
                start = section[i];
                end = start+m;
                answer++;
            }
        }
        return answer;
    }
}