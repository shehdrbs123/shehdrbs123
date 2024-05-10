#include <string>
#include <vector>
#include <iostream>
#include <algorithm>

using namespace std;

vector<int> solution(vector<int> lottos, vector<int> win_nums) {
    vector<int> answer;
    int count{};
    int unknownCount{};
    int lottosSize = lottos.size();
    int min{};
    int max{};
    
    for(int i=0;i<lottosSize;++i)
    {
        auto itr = find(win_nums.begin(),win_nums.end(),lottos[i]);
        if(itr != win_nums.end())
            ++count;
        if(lottos[i] == 0)
            ++unknownCount;
    }
    
    
    max = 7 - (count + unknownCount);
    if(max == 7)
        max = 6;
    answer.emplace_back(max);
    
    min = 7 - count;
    if(min == 7)
        min = 6;
    answer.emplace_back(min);
    
    return answer;
}