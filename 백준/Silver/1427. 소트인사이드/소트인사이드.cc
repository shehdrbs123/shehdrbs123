#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    vector<int> v{};
    string inputStr{};
    
    cin >> inputStr;
    
    v.reserve(inputStr.length());
    for(int i=0;i<inputStr.length();++i)
    {
        v.emplace_back(inputStr[i]-'0');
    }
    
    sort(v.begin(),v.end(),greater<int>());
    
    for(int i : v)
    {
        cout << i;
    }
}