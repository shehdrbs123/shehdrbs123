#include <iostream>

using namespace std;

int firstGold[] =
{
    0,
    500,
    300, 300,
    200, 200, 200,
    50, 50, 50, 50,
    30, 30, 30, 30, 30,
    10, 10, 10, 10, 10, 10
};
int secondGold[] = 
{
    0,
    512,
    256, 256,
    128, 128, 128, 128,
    64, 64, 64, 64, 64, 64, 64, 64,
    32, 32, 32, 32, 32, 32, 32, 32,
    32, 32, 32, 32, 32, 32, 32, 32
};

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    int t;
    cin >> t;
    for(int i=0;i<t;++i)
    {
        int first, second, result = 0;
        cin >> first >>  second;

        if(first <= 21)
            result += firstGold[first];
        
        if(second <= 31)
            result += secondGold[second];
        
        cout << result*10000 << '\n';
    }
}