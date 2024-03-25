gears_number, chain_n = map(int, input().split())
gears = {}
used_gears = []
chain = []
for i in range(0, gears_number):
    a, b = map(int, input().split())
    gears[a] = b
print(gears)
for i in range(0, chain_n):
    s1, s2 = map(int, input().split())
    if s1 in chain:
        index = chain.index(s1)
        if index == (len(chain)-1):
            chain.append(s2)
        elif index == 0:
          chain.insert(0, s2)
        else:
            print('error')
    else:
        if s2 in chain:
            index = chain.index(s2)
            if index == (len(chain) - 1):
                chain.append(s1)
            elif index == 0:
                chain.insert(0, s1)
            else:
                print('error')
        if s2 not in chain:
            chain.append(s1)
            chain.append(s2)
    print(chain)

start, finish = map(int, input().split())
V = int(input())
strenght = 1
if len(chain) > gears_number:
    pass
    # if старт 2 раза => финиш 1 раз, проверить с двух сторон
    # и наоборот
else:
    start_index = chain.index(start)
    finish_index = chain.index(finish)
    if start_index < finish_index:
        for i in range(start_index, finish_index):
            V*=-1
            strenght *= gears[chain[i]]/gears[chain[i+1]]
        print(1)
        print(V)
        print(strenght)

    elif start_index == finish_index:
        print(1)
        print(V)
        print(strenght)

    elif start_index > finish_index:
        pass


