Us = [1, 2, 3, 4, 5]  # start: Us[0], finish: Us[-1],
U = [[1, 2], [1, 3], [1, 4], [2, 3], [2, 5], [3, 4], [3, 5], [4, 5]]
max_flow = [20, 30, 10, 40, 30, 10, 20, 20]
flow = []
total_flow = []
for u in U:
    flow.append([max_flow[U.index(u)], 0])
inf = 10 ** 10
# iteration

for z in range(0, 10):
    I = Us[0]
    print("\nIteraion", z+1)
    marks = {Us[0]: [inf, 0]}
    disabled_ways = []
    while True:
        S1 = []
        S2 = []
        for u in Us:
            if U.count([I, u]) == 1 and not marks.keys().__contains__(u):
                S1.append(u)
            if U.count([u, I]) == 1 and not marks.keys().__contains__(u):
                S2.append(u)

        if len(S1) + len(S2) != 0:
            print(S1, S2)
            # print(U)
            # print(flow)
            max_f = 0
            max_way = []
            # print(I)
            for u in S1:
                if max_f < flow[U.index([I, u])][0] and disabled_ways.count([I, u]) == 0:
                    max_f = flow[U.index([I, u])][0]
                    max_way = [I, u]
            for u in S2:
                # print(u, I)
                if max_f < flow[U.index([u, I])][1] and disabled_ways.count([u, I]) == 0:
                    max_f = flow[U.index([u, I])][1]
                    max_way = [u, I]
            print(max_way)
            if len(max_way) != 0:
                if max_way[0] == I:
                    marks[max_way[1]] = [max_f, I]
                    I = max_way[1]
                    # print('normal', I)
                elif max_way[1] == I:
                    marks[max_way[0]] = [max_f, -I]
                    I = max_way[0]
                # print(marks)
                if I == Us[-1]:
                    break
            else:
                print("is empty", I)
                if I != Us[0]:
                    ks = [x for x in marks.keys()]
                    disabled_ways.append([ks[-2], ks[-1]])
                    I = ks[-2]
                    marks.pop(ks[-1])
                    print(I)
                else:
                    print("\nEND:", sum(total_flow))
                    exit()
        else:
            exit('it is not supposed to go here')
    # 5

    print(marks)
    min_f = min([x[0] for x in marks.values()])
    print(min_f)

    keys = [x for x in marks.keys()]
    for i in range(0, len(keys)-1):
        pair = [keys[i], keys[i + 1]]
        if marks[keys[i + 1]][1] > 0:
            pair = [keys[i], keys[i + 1]]
            flow[U.index(pair)][0] -= min_f
            flow[U.index(pair)][1] += min_f
        elif marks[keys[i + 1]][1] < 0:
            pair = [keys[i + 1], keys[i]]
            flow[U.index(pair)][0] += min_f
            flow[U.index(pair)][1] -= min_f
    print(flow)
    total_flow.append(min_f)
