using System;
using System.Collections.Generic;
public class Solution {
    public int[] solution(int k, int[] score) 
    {
        int[] answer = new int[score.Length];
        int i=0;
        List<int> reward = new List<int>(k);
        
        
        for(;i<k&&i<score.Length;++i)
        {
            reward.Add(score[i]);
            reward.Sort( (x,y) => y-x );
            answer[i] = reward[reward.Count-1];
        }
        
        for(;i<score.Length;++i)
        {
            if(score[i] > reward[reward.Count-1])
            {
                reward.RemoveAt(reward.Count-1);
                reward.Add(score[i]);
            }
            reward.Sort((x,y) => y-x);
            answer[i] = reward[reward.Count-1];
        }
        
        
                
        return answer;
    }
}