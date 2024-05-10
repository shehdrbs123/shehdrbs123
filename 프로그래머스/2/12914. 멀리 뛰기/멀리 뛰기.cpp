#include <string>
#include <vector>
#include <iostream>
using namespace std;

long long sumList[2001];
void DFS(int sum, long long * result);
long long solution(int n) {
    long long answer = 0;
    
    sumList[1] = 1;
    sumList[2] = 2;
    for(int i=3;i<=n;++i)
    {
        sumList[i] = (sumList[i-2] + sumList[i-1])%1234567;
    }

    return sumList[n];
}