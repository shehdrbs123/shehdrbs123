#include <iostream>
#include <cmath>
using namespace std;
int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    int t;
    cin >> t;
    
    for(int i=0; i<t;++i)
    {
        int a1,p1,a2,p2;
        double ppp1, ppp2;
        cin >> a1 >> p1;
        cin >> a2 >> p2;
        
        a2 = a2*a2*M_PI;
        
        ppp1 = a1 / p1;
        ppp2 = a2 / p2;
        if(ppp1 > ppp2)
        {
            cout << "Slice of pizza\n";
        }else
        {
            cout << "Whole pizza\n";
        }
    }
}