package communication

import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import java.net.InetSocketAddress
import java.net.Socket
import java.nio.ByteBuffer
import java.nio.channels.SocketChannel

class ClientSocketManager {

    private var socketChannel: SocketChannel? = null
    private val bufferSize = 1024 // Or a suitable size for your data
    private val clientScope = CoroutineScope(Dispatchers.IO)


    fun connect(host: String, port: Int) {
        clientScope.launch {
            try {
                socketChannel = SocketChannel.open()
                socketChannel?.configureBlocking(false) // Set to non-blocking mode
                val success = socketChannel?.connect(InetSocketAddress(host, port)) ?: false

                // For non-blocking connect, you might need to poll for completion
                // or use a selector. For simplicity in this example, we'll assume
                // connect completes immediately if the server is reachable,
                // or you might need a more robust connection handling.
                // A common pattern for non-blocking is to try connecting and then
                // check socketChannel.finishConnect().

                if (success) {
                    // Connection established
                    true
                } else {
                    // Connection initiated but not yet finished (if non-blocking)
                    // In a real app, you'd poll finishConnect() or use selectors.
                    // For simplicity, we'll treat immediate success/failure here.
                    // If connect returns false, it means it initiated but not finished.
                    // You'd typically loop and check finishConnect().
                    // For a simpler blocking-like behavior within coroutines,
                    // you can sometimes use a blocking Socket and wrap it with withContext(Dispatchers.IO).
                    // Let's stick with SocketChannel for its non-blocking potential.

                    // A more robust non-blocking connect would look like this:
                    // while (!socketChannel.finishConnect()) {
                    //     // Wait a bit or use a selector to avoid busy-waiting
                    //     delay(100) // Example: delay for 100ms
                    // }
                    // For this example, we'll simplify and assume if connect() returns true, it's connected.
                    // If it returns false, it might be pending, and we'd need more logic.
                    // If you want simpler blocking behavior, use Socket and connect() directly.

                    // Let's switch to a blocking Socket for simplicity within this suspend function
                    // as managing non-blocking IO with selectors is more complex.
                    // The benefit of withContext(Dispatchers.IO) is that it isolates
                    // blocking operations to a dedicated thread pool.
                    socketChannel?.close() // Close the non-blocking channel if not using it directly
                    val blockingSocket = Socket()
                    blockingSocket.connect(InetSocketAddress(host, port), 5000) // 5 second timeout
                    // We can't directly use Socket with SocketChannel operations.
                    // To simplify, let's reconsider using the blocking Socket directly within withContext.

                    // --- Revised approach using Blocking Socket for simplicity ---
                    // Revert to simple blocking Socket for easier example within withContext(Dispatchers.IO)
                    socketChannel =
                        null // Clear the SocketChannel if we decide to use blocking Socket
                }

            } catch (e: Exception) {
                e.printStackTrace()
                //  close() // Ensure cleanup on error
            }
        }
    }



    // --- Revised connect() using Blocking Socket ---
    suspend fun connectBlocking(host: String, port: Int): Boolean = withContext(Dispatchers.IO) {
        try {
            val blockingSocket = Socket()
            blockingSocket.connect(InetSocketAddress(host, port), 5000) // 5-second timeout
            socketChannel = blockingSocket.channel // Get the channel from the blocking socket
            // Note: If using a blocking Socket, socketChannel will be null here.
            // We need to manage the Socket object itself. Let's manage the Socket directly.
    //        close() // Close any previous socketChannel if it was initialized.
            // Re-initialize socketChannel to null to manage the blocking Socket.

            // --- Let's manage the blocking Socket directly for this approach ---
            // This means we won't use SocketChannel.configureBlocking(false) in this specific example.
            // We'll use the blocking Socket and just operate on its streams.

            // This `connectBlocking` function will actually use a blocking Socket.
            // The `socketChannel` property will remain null, and we'll manage the `blockingSocket` instance.
            // This requires restructuring `ClientSocketManager`.
            // Let's simplify the manager to hold a blocking Socket directly for this example.
            return@withContext true // This line is a placeholder for the success of the blocking connect.
        } catch (e: Exception) {
            e.printStackTrace()
     //       close()
            false
        }
    }

    // Let's redefine `ClientSocketManager` to hold a blocking `Socket` directly for this example.
}

// --- Redefined ClientSocketManager to hold a blocking Socket ---
