#include <string>
#include <vector>

using namespace std;

int targetNum{};
int result{};
int numbersSize{};
void DFS(vector<int>& numbers, int idx, int sum);
int solution(vector<int> numbers, int target) {
    int answer = 0;
    
    numbersSize = numbers.size();
    targetNum = target;
    DFS(numbers,0,0);
    
    return result;
}

void DFS(vector<int>& numbers, int idx, int sum)
{
    if(idx == numbersSize)
    {
        if(sum == targetNum)
            result+=1;
        return;
    }
    DFS(numbers,idx+1,sum+numbers[idx]);
    DFS(numbers,idx+1,sum-numbers[idx]);
}