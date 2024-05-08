using System;
using System.Text;

public class Solution {
    public int solution(string s) 
    {
        int answer = 0;
        string tmpS = s.ToLower();
       
        for(int i=0;i<=9;++i)
        {
            string stringNum = GetStringNum(i);
            tmpS = tmpS.Replace(stringNum,i.ToString());
        }
                
        answer = int.Parse(tmpS);
        return answer;
    }
    
    public string GetStringNum(int x)
    {
        switch(x)
        {
            case 1:
                return "one";
                break;
            case 2:
                return "two";
                break;
            case 3:
                return "three";
                break;
            case 4:
                return "four";
                break;
            case 5:
                return "five";
                break;
            case 6:
                return "six";
                break;
            case 7:
                return "seven";
                break;
            case 8:
                return "eight";
                break;
            case 9:
                return "nine";
                break;
        }
        return "zero";
    }
}