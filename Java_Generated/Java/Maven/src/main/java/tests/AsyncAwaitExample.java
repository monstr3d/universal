package tests;

import java.util.concurrent.CompletableFuture;
import java.util.concurrent.ExecutionException;

public class AsyncAwaitExample {

    public static void run() {
        System.out.println("Starting async operation...");

        // Simulate an asynchronous operation that returns a String
        CompletableFuture<String> futureResult = simulateAsyncOperation("Hello");

        try {
            // This line "awaits" the completion of the futureResult
            String result = futureResult.get(); // Blocks until futureResult is done
            System.out.println("Async operation completed. Result: " + result);
        } catch (InterruptedException | ExecutionException e) {
            System.err.println("Error during async operation: " + e.getMessage());
            e.printStackTrace();
        }

        System.out.println("Main thread continues...");
    }

    public static CompletableFuture<String> simulateAsyncOperation(String message) {
        return CompletableFuture.supplyAsync(() -> {
            try {
                // Simulate some work
                Thread.sleep(2000);
            } catch (InterruptedException e) {
                Thread.currentThread().interrupt();
                throw new RuntimeException(e);
            }
            return "Processed: " + message;
        });
    }
}