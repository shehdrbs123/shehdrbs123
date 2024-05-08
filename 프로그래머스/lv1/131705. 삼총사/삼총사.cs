using System;

public class Solution {
    public int solution(int[] number) {
        int answer = 0;
        for(int i=0;i<number.Length-2;++i)
        {
            for(int j=i+1;j<number.Length-1;++j)
            {
                for(int k=j+1; k<number.Length; ++k)
                {
                    int isTripple = number[i] + number[j] + number[k];
                    if(isTripple == 0)
                        answer +=1;
                }
            }
        }
        return answer;
    }
}