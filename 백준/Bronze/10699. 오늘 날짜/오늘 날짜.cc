#include <iostream>
#include <iomanip>
#include <ctime>
using namespace std;

int main()
{
    ios::sync_with_stdio(0);
    cin.tie(0);
    
    time_t timer = time(NULL);
    timer += 3600*9;
    struct tm* t = localtime(&timer);
    
    cout << setfill('0');
    cout << setw(4)<< 1900+t->tm_year << "-" 
        << setw(2) << t->tm_mon+1 << "-" 
        << setw(2) << t->tm_mday;
        //<< setw(2) << t->tm_hour << ":" 
        //<< setw(2) << t->tm_min << ":" 
        //<< setw(2) << t->tm_sec;
    
}