#include <iostream>
#include <algorithm>
using namespace std;


char str[11];
int strSize=0;
bool isCorrect()
{
    if(strSize == 0)
        return false;
    
    char preChar = str[0];
    
    for(int i=1;i<strSize;++i)
    {
        if(preChar == str[i])
            return false;
        preChar = str[i];
    }
    return true;
}

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    cin >> str;
    int result = 0;
    for(int i=0;;++i)
    {
        if(str[i] == '\0')
            break;
        ++strSize;
    }

    sort(str,str+strSize);

    do
    {
        if(isCorrect())
            ++result;
    }while(next_permutation(str,str+strSize));
    
    
    cout << result;
    
}