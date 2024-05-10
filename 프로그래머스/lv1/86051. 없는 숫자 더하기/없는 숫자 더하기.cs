using System;

public class Solution {
    public int solution(int[] numbers) {
        int answer = 0;
        int currentCheckNum=0;
        int i=0;
        Array.Sort(numbers);
        
        while(currentCheckNum <= 9)
        {
            if(currentCheckNum != numbers[i])
            {
                answer += currentCheckNum;
            }else
            {
                i = Math.Clamp(i+1,0,numbers.Length-1);
            }
            ++currentCheckNum;
        }
        
        return answer;
    }
}