#include <iostream>
#include <algorithm>
#include <vector>

using namespace std;

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    int n,m;
    cin >> n >> m;
    
    vector<int> v(n);
    
    for(int i=0;i<m;++i)
    {
        v[i] = -1;
    }
    
    do
    {
        for(int i=0;i<n;++i)
        {
            if(v[i] == -1)
                cout << i+1 << ' ';
        }
        cout << '\n';
    }while(next_permutation(v.begin(),v.end()));
    
    
}