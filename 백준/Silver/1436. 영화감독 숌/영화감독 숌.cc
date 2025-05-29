#include <iostream>
#include <string>
using namespace std;

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);

    int num;
    cin >> num;

    int result = 0;
    int start = 665;
    while(num != result)
    {
        ++start;
        string next = to_string(start);
        if(next.find("666") != string::npos)
        {
            ++result;
        }
    }

    cout << start;

}