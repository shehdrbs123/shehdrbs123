#include <iostream>

using namespace std;

int main(void) {
    int x,y;
    ios::sync_with_stdio(false);
    cin.tie(NULL);
    
    cin >> x >> y;
    
    for(int i=0; i<y;++i)
    {
        for(int j=0;j<x;++j)
        {
            cout << '*';
        }
        cout << '\n';
    }
    
}