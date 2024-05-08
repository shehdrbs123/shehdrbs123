def solution(n, computers):
    visit = [i for i in range(n)]
    
    for i in range(n) :
        makeNetwork(visit, n, computers[i],i);
    answer = set()
    for i in range(len(visit)) :
        find(visit,i)
        
    for i in visit :
        answer.add(i)
        
    return len(answer)
        
def makeNetwork(visit, n, computer,currentNode) :    
    for i in range(n) :
        if computer[i] == 1 and i != currentNode :
            union(visit, currentNode, i)
            

def find(parent, x) :
    if parent[x] == x :
        return x
    else :
        y = find(parent,parent[x]);
        parent[x] = y;
        return y;


def union(parent,x,y) :
    x = find(parent,x);
    y = find(parent,y);
    
    if x == y :
        return;
    
    if parent[x] < parent[y] :
        parent[y] = x
    else :
        parent[x] = y
  
