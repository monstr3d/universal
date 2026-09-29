package communication

import android.Manifest
import android.annotation.SuppressLint
import android.content.Context
import android.net.ConnectivityManager
import android.net.NetworkCapabilities
import android.os.Build
import android.util.Log
import androidx.annotation.RequiresPermission
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import java.io.BufferedReader
import java.io.BufferedWriter
import java.io.InputStreamReader
import java.io.OutputStreamWriter
import java.net.InetAddress
import java.net.Socket
import javax.net.SocketFactory
import javax.net.ssl.SSLSocket
import javax.net.ssl.SSLSocketFactory

private const val TAG = "SecureTcpClient"

class SecureTcpClient(private val context: Context) {

    private var socket: SSLSocket? = null
    private var reader: BufferedReader? = null
    private var writer: BufferedWriter? = null

    /**
     * Connects to the secure TCP server and performs communication.
     * @param host The server's hostname or IP address.
     * @param port The server's port number.
     * @param message The message to send to the server.
     * @return The response received from the server, or null if an error occurred.
     */
    @SuppressLint("MissingPermission")
    suspend fun connectAndCommunicate(host: String, port: Int, cert : String, message: String): String? =
        withContext(Dispatchers.IO) {
            if (!isNetworkAvailable()) {
                Log.e(TAG, "No network connection available.")
                return@withContext null
            }

            try {

              //  val file = "c:/AUsers/1MySoft/CSharp/src/Web/ConsoleAppSocket/ConsoleAppSocket/bin/Debug/net9.0/android.pfx"
                // 1. Get the default SSLSocketFactory
                //val sslSocketFactory: SSLSocketFactory =  getCustomSSLSocketFactoryWithCustomTrustManager()
              //  val sslSocketFactory: SSLSocketFactory =  getCustomSSLSocketFactory("file")

                val sslSocketFactory: SSLSocketFactory = SSLSocketFactory.getDefault() as SSLSocketFactory



                // 2. Create an SSLSocket
                Log.d(TAG, "Attempting to connect to $host:$port")
                socket = sslSocketFactory.createSocket(host, port) as SSLSocket
                Log.d(TAG, "Socket created. Attempting to handshake...")

                // Optional: Configure SSL parameters if needed
                // socket?.enabledProtocols = arrayOf("TLSv1.2", "TLSv1.3")
                // socket?.enabledCipherSuites = arrayOf(...)

                // 3. Connect and perform handshake (implicitly happens on first I/O or explicitly with startHandshake())
                // For simplicity, we'll let it happen implicitly during read/write.
                // To explicitly start the handshake: socket?.startHandshake()

                Log.d(TAG, "SSL handshake successful.")

                // 4. Get Input and Output Streams
                writer = BufferedWriter(OutputStreamWriter(socket?.getOutputStream()))
                reader = BufferedReader(InputStreamReader(socket?.getInputStream()))

                // 5. Send the message
                writer?.write("$message\n") // Add newline as a delimiter, adjust as per server protocol
                writer?.flush()
                Log.d(TAG, "Sent message: $message")

                // 6. Receive the response
                val response = reader?.readLine()
                Log.d(TAG, "Received response: $response")

                return@withContext response

            } catch (e: Exception) {
                Log.e(TAG, "Error during secure TCP communication", e)
                return@withContext null
            } finally {
                // 7. Close the connection
                closeConnection()
            }
        }

    /**
     * Closes the socket and associated streams.
     */
    fun closeConnection() {
        try {
            writer?.close()
            reader?.close()
            socket?.close()
            Log.d(TAG, "Connection closed.")
        } catch (e: Exception) {
            Log.e(TAG, "Error closing connection", e)
        } finally {
            writer = null
            reader = null
            socket = null
        }
    }

    /**
     * Checks if the network is available.
     * Requires the `android.permission.ACCESS_NETWORK_STATE` permission.
     */
    @RequiresPermission(Manifest.permission.ACCESS_NETWORK_STATE)
    private fun isNetworkAvailable(): Boolean {
        val connectivityManager = context.getSystemService(Context.CONNECTIVITY_SERVICE) as ConnectivityManager
        return if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
            val network = connectivityManager.activeNetwork ?: return false
            val capabilities = connectivityManager.getNetworkCapabilities(network) ?: return false
            capabilities.hasTransport(NetworkCapabilities.TRANSPORT_WIFI) ||
                    capabilities.hasTransport(NetworkCapabilities.TRANSPORT_CELLULAR) ||
                    capabilities.hasTransport(NetworkCapabilities.TRANSPORT_ETHERNET)
        } else {
            @Suppress("DEPRECATION")
            val activeNetworkInfo = connectivityManager.activeNetworkInfo ?: return false
            @Suppress("DEPRECATION")
            activeNetworkInfo.isConnected
        }
    }
}