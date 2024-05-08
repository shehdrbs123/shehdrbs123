using System;
using System.Collections.Generic;
public class Solution {
    public int[] solution(string s) {
        int[] answer = new int[s.Length];
        Dictionary<char,int> charPos = new Dictionary<char,int>();
        
        for(int i=0;i<s.Length;++i)
        {
            char currentChar = s[i];
            int val;
            if(charPos.TryGetValue(currentChar,out val))
            {
                int pos = val;
                answer[i] = i-pos;
                charPos[currentChar] = i;
            }
            else
            {
                answer[i] = -1;
                charPos.Add(currentChar,i);
            }
        }
        
        
        return answer;
    }
    
    public int[] solve1(string s)
    {
        int[] answer = new int[s.Length];
        Dictionary<char,int> charCheckDic = new Dictionary<char,int>();
        
        for(int i=0;i<s.Length;i++)
        {
            char one = s[i];
            int pos = -1;
            if(charCheckDic.TryGetValue(one,out pos))
            {
                answer[i] = i - pos;
                charCheckDic[one] = i;   
            }
            else
            {
                answer[i] = -1;
                charCheckDic.Add(one,i);
            }
        }
        
        return answer;
    }
}