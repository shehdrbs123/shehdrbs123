#include <iostream>

using namespace std;

int alpha[26];
int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    int n, strSize=0, result = 0;
    cin >> n;
    
    string str;
    cin >> str;
    
    strSize = str.size();
    
    for(int i=0;i<strSize;++i)
    {
        int idx = str[i]-'A';
        ++alpha[idx];
    }
    
    result = alpha['H'-'A'];
    if(result > alpha['I'-'A'])
    {
        result = alpha['I'-'A'];
    }
    if(result > alpha['A'-'A'])
    {
        result = alpha['A'-'A'];
    }
    if(result > alpha['R'-'A'])
    {
        result = alpha['R'-'A'];
    }
    if(result > alpha['C'-'A'])
    {
        result = alpha['C'-'A'];
    }
    cout << result;
}