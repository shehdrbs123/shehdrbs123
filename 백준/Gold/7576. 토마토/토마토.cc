#include <bits/stdc++.h>

using namespace std;

int board[1002][1002];
//int dis[1002][1002];
int x,y;
int dx[] = {0,1,0,-1};
int dy[] = {1,0,-1,0};

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    int tomatoCount = 0;
    int makeRipeTomato = 0;
    int alreadyDone = 1;
    int result = 1;
    queue<pair<int,int>> Q; 
    cin >> y >> x;
   
    tomatoCount = x*y;
    
    for(int i=0;i<x;++i)
    {
        for(int j=0;j<y;++j)
        {
            cin >> board[i][j];
            if(board[i][j] == -1)
                tomatoCount -= 1;
            else if(board[i][j] == 1)
            {
                makeRipeTomato += 1;
                Q.push({i,j});
            }
        }
    }
    
    
    while(!Q.empty())
    {
        alreadyDone=0;
        pair<int,int> cur = Q.front(); Q.pop();
        
        for(int dir=0;dir<4;++dir)
        {
            int nx = dx[dir] + cur.first;
            int ny = dy[dir] + cur.second;
            
            if(nx <0 || nx >= x || ny < 0 || ny >= y) continue;
            //if(dis[nx][ny] != 0) continue;
            if(board[nx][ny] != 0) continue;
            
            board[nx][ny] = board[cur.first][cur.second]+1;
            Q.push({nx,ny});
            
            makeRipeTomato+=1;
            result = max(result,board[nx][ny]);
        }
    }
    
    if(tomatoCount > makeRipeTomato)
        result = 0;
        
    cout << result-1;
}