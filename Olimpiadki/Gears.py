# FUNCTIONS
def second_in(array, element):
    global gears
    counter = 0
    for j in array:
        if j == element and counter == 0:
            counter += 1
        elif j == element and counter == 1:
            return j


def check_subchain(array, i_start, i_finish):
    global gears
    dir = 1
    st = 1
    if i_start < i_finish:
        for j in range(i_start, i_finish):
            dir *= -1
            st *= gears[array[j]] / gears[array[j + 1]]
    elif i_start > i_finish:
        for j in range(i_start, i_finish, -1):
            dir *= -1
            st *= gears[array[j]] / gears[array[j - 1]]
    return [dir, st]


# SET UP
gears_number, chain_n = map(int, input().split())
gears = {}
used_gears = []
chain = []

# GEARS INPUT
for i in range(0, gears_number):
    a, b = map(int, input().split())
    gears[a] = b
print(gears)

# CHAIN INPUT
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

# START-FINISH-DIRECTION
start, finish = map(int, input().split())
direction = int(input())
strenght = 1
possibility = 1

if len(chain) > gears_number:
    # if chain.count(start) == 2:
    #     start_index = chain.index(start)
    #     chain2 = chain.remove(start)
    #     finish_index = chain2.index(start)
    #     middle_index = chain.index(finish)
    #     print(start_index, middle_index, finish_index)
    #     if start_index < middle_index < finish_index:
    #         subchain1 = [x for x in chain if start_index <= chain.index(x) <= middle_index]
    #         subchain2 = [x for x in chain if middle_index <= chain.index(x) <= finish_index]
    #         print(subchain1)
    #         print(subchain2)
    if chain.count(finish) == 2:    # finish ... start ... finish
        start_index = chain.index(finish)
        finish_index = second_in(chain, finish)
        middle_index = chain.index(start)
        print(start_index, middle_index, finish_index)
        if start_index < middle_index < finish_index:
            subchain1 = [chain[x] for x in range(start_index, middle_index + 1)]
            subchain2 = [chain[x] for x in range(middle_index, finish_index + 1)]
            print(subchain1)
            print(subchain2)
            print(check_subchain(subchain1, len(subchain1)-1, 0))
            print(check_subchain(subchain2, 0, len(subchain2)-1))

else:
    start_index = chain.index(start)
    finish_index = chain.index(finish)
    if start_index < finish_index:
        for i in range(start_index, finish_index):
            direction *= -1
            strenght *= gears[chain[i]]/gears[chain[i+1]]
        print(possibility)
        print(direction)
        print(strenght)

    elif start_index == finish_index:
        print(possibility)
        print(direction)
        print(strenght)

    elif start_index > finish_index:
        pass
