#include <string>
#include <vector>
#include <iostream>
#include <string>
#include <algorithm>
#include <cmath>
using namespace std;

int solution(int n) {
    int answer = 0;
    string data = "";
    
    while(n>0)
    {
        int rest = n%3;
        n /= 3;
        data+= rest;
    }
    
    
    int stringSize = data.size();
    reverse(data.begin(),data.end());
    for(int i=0;i<stringSize;++i)
    {
        int dData = data[i];
        answer += dData * pow(3,i);
    }
    
    
    return answer;
}