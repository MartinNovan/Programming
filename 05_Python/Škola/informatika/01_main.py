random = 564
print(random)
if random<600:
    print(random)
for i in range(random,600):
    print(i)
    i = i+1
mojePole = [0,1,2,3,4,5,6]
print(mojePole)
mojePole.pop(2)
print(mojePole)
mojePole.append(10)
print(mojePole)
mojePole[4]=50
print(mojePole)

def main():
    jmeno = input("Zadejte jméno:")
    print("Welcome!", jmeno)

main()
