#include <iostream>

using namespace std;

int computer[102];

int find(int a)
{
    if(computer[a] == a)
        return a;
    else
        return computer[a] = find(computer[a]);
}

void Union(int a, int b)
{
    int ra = find(a);
    int rb = find(b);
    
    if(ra > rb)
    {
        int tmp = ra;
        ra = rb;
        rb = tmp;
    }
    
    computer[rb] = ra;   
}

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    int c, n, result=0;
    
    cin >> c;
    cin >> n;
    
    for(int i=1;i<=c;++i)
    {
        computer[i] = i;
    }
    
    for(int i=0;i<n;++i)
    {
        int a1, a2;
        cin >> a1 >> a2;
        
        if(a1 > a2)
        {
            int tmp = a1;
            a1 = a2;
            a2 = tmp;
        }
        
        Union(a1,a2);
    }
    
    for(int i=1;i<=c;++i)
    {
        int a = find(i);
        if(a == 1)
        {
            result++;
        }
    }
    
    cout << result-1;
}


