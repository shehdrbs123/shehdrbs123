using System;
using System.Text;

public class Solution {
    public string solution(string number, int k) {
        
        //빠른 아이디어를 직접 코드로 써보기
        number = 9 + number;
        StringBuilder sb = new StringBuilder(number);
        int index=0;
        for(int i=0;i<k;++i)
        {
            while(true)
            {
                if(index+1 == sb.Length)
                {
                    sb.Remove(index,1);
                    index--;
                    break;
                }
                
                if(sb[index] < sb[index+1])
                {
                    sb.Remove(index,1);
                    index--;
                    break;
                }
                index++;
            }
        }
        
        return sb.Remove(0,1).ToString();
       /* 
        StringBuilder sb =new StringBuilder();
        int i=0;
        for(; number.Length-i>k; i++){
            int maxIdx=i;
            for(int j = i;j<=i+k;j++){
                if(number[j]>number[maxIdx]){
                    maxIdx = j;
                }
                Console.Write($"{number[maxIdx]} ");
            }
            Console.WriteLine();
            k-= maxIdx-i;
            sb.Append(number[maxIdx]);
            i = maxIdx;
            //Console.WriteLinS(sb.ToString());
        }
        if(number.Length-i>0 && k == 0){
            sb.Append(number.Substring(i,number.Length-i));
        }
        
        return sb.ToString();
        */
        
         // 다른 분꺼 속도좀 보고싶어서 확실히 빠르다... ㅜㅜ 내꺼보다 절반은 빠르넵
         // 바로 옆 숫자 하고만 비교해서 옆보다 큰것들만 남겼는데 되네..
        /*
        string answer = "";
            number = "9" + number;
            StringBuilder sb = new StringBuilder(number);

            int index = 0;
            for(int i = 0; i < k; i++)
            {
                while (true)
                {
                    if(index + 1 == sb.Length)
                    {
                        sb.Remove(index, 1);
                        index--;
                        break;
                    }

                    if(sb[index] < sb[index + 1])
                    {
                        sb.Remove(index, 1);
                        index--;
                        break;
                    }
                    index++;
                    Console.WriteLine(sb.ToString());
                }
                Console.WriteLine();
            }

            return answer = sb.Remove(0,1).ToString();
        */
        // 6~10 테스트 시간초과, 시간이 줄긴함.
        /*
        string dump1;
        
        for(int i=0; i<k; ++i){
            int minIndex = 0;
            dump1 = number.Remove(0,1);
            
            for(int j=1;j<number.Length;++j){
                string dump2 = number.Remove(j,1);
                if(dump1.CompareTo(dump2)<0){
                    dump1 = dump2;
                }
            }
            number = dump1;
            //Console.WriteLine(minIndex + " " + sb.ToString());
        }
        return number;
        */
        // 6~10 테스트 시간초과
      /*  StringBuilder sb = new StringBuilder(number);
        
        StringBuilder sbEx1 = new StringBuilder();
        StringBuilder sbEx2 = new StringBuilder();
        
        for(int i=0; i<k; ++i){
            int minIndex = 0;
            sbEx1 = new StringBuilder(sb.ToString());
            sbEx1.Remove(minIndex,1);
            
            for(int j=1;j<sb.Length;++j){
                sbEx2 = new StringBuilder(sb.ToString());
                sbEx2.Remove(j,1);
                if(sbEx1.ToString().CompareTo(sbEx2.ToString())<0){
                    sbEx1 = sbEx2;
                    minIndex = j;
                }
            }
            sb.Remove(minIndex,1);
            //Console.WriteLine(minIndex + " " + sb.ToString());
        }
        
        return sb.ToString();
        */
    }
}