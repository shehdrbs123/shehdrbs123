public class Solution {
    public int[,] solution(int[,] arr1, int[,] arr2) {
        int[,] answer;
        int y = arr1.GetLength(0);
        int x = arr1.GetLength(1);
        
        answer = new int[y,x];
        
        for(int i=0;i<y;i++)
        {
            for(int j=0;j<x;j++)
            {
                answer[i,j] = arr1[i,j] + arr2[i,j];
            }
        }
        return answer;
    }
}