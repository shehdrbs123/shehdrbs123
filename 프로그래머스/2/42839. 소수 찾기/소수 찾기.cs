using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string numbers) {
        return Solve1(numbers);
    }
    HashSet<int> setCon;
    public int Solve1(string numbers)
    {
        setCon = new HashSet<int>();
        char[] numChar = numbers.ToCharArray();
        bool[] isVisit = new bool[numbers.Length];
        string str = string.Empty;
        DFS(numChar,isVisit,str);
        
        return setCon.Count;
    }
    
    private void DFS(char[] numChar, bool[] isVisit, string result)
    {        
        if(result != string.Empty)
        {
            int intResult = int.Parse(result);
                
            if(isPrime(intResult))
            {
                //Console.WriteLine(intResult.ToString());
                setCon.Add(intResult);
            }
        }
        
        if(result.Length == numChar.Length)
            return;
        
        for(int i=0;i<numChar.Length;++i)
        {
            if(isVisit[i])
                continue;
            
            isVisit[i] = true;
            DFS(numChar,isVisit,result+numChar[i]);
            isVisit[i] = false;
        }
    }
    
    private bool isPrime(int num)
    {
        if(num == 0 || num == 1)
            return false;
        int targetNum = (int)Math.Sqrt(num);
        
        for(int i=2;i<=targetNum;++i)
        {
            if(num%i == 0)
                return false;
        }
        return true;
    }
    
}