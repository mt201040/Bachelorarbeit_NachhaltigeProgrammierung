import java.util.Arrays;
import java.util.Random;
import java.util.concurrent.TimeUnit;

public class Testfall3SortierenJavaNachhaltig {

    public static void main(String[] args) {
        long startTime = System.nanoTime();

        int[] zahlen = new int[100000];

        Random rnd = new Random();

        for (int i = 0; i < zahlen.length; i++) {
            zahlen[i] = rnd.nextInt(100000) + 1;
        }

        quicksort(zahlen, 0, zahlen.length - 1);

        for (int i = 0; i < zahlen.length; i++) {
            System.out.println(zahlen[i] + ", ");
        }

        long endTime = System.nanoTime();
        long elapsedTime = endTime - startTime;
        System.out.println("Laufzeit: " + elapsedTime + " Nanosekunden");
    }

    public static void quicksort(int[] arr, int low, int high) {
        if (low < high) {
            int pivotIndex = partition(arr, low, high);
            quicksort(arr, low, pivotIndex - 1);
            quicksort(arr, pivotIndex + 1, high);
        }
    }

    public static int partition(int[] arr, int low, int high) {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++) {
            if (arr[j] <= pivot) {
                i++;
                swap(arr, i, j);
            }
        }

        swap(arr, i + 1, high);
        return i + 1;
    }

    public static void swap(int[] arr, int i, int j) {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
