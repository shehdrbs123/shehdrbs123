#include <string>
#include <vector>
#include <queue>
#include <algorithm>
#include <iostream>
using namespace std;

vector<int> solution(int k, vector<int> score) 
{
    vector<int> answer;
    vector<int> reward;
    int sSize = score.size();
    
    for(int i=0;i<sSize;++i)
    {
        reward.emplace_back(score[i]);
        sort(reward.begin(), reward.end(),greater<int>());
        
        if(i+1 < k)
        {
            answer.emplace_back(reward[i]);
        }else
        {
            answer.emplace_back(reward[k-1]);
        }
        
    }
    
    
    
    
    
    
    
    return answer;
}