package communication;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;

public class TcpClient {

    private String serverIp;
    private int serverPort;
    private Socket socket;
    private PrintWriter out;
    private BufferedReader in;

    public TcpClient(String ip, int port) {
        this.serverIp = ip;
        this.serverPort = port;
    }

    public void connect() {
        new Thread(new Runnable() {
            @Override
            public void run() {
                try {
                    socket = new Socket(serverIp, serverPort);
                    out = new PrintWriter(new BufferedWriter(new OutputStreamWriter(socket.getOutputStream())), true);
                    in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                    // Start a separate thread to listen for incoming messages
                    listenForMessages();
                } catch (IOException e) {
                    e.printStackTrace();
                    // Handle connection errors
                }
            }
        }).start();
    }

    public void sendMessage(final String message) {
        if (out != null) {
            new Thread(new Runnable() {
                @Override
                public void run() {
                    out.println(message);
                }
            }).start();
        }
    }

    private void listenForMessages() {
        new Thread(new Runnable() {
            @Override
            public void run() {
                try {
                    String line;
                    while ((line = in.readLine()) != null) {
                        // Process received message (e.g., update UI on main thread)
                        System.out.println("Received: " + line);
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                    // Handle read errors or connection closed
                }
            }
        }).start();
    }

    public void disconnect() {
        try {
            if (socket != null) {
                socket.close();
            }
            if (out != null) {
                out.close();
            }
            if (in != null) {
                in.close();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}