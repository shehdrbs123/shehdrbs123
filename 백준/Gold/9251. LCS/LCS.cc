#include <iostream>

using namespace std;

int dp[1001][1001];
int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    string input1;
    string input2;
    
    cin>>input1;
    cin>>input2;
    
    int aSize = input1.size();
    int bSize = input2.size();
    
    if(aSize > bSize)
    {
        int tmp = aSize;
        aSize = bSize;
        bSize = tmp;

        string tmpInput = input1;
        input1 = input2;
        input2 = tmpInput;
    }
        
    
    for(int i=1;i<=aSize;++i)
    {
        for(int j=1;j<=bSize;++j)
        {
            char a = input1[i-1];
            char b = input2[j-1];
            if(a == b)
            {
                dp[i][j] = max(dp[i][j-1],dp[i-1][j-1]+1);
            }
            else
            {
                dp[i][j] = max(dp[i-1][j],dp[i][j-1]);
            }
        }
    }
    
    cout << dp[aSize][bSize];
}