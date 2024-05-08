using System;
public class Solution {
    public string solution(string[] seoul) {
        string answer = "김서방은 {0}에 있다";
        
        int index = Array.FindIndex(seoul,x => x == "Kim");
        answer = string.Format(answer,index);
        return answer;
    }
}