using System;

public class Solution {
    public int[] solution(int[] array, int[,] commands) {
        int[] answer; 
        
        answer = Solve1(array,commands);
        
        return answer;
    }
    
    public int[] Solve1(int[] array, int[,] commands)
    {
        int[] answer; 
        int commandsHeight = commands.GetLength(0);
        
        answer = new int[commandsHeight];
        
        for(int i=0;i<commandsHeight;++i)
        {
            int start = commands[i,0]-1;
            int end = commands[i,1]-1;
            int[] subArray = new int [end-start+1];
            int k=start;
            for(int j=0;j<subArray.Length;++j)
            {
                subArray[j] = array[k];
                ++k;
            }
            
            Array.Sort(subArray);
            int pos = commands[i,2]-1;
            answer[i] = subArray[pos];
        }
        
        return answer;
    }
    
    public int[] Solve2(int[] array, int[,] commands)
    {
        int[] answer = new int[commands.Length/3];

        for(int i=0;i<answer.Length;++i)
        {
            int startIdx = commands[i,0]-1;
            int endIdx = commands[i,1]-1;
            int selectIdx = commands[i,2]-1;

            if(startIdx > endIdx)
            {
                int tmp = startIdx;
                startIdx = endIdx;
                endIdx = tmp;
            }
            int subLength = endIdx - startIdx +1;
            int[] sub = new int[subLength]; 
            int tmpStartIdx = startIdx;
            for(int j=0;j<subLength;++j)
            {
                sub[j] = array[tmpStartIdx];
                ++tmpStartIdx;
            }   
            Console.WriteLine();
            Array.Sort(sub);

            answer[i] = sub[selectIdx];
        }
        

        return answer;
    }
}