using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] arr, int divisor) {
        List<int> answer = new List<int>(arr.Length);
        
        for(int i=0;i<arr.Length;++i)
        {
            if(arr[i]%divisor == 0)
                answer.Add(arr[i]);
        }
        
        if(answer.Count == 0)
            answer.Add(-1);
        
        answer.Sort();
        
        return answer.ToArray();    
    }
}