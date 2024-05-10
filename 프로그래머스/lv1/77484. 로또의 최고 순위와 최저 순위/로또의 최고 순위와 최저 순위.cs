using System;

public class Solution {
    public int[] solution(int[] lottos, int[] win_nums) {
        int[] answer = new int[] {0,0};
        int rightNum=0;
        int empty=0;
        for(int i=0;i<lottos.Length;++i)
        {
            if(Array.Find(win_nums,(x) => x == lottos[i]) != 0)
                rightNum++;
            if(lottos[i] == 0)
                empty++;
        }
            
        answer[0] = Math.Clamp(6-(rightNum+empty)+1,1,6);
        answer[1] = Math.Clamp(6-rightNum+1,1,6);
       
        
        return answer;
    }
}