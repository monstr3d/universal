package tests;
import java.io.IOException;
import java.util.Arrays;
import java.util.List;
import java.util.concurrent.CompletableFuture;
import java.util.concurrent.ExecutionException;
import java.util.stream.Collectors;

import communication.AsyncTcpClient;
import communication.ConsoleByteReceiver;

public class AsyncWhenAllExample {

    public static void run() {
        //ke.show("Starting multiple async operations...");

        CompletableFuture<String> future1 = simulateAsyncOperation("Data1");
        CompletableFuture<String> future2 = simulateAsyncOperation("Data2");
        CompletableFuture<String> future3 = simulateAsyncOperation("Data3");

        // Combine them using allOf()
        CompletableFuture<Void> allFutures = CompletableFuture.allOf(future1, future2, future3);

        try {
            // "await" for all operations to complete
            allFutures.get(); // Blocks until future1, future2, and future3 are all done

            System.out.println("All async operations completed successfully.");

            // Now we can safely get the results from individual futures
            future1.get(); // No blocking here as they are already done
            String result2 = future2.get();
            String result3 = future3.get();

            System.out.println("Results: ");
            System.out.println("- ");
            System.out.println("- " + result2);
            System.out.println("- " + result3);

        } catch (InterruptedException | ExecutionException e) {
            System.err.println("An error occurred during one of the async operations: " + e.getMessage());
            e.printStackTrace();
        }

        System.out.println("Main thread continues...");
    }

    public Boolean s()
    {
        return  true;
    }

    public CompletableFuture simulate()
    {
        return CompletableFuture.supplyAsync(() ->  s());
    }
    public static CompletableFuture<String> simulateAsyncOperation(String data) {
        return CompletableFuture.supplyAsync(() -> {
            try {

                var c = new AsyncTcpClient("31.10.82.229",7168, new ConsoleByteReceiver());
                var string = "Hello world";
                var  b = string.getBytes();
                c.start(b);

                // Simulate work with varying delays
                long delay = (long) (Math.random() * 3000) + 1000;
                System.out.println("Starting work for: " + data + " (delay: " + delay + "ms)");
                Thread.sleep(delay);
                System.out.println("Finished work for: " + data);
            } catch (InterruptedException e) {
                Thread.currentThread().interrupt();
                throw new RuntimeException(e);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            return "Processed: " + data;
        });
    }
}
