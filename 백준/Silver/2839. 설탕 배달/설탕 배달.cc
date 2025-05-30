#include <iostream>
#include <cmath>

using namespace std;
int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    int weight, resultBack=10000;
    cin >> weight;
    
    for(int i = weight/5;i>=0;--i)
    {
        int rest = weight - (5*i);

        if(rest%3 == 0)
        {
            int curBack = rest/3 + i;
            if(resultBack > curBack)
                resultBack = curBack;
        }
    }
    
    if(resultBack == 10000)
        resultBack = -1;
        
    cout << resultBack;
}