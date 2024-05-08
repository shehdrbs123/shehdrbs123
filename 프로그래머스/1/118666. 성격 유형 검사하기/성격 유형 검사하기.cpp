#include <string>
#include <vector>
#include <unordered_map>
#include <algorithm>
#include <iostream>

using namespace std;
char GetCharacter(unordered_map<string,int>& map, string target)
{
    auto itr = map.find(target);
    char result = target[0];
    if(itr != map.end())
    {
        if(itr->second > 0)
            result = target[1];
        else
            result = target[0];
    }
    return result;
}

string solution(vector<string> survey, vector<int> choices) {
    unordered_map<string,int> map;
    string answer = "";
    
    int choicesSize = choices.size();
    
    for(int i=0; i<choicesSize; ++i)
    {
        string name = survey[i];
        int choice = choices[i]-4;
        if(name.compare("TR") == 0 || name.compare("FC") == 0|| name.compare("MJ") == 0 || name.compare("NA") == 0)
        {
            reverse(name.begin(),name.end());
            choice *= -1;
        }
        
        auto itr = map.find(name);
        if(itr == map.end())
        {
            map.emplace(name,choice);
        }else
        {
            itr->second += choice;
        }
    }
    
    
    answer += GetCharacter(map,"RT");
    answer += GetCharacter(map,"CF");
    answer += GetCharacter(map,"JM");
    answer += GetCharacter(map,"AN");
    
    return answer;
}