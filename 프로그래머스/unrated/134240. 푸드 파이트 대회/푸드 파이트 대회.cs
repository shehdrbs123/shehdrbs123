using System;
using System.Text;
using System.Linq;
public class Solution {
    public string solution(int[] food) {
        string answer = "";
        StringBuilder sb = new StringBuilder(100);
        for(int i=1;i<food.Length;++i)
        {
            int foodCount = (int)food[i]/2;
            for(int j=0;j<foodCount;++j)
            {
                sb.Append(i);
            }
        }
        string tmp = new string(sb.ToString().Reverse().ToArray());
        sb.Append(0).Append(tmp);
        answer = sb.ToString();
        return answer;
    }
}