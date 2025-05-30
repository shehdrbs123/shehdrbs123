#include <iostream>

using namespace std;

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    int start, end, totalPage, result=0;
    cin >> start >> end;
    
    totalPage = end - start + 1;
    
    if(start%2 == 0)
    {
        result +=1;
        totalPage -= 1;
    }
    
    if(end%2 == 1)
    {
        result +=1;
        totalPage -= 1;
    }
    
    result += totalPage/2;
    
    cout << result;
        
}