using System;
using System.Text;
public class Solution {
    public int solution(int n) {
        StringBuilder sb = new StringBuilder(200);
        int answer = 0;
        int tmpN = n;
        int rest = 0;
        int restoreTens = 0;
        
        while(tmpN>=1)
        {
            rest = tmpN%3;
            tmpN /= 3;
            sb.Append(rest);
        }
        char[] changed = sb.ToString().ToCharArray();
        Array.Reverse(changed);
        
        for(int i=0;i<changed.Length;++i)
        {
            int value = (int)Math.Pow(3,i)*(changed[i]-'0');
            answer += value;
        }
        
        
        return answer;
    }
}