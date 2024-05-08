#include <bits/stdc++.h>

using namespace std;

string board[102];
int dis[102][102];
int x,y;
int dx[] = {0,1,0,-1};
int dy[] = {1,0,-1,0};

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
        
    cin >> x >> y;
    
    for(int i=0;i<x;++i)
    {
        cin >> board[i];
    }
    
    queue<pair<int,int>> Q;
    dis[0][0] = 1;
    Q.push({0,0});
    while(!Q.empty())
    {
        pair<int,int> pos = Q.front(); Q.pop();
        
        for(int dir=0;dir<4;++dir)
        {
            int nx = dx[dir] + pos.first;
            int ny = dy[dir] + pos.second;
            
            if(nx<0 || nx>=x || ny<0 || ny>=y) continue;
            if(dis[nx][ny] != 0 || board[nx][ny] != '1') continue;
            
            dis[nx][ny] = dis[pos.first][pos.second]+1;
            Q.push({nx,ny});
        }
    }
    
    cout << dis[x-1][y-1];    
}