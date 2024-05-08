using System;
using System.Collections.Generic;
public class Solution {
    public int[] solution(string[] keymap, string[] targets) {
        int[] answer = new int[targets.Length];
        Dictionary<char,int> numMap = new Dictionary<char,int>();
        
        for(int i=0;i<keymap.Length;++i)
        {
            for(int j=0;j<keymap[i].Length;++j)
            {
                int val;
                if(numMap.TryGetValue(keymap[i][j],out val))
                {
                    if(j+1 < val)
                        numMap[keymap[i][j]] = j+1;
                }else
                {
                    numMap.Add(keymap[i][j],j+1);
                }
            }
        }
        
        
        
        for(int i=0;i<targets.Length;++i)
        {
            for(int j=0;j<targets[i].Length;++j)
            {
                int val;
                if(numMap.TryGetValue(targets[i][j],out val))
                {
                    answer[i] += val;
                }else
                {
                    answer[i] = -1;
                    break;
                }
            }
        }
        
        return answer;
    }
}