using System;
using System.Collections.Generic;
public class Solution {
    public string solution(string s) {
        string answer = "";
        string[] splitedString = s.Split(' ');
        SortedSet<int> sortedSet = new SortedSet<int>();
        for(int i=0;i<splitedString.Length;++i)
        {
            int parsedInt = int.Parse(splitedString[i]);
            sortedSet.Add(parsedInt);
        }
        
        answer = sortedSet.Min.ToString() + " " + sortedSet.Max.ToString();
        
        return answer;
    }
    //예전 풀이
    public string solution2(string s) {
        string answer = "";
        string[] splitdata = s.Split(' ');
        int max = Convert.ToInt32(splitdata[0]);
        int min = Convert.ToInt32(splitdata[0]);
        
        for(int i=1; i<splitdata.Length;i++)
        {
            int num = Convert.ToInt32(splitdata[i]);
            max = Math.Max(num,max);
            min = Math.Min(num,min);
        }
        answer = Convert.ToString(min) + " " + Convert.ToString(max) ;
        return answer;
    }
}