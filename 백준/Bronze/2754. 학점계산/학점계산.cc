#include <iostream>
#include <map>

using namespace std;

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    map<string,string> m;
    m.emplace("A+","4.3");
    m.emplace("A0","4.0");
    m.emplace("A-","3.7");
    m.emplace("B+","3.3");
    m.emplace("B0","3.0");
    m.emplace("B-","2.7");
    m.emplace("C+","2.3");
    m.emplace("C0","2.0");
    m.emplace("C-","1.7");
    m.emplace("D+","1.3");
    m.emplace("D0","1.0");
    m.emplace("D-","0.7");
    m.emplace("F","0.0");

    string a;
    cin >> a;
    
    auto itr = m.find(a);
    cout << itr->second;
}