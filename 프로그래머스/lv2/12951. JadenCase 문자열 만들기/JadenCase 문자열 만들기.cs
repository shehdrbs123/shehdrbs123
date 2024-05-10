using System;
using System.Text;
public class Solution {
    public string solution(string s)
    {
        char[] makeJadenCase = s.ToCharArray();
        const char gap = (char)('a' - 'A');
        bool isFirst = true;
        for(int i=0;i<makeJadenCase.Length;++i)
        {
            char make = makeJadenCase[i];
            
            if(make == ' ')
            {
                isFirst = true;
            }else
            {
                if(isFirst)
                {
                    if('a' <=make &&make <= 'z')
                        make -= gap;
                    isFirst = false;
                }else
                {
                    if('A' <=make && make <= 'Z')
                        make += gap;
                }   
            }
            makeJadenCase[i] = make;
        }
        
                
        return new String(makeJadenCase);
    }
    //예전 풀이
    public string solution1(string s) {
        char[] c1;
        bool isFirst = true;
        int gap = 'a'-'A';
        c1 = s.ToCharArray();
        
        
        
        for(int i=0;i<c1.Length;i++)
        {
            if(c1[i] == ' ')
                isFirst=true;
            else if(isFirst)
            {
                if( c1[i] >= 'a' && c1[i] <= 'z')
                {
                    c1[i] -= (char)gap;               
                }
                isFirst=false;     
            }else
            {
                if(c1[i] >= 'A' && c1[i]<='Z')
                {
                    c1[i] += (char)gap;
                }
            }
        }
                
        
        
        return new string(c1);
    }
}