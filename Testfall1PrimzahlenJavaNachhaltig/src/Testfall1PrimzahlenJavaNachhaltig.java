import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.TimeUnit;

public class Testfall1PrimzahlenJavaNachhaltig {

    public static void main(String[] args) {
        long startTime = System.nanoTime();

        List<Integer> primes = new ArrayList<>();
        
        for (int i = 2; i <= 500000; i++) {
            if (isPrime(i)) {
                primes.add(i);
            }
        }

        for (int prime : primes) {
            System.out.println(prime + ", ");
        }

        long endTime = System.nanoTime();
        long elapsedTime = endTime - startTime;
        System.out.println("Laufzeit: " + elapsedTime + " Nanosekunden");
    }
    
    private static boolean isPrime(int number) {
        if (number < 2) {
            return false;
        }
        
        for (int i = 2; i <= Math.sqrt(number); i++) {
            if (number % i == 0) {
                return false;
            }
        }
        
        return true;
    }
}
