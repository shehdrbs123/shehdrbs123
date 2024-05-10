using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string today, string[] terms, string[] privacies)
    {       
        List<int> answer = new List<int>(100);
        Dictionary<string,int> termsDic = new Dictionary<string,int>();
        float todayCounts = GetExpiredDate(today," ",termsDic);
        
        for(int i=0;i<terms.Length;++i)
        {
            string[] splited = terms[i].Split(" ");
            int termsNum = int.Parse(splited[1]);
            termsDic.Add(splited[0],termsNum);
        }
        
        for(int i=0;i<privacies.Length;++i)
        {
            string[] splited = privacies[i].Split(' ');
            float ExpiredDate = GetExpiredDate(splited[0],splited[1],termsDic);
            
            if(todayCounts > ExpiredDate)
            {
                answer.Add(i+1);
            }
            
        }
        
        return answer.ToArray(); 
    }
    
    private float GetExpiredDate(string dateTime, string terms, Dictionary<string,int> termsDic)
    {
        string[] dateSplited = dateTime.Split('.');
        float DayTime = float.Parse(dateSplited[2]);
        
        DayTime += float.Parse(dateSplited[1])*28;
        DayTime += (float.Parse(dateSplited[0])-2000) * (28*12);
        
        int termsNum=0;
        if(termsDic.TryGetValue(terms, out termsNum))
        {
            DayTime += termsNum*28 - 1;
        }else
        {
            //Console.WriteLine("없다고?");
        }
        
        
        return DayTime;
        
    }
    
    public int[] solution2(string today, string[] terms, string[] privacies)
    {       
        List<int> tempAnswer = new List<int>();
        Dictionary<string,int> termsDic = new Dictionary<string, int>();

        string[] todaySplit = today.Split('.');
        int[] answer  = new int[]{};
        int todayCount=0;

        //데이터 가공
        todayCount += (Convert.ToInt32(todaySplit[0])-1) * 336;
        todayCount += (Convert.ToInt32(todaySplit[1])-1) * 28;
        todayCount += Convert.ToInt32(todaySplit[2]);

        //글자찾기 find로 찾는거 별로라서 dictionary로 가공함
        Array.ForEach<string>(terms, (x) => 
        {
            string[] data = x.Split(' ');
            termsDic.Add(data[0],Convert.ToInt32(data[1])*28);
        });

        for(int i=0;i<privacies.Length;i++)
        {
            string[] splitString = privacies[i].Split(' ');
            string[] dateSplit = splitString[0].Split('.');

            int allDay = 0;
            allDay += (Convert.ToInt32(dateSplit[0])-1) * 336;
            allDay += (Convert.ToInt32(dateSplit[1])-1) * 28;
            allDay += Convert.ToInt32(dateSplit[2])-1;
            allDay += termsDic[splitString[1]];
            if(allDay < todayCount)
            {
                tempAnswer.Add(i+1);
            }
            
        }
        answer = tempAnswer.ToArray();
        
        return answer; 
    }
}