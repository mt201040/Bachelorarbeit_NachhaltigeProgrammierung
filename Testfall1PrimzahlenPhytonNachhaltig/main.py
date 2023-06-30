import time
import math

start_time = time.time()

n = 500000
is_prime = [True] * (n + 1)
primes = []

is_prime[0] = is_prime[1] = False

for i in range(2, int(math.sqrt(n)) + 1):
    if is_prime[i]:
        for j in range(i * i, n + 1, i):
            is_prime[j] = False

for i in range(2, n + 1):
    if is_prime[i]:
        primes.append(i)

for prime in primes:
    print(prime, end=", \n")

end_time = time.time()
elapsed_time = end_time - start_time
print("Laufzeit:", elapsed_time, "Sekunden")
input()
