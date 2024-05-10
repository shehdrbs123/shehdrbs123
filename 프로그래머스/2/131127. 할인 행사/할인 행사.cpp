#include <string>
#include <vector>
#include <unordered_map>
#include <iostream>
using namespace std;

int solution(vector<string> want, vector<int> number, vector<string> discount) {
    unordered_map<string,int> wantsCount;
    
    int rightDate = 0;
    int discountSize = discount.size();
    int wantSize = want.size();
    int numberCount{};
    
    // 총 개수 값 구하기
    for(int i=0;i<wantSize;++i)
    {
        numberCount += number[i];
    }
    
    //10일치 전부 dictionary에 넣기
    for(int i=0;i<numberCount-1;++i)
    {
        auto itr = wantsCount.find(discount[i]);
        if(itr == wantsCount.end())
        {
            wantsCount.emplace(discount[i],1);
        }else
        {
            itr->second += 1;
        }
    }
    
    for(int i=numberCount-1; i < discountSize; ++i)
    {
        auto itr = wantsCount.find(discount[i]);
        if(itr == wantsCount.end())
        {
            wantsCount.emplace(discount[i],1);
        }else
        {
            itr->second += 1;
        }
        
        
        bool isComplete = true;
        for(int j=0;j<wantSize;++j)
        {
            auto itr = wantsCount.find(want[j]);
            if(itr == wantsCount.end() || itr->second < number[j])
            {
                isComplete = false;
                break;
            }
        }        
        
        if(isComplete)
        {
            rightDate++;
        }

        auto itr2 = wantsCount.find(discount[i-(numberCount-1)]);
        if(itr2 != wantsCount.end())
        {
            //cout << itr2->first << '\n';
            itr2->second -= 1;
            if(itr2->second <= 0 )
                wantsCount.erase(discount[i-(numberCount-1)]);
        }
    }
    
    return rightDate;
}