#include <string>
#include <vector>
#include <algorithm>

using namespace std;

int solution(int k, int m, vector<int> score) {
    int answer = 0;
    int currentAppleCount = 0;
    int minScore = k;
    
    
    sort(score.begin(), score.end(),greater<int>());
    
    for(auto itr = score.begin(); itr != score.end(); itr++)
    {
        ++currentAppleCount;
        minScore = min(minScore,*itr);
        if(currentAppleCount >= m)
        {
            answer += currentAppleCount * minScore;
            currentAppleCount = 0;
            minScore = k;
        }
    }
    
    
    return answer;
}