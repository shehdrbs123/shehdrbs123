using System;
using System.Collections;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string[] wallpaper) {
        int[] answer;
        
        solve(wallpaper,out answer);

        return answer;
    }
    
    private void solve(string[] wallpaper, out int[] answer)
    {
        int minX=int.MaxValue, maxX=int.MinValue;
        int minY=minX, maxY=maxX;
        
        answer = new int[4];
        for(int i=0;i<wallpaper.Length;++i)
        {
            string line = wallpaper[i];
            for(int j=0;j<line.Length;++j)
            {
                char isFile = line[j];
                if(isFile == '#')
                {
                    minX = Math.Min(minX,j);
                    minY = Math.Min(minY,i);
                    maxX = Math.Max(maxX,j+1);
                    maxY = Math.Max(maxY,i+1);
                }
            }
        }
        
        answer[0] = minY;
        answer[1] = minX;
        answer[2] = maxY;
        answer[3] = maxX;
    }

    
    //이전 풀이
    private void GetFilesPos(string[] wallpaper,List<Tuple<int,int>> files)
    {
        if(files == null)
            files = new List<Tuple<int, int>>();

        for(int i=0;i<wallpaper.Length;i++)
        {
            string wallpaperRow = wallpaper[i];
            for(int j=0;j<wallpaperRow.Length; j++)
            {
                if(wallpaperRow[j] == '#')
                {
                    files.Add(new Tuple<int, int>(i,j));
                }
            }
        }
        //files.ForEach( x => Console.WriteLine(x.Item1 + " " + x.Item2));
    }

    private void GetDragRange(List<Tuple<int,int>> filesPos,int[] answer)
    {
        int xMax, xMin;
        int yMax, yMin;
        xMin = filesPos[0].Item1;
        xMax = filesPos[0].Item1+1;
        yMin = filesPos[0].Item2;
        yMax = filesPos[0].Item2+1;
        filesPos.RemoveAt(0);

        filesPos.ForEach( (x) => {
            if(x.Item1+1 > xMax)
            {
                xMax = x.Item1+1;
            }
            else if (x.Item1 < xMin)
            {
                xMin = x.Item1;
            }

            if(x.Item2+1 > yMax)
            {
                yMax = x.Item2+1;
            }
            else if(x.Item2 < yMin)
            {
                yMin = x.Item2;
            }
        });

        answer[0] = xMin;
        answer[1] = yMin;
        answer[2] = xMax;
        answer[3] = yMax;   
    }
}