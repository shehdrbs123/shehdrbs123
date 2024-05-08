using System;
using System.Collections.Generic;
public class Solution {
    public int[] solution(int[] answers) {
        
        int[][] idiot = new int[3][] {
            new int[]{1,2,3,4,5},
            new int[]{2,1,2,3,2,4,2,5},
            new int[]{3,3,1,1,2,2,4,4,5,5}
        };
        int[] result = new int[]{0,0,0};
        List<int> answer = new List<int>(3);
        
        for(int i=0;i<idiot.GetLength(0);++i)
        {
            for(int j=0;j<answers.Length;++j)
            {
                int idiotIdx = j%idiot[i].Length;
                if(answers[j]==idiot[i][idiotIdx])
                    result[i]+=1;
            }
        }
        int max = result[0];
        for(int i=1;i<3;++i)
        {
            max = Math.Max(max,result[i]);
        }
        
        for(int i=0;i<3;++i)
        {
            if(max == result[i])
                answer.Add(i+1);
        }
        
        return answer.ToArray();
    }
}