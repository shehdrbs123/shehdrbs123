public class Solution {
    public int[] solution(int n, int m) {
        int[] answer = new int[2];
        int tmpM = m;
        int tmpN = n;
        
        while(true)
        {
            int rest = tmpM%tmpN;
            if(rest == 0)
                break;
            tmpM = tmpN;
            tmpN = rest;
        }
        
        answer[0] = tmpN;
        
        
        tmpM = m;
        tmpN = n;
        
        answer[1] = tmpM*tmpN/answer[0];
        
        return answer;
    }
}