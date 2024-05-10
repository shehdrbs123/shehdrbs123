using System;
using System.Collections.Generic;

public class Solution {
    public string[] solution(string[] players, string[] callings) {
        string[] answer = new string[] {};
        Dictionary<string,int> playerIndex = new Dictionary<string,int>();
        
        
        for(int i=0;i<players.Length;++i)
        {
            playerIndex.Add(players[i],i);
        }
        
        for(int i=0;i<callings.Length;++i)
        {
            string overTake = callings[i];
            int currentIdx=playerIndex[overTake];
            int overTakedIdx = currentIdx -1;
            if(overTakedIdx >= 0)
            {
                string overTaked = players[overTakedIdx];
                players[overTakedIdx] = overTake;
                players[currentIdx] = overTaked;
                
                playerIndex[overTake] = overTakedIdx;
                playerIndex[overTaked] = currentIdx;
            }
        }
        
        return players;
    }
    // 이전 풀이
    public string[] solution2(string[] players, string[] callings) {
        string[] answer = new string[] {};
        int callingLength = callings.Length;
        int playerLength= players.Length;
            
        Dictionary<string,int> dic = new  Dictionary<string,int>();

        for(int i=0;i<playerLength;i++)
        {
            dic.Add(players[i],i);
        }

        for(int i=0;i<callingLength;i++)
        {
            string SrcString;
            int FoundIndex;

            SrcString = callings[i];
            FoundIndex = dic[SrcString];
            dic[SrcString]--;
            dic[players[FoundIndex-1]]++;

            swap(players,FoundIndex,FoundIndex -1);

        }
        return players;
    }

    private void swap(string[] array, int SrcIdx, int DstIdx)
    {
        string DstString = array[SrcIdx];
        array[SrcIdx] = array[DstIdx];
        array[DstIdx] = DstString;
    }
}