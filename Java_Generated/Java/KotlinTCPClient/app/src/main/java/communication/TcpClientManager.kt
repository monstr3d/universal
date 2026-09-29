package communication



import android.util.Log
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.coroutineScope
import kotlinx.coroutines.isActive
import kotlinx.coroutines.launch
import kotlinx.coroutines.sync.Mutex
import kotlinx.coroutines.sync.withLock
import kotlinx.coroutines.withContext
import java.io.ByteArrayOutputStream
import java.io.IOException
import java.net.InetSocketAddress
import java.net.Socket

class TcpClientManager(
    private val serverAddress: String,
    private val serverPort: Int,
    private val bufferSize: Int = 8192 // 8KB buffer for reading
) {

    private val TAG = "TcpClientManager"

    private  var isActive   = true
    private var socket: Socket? = null
    private val receivedDataMutex = Mutex()
    private var receivedDataOutputStream: ByteArrayOutputStream? = null

    // Function to start the client and begin receiving data
    suspend fun startAndReceiveData() {
        if (socket?.isConnected == true) {
            Log.w(TAG, "Client is already connected.")
            return
        }

        // Use coroutineScope to manage child coroutines and ensure cancellation
        coroutineScope {
            try {
                Log.d(TAG, "Attempting to connect to $serverAddress:$serverPort")
                socket = Socket()
                socket?.connect(InetSocketAddress(serverAddress, serverPort), 5000) // 5-second timeout
                Log.i(TAG, "Connected to server.")

                // Initialize ByteArrayOutputStream for accumulation
                receivedDataOutputStream = ByteArrayOutputStream()

                // Launch a coroutine to continuously read data
                launch(Dispatchers.IO) {
                    readDataLoop()
                }

            } catch (e: IOException) {
                Log.e(TAG, "Connection error: ${e.message}")
                closeConnection()
            } catch (e: Exception) {
                Log.e(TAG, "An unexpected error occurred during connection: ${e.message}")
                closeConnection()
            }
        }
    }

    // The loop that reads data from the socket
    private suspend fun readDataLoop() {
        val buffer = ByteArray(bufferSize)
        var bytesRead: Int

        // Ensure this block is executed within a coroutine scope that can be cancelled
        while (isActive && socket?.isConnected == true) {
            try {
                val inputStream = socket?.getInputStream() ?: break
                bytesRead = inputStream.read(buffer)

                if (bytesRead == -1) {
                    // End of stream reached (server closed connection)
                    Log.i(TAG, "Server closed the connection.")
                    break
                }

                if (bytesRead > 0) {
                    // Accumulate received bytes
                /*    receivedDataOutputStream?.let {
                        // Protect access to the output stream with a mutex
                       receivedDataOutputStream.withLock {
                            it.write(buffer, 0, bytesRead)
                            Log.d(TAG, "Received $bytesRead bytes. Total accumulated: ${it.size()}")
                        }
                    }*/
                }
            } catch (e: IOException) {
                if (!isActive) {
                    Log.d(TAG, "Read operation interrupted due to coroutine cancellation.")
                } else {
                    Log.e(TAG, "Error reading from socket: ${e.message}")
                }
                break // Exit loop on read error
            } catch (e: Exception) {
                Log.e(TAG, "An unexpected error occurred during reading: ${e.message}")
                break // Exit loop on unexpected error
            }
        }
        Log.d(TAG, "Exiting readDataLoop.")
        closeConnection() // Clean up resources when the loop ends
    }

    // Function to get the accumulated data
    suspend fun getAccumulatedData(): ByteArray? {
      /*  return receivedDataOutputStream?.let {
            // Access the data safely using the mutex
            it.withLock {
                it.toByteArray()
            }
            var i = 0;
        }*/

      return null;
    }

    // Function to clear the accumulated data
    suspend fun clearAccumulatedData() {
        receivedDataOutputStream?.let {
          /*  it.withLock {
                it.reset()
                Log.d(TAG, "Accumulated data cleared.")
            }*/
        }
    }

    // Function to stop the client and close the connection
    fun stopClient() {
        Log.d(TAG, "Stopping client.")
        closeConnection()
    }

    // Helper function to close the socket and streams
    private fun closeConnection() {
        try {
            socket?.apply {
                if (!isClosed) {
                    shutdownOutput() // Signal server that we are done sending (if applicable)
                    shutdownInput()  // Signal server that we are done receiving
                    close()
                    Log.i(TAG, "Socket closed.")
                }
            }
        } catch (e: IOException) {
            Log.e(TAG, "Error closing socket: ${e.message}")
        } finally {
            socket = null
            receivedDataOutputStream?.close() // Close the output stream
            receivedDataOutputStream = null
            Log.d(TAG, "Resources cleaned up.")
        }
    }
}