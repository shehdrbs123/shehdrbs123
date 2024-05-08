using System;
using System.Collections.Generic;
public class Solution {
    private long targetNum;
    private long addNum;
    public int solution(int x, int y, int n) {
        int answer = 0;
        targetNum = y;
        addNum = n;
        
        Queue<Check> bfsQueue = new Queue<Check>(10000);
        HashSet<long> checkVisit = new HashSet<long>();
        
        bfsQueue.Enqueue(new Check(x,1));
        
        
        while(bfsQueue.Count > 0)
        {
            Check value = bfsQueue.Dequeue();
            
            long add = value.num + n;
            long multi2 = value.num * 2;
            long multi3 = value.num * 3;
                            
            if(add == targetNum || multi2 == targetNum || multi3 == targetNum)
            {
                answer = value.count;
                break;
            }  
            
            
            if(add < targetNum && !checkVisit.Contains(add))
            {
                checkVisit.Add(add);
                bfsQueue.Enqueue(new Check(add, value.count+1));
            }
            if(multi2 < targetNum && !checkVisit.Contains(multi2))
            {
                checkVisit.Add(multi2);
                bfsQueue.Enqueue(new Check(multi2, value.count+1));
            }
            if(multi3 < targetNum && !checkVisit.Contains(multi3))
            {
                checkVisit.Add(multi3);
                bfsQueue.Enqueue(new Check(multi3, value.count+1));
            }
        }
        
        if(x!= y && answer == 0)
            answer = -1;
        
        return answer;
    }  
    
    public class Check
    {
        public long num = 0;
        public int count = 0;
        public Check(long num, int count)
        {
            this.num = num;
            this.count = count;
        }
    }
}