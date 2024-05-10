#include <string>
#include <vector>
#include <iostream>
#include <cmath>

using namespace std;

int solution(vector<vector<int>> triangle) {
    int answer = 0;
    vector<vector<int>> v(triangle.size());
    
    for(int i=0;i<triangle.size();++i)
    {
        v[i].reserve(triangle[i].size());
        for(int j=0;j<triangle[i].size();++j)
        {
            v[i].emplace_back(0);
        }
    }
    
    v[0][0] = triangle[0][0];
    
    for(int i=0;i<triangle.size()-1;++i)
    {
        for(int j=0;j<triangle[i].size();++j)
        {
            int left = v[i][j] + triangle[i+1][j];
            int right = v[i][j] + triangle[i+1][j+1];
            
            v[i+1][j] = max(v[i+1][j],left);
            v[i+1][j+1] = max( v[i+1][j+1],right);
               
            answer = max(left, answer);
            answer = max(right, answer);
        }
    }
    
    
    
    
    return answer;
}