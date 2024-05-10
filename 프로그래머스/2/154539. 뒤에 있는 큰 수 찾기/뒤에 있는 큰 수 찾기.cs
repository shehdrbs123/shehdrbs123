using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] numbers) {
        int[] answer = new int[numbers.Length];
        Stack<IndexValue> stackable = new Stack<IndexValue>();
        
        stackable.Push(new IndexValue(0,numbers[0]));
        
        for(int i=1;i<numbers.Length;++i)
        {
            //Console.WriteLine(stackable.Peek().value+ " " +numbers[i] + " " + stackable.Count);
            while(stackable.Count>0 && stackable.Peek().value < numbers[i])
            {
                IndexValue value = stackable.Pop();
                answer[value.idx] = numbers[i];
            }
            
            stackable.Push(new IndexValue(i,numbers[i]));
        }
        
        while(stackable.Count>0)
        {
            IndexValue value = stackable.Pop();
            answer[value.idx] = -1;
        }
        
        return answer;
    }
    public class IndexValue
    {
        public int idx;
        public int value;
        public IndexValue(int idx, int value)
        {
            this.idx = idx;
            this.value = value;
        }
    }
}