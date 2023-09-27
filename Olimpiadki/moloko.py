f = open('input1.txt', 'r')
a = [i for i in f.read().split('\n')]
minCost = float("inf")
minCostFirm = None

for i in range(int(a[0])):
    x1, y1, z1, x2, y2, z2, p1, p2 = map(float, a[i+1].split())
    v1 = int(x1*y1*z1)
    s1 = int(2*x1*y1 + 2*x1*z1 + 2*z1*y1)
    v2 = int(x2*y2*z2)
    s2 = int(2*x2*y2 + 2*x2*z2 + 2*z2*y2)
    milkPrice = round((p2*s1 - p1*s2)/(v2*s1 - v1*s2)*1000, 2)
    if milkPrice < minCost:
        minCostFirm = i+1
    minCost = min(minCost, milkPrice)
print(minCostFirm, minCost)
