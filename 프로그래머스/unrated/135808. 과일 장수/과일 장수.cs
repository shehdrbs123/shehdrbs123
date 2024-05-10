using System;

public class Solution {
    public int solution(int k, int m, int[] score) {
        int answer = 0;
        
        Array.Sort(score,(x,y)=> x-y);
        
        //Array.ForEach(score, x => Console.WriteLine(x) );
                   
        for(int i=score.Length-1;i>=m-1;i-=m)
        {
            answer += score[i-m+1] * m;
        }
        return answer;
    }
}