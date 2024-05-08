public class Solution {
    public int solution(int[] arr) {
        int answer = 0;
        //약수를 구하고 약수들 중 가장 큰 지수값을 가지는 것들을 곱하기
        answer = arr[0];
        for(int i=1;i<arr.Length;++i)
        {
            answer = lcm(answer,arr[i]);
        }
        return answer;
    }
    
    private int gcd(int a, int b)
    {
        int rest = a%b;
        while(rest != 0)
        {
            a = b;
            b = rest;
            rest = a%b;
        }
        
        return b;
    }
    
    private int lcm(int a, int b)
    {
        return  a*b/gcd(a,b);
    }
}