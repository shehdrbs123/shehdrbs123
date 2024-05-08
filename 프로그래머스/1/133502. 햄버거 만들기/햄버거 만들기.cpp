#include <string>
#include <vector>

using namespace std;

int solution(vector<int> ingredient) {
    vector<int> stack;
    int hamberger[] = {1,2,3,1};
    int answer = 0;
    int stackedCount = 0 ;
    int ingredientSize = ingredient.size();
    
    for(int i=0;i<ingredientSize;++i)
    {
        ++stackedCount;
        stack.emplace_back(ingredient[i]);
        if(stackedCount >= 4)
        {
            bool isHamberger=true;
            for(int j=0;j<4;++j)
            {
                if(stack[stackedCount-1-j] != hamberger[3-j])
                {
                    isHamberger=false;
                    break;
                }
            }
            
            if(isHamberger)
            {
                for(int j=0;j<4;++j)
                {
                    stack.pop_back();
                }
                stackedCount-=4;
                ++answer;
            }
        }
    }
    
    return answer;
}