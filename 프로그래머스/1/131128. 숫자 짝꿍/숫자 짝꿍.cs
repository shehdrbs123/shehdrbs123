using System;
using System.Collections.Generic;
public class Solution {
    public string solution(string X, string Y) {
        string answer = "";
        Dictionary<int,int> XCounter = new Dictionary<int,int>();
        Dictionary<int,int> YCounter = new Dictionary<int,int>();
        List<char> s = new List<char>();
        int i=0;
        if(X.Length > Y.Length)
        {
            string tmp = X;
            X = Y;
            Y = tmp;
        }
        
        for(;i<X.Length;i++)
        {
            int val;
            if(XCounter.TryGetValue(X[i],out val))
            {
                val += 1;
                XCounter[X[i]] = val;
            }else
                XCounter.Add(X[i],1);
            
            if(YCounter.TryGetValue(Y[i],out val))
            {
                val += 1;
                YCounter[Y[i]] = val;
            }else
                YCounter.Add(Y[i],1);
            
        }
        
        for(;i<Y.Length;i++)
        {
            int val;
            if(YCounter.TryGetValue(Y[i],out val))
            {
                val += 1;
                YCounter[Y[i]] = val;
            }else
                YCounter.Add(Y[i],1);
        }
        
        foreach(var a in XCounter)
        {
            int yVal;
            if(YCounter.TryGetValue(a.Key,out yVal))
            {
                int count = Math.Min(yVal,a.Value);
                while(count>0)
                {
                    s.Add((char)a.Key);
                    count--;
                }
            }
        }
        
        s.Sort((x,y) => y-x);
        if(s.Count==0)
            answer = "-1";
        else if (s[0] == '0')
            answer = "0";
        else
            answer = new string(s.ToArray());
        
        return answer;
    }
}