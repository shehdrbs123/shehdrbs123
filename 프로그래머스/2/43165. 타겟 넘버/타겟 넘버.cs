using System;

public class Solution {
    int[] numbers;
    int target;
    int answer;
    public int solution(int[] numbers, int target) {
        this.numbers = numbers;
        this.target = target;
        this.answer = 0;
        DFS(0,0);
        return answer;
    }
    
    private void DFS(int idx, int result)
    {
        if(idx == numbers.Length)
        {
            if(result == target)
                answer+=1;
            return;
        }
        
        DFS(idx+1,result-numbers[idx]);
        DFS(idx+1,result+numbers[idx]);
    }
}