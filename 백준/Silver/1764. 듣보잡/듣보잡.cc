#include <iostream>
#include <set>
#include <vector>
#include <algorithm>
using namespace std;

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);

    int N,M;
    string inputStr;
    
    set<string> compareSet{};
    vector<string> v{};
    
    cin >> N >> M;
    
    for(int i=0;i<N;++i)
    {
        cin >> inputStr;
        compareSet.emplace(inputStr);
    }
    
    for(int i=0;i<M;++i)
    {
        cin >> inputStr;
        if(compareSet.find(inputStr) != compareSet.end())
            v.emplace_back(inputStr);
    }

    sort(v.begin(),v.end(),less<string>());
    
    cout << v.size() << '\n';
    for(string i : v)
    {
        cout << i << '\n';
    }
}