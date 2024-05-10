#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

string solution2(vector<int> food) {
    string answer = "";
    string temp{};    
    
    for(int i = 1 ;i<food.size(); i++)
    {
        int place = food[i]/2;
        for(int j=0; j < place; j++)
        {
            answer += i + '0';
        }
    }
    temp = answer;
    reverse(temp.begin(),temp.end());
    
    answer.append("0").append(temp);
    
    return answer;
}

string solution(vector<int> food) {
    string answer = "";
    string temp{};

    auto it = food.begin();
    it++;
    for(auto it = food.begin(); it != food.end(); ++it)
    {
        int num = (*it)/2;
        
        for(int j=0; j<num;++j)
        {
            answer += (char)(it-food.begin())+'0';
        }
    }
    
    temp = answer;
    reverse(temp.begin(),temp.end());
    
    answer.append("0").append(temp);
    
        
    
    return answer;
}




// 포문 1번 부터 시작
// 2로 나눈 몫만 사용해서 문자열에 넣고
// 반복
// 마지막에 0과 reverse한 내용을 넣어서 마무리