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
    direction_f = 1
    st = 1
    if i_start < i_finish:
        for j in range(i_start, i_finish):
            direction_f *= -1
            st *= gears[array[j]] / gears[array[j + 1]]
    elif i_start > i_finish:
        for j in range(i_start, i_finish, -1):
            direction_f *= -1
            st *= gears[array[j]] / gears[array[j - 1]]
    return [direction_f, st]


TESTS = 13

for test in range(1, TESTS+1):
    if test < 10:
        test = str(f'0{test}')
    print(f'Test {test}: ')
    # SET UP
    f = open(f"D:\Programming\Python\pythonProject1\chain-input\input_s1_{test}.txt")
    gears_number, chain_n = map(int, f.readline().split())
    gears = {}
    used_gears = []
    chain = []
    possibility = 1

    # GEARS INPUT
    for i in range(0, gears_number):
        a, b = map(int, f.readline().split())
        gears[a] = b
    # print(gears)

    # CHAIN INPUT
    for i in range(0, chain_n):
        s1, s2 = map(int, f.readline().split())
        if s1 in chain:
            index = chain.index(s1)
            if index == (len(chain)-1):
                chain.append(s2)
            elif index == 0:
              chain.insert(0, s2)
            else:
                possibility = -1
                break
        else:
            if s2 in chain:
                index = chain.index(s2)
                if index == (len(chain) - 1):
                    chain.append(s1)
                elif index == 0:
                    chain.insert(0, s1)
                else:
                    possibility = -1
                    break
            if s2 not in chain:
                chain.append(s1)
                chain.append(s2)
        # print(chain)
    if possibility == 1:
        # START-FINISH-DIRECTION
        start, finish = map(int, f.readline().split())
        direction = int(f.readline())
        strenght = 1

        if len(chain) > gears_number:
            if chain.count(start) == 2:
                start_index = chain.index(start)
                chain2 = chain.remove(start)
                finish_index = chain2.index(start)
                middle_index = chain.index(finish)
                print(start_index, middle_index, finish_index)
                if start_index < middle_index < finish_index:
                    subchain1 = [x for x in chain if start_index <= chain.index(x) <= middle_index]
                    subchain2 = [x for x in chain if middle_index <= chain.index(x) <= finish_index]
                    if not (check_subchain(subchain1, len(subchain1) - 1, 0) and check_subchain(subchain2, 0, len(subchain2) - 1)):
                        possibility = -1
            if chain.count(finish) == 2:    # finish ... start ... finish
                start_index = chain.index(finish)
                finish_index = second_in(chain, finish)
                middle_index = chain.index(start)
                if start_index < middle_index < finish_index:
                    subchain1 = [chain[x] for x in range(start_index, middle_index + 1)]
                    subchain2 = [chain[x] for x in range(middle_index, finish_index + 1)]

                    if not (check_subchain(subchain1, len(subchain1)-1, 0) and check_subchain(subchain2, 0, len(subchain2)-1)):
                        possibility = -1

        else:
            start_index = chain.index(start)
            finish_index = chain.index(finish)
            if start_index < finish_index:
                for i in range(start_index, finish_index):
                    direction *= -1
                    strenght *= gears[chain[i]]/gears[chain[i+1]]

            elif start_index == finish_index:
                pass
                # print(possibility)
                # print(direction)
                # print(strenght)

            elif start_index > finish_index:
                pass
                # print('wrong way')

    # CHECK
    f_out = open(f"D:\Programming\Python\pythonProject1\chain-input\output_s1_{test}.txt")
    check = False
    if possibility == int(f_out.readline()):
        print('Possibility +')
        check = True
    else:
        print("Possibility -")
    if possibility > 0 and check:
        if direction == int(f_out.readline()):
            print('Direction +')
        else:
            print("Direction -")

        if strenght == float(f_out.readline()):
            print('Strength +')
        else:
            print("Strenght -")
