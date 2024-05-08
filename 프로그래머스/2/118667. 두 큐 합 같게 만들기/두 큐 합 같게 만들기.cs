using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] queue1, int[] queue2) {
        int answer = 0;
        long total = 0;
        long queue1Sum = 0;
        long queue2Sum = 0;
        Queue<int> queue1Queue = new Queue<int>();
        Queue<int> queue2Queue = new Queue<int>();
        
        
        // 데이터 가공
        for(int i=0;i<queue1.Length;++i)
        {
            total += queue1[i] + queue2[i];
            queue1Queue.Enqueue(queue1[i]);
            queue2Queue.Enqueue(queue2[i]);
            queue1Sum += queue1[i];
            queue2Sum += queue2[i];
        }
        
        
        //본격 체크
        int loop = (queue1.Length + queue2.Length) * 2;
        int j=0;
        for(;j<loop;++j)
        {
            if(queue1Sum == queue2Sum)
            {
                break;
            }else if(queue1Sum > queue2Sum)
            {
                int queue1First = queue1Queue.Dequeue();
                queue2Queue.Enqueue(queue1First);
                queue1Sum -= queue1First;
                queue2Sum += queue1First;                
            }else
            {
                int queue2First = queue2Queue.Dequeue();
                queue1Queue.Enqueue(queue2First);
                queue2Sum -= queue2First;
                queue1Sum += queue2First;
            }
            answer += 1;       
        }
        
        if(j == loop && queue1Sum != queue2Sum)
            return -1;
                                 
        return answer;
    }
}