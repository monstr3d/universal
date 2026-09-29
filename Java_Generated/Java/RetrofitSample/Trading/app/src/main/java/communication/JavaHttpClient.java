package communication;

import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

public class JavaHttpClient {

    private volatile boolean cancelled = false;
    private HttpURLConnection connection;
    private final ExecutorService executor = Executors.newSingleThreadExecutor();
    private Future<?> currentTask;

    public void sendRequest(String urlString) {
        cancelled = false; // Reset cancellation flag for a new request

        currentTask = executor.submit(() -> {
            try {
                URL url = new URL(urlString);
                connection = (HttpURLConnection) url.openConnection();
                connection.setRequestMethod("GET"); // Or POST, etc.
                connection.setConnectTimeout(5000); // 5 seconds
                connection.setReadTimeout(10000);  // 10 seconds

                System.out.println("Sending request to: " + urlString);

                // This is where the blocking call happens.
                // If cancelled is true, we want to interrupt this.
                // However, HttpURLConnection itself doesn't have a direct "cancel" method.
                // We rely on interrupting the thread or closing the connection.

                // A common pattern is to check the cancelled flag periodically,
                // but this is tricky with blocking I/O operations.
                // The most effective way is to call disconnect() externally.

                try (InputStream in = connection.getInputStream()) {
                    // Simulate processing the response
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = in.read(buffer)) != -1) {
                        if (cancelled) {
                            System.out.println("Request cancelled during read!");
                            // Even if we detect cancellation here, the underlying
                            // stream might still be active. The external disconnect
                            // is the primary mechanism.
                            return;
                        }
                        // Process buffer data...
                        // System.out.println("Read " + bytesRead + " bytes.");
                    }
                    System.out.println("Request completed successfully.");
                } catch (IOException e) {
                    if (e.getMessage() != null && e.getMessage().contains("Interrupted")) {
                        System.out.println("Request was interrupted (likely cancelled).");
                    } else {
                        System.err.println("Error during request: " + e.getMessage());
                    }
                } finally {
                    if (connection != null) {
                        connection.disconnect(); // Always disconnect
                    }
                }

            } catch (IOException e) {
                System.err.println("Error opening connection: " + e.getMessage());
            }
        });
    }

    public void cancelRequest() {
        System.out.println("Attempting to cancel request...");
        cancelled = true; // Signal cancellation to the thread (if it checks)

        if (connection != null) {
            connection.disconnect(); // This is the most effective way to interrupt.
        }

        if (currentTask != null && !currentTask.isDone()) {
            currentTask.cancel(true); // Attempt to interrupt the thread
        }
    }
}
/*
    public static void main(String[] args) throws InterruptedException {
        HttpURLConnectionCancelExample client = new HttpURLConnectionCancelExample();
        String slowUrl = "http://httpbin.org/delay/5"; // A URL that delays for 5 seconds

        client.sendRequest(slowUrl);

        // Let it run for a bit, then cancel
        Thread.sleep(2000); // Wait for 2 seconds
        client.cancelRequest();

        // Wait a bit to see cancellation messages
        Thread.sleep(3000);

        // Example of sending another request after cancellation
        System.out.println("\nSending another request after cancellation...");
        client.sendRequest("http://httpbin.org/get");
        Thread.sleep(2000); // Wait for the response

        client.executor.shutdownNow(); // Clean up executor
    }
}

}*/
