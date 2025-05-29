#include <iostream>
#include <string>
using namespace std;

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);

    int a,b,c;

    cin >> a >> b >> c;

    int resultToNum = 0;
    int resultToStr = 0;

    resultToNum = a+b-c;
    
    string strA = to_string(a);
    string strB = to_string(b);

    strA.append(strB);

    resultToStr = stoi(strA);
    resultToStr -= c;
    
    
    cout << resultToNum << '\n';
    cout << resultToStr; 

}