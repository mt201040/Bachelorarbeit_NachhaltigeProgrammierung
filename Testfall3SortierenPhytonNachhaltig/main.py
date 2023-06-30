import random
import time

start_time = time.time()

zahlen = [random.randint(1, 100000) for _ in range(100000)]
zahlen.sort()

for zahl in zahlen:
    print(zahl, end=", \n")

end_time = time.time()
elapsed_time = end_time - start_time
print("Laufzeit:", elapsed_time, "Sekunden")
input()
