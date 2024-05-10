using System;
using System.Collections.Generic;
public class Solution {
    public int solution(int[] order) {
        int answer = 0;
        Stack<int> stack = new Stack<int>();
        
        int currentBox =0;
        int orderedBox =1;
        for(int i=0;i<order.Length && currentBox < order.Length;++i,++orderedBox)
        {           
            //Console.WriteLine($"{order[currentBox]} {stack.Count > 0 ? stack.Peek() : -1}  {orderedBox} ");
            if(stack.Count > 0 && stack.Peek() == order[currentBox])
            {
                stack.Pop();
                ++answer;
                ++currentBox;
                --orderedBox;
                --i;
                continue;
            }else if(orderedBox <= order.Length && orderedBox == order[currentBox])
            {
                ++answer;
                ++currentBox;
                --i;
                continue;
            }
            stack.Push(orderedBox);
        }
        
        return answer;
    }
}