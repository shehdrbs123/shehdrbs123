#include <iostream>
#include <vector>
using namespace std;

int dp[10001];
int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    int N,M;
    cin >> N >> M;
    
    vector<pair<int,int>> goods{};
    goods.emplace_back(0,0);
   
    for(int i=0;i<N;++i)
    {
        int V,C,K;
        cin >> V >> C >> K;

        for(int j=K;j>0;j >>=1)
        {
            int count = j-(j>>1);
            goods.emplace_back(V*count,C*count);
        }
    }

    for(int i=1;i<goods.size();++i)
    {
        int volume = goods[i].first;
        int value = goods[i].second;
        for(int j=M;j>=volume;--j)
        {
            dp[j] = max(dp[j],dp[j-volume]+value);
        }
    }

    cout << dp[M];
}