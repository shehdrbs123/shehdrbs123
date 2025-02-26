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

string strs[20001];
// set으로 중복 체크, static 배열에 바로 넣기
int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    int num=0;
    int strsLength = 0;
    set<string> s{};

    cin >> num;
    cin.ignore();
    
    for(int i=0;i<num;++i)
    {
        string inputStr;
        getline(cin,inputStr);
        if(s.emplace(inputStr).second)
        {
            strs[strsLength] = inputStr;    
            ++strsLength;
        }
    }

    sort(strs,strs+strsLength,compare);
    
    for(int i=0;i<strsLength;++i)
    {
        cout << strs[i] << '\n';
    }
}