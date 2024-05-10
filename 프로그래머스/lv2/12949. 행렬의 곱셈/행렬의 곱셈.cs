using System;

public class Solution {
    public int[,] solution(int[,] arr1, int[,] arr2) {
        int[,] answer;
        
        int arr1Row = arr1.GetLength(0);
        int arr2Row = arr2.GetLength(0);
        int arr1Col = arr1.GetLength(1);
        int arr2Col = arr2.GetLength(1);
        
        if(arr1Col != arr2Row)
        {
            int[,] tmp = arr1;
            arr1 = arr2;
            arr2 = tmp;
        }
        
        answer = new int[arr1Row,arr2Col];
        
        for(int i=0;i<arr1Row;++i)
        {
            for(int j=0;j<arr2Col;++j)
            {
                int result= 0;
                for(int k=0;k<arr1Col;++k)
                {
                    result += arr1[i,k]* arr2[k,j];
                }
                answer[i,j] = result;
            }
        }
        
        return answer;
    }
    // 3*2 2*2
    // 3*3 3*3
    // 2*3 2*2
    // 2*2 2*3
}