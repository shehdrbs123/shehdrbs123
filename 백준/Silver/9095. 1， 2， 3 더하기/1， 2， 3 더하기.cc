#include <iostream>

using namespace std;

int N;
int dp[11];
int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    cin >> N;
    dp[0] = 0;
    dp[1] = 1;
    dp[2] = 2;
    dp[3] = 4;
    for(int i=4;i<11;++i)
    {
        dp[i] = dp[i-1] + dp[i-2] + dp[i-3];
    }
    
    
    for(int i=0;i<N;++i)
    {
        int t;
        cin >> t;
        cout << dp[t] << '\n';
    }
}