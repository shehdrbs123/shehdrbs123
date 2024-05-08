using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
public class Solution {
    public int solution(int[] priorities, int location) {
        int answer = 0;
        
    
        Queue<NumWithIdx> q = new Queue<NumWithIdx>();
        for(int i=0;i<priorities.Length;++i)
        {
            q.Enqueue(new NumWithIdx(priorities[i],i));
        }
        
        while(q.Count>0)
        {
            int max = int.MinValue;
            int maxIdx = 0;
            for(int i=0;i<priorities.Length;++i)
            {
                if(max < priorities[i])
                {
                    max = priorities[i];
                    maxIdx = i;
                }
            }
            priorities[maxIdx] = 0;
            while(q.Peek().num != max)
            {
                q.Enqueue(q.Dequeue());
            }
            
            NumWithIdx num = q.Dequeue();
            answer++;
            
            if(num.idx==location)
                break;
        }
        
        
        
        return answer;
    }
    public class NumWithIdx : IComparer<int>
    {
        public int num;
        public int idx;
        public NumWithIdx(int num, int idx)
        {
            this.num = num;
            this.idx = idx;
        }
        public int Compare(int x,int y)
        {
            return y-x;
        }
    }
}