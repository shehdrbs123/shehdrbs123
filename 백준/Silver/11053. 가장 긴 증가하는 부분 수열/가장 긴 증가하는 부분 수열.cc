#include <iostream>
#include <vector>
#include <cmath>

using namespace std;

int dp[1001];
int sequence[1001];
int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    int N;
    
    cin >> N;
    


    for(int i=0;i<N;++i)
    {
        cin >> sequence[i];
        dp[i] = 1;
    }
        
    int result = 1;

    for(int i=1;i<N;++i)
    {
        for(int j=i-1;j>=0;--j)
        {
            if(sequence[i] > sequence[j])
            {
                dp[i] = max(dp[i],dp[j]+1);
            }
        }
        result = max(dp[i],result);
    }
    
    cout << result;
}