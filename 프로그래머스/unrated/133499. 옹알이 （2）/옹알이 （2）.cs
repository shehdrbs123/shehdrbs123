using System;

public class Solution {
    public int solution(string[] babbling) {
        int answer = 0;
        string[] bab = {"aya","ye","woo","ma"};
        string[] babReplace = {"   ","  ","   ","  "};
        for(int i=0;i<babbling.Length;++i)
        {
            string tmp = babbling[i];
            bool isComplete = true;
            for(int j=0;j<bab.Length&&isComplete;++j)
            {
                int start = tmp.IndexOf(bab[j]);
                int end = start+bab[j].Length;
                while(start!= -1)
                {
                    //Console.WriteLine(tmp);
                    tmp = tmp.Remove(start,bab[j].Length);
                    tmp = tmp.Insert(start,babReplace[j]);
                    //Console.WriteLine(tmp);
                    start = tmp.IndexOf(bab[j]);
                    if(start == end)
                    {
                        isComplete = false;
                        break;
                    }
                    end = start+bab[j].Length;
                }
            }
            
            foreach(var v in tmp)
            {
                if(v != ' ')
                {
                    isComplete = false;
                    break;
                }
            }
            answer += isComplete ? 1 : 0;
        }
        return answer;
    }
}