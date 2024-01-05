file = f'input_s1_01.txt'

with open(file) as f:
    X, Y, L, C1, C2, C3, C4, C5, C6 = [int(i) for i in f.readline().split(' ')]

whole_wall = 2*X + 2*Y
repaired_wall = 0
rebuilt_wall = 0
new_wall = 0
remains = L

if C1 < C2 + C3 and C1 <= C2 + C4 + C5 + C6:
    repaired_wall = min(L, max(X, Y))
    whole_wall -= repaired_wall
    remains -= repaired_wall

if C2 + C3 < C2 + C4 + C5 + C6:
    rebuilt_wall = min(remains, whole_wall)
    remains -= rebuilt_wall
    whole_wall -= rebuilt_wall

new_wall = whole_wall

min_cost = repaired_wall * C1 + rebuilt_wall * (C2 + C3) + new_wall * (C4 + C5) + remains * (C2 + C6)

print(f'Итого: {min_cost}')