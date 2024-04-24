def output():
    for i in range(0, len(matrix)):
        for j in range(0, len(matrix[i])):
            print(matrix[i][j], end='\t')
        print(' ')
    print(' ')
    
def count_deltas(y, x):
    sum1 = []
    sum2 = []
    for i in range(0, len(matrix)):
        if i != y and i != x:
            sum1.append(matrix[i][x])
    for j in range(0, len(matrix[i])):
        if j != x and j != y:
            sum2.append(matrix[y][j])
    return min(sum1) + min(sum2)
# сумма минимальных по столбцам и строкам - минимальная граница

# нахождение степеней нулей (минимальное значение в строке и столбце за исключением этого элемента)

# куда берем ноль с максимальной степенью - мин граница, в другую сторону прибавляем степень нуля к мин границе

# уничтожаем строку и столбец и добавляем ячейку бесконечности
# на итерации: минимумы по строке, уменьшили, минимумы по слобцам, уменьшили, сложили, посчитали оценку, посчитали степени нуля, выбрали наибольшую
inf = float('inf')
matrix = [ 
    [inf, 41, 80, 23, 32], 
    [41, inf, 45, 12, 37],
    [80, 45, inf, 50, 64],
    [23, 12, 50, inf, 67],
    [32, 37, 64, 67, inf]
    ]
# alpha count
alpha = [min(x) for x in matrix]
print(alpha)
# - alpha 
for i in range(0, len(matrix)):
    for j in range(0, len(matrix[i])):
        if matrix[i][j] != inf:
            matrix[i][j] = matrix[i][j]-alpha[i]
print("after alpha")
output()

#beta count
beta = [x for x in matrix[0]]
for i in range(1, len(matrix)):
    for j in range(0, len(matrix[i])):
        beta[j] = min(beta[j], matrix[i][j])
print(beta)

# - beta
for i in range(0, len(matrix)):
    for j in range(0, len(matrix[i])):
        if matrix[i][j] != inf:
            matrix[i][j] = matrix[i][j]-beta[j]
print("after beta")
output()

marl = sum(alpha + beta)
deltas = []

for i in range(0, len(matrix)):
    for j in range(0, len(matrix[i])):
        if matrix[i][j] == 0:
            deltas.append([i, j, count_deltas(i, j)])
print(deltas)
max_delta = 0
for i in range(1, len(deltas)):
    if deltas[i][2] > deltas[max_delta][2]:
        max_delta = i
print(max_delta)
