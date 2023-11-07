import math
N = int(input('Enter N'))

def razv(n):
    if n == 3:
        return 1
    elif n < 3:
        return 0
    elif n > 3:
        fp = math.floor(n/2)
        sp = math.floor(n/2) + (n % 2)
        return razv(fp) + razv(sp)
        
print(razv(N))
    


    
    