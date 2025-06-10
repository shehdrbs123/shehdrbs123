#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int num[1000001];
int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    int N;
    cin >> N;
    
    for(int i=0;i<N;++i)
    {
        cin >> num[i];
    }
    
    vector<int> v;
    v.reserve(1000001);

    v.emplace_back(num[0]);

    for(int i=1;i<N;++i)
    {
        if(v[v.size()-1] < num[i])
        {
            v.emplace_back(num[i]);
        }else
        {
            auto itr = lower_bound(v.begin(),v.end(),num[i]);
            *itr = num[i];
        }
    }

    cout << v.size();
}