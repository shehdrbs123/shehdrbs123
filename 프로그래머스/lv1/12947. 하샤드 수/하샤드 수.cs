public class Solution {
    public bool solution(int x) {
        bool answer = true;
        int backupX = x;
        int hasad = 0;
        
        while(x>=1)
        {
            int rest;
            
            rest = x%10;
            x = x/10;
            hasad += rest;
        }
        
        if(hasad == 0 ||backupX % hasad != 0)
            answer = false;
        
        
        return answer;
    }
}