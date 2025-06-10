#include <iostream>

using namespace std;

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    cout << fixed;
    cout.precision(2);
    
    while(true)
    {
        double num;
        cin >> num;
        if(num == 0)
            break;
        
        double result = 1 + num + num*num + num*num*num + num*num*num*num;
        cout << result << '\n';
    }
}