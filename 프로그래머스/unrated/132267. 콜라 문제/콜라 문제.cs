using System;

public class Solution {
    public int solution(int a, int b, int n) {
        int answer = 0;
        
        int rest=0;
        int currentCount=n;
        int divide;
        int i=0;
        while(a <= currentCount)
        {
            divide = currentCount/a;
            currentCount = currentCount%a;
            //Console.WriteLine($"{currentCount} {divide}");
            int GetBottle = divide*b;
            currentCount += GetBottle;
            answer+=GetBottle;
        }
        
        return answer;
    }
}