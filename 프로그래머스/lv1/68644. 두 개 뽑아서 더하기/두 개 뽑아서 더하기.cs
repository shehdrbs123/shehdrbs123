using System;
using System.Collections.Generic;
public class Solution {
    public int[] solution(int[] numbers) {
        int[] answer;
        SortedSet<int> madeNumbers = new SortedSet<int>();
        
        for(int i=0;i<numbers.Length-1;++i)
        {
            for(int j=i+1;j<numbers.Length;++j)
            {
                madeNumbers.Add(numbers[i]+numbers[j]);
            }
        }
        
        answer = new int[madeNumbers.Count];
        var enumerator = madeNumbers.GetEnumerator();
        for(int i=0;i<answer.Length;++i)
        {
            enumerator.MoveNext();
            answer[i] = enumerator.Current;
        }
        return answer;
    }
}