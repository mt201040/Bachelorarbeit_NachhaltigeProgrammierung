import java.util.Arrays;
import java.util.concurrent.TimeUnit;

public class Testfall1PrimzahlenJava {

    public static void main(String[] args) {
        long startTime = System.nanoTime();

        int[] primes = new int[500000];
        int primeCount = 0;
        int isPrime = 0;

        for (int i = 2; i <= 500000; i++) {
            isPrime = 0;
            for (int j = 1; j <= 500000; j++) {
                if (i % j == 0) {
                    isPrime++;
                }
            }

            if (isPrime <= 2) {
                primes[primeCount] = i;
                primeCount++;
            }
        }

        for (int i = 0; i < primeCount; i++) {
            System.out.println(primes[i] + ", ");
        }

        long endTime = System.nanoTime();
        long elapsedTime = endTime - startTime;
        long seconds = TimeUnit.NANOSECONDS.toSeconds(elapsedTime);
        System.out.println("Laufzeit: " + seconds + " Sekunden");
    }
}
