package communication;

import java.io.IOException;
import java.lang.reflect.Array;
import java.net.InetSocketAddress;
import java.nio.Buffer;
import java.nio.ByteBuffer;
import java.nio.channels.SelectionKey;
import java.nio.channels.Selector;
import java.nio.channels.SocketChannel;
import java.util.Arrays;
import java.util.Iterator;
import java.util.Set;

import communication.interfaces.IByteReceiver;
import error_handler.ConsoleErrorHandler;
import error_handler.interfaces.IErrorHandler;

import javax.swing.*;

public class AsyncTcpClient {

    private Selector selector;
    private SocketChannel clientChannel;
    private ByteBuffer readBuffer;

    private IByteReceiver byteReceiver;

    private  static IErrorHandler errorHandler = new ConsoleErrorHandler();

    public AsyncTcpClient(String host, int port, IByteReceiver byteReceiver) throws IOException {
        this.byteReceiver = byteReceiver;
        // 1. Create a Selector
        this.selector = Selector.open();

        // 2. Create a SocketChannel and configure it for non-blocking
        this.clientChannel = SocketChannel.open();
        this.clientChannel.configureBlocking(false);

        // 3. Initiate connection
        if (clientChannel.connect(new InetSocketAddress(host, port))) {
            // Connection established immediately (rare for remote servers)
            showMessage("Connected immediately.");
            // If connected immediately, we need to register for read operations
            registerForRead();
        }
        else
        {
            // Connection is in progress, register for OP_CONNECT
            this.clientChannel.register(selector, SelectionKey.OP_CONNECT);
            showMessage("Connection initiated, waiting for completion...");
        }

        this.readBuffer = ByteBuffer.allocate(1024); // Allocate a buffer for reading
    }

    public  static void setErrorHandler(IErrorHandler errorHandler)
    {
        AsyncTcpClient.errorHandler = errorHandler;
    }
    private void registerForRead() throws IOException {
        // Register for read operations
        this.clientChannel.register(selector, SelectionKey.OP_READ);
        showMessage("Registered for read operations.");
    }

    public void start(byte[] bytes) throws IOException {
        while (true) {
            // 4. Wait for events (blocks until at least one channel is ready)
            int readyChannels = selector.select();

            if (readyChannels == 0) {
                // No channels are ready, continue or do other work
                continue;
            }

            // 5. Get the set of ready keys
            Set<SelectionKey> selectedKeys = selector.selectedKeys();
            Iterator<SelectionKey> keyIterator = selectedKeys.iterator();

            // 6. Process ready channels
            while (keyIterator.hasNext()) {
                SelectionKey key = keyIterator.next();
                keyIterator.remove(); // Remove the key from the selected set

                try {
                    if (key.isConnectable()) {
                        // Connection complete
                        if (clientChannel.finishConnect()) {
                            showMessage("Connection successful!");
                            // Now that we're connected, register for read operations
                            registerForRead();
                            // You can also write something to the server here if needed
                            //  sendMessage("Hello from async client!");
                            sendBytes(bytes);
                        } else {
                            // Connection failed (shouldn't happen if finishConnect returns false after isConnectable is true)
                            showMessage("Connection failed.");
                            clientChannel.close();
                            return;
                        }
                    } else if (key.isReadable()) {
                        // Data available for reading
                        handleRead(key);
                     }
                    // You could also handle OP_WRITE if needed for sending data
                    // else if (key.isWritable()) {
                    //     handleWrite(key);
                    // }

                } catch (IOException e) {
                    handleError(e);
                    key.cancel(); // Cancel the key
                    try {
                        key.channel().close(); // Close the channel
                    } catch (IOException ex) {
                        ex.printStackTrace();
                    }
                }
            }
        }
    }

    int num = 0;

    int p = 0;
    byte[] all = null;

    private void handleRead(SelectionKey key) throws IOException {
        SocketChannel channel = (SocketChannel) key.channel();
        readBuffer.clear(); // Clear the buffer for new data

        int bytesRead = channel.read(readBuffer);


        if (bytesRead == -1) {
            // Connection closed by server
            showMessage("Connection closed by server.");
            key.cancel();
            channel.close();
            return;
        }

        if (bytesRead > 0)
        {

            readBuffer.flip(); // Prepare buffer for reading
            byte[] data = new byte[bytesRead];
            readBuffer.get(data);
            if (num > 0)
            {
                System.arraycopy(data, 0, all, p, bytesRead);
                num -= bytesRead;
                p += bytesRead;
                if (num == 0)
                {
                    byteReceiver.receiveBytes(all, all.length);
                }
                if (num < 0)
                {

                }
                return;
            }

            if (bytesRead <= 1019)
            {
               byteReceiver.receiveBytes(data, bytesRead);
            }
            else {
                // Source - https://stackoverflow.com/a
// Posted by Cowan, modified by community. See post 'Timeline' for change history
// Retrieved 2025-11-10, License - CC BY-SA 2.5

                num = ByteBuffer.wrap(data).getInt();
                num = Integer.reverseBytes(num);
                all = new byte[num];
                var k = bytesRead - 4;
                System.arraycopy(data, 4, all, 0, k);
                num -= k;
                p = k;

            }
            //   String message = new String(data);
            //  showMessage("Received: " + message);
        }
    }

    public void sendBytes(byte[] bytes)   throws IOException {
        if (clientChannel != null && clientChannel.isConnected()) {
            ByteBuffer writeBuffer = ByteBuffer.wrap(bytes);
            clientChannel.write(writeBuffer);

        } else {
            showMessage("Cannot send bytes: Client not connected.");
        }
    }


    public void sendMessage1(String message) throws IOException {
        sendBytes(message.getBytes());
    }
    public void close() throws IOException {
        if (clientChannel != null) {
            clientChannel.close();
        }
        if (selector != null) {
            selector.close();
        }
    }

    public static void showMessage(String message)
    {
        errorHandler.show(message);
    }

    public  static  void handleError(Throwable e)
    {
        errorHandler.handle(e);
    }

    public static void main(String[] args) {
        // Replace with your server's host and port
        String serverHost = "localhost";
        int serverPort = 12345;

        try {
            AsyncTcpClient client = new AsyncTcpClient(serverHost, serverPort, null);
            // Run the client in a separate thread to avoid blocking the main thread
            new Thread(() -> {
                try {
                    client.start(null);
                } catch (IOException e) {
                    e.printStackTrace();
                    showMessage("Client encountered an error.");
                }
            }).start();

            // Example of sending a message after a delay
            Thread.sleep(2000); // Give the connection time to establish
            //    client.sendMessage("Hello World!");

            // Keep the main thread alive for a while to observe the client
            Thread.sleep(10000);
            client.close();
            showMessage("Client closed.");

        } catch (IOException | InterruptedException e) {
            handleError(e);
            e.printStackTrace();
        }
    }
}