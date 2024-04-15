import random

matrix = [
    [0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0]
]
start = [3, 3]
finish = [0, 6]
#random
for i in range(0, len(matrix)):
    for j in range(0, len(matrix[i])):
        rand = random.random()
        if rand > 0.7:
            if not (i == start[0] and j == start[1]):
                if not (i == finish[0] and j == finish[1]):
                    matrix[i][j] = -1
#print
def output():
    for i in range(0, len(matrix)):
        for j in range(0, len(matrix[i])):
            print(matrix[i][j], end='\t')
        print(' ')
    print(' ')
    
output()

matrix[start[0]][start[1]] = 1

output()

check = True

while check:
    check = False
    for i in range(0, len(matrix)):
        for j in range(0, len(matrix[i])):
            if matrix[i][j] > 0:
                # print(matrix[i][j])
                # current_point - matrix[i][j]
                for y in range(i-1, i + 2):
                    for x in range(j - 1, j + 2):
                        if 0 <= y <= 7 and 0 <= x <= 6:
                                
                            # neighbour - matrix[y][x]
                            if matrix[y][x] == 0:
                                matrix[y][x] = matrix[i][j]+1
                                check = True
                                # output()
                            if matrix[y][x] >= 0:
                                if matrix[i][j] + 1 < matrix[y][x]:
                                    matrix[x][y] = matrix[i][j] + 1
                                    check = True
                                    # output()

for i in range(0, len(matrix)):
    for j in range(0, len(matrix[i])):
        print(matrix[i][j], end='\t')
    print(' ')
if(matrix[finish[0]][finish[1]])!= 0:
    print(matrix[finish[0]][finish[1]])
else:
    print('impossible')
