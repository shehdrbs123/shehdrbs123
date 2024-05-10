#include <string>
#include <vector>
#include <sstream>
#include <set>
#include <iostream>
using namespace std;

vector<int> solution(vector<string> operations) {
    vector<int> answer{};
    set<int> container{};
    int operationsSize = operations.size();
    
    for(int i=0;i<operationsSize;++i)
    {
        char operation{};
        string subStr{};
        int number{};
        
        operation = operations[i][0];
        subStr = operations[i].substr(2);
        number = stoi(subStr);
        
        if(operation == 'I')
        {
            container.emplace(number);
        }else if(!container.empty() && operation == 'D')
        {
            if(number == 1)
            {
                container.erase(--container.end());
            }else
            {
                container.erase(container.begin());
            }
        }
    }
    
    if(container.empty())
    {
        answer.emplace_back(0);
        answer.emplace_back(0);
    }else
    {
        answer.emplace_back(*(--container.end()));
        answer.emplace_back(*container.begin());
    }
    
    return answer;
}