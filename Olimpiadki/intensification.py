from datetime import datetime
products = 0
s1, s2, s3 = map(int, input('start date:').split('.'))
e1, e2, e3 = map(int, input('end date:').split('.'))
P = int(input())

date1 = datetime.strptime(f'{s2}/{s1}/{s3}', '%m/%d/%Y')
date2 = datetime.strptime(f'{e2}/{e1}/{e3}', '%m/%d/%Y')
 
num_days = (date2 - date1).days

for i in range(num_days+1):
    products += P
    P += 1
    # print(products, P)
print(products)