Us=[1, 2, 3, 4, 5]
U = [[1, 2], [1, 4], [1, 5], [2, 3], [3, 5], [4, 3], [4, 5]]
W = [10, 30, 100, 50, 10, 20, 60]
start, finish = 1, 5
s = [start]
minDistances = {start:0}
ind = 0
used = [1]

for i in range(len(U)):
    if U[i][0] == start:
        minDistances[U[i][1]] = W[i]
        used.append(U[i][1])

for i in Us:
    if used.count(i)==0:
        minDistances[i] = float('inf')

while True:
    currentElement = s[ind]
    possibleUs = []
    possibleWeights = []
    
    for i in range(len(U)):
        if U[i][0]==currentElement:
            possibleUs.append(U[i][1])
            possibleWeights.append(W[i])

    for i in possibleUs:
        if s.count(i) == 0:
            value = min(minDistances[i], minDistances[currentElement] + possibleWeights[possibleUs.index(i)])
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
    else:
        minDistances[minU] = (minDistances[minU] + possibleWeights.index(min(possibleWeights)))
        break

result = minDistances[finish]
print(f'result: {result}')
print(minDistances)

way = [finish]

for i in range(0, len(Us)):
    leng = 0
    pair = [Us[i], way[-1]]
    for j in range(len(U)):
        if U[j] == pair:
            leng = W[j]
            break
    if minDistances[Us[i]] + leng == result:
        way.append(Us[i])
        result -= leng
way.append(start)
print(way)
