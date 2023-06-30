import java.util.Arrays;
import java.util.Random;
import java.util.concurrent.TimeUnit;

public class Testfall3SortierenJava {

    public static void main(String[] args) {
        long startTime = System.nanoTime();

        int[] zahlen = new int[100000];

        Random rnd = new Random();

        for (int i = 0; i < zahlen.length; i++) {
            zahlen[i] = rnd.nextInt(100000) + 1;
        }

        for (int i = 0; i < zahlen.length - 1; i++) {
            for (int j = 0; j < zahlen.length - i - 1; j++) {
                if (zahlen[j] > zahlen[j + 1]) {
                    int tempVar = zahlen[j];
                    zahlen[j] = zahlen[j + 1];
                    zahlen[j + 1] = tempVar;
                }
            }
        }

        for (int i = 0; i < zahlen.length; i++) {
            System.out.println(zahlen[i] + ", ");
        }

        long endTime = System.nanoTime();
        long elapsedTime = endTime - startTime;
        long seconds = TimeUnit.NANOSECONDS.toSeconds(elapsedTime);
        System.out.println("Laufzeit: " + seconds + " Sekunden");
    }
}
