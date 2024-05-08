using System.Text;
using System;
public class Solution {
    public string solution(string s) {
        string answer = "";
        string[] splitStrings = s.Split();
        StringBuilder sb = new StringBuilder(100);
        
        for(int i=0;i<splitStrings.Length;++i)
        {
            char[] data = splitStrings[i].ToCharArray();
            
            for(int j=0; j<data.Length;++j)
            {
                if(j%2 == 0)
                {
                    if('a'<= data[j] && data[j]<= 'z')
                    {
                        data[j] = (char)(data[j] - 'a' + 'A');
                    }
                }
                else
                {
                    if('A'<= data[j] && data[j]<= 'Z')
                    {
                        data[j] = (char)(data[j] - 'A' + 'a');
                    }
                }
            }
            sb.Append(new String(data).ToString());
            if(i != splitStrings.Length-1)
                sb.Append(" ");
        }
        answer = sb.ToString();
        return answer;
    }
}