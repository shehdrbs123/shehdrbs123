using System;
using System.Text;
public class Solution {
    public string solution(string phone_number) {
        StringBuilder sb = new StringBuilder(phone_number.Length);
        string prefixSubstring;
        string suffixSubstring;
        
        suffixSubstring = phone_number.Substring(phone_number.Length-4,4);
        prefixSubstring = phone_number.Substring(0,phone_number.Length-4);
          
        for(int i=0;i<prefixSubstring.Length;++i)
        {
            sb.Append("*");
        }
        sb.Append(suffixSubstring);
        return sb.ToString();
    }
}