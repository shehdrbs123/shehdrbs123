#include <iostream>
#include <cmath>
#include <vector>
#include <memory.h>
using namespace std;

int buildTime[1001];
vector<int> beforeBuild[1001];
int beforeBuildTime[1001];


int GetMinimumTime(int idx)
{
    if(beforeBuildTime[idx] != -1)  
    {
        return buildTime[idx] + beforeBuildTime[idx];
    }
    
    if(beforeBuild[idx].empty())
    {
        // cout << "idx : " << idx << " : " << building[idx].buildTime << "\n";
        return buildTime[idx];
    }
    
    int prevBuildSize = beforeBuild[idx].size();
    int maxTime = 0;
    for(int i=0;i<prevBuildSize;++i)
    {
        int beforeTime = GetMinimumTime(beforeBuild[idx][i]);
        maxTime = max(maxTime, beforeTime);
    }

    beforeBuildTime[idx] = maxTime;
        
    return buildTime[idx] + maxTime;
}


int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    int testCase;
    cin >> testCase;

    for(int i=0;i<1001;++i)
    {
        //beforeBuild[i].reserve(100001);
        beforeBuildTime[i] = -1;
    }
    
    for(int i=0;i<testCase;++i)
    {
        int n, k, target, result = 0;
        cin >> n >> k;
        
        //빌드 시간 측정
        for(int j=0;j<n;++j)
        {
            cin >> buildTime[j];
        }
        
        //빌드 그래프 설정
        for(int j=0;j<k;++j)
        {
            int prev,next;
            cin >> prev >> next;
            
            beforeBuild[next-1].emplace_back(prev-1);
        }
        
        
        // 타겟으로부터 측정
        cin >> target;
        
        result = GetMinimumTime(target-1);
        
        cout << result << '\n';
        
        // 사용 후 벡터 정리

        memset(buildTime, 0, sizeof(int)*n);
        memset(beforeBuildTime, 0, sizeof(int)*n);
        for(int j=0;j<n;++j)
        {
            beforeBuild[j].clear();
            beforeBuildTime[j] = -1;
        }
    }
    return 0;
}