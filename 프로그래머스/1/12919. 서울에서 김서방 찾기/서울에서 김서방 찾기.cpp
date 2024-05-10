#include <string>
#include <vector>
#include <algorithm>
#include <iostream>

using namespace std;

string solution(vector<string> seoul) {
    string answer = "김서방은 ";
    int s = seoul.size();
       
    
    
    auto findItr = find(seoul.begin(),seoul.end(),"Kim");
    answer += to_string(findItr - seoul.begin());

    
    answer.append("에 있다");
    return answer;
}