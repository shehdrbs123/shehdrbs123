#include <string>
#include <vector>
#include <sstream>
#include <algorithm>
#include <cmath>

using namespace std;

int solution(int n, int k) {
    int answer = 0;
    vector<string> splitStr;
    string changedStr = "";
    string tmp;
    while(n>=1)
    {
        int rest = n%k;
        n /= k;
        changedStr += rest + '0';
    }
    reverse(changedStr.begin(),changedStr.end());
    istringstream iss(changedStr);
    
    while(getline(iss,tmp,'0'))
    {
        if(!tmp.empty())
        {
            long num = stol(tmp);
            if(num > 1)
            {
                int targetNum = sqrt(num);
                int divideCount=0;
                for(int i=1;i<=targetNum;++i)
                {
                    if(num%i == 0)
                    {
                        ++divideCount;
                        if(num/i != i)
                            ++divideCount;
                    }
                }

                if(divideCount == 2)
                    ++answer;
            }
        }
        
    }
    
    
    return answer;
}