using System;
using System.Collections;
using System.Collections.Generic;


public class Solution {
        public int[] solution(string[] id_list, string[] report, int k) 
        {
            int[] answer= new int[id_list.Length];
            Dictionary<string,HashSet<string>> rDic = new Dictionary<string,HashSet<string>>();
            Dictionary<string,int> pDic = new Dictionary<string,int>();
            
            //입력자료 정리
            
            foreach(var r in report)
            {
                string reportor;
                string reported;
                string[] splited = r.Split();
                
                reportor = splited[0];
                reported = splited[1];
                
                HashSet<string> reportedSet;
                bool isAlreadyReport = false;
                if(!rDic.TryGetValue(reportor,out reportedSet))
                {
                    reportedSet = new HashSet<string>();
                    rDic.Add(reportor,reportedSet);
                }
                
                if(reportedSet.Contains(reported))
                {
                    isAlreadyReport = true;
                }
                
                reportedSet.Add(reported);
             
                    
                if(!isAlreadyReport)
                {
                    int reportedCount = 1;
                    pDic.TryGetValue(reported, out reportedCount);
                    reportedCount+=1;
                    pDic[reported] = reportedCount;
                }
            }
            
            // 메일 처리
            
            for(int i=0;i<id_list.Length;++i)
            {
                int processResult=0;
                
                HashSet<string> reportList;
                if(rDic.TryGetValue(id_list[i],out reportList))
                {
                    foreach(var r in reportList)
                    {
                        int reportCount=0;
                        pDic.TryGetValue(r,out reportCount);
                        if(reportCount>=k)
                            ++processResult;
                    }    
                }
                
                answer[i] = processResult;
            }
            
            
            return answer;
        }
         // 예전 풀이
         public int[] solution2(string[] id_list, string[] report, int k) 
         {
            int[] answer = new int[id_list.Length];
            Dictionary<string,int> sDic = new Dictionary<string,int>();
            Dictionary<string,HashSet<string>> rDic = new Dictionary<string,HashSet<string>>();

            // 데이터 가공
            for(int i=0;i<report.Length;i++)
            {
                string[] reportSplit = report[i].Split(' ');
                string user=reportSplit[0];
                string suspendUser=reportSplit[1];
                int count=0;
                HashSet<string> suslist;

                if(!rDic.TryGetValue(user,out suslist))
                {
                    suslist = new HashSet<string>();
                    rDic.Add(user,suslist);
                }

                if(!suslist.Contains(suspendUser))
                {
                    suslist.Add(suspendUser);
                    if(sDic.ContainsKey(suspendUser))
                        sDic[suspendUser] += 1;
                    else
                        sDic.Add(suspendUser,1);
                }

            }
        
        
        // 문제 풀이
        List<string> emailList = new List<string>();
            foreach(KeyValuePair<string,int> kv in sDic)
            {
                //Console.WriteLine("{0} , {1}",kv.Key,kv.Value);
                if(kv.Value >= k){
                    emailList.Add(kv.Key); 
                }
            }

            foreach(KeyValuePair<string,HashSet<string>> kv in rDic)
            {
                foreach(string s in emailList)
                {
                    if(kv.Value.Contains(s))
                    {
                        int idx = Array.FindIndex(id_list,(x) => x == kv.Key);
                        answer[idx] += 1;
                    }
                }
            }

       // printData(rDic,sDic);
            return answer;
        }
    
    private void printData(Dictionary<string,HashSet<string>> rDic, Dictionary<string,int> sDic)
    {
        foreach(KeyValuePair<string,HashSet<string>> kv in rDic)
        {
            Console.Write("key : {0} Suspend : ",kv.Key);
            foreach(string s in kv.Value)
            {
                Console.Write("{0} ",s);
            }
            Console.WriteLine();
        }
        
        foreach(KeyValuePair<string,int> kv in sDic)
        {
            Console.WriteLine("key : {0} , suspended : {1} ",kv.Key,kv.Value);
        }
    }
}