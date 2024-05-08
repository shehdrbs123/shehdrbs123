using System;

public class Solution {
    char[] chars = {'A','E','I','O','U'};
    string targetWord;
    int answer=0;
    bool isFind = false;
    public int solution(string word) {
        targetWord= word;
        
        DFS("",0);
        
        return answer;
    }
    
    public int DFS(string cur,int count)
    {
        if(cur.Length>=5)
            return count;
        
        for(int i=0;i<chars.Length;++i)
        {
            string added = cur + chars[i];
            if(targetWord.CompareTo(added)==0)
            {
                answer = count+1;
                isFind = true;
            }
            if(isFind)
                break;
            count = DFS(added,count+1);
        }
        return count;
    }
}