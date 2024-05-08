using System;
public class Solution {
    public string solution(int a, int b) {
        string answer = "";
        DateTime date = new DateTime(2016,a,b);
        
        string DayOfWeek = date.DayOfWeek.ToString();
        DayOfWeek = DayOfWeek.ToUpper().Substring(0,3);
        
        return DayOfWeek;
    }
}