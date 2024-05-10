public class Program
{
    public static void Main()
    {
        string inputString;
        float totalScore = 0;
        float totalEdu=0;
        
        while(true)
        {
            string[] splitString;
            float eduScore = 0;
            float score=0.0f;
            
            inputString = Console.ReadLine();
            if(inputString== null || inputString=="")
                break;
            splitString = inputString.Split();
            
            
            eduScore = float.Parse(splitString[1]);
            switch(splitString[2])
            {
                case "A+" :
                    score = 4.5f;
                    break;
                case "A0" :
                    score = 4.0f;
                    break;
                case "B+" :
                    score = 3.5f;
                    break;                    
                case "B0" :
                    score = 3.0f;
                    break;
                case "C+" :
                    score = 2.5f;
                    break;                    
                case "C0" :
                    score = 2.0f;
                    break;
                case "D+" :
                    score = 1.5f;
                    break;                    
                case "D0" :
                    score = 1.0f;
                    break;
                case "F" :
                    break;
            }

            if (splitString[2] != "P")
            {
                totalScore+=score*eduScore;
                totalEdu += eduScore;
            }
        }
        
        Console.WriteLine(Math.Round(totalScore/totalEdu,6));
    }
}