using System;
public class Solution {
    public string[] solution(string[] strings, int n) {
        
        Array.Sort(strings,(x,y)=>{
            char a = x[n];
            char b = y[n];
            
            if(a==b)
            {
                return x.CompareTo(y);
            }
            return a-b;
        });
        
        return strings;
    }
}