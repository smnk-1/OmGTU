# Цикл
K = [1, 2, 3, 20]
for i in range(len(K)):
    k = K[i]
    n = 5
    m = 10
    m1=0
    l = 7
    s = 0
    for i in range(k):
        s += 2*(m+m1+l+n)
        m1 += m
    print(s)
 
 
 # Формула
while True:
    k = int(input('Введите К'))
    n = 5
    m = 10
    l = 7
    print(2*k*l + (k**2 + k)*m + 2*k*n)
