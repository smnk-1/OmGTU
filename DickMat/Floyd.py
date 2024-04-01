Us = [1, 2, 3, 4, 5]
U = [[1, 2], [1, 3], [1, 5], [2,1], [2, 4], [3, 2], [3, 5], [4, 1], [4, 3], [4, 5], [5, 2]]
W = [5, 13, 3, 5, 12, 21, 8, 9, 4, 67, 17]
start = 5
finish = 3
graph = []

for i in range(1, len(Us)+1):
    stroka = []
    for j in range(1, len(Us)+1):
        pair = [i, j]
        if pair in U:
            stroka.append(W[U.index(pair)])
        else:
            stroka.append(float('inf'))
    graph.append(stroka)
    
start_graph = [x[:] for x in graph]

for i in range(len(Us)):
    for j in range(len(Us)):
        print(graph[i][j], end = '\t')
    print('\n')

for p in range(0, len(Us)):
    for i in range(0, len(Us)):
        for j in range(0, len(Us)):
            if i != j:
                graph[i][j] = min(graph[i][j], graph[i][p] + graph[p][j])

print(' ')
for i in range(len(Us)):
    for j in range(len(Us)):
        print(graph[i][j], end = '\t')
    print('\n')
    
print(' ')
print(f'way {start} => {finish}')
way = [finish]
result = graph[start-1][finish-1]

while result != 0:
    for i in range(0, len(Us)):
        leng = 0
        pair = [i+1, way[-1]]
        for j in range(len(U)):
            if U[j] == pair:
                leng = W[j]
        if start-1 == i:
            if leng == result:
                way.append(i+1)
                result -= leng
                break
        elif graph[start-1][i] + leng == result and leng != 0:
            way.append(i+1)
            result -= leng
print(way)
              
