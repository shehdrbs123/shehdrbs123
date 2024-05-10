using System;
public class Solution {
    long[] arPibonacci = new long[100001];
    public int solution(int n) {
        int answer = 0;
        Array.Fill(arPibonacci,-1);
        arPibonacci[0] = 0;
        arPibonacci[1] = 1;
        pibonacci((long)n);
        
        return (int)(arPibonacci[n]);
    }
    
    private long pibonacci(long n)
    {
        if(arPibonacci[n] != -1)
            return arPibonacci[n];
        arPibonacci[n] = (pibonacci(n-1) + pibonacci(n-2)) % 1234567;
        return arPibonacci[n];
    }
}