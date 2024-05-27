Us = [1, 2, 3, 4, 5]  # start: Us[0], finish: Us[-1],
U = [[1, 2], [1, 3], [1, 4], [2, 3], [2, 5], [3, 4], [3, 5], [4, 5]]
max_flow = [20, 30, 10, 40, 30, 10, 20, 20]
flow = []

for u in U:
    flow.append([max_flow[U.index(u)], 0])
inf = 10 ** 10
# iteration
marks = {Us[0]: [inf, 0]}
i = Us[0]
while True:
    S = []
    for u in Us:
        if U.count([i, u]) == 1 and not marks.keys().__contains__(u):
            S.append(u)
    if len(S) != 0:
        max_f = 0
        max_way = []
        for u in S:
            if max_f < flow[U.index([i, u])][0]:
                max_f = flow[U.index([i, u])][0]
                max_way = [i, u]
            # elif max_f < flow[U.index([u, i])][1]:  # backwards
            #     max_f = flow[U.index([u, i])][1]
            #     max_way = [u, i]
        print(max_f, max_way)
        
        break


        # c = max([flow[U.index([i, x])] for x in S])     # if nothing works rewrite here
        # marks[flow.index(c)] = [c[0], i]
        # if Us[flow.index(c)] == Us[-1]:
        #     break
        # else:
        #     i = U[flow.index(c)][1]
        #     print(i)
        #     print(marks)
        #     print()
