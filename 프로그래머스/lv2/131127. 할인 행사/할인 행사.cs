using System;
using System.Collections.Generic;
public class Solution {
    public int solution(string[] want, int[] number, string[] discount) {
        int answer = 0;
        Dictionary<string, int> dicCount = new Dictionary<string,int>();
        int i = 0;
        
        for(;i<9;++i)
        {
            if(dicCount.TryGetValue(discount[i],out int count))
            {
                count+=1;
                dicCount[discount[i]] = count;
            }
            else
            {
                dicCount.Add(discount[i],1);
            }
        }
        
        for(;i<discount.Length;++i)
        {
            bool isOk=true;
            
            if(dicCount.TryGetValue(discount[i],out int num))
            {
                num+=1;
                dicCount[discount[i]] = num;
            }
            else
            {
                dicCount.Add(discount[i],1);
            }
            
            for(int j=0;j<want.Length;++j)
            {
                if(dicCount.TryGetValue(want[j], out int count))
                {
                    if(number[j] > count)
                    {
                        isOk=false;
                        break;
                    }
                }else
                {
                    isOk=false;
                    break;
                }
            }
            dicCount[discount[i-9]] -=1;
            
            
            answer += isOk ? 1 : 0;
        }
        
        
        return answer;
    }
    
    private void GetValue()
    {
        
    }
}