import time

start_time = time.time()

primes = []
prime_count = 0

for i in range(2, 50001):
    is_prime = 0
    for j in range(1, i + 1):
        if i % j == 0:
            is_prime += 1

    if is_prime <= 2:
        primes.append(i)
        prime_count += 1

for prime in primes:
    print(prime, end=", \n")

end_time = time.time()
elapsed_time = end_time - start_time
print("Laufzeit:", elapsed_time, "Sekunden")
input()
