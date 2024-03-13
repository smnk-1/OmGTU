Us=[1, 2, 3, 4, 5]
#U=[[1, 2], [1, 3], [1, 4], [1,5], [2, 1], [2, 3], [2, 4], [2, 5], [3, 1], [3, 2], [3, 4], [3, 5], [4, 1], [4, 2], [4, 3], [4, 5], [5, 1], [5, 2], [5, 3], [5, 4]]
#W = [41, 80, 23, 32, 5, 45, 12, 37, 80, 45, 50, 64, 23, 12, 50, 67, 32, 37, 64, 67]
#start = 5
#finish = 2
U = [[1, 2], [1, 4], [1, 5], [2, 3], [3, 5], [4, 3], [4, 5]]
W = [10, 30, 100, 50, 10, 20, 60]
start = 1
finish = 5
s = [start]
minDistances = {start:0}
ind = 0

used = [1]
for i in range(len(U)):
    if U[i][0] == start:
        minDistances[U[i][1]] = W[i]
        used.append(U[i][1])
print(minDistances)
print(used)
for i in Us:
    if used.count(i)==0:
        minDistances[i] = float('inf')

while True:
    print(s)
    print(minDistances)
    
    currentElement = s[ind]
    print("current: ", end='')
    print(currentElement)
    possibleUs = []
    possibleWeights = []
    
    for i in range(len(U)):
        if U[i][0]==currentElement:
            possibleUs.append(U[i][1])
            possibleWeights.append(W[i])
            
    print("possible: ", end='')
    print(possibleUs, end=', ')
    print(possibleWeights)
    
    for i in possibleUs:
        if s.count(i) == 0:
            print(i, end=' =>')
            value = min(minDistances[i], minDistances[currentElement] + possibleWeights[possibleUs.index(i)])
            print(value)
            minDistances[i] = value

    minW = float('inf')
    for key, value in minDistances.items():
        if s.count(key)==0:
            if value < minW:
                minW = value
                minU = key
    
    if minU != finish:
        s.append(minU)
        ind += 1
        print(' ')
    else:
        minDistances[minU] = (minDistances[minU] + possibleWeights.index(min(possibleWeights)))
        break
    
print('result:')
print(minDistances[finish])
