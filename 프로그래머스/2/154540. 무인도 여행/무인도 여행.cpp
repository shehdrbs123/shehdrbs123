#include <string>
#include <vector>
#include <queue>
#include <algorithm>
#include <iostream>

using namespace std;
bool visited[102][102];
int dx[] = {0,1,0,-1};
int dy[] = {1,0,-1,0};

vector<int> solution(vector<string> maps) {
    vector<int> answer;
    queue<pair<int,int>> q;
    
    for(int i=0;i<maps.size();++i)
    {
        int strSize = maps[i].size();
        for(int j=0;j<strSize;++j)
        {
            int result{};
            if(maps[i][j] != 'X' && visited[i][j] != true)
            {
                q.emplace(i,j);
                result+=maps[i][j]-'0';
                visited[i][j] = true;
            }
            
            while(!q.empty())
            {
                pair<int,int> pos = q.front(); q.pop();
                
                for(int dir=0;dir < 4; ++dir)
                {
                    int nx = dx[dir] + pos.first;
                    int ny = dy[dir] + pos.second;
                    
                    if(nx < 0 || nx >= maps.size() || ny < 0|| ny >= maps[i].size()) continue;
                    if(maps[nx][ny] == 'X' || visited[nx][ny] == true) continue;
                    
                    visited[nx][ny] = true;
                    result += maps[nx][ny]-'0';
                    q.emplace(nx,ny);
                }
                
            }
            
            if(result > 0)
                answer.emplace_back(result);
        }
    }
    
    if(answer.size() > 0)
    {
        sort(answer.begin(),answer.end());    
    }else
        answer.emplace_back(-1);
    
    
    return answer;
}