import math
MaxN = int(input())
answer = 0
for i in range(1, int(math.log2(MaxN + 1)) + 1):
    answer += MaxN//(2**i-1)
print(answer)