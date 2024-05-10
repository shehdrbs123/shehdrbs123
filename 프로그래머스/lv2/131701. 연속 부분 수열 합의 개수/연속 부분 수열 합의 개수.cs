using System;
using System.Collections.Generic;
public class Solution {
    public int solution(int[] elements) {
        HashSet<int> collect = new HashSet<int>();
        for(int i=1;i<elements.Length+1;++i)
        {
            for(int j=0;j<elements.Length;++j)
            {
                int sum = 0;
                for(int k=j;k<j+i;++k)
                {
                    int idx = k % elements.Length;
                    sum += elements[idx];
                }                
                collect.Add(sum);
            }
        }
        return collect.Count;
    }
}