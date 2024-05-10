using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int k, int[,] dungeons) 
    {
        int answer=int.MinValue;
        
        List<Dungoen> list = new List<Dungoen>(8);
        
        for(int i=0;i<dungeons.GetLength(0);++i)
        {
            list.Add(new Dungoen(dungeons[i,0],dungeons[i,1]));
        }
        list.Sort();
        
        //list.ForEach((x) => Console.WriteLine($"{x.needFatigue} {x.consumeFatigue}"));
        
        do
        {
            int currentFatigue = k;
            int currentClearCount = 0;
            for(int i=0;i<list.Count;++i)
            {
                if(list[i].needFatigue > currentFatigue || list[i].consumeFatigue > currentFatigue)
                    break;
                currentFatigue -= list[i].consumeFatigue;
                ++currentClearCount;
            }
            if(currentClearCount > answer)
                answer = currentClearCount;
        }while(next_Permutation(list));
        
        return answer;
    }
    
    private bool next_Permutation(List<Dungoen> list)
    {
        int size = list.Count;
        int i = size-1;
        
        while(i>0&&list[i-1].needFatigue>=list[i].needFatigue) i--;
        if(i==0) return false;


        int j = size-1;
        
        while(list[i-1].needFatigue >= list[j].needFatigue ) j--;
        

        Swap(list,i-1,j);
       
        
        int k = size-1;
        while(i < k) {
			Swap(list, i++, k--);			
	    }
        //list.ForEach((x) => Console.WriteLine($"{x.needFatigue} {x.consumeFatigue}"));
        Console.WriteLine();
        return true;
    }
    
    private void Swap(List<Dungoen> list, int srcIdx, int dstIdx)
    {
        Dungoen tmp = list[srcIdx];
        list[srcIdx] = list[dstIdx];
        list[dstIdx] = tmp;
    }
    
    public class Dungoen : IComparable<Dungoen>
    {
        public int needFatigue;
        public int consumeFatigue;
        public Dungoen(int n, int c)
        {
            needFatigue = n;
            consumeFatigue = c;
        }
        
        public int CompareTo(Dungoen other)
        {
            int result = needFatigue - other.needFatigue;
            if(result==0)
                result = consumeFatigue - other.consumeFatigue;
            return result;
        }
    }
}