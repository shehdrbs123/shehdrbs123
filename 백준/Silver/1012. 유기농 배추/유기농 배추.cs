public class Program
{
    public static void Main(string[] args)
    {
        string[] splitString;
        int[,] field;
        List<Point> cavages;
        Queue<Point> q = new Queue<Point>();
        int inputCount;
        
        inputCount = int.Parse(Console.ReadLine());
        for(int i=0;i<inputCount;++i)
        {
            int xSize,ySize, wormsCount;
            int result=0;
            
            splitString = Console.ReadLine().Split();
            xSize = int.Parse(splitString[0]);
            ySize = int.Parse(splitString[1]);
            
            wormsCount = int.Parse(splitString[2]);
            cavages = new List<Point>();
            field = new int[ySize+2,xSize+2];
            
            // 필요 데이터 가공
            for(int j=0;j<wormsCount;j++)
            {
                Point pos;
                int x, y;
                
                splitString = Console.ReadLine().Split();
                x = int.Parse(splitString[0])+1;
                y = int.Parse(splitString[1])+1;
                pos = new Point(x,y);
                
                field[y,x] = 1;
                cavages.Add(pos);
            }
            
            foreach(var cavage in cavages)
            {
                if(field[cavage.y,cavage.x] == 1)
                {
                    q.Enqueue(cavage);
                    field[cavage.y,cavage.x] = 0;
                    while(q.Count > 0)
                    {
                        Point p = q.Dequeue();
                        if(field[p.y,p.x+1] == 1)
                        {
                            Point right = cavages.Find((x) => x.x == p.x+1 && x.y == p.y);
                            field[p.y, p.x + 1] = 0;
                            q.Enqueue(right);
                        }
                        if(field[p.y,p.x-1] == 1)
                        {
                            Point left = cavages.Find((x) => x.x == p.x-1 && x.y == p.y);
                            field[p.y, p.x - 1] = 0;
                            q.Enqueue(left);
                        }
                        if(field[p.y+1,p.x] == 1)
                        {
                            Point down = cavages.Find((x) => x.x == p.x && x.y == p.y+1);
                            field[p.y+1, p.x] = 0;
                            q.Enqueue(down);
                        }
                        if(field[p.y-1,p.x] == 1)
                        {
                            Point up = cavages.Find((x) => x.x == p.x && x.y == p.y-1);
                            field[p.y-1, p.x] = 0;
                            q.Enqueue(up);
                        }
                    }
                    result+=1;
                }
            }
            Console.WriteLine(result);
        }
    }
    
    public class Point
    {
        public int x;
        public int y;

        public Point(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }
    }
}