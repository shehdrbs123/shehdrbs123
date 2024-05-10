public class Solution {
    public int solution(int num) {
        int answer = 0;
        long tempNum = num;
        int count=0;
        
        if(tempNum == 1)
            return 0;
        
        while(tempNum != 1 && count < 500)
        {
            if(tempNum%2 == 0) tempNum /= 2;
            else tempNum = tempNum*3+1;
            
            ++count;
        }
        
        if(count >= 500) 
            answer = -1;
        else 
            answer = count;
        
        
        return answer;
    }
}