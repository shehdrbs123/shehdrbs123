#include <string>
#include <vector>
#include <iostream>
#include <cmath>
using namespace std;

void print(vector<string>& strs)
{
    for(auto a : strs)
    {
        cout << a << " ";
    }
    cout << endl;
}

int GetLength(int strSize, int count)
{
    int length = 0;
    if(count == 1)
    {
        length = strSize;
    }
    else
    {
        int digitCount=0;
        while(count>0)
        {
            ++digitCount;
            count /= 10;
        }
        length = strSize+digitCount;
    }
    return length;
}

int solution(string s) {
    int answer = s.size();
    int size= s.size();
    
    for(int i=1;i<size;++i)
    {
        int vLength = ceil((float)size/i);
        vector<string> v;
        v.reserve(vLength);
        int j=0;
        for(;j<size;j+=i)
        {
            string sub = s.substr(j,i);
            v.emplace_back(sub);
        }
        //print(v);
        
        int p = 0;
        int count = 1;
        int comLength = 0;
        for(int j=1;j<vLength;++j)
        {
            if(v[p] != v[j])
            {
                comLength += GetLength(v[p].size(),count);
                p = j;
                count = 1;
                if(j == vLength-1 )
                    comLength += GetLength(v[p].size(),count);
            }
            else
            {
                ++count;
                if(j == vLength-1 )
                    comLength += GetLength(v[p].size(),count);
            }
        }

        
        answer = min(answer,comLength);
    }
    return answer;
}