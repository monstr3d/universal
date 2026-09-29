package communication;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.UnknownHostException;

public class SimpleClient {

    private static final String SERVER_IP = "127.0.0.1"; // Localhost
    private static final int SERVER_PORT = 12345;      // Port the server is listening on

    public static void run(String[] args) {
        Socket socket = null;
        PrintWriter out = null;
        BufferedReader in = null;

        try {
            // 1. Create a Socket to connect to the server
            System.out.println("Connecting to " + SERVER_IP + ":" + SERVER_PORT + "...");
            socket = new Socket(SERVER_IP, SERVER_PORT);
            System.out.println("Connected to server!");

            // 2. Get Input/Output Streams
            // For sending data to the server
            out = new PrintWriter(new OutputStreamWriter(socket.getOutputStream()), true);
            // For receiving data from the server
            in = new BufferedReader(new InputStreamReader(socket.getInputStream()));

            // 3. Send a message to the server
            String messageToSend = "Hello from client!";
            System.out.println("Sending: " + messageToSend);
            out.println(messageToSend);

            // 4. Receive a response from the server
            String responseFromServer = in.readLine();
            if (responseFromServer != null) {
                System.out.println("Received: " + responseFromServer);
            } else {
                System.out.println("Server closed the connection unexpectedly.");
            }

        } catch (UnknownHostException e) {
            System.err.println("Host not found: " + SERVER_IP);
            e.printStackTrace();
        } catch (IOException e) {
            System.err.println("I/O error: " + e.getMessage());
            e.printStackTrace();
        } finally {
            // 5. Close resources in the finally block
            try {
                if (out != null) {
                    out.close();
                }
                if (in != null) {
                    in.close();
                }
                if (socket != null && !socket.isClosed()) {
                    socket.close();
                    System.out.println("Socket closed.");
                }
            } catch (IOException e) {
                System.err.println("Error closing resources: " + e.getMessage());
                e.printStackTrace();
            }
        }
    }
}