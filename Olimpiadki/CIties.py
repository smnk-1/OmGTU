f = open("input_s1_02.txt").read().split()
chains = []


def is_cycle(arr):
    if arr[0][0] == arr[-1][-1]:
        return True
    else:
        return False


def chain_search(i):
    global chains
    global f
    chains.append([f[0]])
    f.pop(0)
    check = True
    while check:
        check = False
        for string in f:
            if chains[i][-1][-1] == string[0]:
                check = True
                chains[i].append(string)
                f.remove(string)


i = 0
while len(f) != 0:
    chain_search(i)
    i += 1
print(chains)

flag = True
while flag:
    flag = False
    for i in range(0, len(chains)):
        for j in range(0, len(chains[i])):
            letter = chains[i][j][-1]
            # for k in range(1, len(chains)):
            #     if chains[k][0][0] == letter:
            #         index = j
            #         flag = True
            #         for s in chains[k]:
            #             chains[i].insert(index, s)
            #             index += 1
            #         print(chains)
            print(letter)
