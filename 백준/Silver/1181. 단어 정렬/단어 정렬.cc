#include <iostream>
#include <set>
#include <vector>
#include <algorithm>
using namespace std;

bool compare(string i, string j) 
{
    if(i.length() == j.length())
        return i.compare(j) < 0;
    return i.length() < j.length();
}

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    int num=0;
    cin >> num;
    cin.ignore();
    
    set<string> s{};
    for(int i=0;i<num;++i)
    {
        string inputStr;
        getline(cin,inputStr);
        s.emplace(inputStr);
    }
    vector<string> v(s.begin(),s.end());
    
    sort(v.begin(),v.end(),compare);
    
    for(string i : v)
    {
        cout << i << '\n';
    }
}