using System.Text;
public class Solution {
    public string solution(int n) {
        StringBuilder sb = new StringBuilder(n);
        char added = '수';
        for(int i=0;i<n;++i)
        {
            sb.Append(added);
            if(added == '수')
                added = '박';
            else
                added = '수';
            
        }
        
        
        return sb.ToString();
    }
}