using System;
using System.Text;
using System.Linq;
public class Solution {
    public int[] solution(string s) {
        StringBuilder sb = new StringBuilder(150000);
        int[] answer = new int[2];
        int count = 0;
        while(s.Length > 1)
        {
            char[] arr = s.ToCharArray();
            int removedZero=0;
            int resultLength = 0;
            
            for(int i=0;i<arr.Length;++i)
            {
                if(arr[i] == '0')
                {
                    ++removedZero;
                }
                else
                {
                    sb.Append(arr[i]);    
                }
            }
            s = sb.ToString();
            sb.Clear();
            resultLength = s.Length;
            
            while(resultLength>=1)
            {
                sb.Append(resultLength % 2);
                resultLength /= 2;
            }
            s = new string(sb.ToString().Reverse().ToArray());
            sb.Clear();
            
            ++answer[0];
            answer[1] += removedZero;
            
        }
        
        return answer;
    }
}