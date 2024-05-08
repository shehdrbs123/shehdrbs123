using System;
using System.Text;
using System.Collections.Generic;
public class Solution {
    public int solution(string s) {
        int answer = 0;
        int currentChar = s[0];
        int charCount=1;
        int otherCount=0;
        List<string> splitedString = new List<string>(1000);
        
        StringBuilder sb = new StringBuilder(10000);
        
        for(int i=1;i<s.Length-1;++i)
        {
            if(currentChar == s[i])
                charCount++;
            else
                otherCount++;
            if(otherCount == charCount)
            {
                otherCount = 0;
                charCount = 1;
                currentChar = s[i+1];
                splitedString.Add(sb.ToString());
                sb.Clear();
                i+=1;
            }
        }
        splitedString.Add(sb.ToString());
        answer = splitedString.Count;
        return answer;
    }
}