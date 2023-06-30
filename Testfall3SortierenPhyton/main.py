import random
import time

start_time = time.time()

zahlen = [0] * 100000

for i in range(len(zahlen)):
    zahlen[i] = random.randint(1, 100000)

for i in range(len(zahlen) - 1):
    for j in range(len(zahlen) - i - 1):
        if zahlen[j] > zahlen[j + 1]:
            zahlen[j], zahlen[j + 1] = zahlen[j + 1], zahlen[j]

for zahl in zahlen:
    print(zahl, end=", \n")

end_time = time.time()
elapsed_time = end_time - start_time
print("Laufzeit:", elapsed_time, "Sekunden")
input()
