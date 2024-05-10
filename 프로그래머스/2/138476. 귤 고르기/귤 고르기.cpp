#include <string>
#include <vector>
#include <map>
#include <algorithm>
using namespace std;

int solution(int k, vector<int> tangerine) {
    map<int,int> collector{};
    int answer = 0;
    int tangerineCount = 0;
    int tangerineSize = tangerine.size();

    for(int i=0;i<tangerineSize; ++i)
    {
        auto itr = collector.find(tangerine[i]);
        if(itr == collector.end())
        {
            collector.emplace(tangerine[i],1);
        }else
        {
            itr->second += 1;
        }
    }
    
    vector<pair<int,int>> sorter(collector.begin(),collector.end());
    
    sort(sorter.begin(),sorter.end(), [&](pair<int,int> a,pair<int,int>b) -> bool {
        return a.second > b.second;
    });
    
    int sorterSize = sorter.size();
    
    for(int i=0;i<sorterSize;++i)
    {
        tangerineCount += sorter[i].second;
        answer++;
        if(tangerineCount >= k)
        {
            break;
        }
    }
    
    return answer;
}