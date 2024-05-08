#include <string>
#include <vector>
#include <unordered_map>
using namespace std;

vector<int> solution(string s) {
    unordered_map<char,int> charPos;
    vector<int> answer;
    int strSize = s.size();
    for(int i=0;i<strSize;++i)
    {
        int prePos = -1;
        
        auto itr = charPos.find(s[i]);
        if(itr != charPos.end())
        {
            prePos = i - itr->second;
            itr->second = i;
        }else
        {
            charPos.emplace(s[i],i);    
        }
        
        
        answer.emplace_back(prePos);
    }
    
    return answer;
}