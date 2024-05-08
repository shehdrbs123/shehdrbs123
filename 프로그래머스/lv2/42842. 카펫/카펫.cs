using System;

public class Solution {
    public int[] solution(int brown, int yellow) {
        int[] answer = new int[2];
        int total = brown + yellow;
        int x = brown/2-1;
        int y = 1;
       
        while(total != x*(y+2) )
        {
            --x;
            ++y;
        }
        answer[0] = x;
        answer[1] = y+2;
        return answer;
    }
}