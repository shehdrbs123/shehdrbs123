#include <iostream>
#include <cmath>


void nQueen(int* pData, int nLength, int y, int* ans);
bool isProving(const int* pData, int y);

using namespace std;
int main()
{
    int n_Num{};
    int* queenList{};
    int result{};

    cin >> n_Num;
    queenList = new int[n_Num] {};


    nQueen(queenList, n_Num, 0, &result);
    
    printf("%d", result);

    delete [] queenList;
}

void nQueen(int* pData, int nLength, int y, int * ans)
{
    if (y >= nLength)
    {
        (*ans)++;
        return;
    }

    for (int row = 0; row < nLength; row++)
    {
        pData[y] = row;
        if (isProving(pData, y))
            nQueen(pData, nLength, y+1, ans);
    }
}

bool isProving(const int* pData, int y)
{
    for (int y1 = y - 1; y1 >= 0; y1--) 
    {
        if (pData[y1] == pData[y] || abs(pData[y1] - pData[y]) == abs(y1 - y))
            return false;
    }
    return true;
}
