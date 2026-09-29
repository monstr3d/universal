package communication

import kotlinx.coroutines.*
import java.io.*
import java.net.Socket
import java.net.ConnectException

class RawSocketClientManager {

    private var socket: Socket? = null
    private var reader: BufferedReader? = null
    private var writer: PrintWriter? = null
    private val clientScope = CoroutineScope(Dispatchers.IO)

    fun connectAndCommunicate(host: String, port: Int, messageToSend: String) {
        clientScope.launch {
            try {
                // Establish Connection
                socket = Socket(host, port)
                println("Raw Socket Connected to $host:$port")

                // Get Streams
                writer = PrintWriter(OutputStreamWriter(socket?.getOutputStream()), true)
                reader = BufferedReader(InputStreamReader(socket?.getInputStream()))

                // Send Message
                writer?.println(messageToSend)
                println("Raw Socket Sent: $messageToSend")

                // Receive Response
                val response = reader?.readLine()
                println("Raw Socket Received: $response")

                withContext(Dispatchers.Main) {
                    // Update UI
                }

            } catch (e: ConnectException) {
                println("Raw Socket Connection Error: Could not connect to $host:$port. Is the server running?")
                withContext(Dispatchers.Main) { /* Show error to user */ }
            } catch (e: Exception) {
                println("Raw Socket Communication Error: ${e.message}")
                withContext(Dispatchers.Main) { /* Show error to user */ }
            } finally {
                closeResources()
            }
        }
    }

    fun closeResources() {
        try {
            writer?.close()
            reader?.close()
            socket?.close()
        } catch (e: IOException) { /* Handle error */ }
        writer = null
        reader = null
        socket = null
        println("Raw Socket resources closed.")
    }

    fun cancelAll() {
        clientScope.cancel() // Cancels all coroutines launched within this scope
        closeResources()
    }
}