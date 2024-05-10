using System;
using System.Text;
using System.Collections.Generic;

public class Solution {
    public string solution(int[] numbers) {
        StringBuilder sb = new StringBuilder(100000);
        Array.Sort(numbers,(x,y) => {
            string strX = x.ToString();
            string strY = y.ToString();
            int compX = int.Parse(strX + strY);
            int compY = int.Parse(strY + strX);
            
            return compY - compX;
        });
        if(numbers[0] ==0)
            return "0";
        Array.ForEach(numbers, x => sb.Append(x));
        return sb.ToString();
    }
    
    public int compareStr(string x, string y)
    {
        return 0;
    }
}