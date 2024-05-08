public class Solution {
    public string solution(string s) {
        string answer = "";
        int halfPos = (int)(s.Length*0.5f);
        
        if(s.Length % 2 == 1)
            answer = s.Substring(halfPos,1);
        else
            answer = s.Substring(halfPos-1,2);
        
        
        return answer;
    }
}