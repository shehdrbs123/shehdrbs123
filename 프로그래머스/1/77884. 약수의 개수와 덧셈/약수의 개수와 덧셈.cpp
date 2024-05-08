#include <string>
#include <vector>
#include <cmath>
using namespace std;

int GetCDCount(int num);
int solution(int left, int right) {
    int answer = 0;
    
    for(;left<=right;++left)
    {
        int CDCount = GetCDCount(left);
        if(CDCount % 2 == 0)
        {
            answer += left;
        }else
        {
            answer -= left;
        }
    }
    return answer;
}

int GetCDCount(int num)
{
    int half = sqrt(num)+1;
    int CDCount=0;
    for(int i=1;i<=half; ++i)
    {
        if(num % i == 0)
        {
            if(i != num/i)
                ++CDCount;
            ++CDCount;
        }
    }
    return CDCount;
}