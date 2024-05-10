using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string s) {
        int answer = 0;
        Queue<char> q = new Queue<char>(s.ToCharArray());
        Stack<char> stk =  new Stack<char>();
        for(int i=0;i<s.Length;++i)
        {
            bool isOk = true;
            foreach(var a in q)
            {
                if(a == '(' || a == '{' || a =='[')
                {
                    stk.Push(a);
                }
                else if(a == ']')
                {
                    if(stk.Count >0 && stk.Peek() == '[')
                    {
                        stk.Pop();   
                    }else
                    {
                        isOk = false;
                        break;
                    }
                }else if(a== '}')
                {
                     if(stk.Count >0 && stk.Peek() == '{')
                    {
                        stk.Pop();   
                    }else
                    {
                        isOk = false;
                        break;
                    }
                }
                else if( a== ')')
                {
                     if(stk.Count >0 && stk.Peek() == '(')
                    {
                        stk.Pop();   
                    }else
                    {
                        isOk = false;
                        break;
                    }
                }
            }
            
            if(stk.Count == 0 && isOk)
                ++answer;
            stk.Clear();
            char next = q.Peek();
            q.Dequeue();
            q.Enqueue(next);
        }
        return answer;
    }
    //이전 풀이
    public int solution1(string s) {
        int answer = 0;
        LinkedList<char> list = new LinkedList<char>();
        char[] tempChar = s.ToCharArray();
        
        for(int i=0;i<tempChar.Length;i++)
        {
            list.AddLast(tempChar[i]);
        }
        
        for(int i=0;i<s.Length;i++)
        {
            int sCase=0;
            int mCase=0;
            int hCase=0;
            bool isOK=true;
            var node = list.First;
            while(node != null && isOK)
            {
                if(node.Value == '(')
                {
                    ++sCase;
                }
                else if(node.Value =='{')
                {
                    ++mCase;
                }
                else if(node.Value == '[')
                {
                    ++hCase;
                }
                else if(node.Value == ')')
                {
                    if(sCase > 0)
                        --sCase;
                    else
                        isOK = false;
                }
                else if(node.Value == '}')
                {
                    if(mCase > 0)
                        --mCase;
                    else
                        isOK = false;
                }else
                {
                    if(hCase > 0)
                        --hCase;
                    else
                        isOK = false;
                }
                node = node.Next;
            }
            if(isOK)
                ++answer;
            char temp = list.First.Value;
            list.RemoveFirst();
            list.AddLast(temp);
            
        }
        return answer;
    }
}