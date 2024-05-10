using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] progresses, int[] speeds) {
        List<int> answer = new List<int>(100);
        int previousDay=-1;
        for(int i=0;i<progresses.Length;++i)
        {
            int restJob = 100-progresses[i];
            int restDay = (int)Math.Ceiling(restJob/(double)speeds[i]);
            if(restDay > previousDay)
            {
                previousDay = restDay;
                answer.Add(1);
            }
            else
            {
                answer[answer.Count-1]+=1;
            }
        }
        return answer.ToArray();
    }
}