package communication

import android.os.NetworkOnMainThreadException
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import java.io.BufferedReader
import java.io.FileInputStream
import java.io.FileNotFoundException
import java.io.IOException
import java.io.InputStreamReader
import java.io.PrintWriter
import java.net.SocketException
import java.security.KeyManagementException
import java.security.KeyStore
import java.security.KeyStoreException
import java.security.NoSuchAlgorithmException
import java.security.cert.CertificateException
import javax.net.ssl.SSLContext
import javax.net.ssl.SSLSocket
import javax.net.ssl.TrustManagerFactory

class SecureTcpCertificateStoreClient (
    private val host: String,
    private val port: Int,
    private val trustStore : KeyStore?,
)
{
    private var sslSocket: SSLSocket? = null
    private var outStream: PrintWriter? = null
    private var inStream: BufferedReader? = null

    private val clientScope = CoroutineScope(Dispatchers.IO)


    fun connect() {
        try {

            // 1. Load the Truststore

            // 2. Create TrustManagerFactory and TrustManager
            val trustManagerFactory =
                TrustManagerFactory.getInstance(TrustManagerFactory.getDefaultAlgorithm())
            trustManagerFactory.init(trustStore)
            val trustManagers = trustManagerFactory.trustManagers

            // If you need client authentication, you would also load a keystore for the client
            // and initialize a KeyManagerFactory here.

            // 3. Create SSLContext
            val sslContext = SSLContext.getInstance("TLSv1.2")
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
        }
        catch (e: KeyStoreException) {
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
        catch (e : NetworkOnMainThreadException)
        {
            println("Android On main thread exception")
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

    fun connectAndSend(message: String)
    {

        clientScope.launch {
            connect();
            sendMessage(message);
           var s =  receiveMessage();
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


}