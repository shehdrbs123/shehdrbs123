#include <iostream>
#include <string>
#include <cmath>
using namespace std;

int dp[1001][1001];
int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    string a,b;
    cin >> a;
    cin >> b;

    int aSize = a.size();
    int bSize = b.size();
    int result = 0;
    
    for(int i=0;i<aSize;++i)
    {
        for(int j=0;j<bSize;++j)
        {
            int dpAidx = i+1;
            int dpBidx = j+1;
            
            if(a[i] == b[j])
            {
                dp[dpAidx][dpBidx] = dp[dpAidx-1][dpBidx-1] + 1;
            }else
            {
                dp[dpAidx][dpBidx] = max(dp[dpAidx-1][dpBidx],dp[dpAidx][dpBidx-1]);
            }
            
            result = max(result,dp[dpAidx][dpBidx]);
        }
    }
    
    cout << result;
}