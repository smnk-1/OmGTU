import random

# def count_zeros():
#     global matrix
#     count = 0
#     for x in range(0, len(matrix)):
#         count += matrix[i].count(0)
#     return count
#
#
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
start = [0, 0]
finish = [7, 6]

for i in range(0, len(matrix)):
    for j in range(0, len(matrix[i])):
        rand = random.random()
        if rand > 0.7:
            if not (i == start[0] and j == start[1]):
                if not (i == finish[0] and j == finish[1]):
                    matrix[i][j] = -1

for i in range(0, len(matrix)):
    for j in range(0, len(matrix[i])):
        print(matrix[i][j], end='\t')
    print(' ')

start = 1
check = True
while check:
    check = False
    for i in range(0, len(matrix)):
        for j in range(0, len(matrix[i])):
            if matrix[i][j] >= 0:
                # current_point - matrix[i][j]
                for y in range(i-1, i + 2):
                    for x in range(j - 1, j + 2):
                        if 0 <= y <= 7 and 0 <= x <= 6:
                            # neighbour - matrix[y][x]
                            # to do if 0 - +1, else - min

for i in range(0, len(matrix)):
    for j in range(0, len(matrix[i])):
        print(matrix[i][j], end='\t')
    print(' ')
