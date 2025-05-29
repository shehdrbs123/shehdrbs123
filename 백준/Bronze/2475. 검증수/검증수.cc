#include <iostream>

using namespace std;

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);

    int num[5];

    for(int i=0;i<5;++i)
    {
        cin >> num[i];
    }

    int result = 0;
    for(int i=0;i<5;++i)
    {
        result += num[i] * num[i];
    }

    cout << result % 10;
}