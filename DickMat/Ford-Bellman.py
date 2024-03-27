Us = [1, 2, 3, 4, 5]
U = [[1, 2], [1, 5], [2, 3], [2, 4], [2, 5], [3, 4], [3, 5], [4, 3], [5, 4]]
W = [1, 3, 8, 7, 1, 1, 5, 2, 4]
n = len(Us)
start = 1
distances = []
# Zero iteration
for i in range(0, n):
    if i+1 == start: distances.append(0)
    else: distances.append(float('inf'))
# First and more iteration
for i in range(0, n-1):
    if distances[i] != float('inf'):
        current_distance = distances[i]
        u = i+1
        for j in range(0, len(U)):
            if U[j][0] == u:
                v = U[j][1]
                additional_distance = W[j]
                if distances[v-1] > current_distance + additional_distance:
                    distances[v-1] = current_distance+additional_distance
# Check iteration
distances_backup = distances
if distances[i] != float('inf'):
        current_distance = distances[i]
        u = i+1
        for j in range(0, len(U)):
            if U[j][0] == u:
                v = U[j][1]
                additional_distance = W[j]
                if distances[v-1] > current_distance + additional_distance:
                    distances[v-1] = current_distance+additional_distance
if distances != distances_backup:
    print('Cirle with negative weight')
else:
    print(distances)
    for finish in range(1, n+1):
        if finish != start:
            way = [finish]
            result = distances[finish-1]
            while result != 0:
                for i in range(0, len(Us)):
                    leng = 0
                    pair = [Us[i], way[-1]]
                    for j in range(len(U)):
                        if U[j] == pair:
                            leng = W[j]
                            break
                    if distances[Us[i]-1] + leng == result:
                        way.append(Us[i])
                        result -= leng
            print(f'{finish} : {way}')
