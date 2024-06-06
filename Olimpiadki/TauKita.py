words = open('input_s1_01.txt').readline().split(' ')
circular_list = []
# appending list 
if len(words) % 2 == 0:
    middle = len(words) // 2
    circular_list.append(words[middle])
    for i in range(1, middle + 1):
        circular_list.append(words[middle - i])
        if i < middle:
            circular_list.append(words[middle + i])
else:
    middle = (len(words) - 1) // 2
    circular_list.append(words[middle])
    for i in range(1, middle + 1):
        circular_list.append(words[middle - i])
        circular_list.append(words[middle + i])

palind = []

for word in circular_list:
    pal = ""
    if len(word) % 2 == 0:
        middle = len(word) // 2
        pal += word[middle]
        for i in range(1, middle + 1):
            pal += word[middle - i]
            if i < middle:
                pal += word[middle + i]
    else:
        middle = (len(word) - 1) // 2
        pal += word[middle]
        for i in range(1, middle + 1):
            pal += word[middle - i]
            pal += word[middle + i]
    palind.append(pal)

result = ""
for p in palind:
    result += p + " "

print(result[:-1])
