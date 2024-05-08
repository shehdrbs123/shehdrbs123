using System;

public class Solution {
    public int solution(int[,] sizes) {
        int answer = 0;
        int x=0,y = 0;
        
        for(int i=0;i<sizes.GetLength(0);++i)
        {
            int width, height = 0;
 
            width = sizes[i,0];
            height = sizes[i,1];
            if(width < height)
            {
                int tmp = width;
                width = height;
                height = tmp;
            }
            
            x = Math.Max(x,width);
            y = Math.Max(y,height);
            
        }
        
        answer = x*y;
        return answer;
    }
}