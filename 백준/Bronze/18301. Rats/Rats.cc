#include <iostream>
#include <cmath>

using namespace std;
int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    int n1,n2,n12;
    cin >> n1 >> n2 >> n12;
    
    cout << (int)round((n1+1)*(n2+1)/(n12+1)-1);
}