#include <iostream>

using namespace std;

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    while(true)
    {
        long long a,b,c;
        cin >> a >> b >> c;
        if(a == 0 && b == 0 && c == 0)
            break;
        
        long long aSqr = a*a;
        long long bSqr = b*b;
        long long cSqr = c*c;

        if(aSqr + bSqr == cSqr || aSqr+cSqr == bSqr || bSqr+cSqr == aSqr)
            cout << "right\n";
        else
            cout << "wrong\n";
    }
}