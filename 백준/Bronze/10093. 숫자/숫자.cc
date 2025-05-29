#include <iostream>
#define ll unsigned long long
using namespace std;

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    ll a, b;

    cin >> a >> b;
    
    if(a>b)
    {
        ll tmp = a;
        a = b;
        b = tmp;
    }
        
    if(a==b)
        cout << "0\n";
    else
        cout << b-a-1 << '\n';
    for(a += 1; a<b; ++a)
    {
        cout << a << " ";
    }
    
}