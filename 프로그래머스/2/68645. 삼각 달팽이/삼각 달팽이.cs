using System;

public class Solution {
    public int[] solution(int n) {
        int[] answer;
        int size = 0;
        for(int i=1;i<=n;++i)
        {
            size += i;
        }
        answer = new int[size];
        
        int gap = 0;
        int currentIdx =0;
        int k = 1;
        int direction = 0;
        for(int i=n; i>0; --i)
        {
            if(direction == 0)
            {
                for(int j=0;j<i;++j)
                {
                    currentIdx += gap;
                    answer[currentIdx] = k;
                    ++k;
                    ++gap;
                }
            }else if(direction == 1)
            {                
                for(int j=0;j<i;++j)
                {
                    currentIdx+=1;
                    answer[currentIdx] = k;
                    ++k;
                }
            }else 
            {
                //Console.WriteLine(i);
                
                for(int j=0;j<i;++j)
                {
                    currentIdx-=gap;
                    gap-=1;
                    answer[currentIdx] = k;
                    ++k;
                }
            }
            
            direction = (direction+1) % 3;
        }
        
       
        //Array.ForEach(answer, x => Console.Write(x + " "));
        
        return answer;
    }
}