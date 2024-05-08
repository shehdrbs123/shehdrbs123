using System;

public class Solution {
    public int[] solution(int n, long left, long right) {
        int[] answer = new int[right-left+1];
        long answerIdx = 0;
        long idx = 0;
        for(long i=left;i<=right;++i)
        {
            long row = i%n;
            long height = i/n;
            int num = (int)Math.Max(row+1,height+1);
            answer[answerIdx] = num;
            ++answerIdx;
        }
        
        return answer;
    }
}