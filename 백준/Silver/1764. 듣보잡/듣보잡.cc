#include <iostream>
#include <set>
using namespace std;

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);

    int N,M;
    string inputStr;
    
    set<string> compareSet{};
    set<string> resultSet{};
    
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
            resultSet.emplace(inputStr);
    }
    
    cout << resultSet.size() << '\n';
    for(string i : resultSet)
    {
        cout << i << '\n';
    }
}