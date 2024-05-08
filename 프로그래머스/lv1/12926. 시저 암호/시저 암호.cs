public class Solution {
    public string solution(string s, int n) {
        string answer = "";
        char[] charString = s.ToCharArray();
        
        for(int i=0;i<charString.Length;++i)
        {
            int tmp;
            char baseChar = 'A';
            
            if(charString[i] == ' ')
                continue;
            else if(charString[i] >= 'a')
            {
                baseChar = 'a';
            }
            
            tmp = charString[i] -baseChar;
            tmp = (tmp+n)%26;
            tmp += baseChar;
            charString[i] = (char)tmp;
        }
        
        answer = new string(charString);
        return answer;
    }
}