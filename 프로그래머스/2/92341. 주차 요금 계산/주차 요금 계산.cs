using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] fees, string[] records) {
        List<int> answer = new List<int>();
        Dictionary<string,int> carRecords = new Dictionary<string,int>();
        SortedDictionary<string,int> carBills = new SortedDictionary<string,int>();
        int baseTime = fees[0];
        int baseFee = fees[1];
        int NormalTime = fees[2];
        int NormalFee = fees[3];
        
        for(int i=0;i<records.Length;++i)
        {
            string[] splits = records[i].Split(' ');
            int time = caculateTime(splits[0]);
            if(splits[2] == "IN")
            {
                carRecords.Add(splits[1],time);
            }else
            {
                int inTime = carRecords[splits[1]];
                int parkedTime = time-inTime;
               
                 if(carBills.ContainsKey(splits[1]))
                {
                    carBills[splits[1]] += parkedTime;
                }else
                {
                    carBills.Add(splits[1],parkedTime);
                }
                
                carRecords.Remove(splits[1]);
            }
        }
        
        foreach(var record in carRecords)
        {
            int inTime = record.Value;
            int parkedTime = 1439-inTime;   
            
            if(carBills.ContainsKey(record.Key))
            {
                carBills[record.Key] += parkedTime;
            }else
            {
                carBills.Add(record.Key,parkedTime);
            }
            
        }
        
        foreach(var carBill in carBills)
        {   
            int calculateValue = Math.Max(carBill.Value-baseTime,0);   
            
            int fee = ((int)Math.Ceiling((double)calculateValue/(double)NormalTime)) * NormalFee + baseFee;
            answer.Add(fee);
        }
        
        
        
        
        return answer.ToArray();
    }
    
    private int caculateTime(string time)
    {
        string[] splitTime = time.Split(':');
        int resultTime = 0;
        int hour = int.Parse(splitTime[0]);
        int minute = int.Parse(splitTime[1]);
        
        resultTime = (hour * 60) + minute;
        return resultTime;
    }
}