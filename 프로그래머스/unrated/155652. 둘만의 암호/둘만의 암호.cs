using System;
using System.Text;
public class Solution {
    public string solution(string s, string skip, int index) {
        string answer = "";
        StringBuilder sb = new StringBuilder(50);
        for(int i=0;i<s.Length;++i)
        {
            sb.Append(ChangeChar(s[i],skip,index));
        }
        
        answer= sb.ToString();
        return answer;
    }
    
    private char ChangeChar(char s, string skip, int idx)
    {
        int tmp=s-'a';
        for(int i=0;i<idx;++i)
        {
            tmp = (tmp+1)%26;
            if(skip.Contains((char)(tmp+'a')))
                --i;
        }
        tmp += 'a';
        return (char)tmp;
    }
}