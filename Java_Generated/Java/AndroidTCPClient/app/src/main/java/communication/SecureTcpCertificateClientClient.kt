package communication

import java.io.*
import java.net.SocketException
import java.security.*
import java.security.cert.CertificateException
import javax.net.ssl.*

class SecureTcpCertificateClientClient(
    private val host: String,
    private val port: Int,
    private val truststorePath: String,
    private val truststorePassword: CharArray
)
{

    private var sslSocket: SSLSocket? = null
    private var outStream: PrintWriter? = null
    private var inStream: BufferedReader? = null

    fun connect() {
        try {
            // 1. Load the Truststore
            val truststore =
                KeyStore.getInstance("JKS") // Or "PKCS12" depending on your truststore format
            FileInputStream(truststorePath).use { fis ->
                truststore.load(fis, truststorePassword)
            }

            // 2. Create TrustManagerFactory and TrustManager
            val trustManagerFactory =
                TrustManagerFactory.getInstance(TrustManagerFactory.getDefaultAlgorithm())
            trustManagerFactory.init(truststore)
            val trustManagers = trustManagerFactory.trustManagers

            // If you need client authentication, you would also load a keystore for the client
            // and initialize a KeyManagerFactory here.

            // 3. Create SSLContext
            val sslContext = SSLContext.getInstance("TLS")
            sslContext.init(
                null,
                trustManagers,
                null
            ) // null for KeyManager (no client auth in this example)

            // 4. Create SSLSocketFactory
            val sslSocketFactory = sslContext.socketFactory

            // 5. Create and Connect SSLSocket
            println("Connecting to $host:$port...")
            sslSocket = sslSocketFactory.createSocket(host, port) as SSLSocket
            sslSocket?.also {
                it.useClientMode = true // Client mode
                it.startHandshake() // Perform the SSL handshake

                println("SSL Handshake successful!")

                // Get I/O streams
                outStream = PrintWriter(it.outputStream, true)
                inStream = BufferedReader(InputStreamReader(it.inputStream))

                println("Connection established.")
            }
        } catch (e: FileNotFoundException) {
            println("Error: Truststore file not found at ${truststorePath}")
            e.printStackTrace()
        } catch (e: KeyStoreException) {
            println("Error: Invalid keystore.")
            e.printStackTrace()
        } catch (e: NoSuchAlgorithmException) {
            println("Error: SSL algorithm not supported.")
            e.printStackTrace()
        } catch (e: KeyManagementException) {
            println("Error: Key management issue.")
            e.printStackTrace()
        } catch (e: CertificateException) {
            println("Error: Certificate issue.")
            e.printStackTrace()
        } catch (e: SocketException) {
            println("Error: Network socket error during connection.")
            e.printStackTrace()
        } catch (e: IOException) {
            println("Error: I/O error during connection.")
            e.printStackTrace()
        }
    }

    fun getSocket() : SSLSocket?
    {
        return  sslSocket
    }

    fun sendMessage(message: String) {
        if (outStream != null && sslSocket?.isConnected == true) {
            println("Sending: $message")
            outStream?.println(message)
        } else {
            println("Cannot send message. Connection not established or closed.")
        }
    }

    fun receiveMessage(): String? {
        return if (inStream != null && sslSocket?.isConnected == true) {
            try {
                inStream?.readLine()
            } catch (e: IOException) {
                println("Error reading message: ${e.message}")
                null
            }
        } else {
            println("Cannot receive message. Connection not established or closed.")
            null
        }
    }

    fun disconnect() {
        try {
            outStream?.close()
            inStream?.close()
            sslSocket?.close()
            println("Disconnected from server.")
        } catch (e: IOException) {
            println("Error closing connection: ${e.message}")
        } finally {
            sslSocket = null
            outStream = null
            inStream = null
        }
    }


    fun run() {
        // !!! IMPORTANT !!!
        // Replace these with your actual server details and truststore path/password.
        val serverHost = "localhost" // Or your server's IP/hostname
        val serverPort = 6666      // Your server's SSL/TLS port

        // Path to your truststore file (e.g., cacerts, or a custom JKS/PKCS12 file)
        // For local testing with self-signed certificates, you might need to create one.
        // You can often find the default Java truststore at JAVA_HOME/lib/security/cacerts
        val truststorePath =
            System.getProperty("javax.net.ssl.trustStore") ?: "path/to/your/client.truststore"
        val truststorePassword =
            (System.getProperty("javax.net.ssl.trustStorePassword") ?: "changeit").toCharArray()


        val client = SecureTcpCertificateClientClient(
            serverHost,
            serverPort,
            truststorePath,
            truststorePassword
        )
        client.connect()

        if (client.sslSocket?.isConnected == true) {
            // Send a message and wait for a response
            client.sendMessage("Hello, Secure Server!")
            val response = client.receiveMessage()
            if (response != null) {
                println("Received: $response")
            }

            // You can continue sending and receiving messages here

            // Disconnect when done
            client.disconnect()
        } else {
            println("Failed to connect. Exiting.")
        }
    }
}