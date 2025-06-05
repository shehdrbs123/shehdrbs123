#include <iostream>
#include <string>

using namespace std;

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    int t;
    cin >> t;
    for(int i=0;i<t;++i)
    {
        long long num1, num2, result,realResult;
        char cal,tmp;
        cin >> num1 >> cal >> num2 >> tmp >> result;
        
        switch(cal)
        {
            case '*' :
                realResult = num1 * num2;
                break;
            case '-' :
                realResult = num1 - num2;
                break;
            case '+' :
                realResult = num1 + num2;
                break;
            case '/' :
                realResult = num1 / num2;
                break;
            default :
                break;
        }
        
        if(realResult == result)
        {
            cout << "correct\n";
        }else
        {
            cout << "wrong answer\n";
        }
    }
}