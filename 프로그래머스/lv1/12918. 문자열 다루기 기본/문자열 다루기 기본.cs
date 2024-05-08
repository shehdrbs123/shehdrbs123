using System;
using System.Text.RegularExpressions;

public class Solution {
    public bool solution(string s) {
        return solve2(s);
    }
    
    public bool solve2(string s)
    {
        Regex reg = new Regex(@"^[0-9]{4}$|^[0-9]{6}$");
        bool result;
        
        result = reg.IsMatch(s);
        
        return result;
    }
    
    public bool solve1(string s)
    {
        char[] c = s.ToCharArray();
        if(s.Length == 4 || s.Length == 6)
        {
            foreach(char a in c)
            {   
                if( a <'0' || a >'9')
                    return false;
            }
            return true;
        }        
        return false;
    }
}