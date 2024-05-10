using System;
public class Solution {
    public long solution(long n) {
        long answer = 0;
        char[] tmp;

        tmp = n.ToString().ToCharArray();
        
        Array.Sort(tmp,(x,y) => y.CompareTo(x));
        
        
        answer = long.Parse(tmp);
        
        return answer;
    }
}