using System;
public class Solution {
    public string solution(string s) {
        string answer = "";
        char[] charArr = s.ToCharArray();
        
        Array.Sort(charArr, (x,y) => y.CompareTo(x));
        
        answer = new string(charArr);
        return answer;
    }
}