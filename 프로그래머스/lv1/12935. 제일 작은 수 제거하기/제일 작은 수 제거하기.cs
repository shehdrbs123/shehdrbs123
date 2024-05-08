using System.Collections.Generic;
public class Solution {
    public int[] solution(int[] arr) {
        List<int> answer = new List<int>(arr.Length-1);
        int minIdx = 0;
        for(int i=1;i<arr.Length;++i)
        {
            if(arr[minIdx] > arr[i])
                minIdx = i;
        }
        
        
        for(int i=0;i<arr.Length;++i)
        {
            if(minIdx == i)
                continue;
            answer.Add(arr[i]);
        }
        
        if(answer.Count == 0)
            answer.Add(-1);
        
        return answer.ToArray();
    }
}