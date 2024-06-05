matrix = [
    [0, 1, 1, 1, 0, 0, 0],
    [1, 0, 1, 0, 1, 0, 1],
    [1, 1, 0, 1, 1, 1, 1],
    [1, 0, 1, 0, 1, 1, 1],
    [0, 1, 1, 1, 0, 1, 0],
    [0, 0, 1, 1, 1, 0, 1],
    [0, 1, 1, 1, 0, 1, 0]
]
V = [1, 2, 3, 4, 5, 6, 7]
S = [V[0]]
banned_v = 0
while True:
    if len(S) != 0:
        if len(S) != len(V):
            flag = False
            for i in range(0, len(matrix[S[-1]-1])):
                if matrix[S[-1]-1][i] == 1 and S.count(i+1) == 0 and i > banned_v-1:
                    S.append(i+1)
                    banned_v = 0
                    flag = True
                    break
            if not flag:
                banned_v = S[-1]
                S.pop(-1)
        else:
            if matrix[S[-1]-1][S[0]-1] == 1:
                print("Cycle", S)
                break
            else:
                print("Way", S)
            banned_v = S[-1]
            S.pop(-1)
    else:
        break
