using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    public string solution(string[] survey, int[] choices) {
        string answer = "";
        
        answer = Solve(survey,choices);
        
        return answer;
    }
    //현재 풀이
    private string Solve(string[] survey, int[] choices)
    {
        Dictionary<string,int> scoreCount = new Dictionary<string,int>();
        string[] personality = new string[]{ "RT","CF","JM","AN"};
        char[] result = new char[4];
        for(int i=0;i<survey.Length;++i)
        {
            int score = 0;
            string selected = survey[i];
            int currentScore = choices[i]-4;
            if(scoreCount.TryGetValue(selected,out score))
            {
                scoreCount[selected] += currentScore;
                
            }else
            {
                scoreCount.Add(selected, currentScore);
            }
        }
        
        for(int i=0;i<personality.GetLength(0); ++i)
        {
            string sit1 = personality[i];
            string sit2 = new string(sit1.Reverse().ToArray());
            
            int sit1Score = 0;
            int sit2Score = 0;
            scoreCount.TryGetValue(sit1, out sit1Score);
            scoreCount.TryGetValue(sit2, out sit2Score);            
            //Console.WriteLine(sit1Score + " " + sit2Score);           
            int resultScore = sit1Score - sit2Score;
            
            if(resultScore>0)
                result[i] = sit1[1];
            else
                result[i] = sit1[0];
        }
        return new string(result);
    }
    
    
    
    
    //이전의 풀이
    private void MakeResult( Dictionary<string,int> surveySum,string[] survey, int[] choices)
    {
        for(int i=0;i<survey.Length;i++)
        {
            string style = survey[i];
            int score = choices[i]-4;
            
            int sum = 0;
            if(surveySum.TryGetValue(style,out sum))
            {
                surveySum[style] += score;
            }
            else
            {
                surveySum.Add(style,score);
            }
        }
    }
    
    private void MakeYourStyle(Dictionary<string,int> surveySum,out string answer)
    {
        string[] arStyles = {"RT","CF","JM","AN"};
        int[] sumResult = new int[arStyles.Length];
        char[] result= {'R','C','J','A'};
        
        for(int i=0;i<arStyles.Length;i++)
        {
            int score1=0,score2=0;
            string baseArStyle = arStyles[i];
            
            char[] reverseTemp = baseArStyle.ToCharArray();
            Array.Reverse(reverseTemp);
            string reverseArStyle = new String(reverseTemp);
            
            surveySum.TryGetValue(baseArStyle, out score1);
            
            surveySum.TryGetValue(reverseArStyle,out score2);
            
            //Console.WriteLine("{0} : {1} {2} : {3}",baseArStyle,score1, reverseArStyle,score2);
            sumResult[i] = score1 - score2;
        }
        
        for(int i=0;i<sumResult.Length; i++)
        {
            if(sumResult[i] > 0)
            {
                result[i] = arStyles[i][1];
            }
        }
        //foreach(KeyValuePair<string,int> a in surveySum)
        //    Console.WriteLine("key {0}, value {1}",a.Key, a.Value);
        
        answer = new String(result);
    }
    
}