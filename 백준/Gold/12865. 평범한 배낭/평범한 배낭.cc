#include <iostream>
#include <vector>
#include <cmath>
#define WEIGHT first
#define VALUE second

using namespace std;

int dp[100001][101];
int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    int N,K;
    cin >> N >> K;
    
    vector<pair<int,int>> goods{};
    goods.reserve(N+1);
    goods.emplace_back(0,0);
    
    int minW=100001;
    for(int i=1;i<=N;++i)
    {
        int w,v;
        cin >> w >> v;
        goods.emplace_back(w,v);
        if(minW>w)
            minW = w;
    }
    
    //dp 테이블 초기화
    for(int i=0;i<minW;++i)
    {
        for(int j=0;j<N;++j)
        {
            dp[i][j] = 0;
        }
    }
    
    for(int i=0;i<K;++i)
    {
        dp[i][0] = 0;
    }
    
    int result = 0;
    //dp 계산하기
    for(int i=minW;i<=K;++i)
    {
        for(int j=1;j<=N;++j)
        {
            auto g = goods[j];

            if(i-g.WEIGHT < 0)
            {
                dp[i][j] = dp[i][j-1];
                continue;
            }

            int preDP = dp[i][j-1];
            int insertDP = dp[i-g.WEIGHT][j-1]+g.VALUE;
            
            dp[i][j] = max(preDP,insertDP);
            if(i==K)
            {
                result = max(result,dp[i][j]);
            }
        }
    }
    
    cout << result;
    
}