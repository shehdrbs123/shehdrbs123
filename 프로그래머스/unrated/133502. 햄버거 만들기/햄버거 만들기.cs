using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] ingredient) {
        int answer =0;
        answer = solve2(ingredient);
        return answer;        
    }
    
    private int solve2(int[] ingredient)
    {
        int answer= 0;
        int[] recipe = new int[] {1,2,3,1};
        List<int> stack = new List<int>();
        int i=0;
        for(;i<ingredient.Length && i<3;++i)
        {
            stack.Add(ingredient[i]);
        }
        
        for(;i<ingredient.Length;++i)
        {
            stack.Add(ingredient[i]);
            
            if(stack.Count >= 4)
            {
                bool isOk = true;
                int k = 0;
                for(int j=stack.Count-4;j<stack.Count;j++)
                {
                    if(stack[j] != recipe[k])
                    {
                        isOk=false;
                        break;
                    }
                    k++;
                }
                if(isOk)
                {
                    stack.RemoveRange(stack.Count-4,4);
                    answer++;
                }
            }
        }
        
        return answer;
    }
    
    private int solve1(int[] ingredient)
    {
        int answer = 0;
        List<int> stack = new List<int>();
        
        for(int i=0;i<ingredient.Length;i++)
        {
            stack.Add(ingredient[i]);
            if(stack.Count >= 4)
            {
                if(MakeBread(stack))
                {
                    answer++;
                    
                }   
            }
        }
        return answer;
    }
    int[] makableBread = new int[]{1,2,3,1};
    private bool MakeBread(List<int> stack)
    {
        int lastIdx = stack.Count-4;
        for(int i=0;i<makableBread.Length;i++)
        {
            if(stack[lastIdx + i] != makableBread[i])
            {
                return false;
            }
        }
        stack.RemoveRange(lastIdx, 4);
        return true;
    }
}