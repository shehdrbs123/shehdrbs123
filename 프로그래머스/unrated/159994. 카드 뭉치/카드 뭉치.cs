using System;

public class Solution {
    public string solution(string[] cards1, string[] cards2, string[] goal) {
        int j=0,k=0;
        string Result = "Yes";
        for(int i=0;i<goal.Length;++i)
        {
            if(j< cards1.Length && goal[i] == cards1[j])
            {
                j++;
            }else if(k < cards2.Length && goal[i] == cards2[k])
            {
                k++;
            }else
            {
                Result = "No";
                break;
            }
                
        }
        return Result;
    }
}