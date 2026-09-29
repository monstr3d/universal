package com.synthylink.androidtcpclient


import android.content.Context
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.lifecycle.lifecycleScope
import communication.ClientSocketManager
import communication.SecureTcpCertificateClientClient
import communication.SecureTcpCertificateStoreClient
import communication.TcpClient
//import communication.SecureTcpClient
import kotlinx.coroutines.launch
import java.io.FileInputStream
import java.io.IOException
import java.io.InputStream
import java.security.KeyStore

class MainActivity : AppCompatActivity() {

    private lateinit var hostEditText: EditText
    private lateinit var portEditText: EditText
    private lateinit var messageEditText: EditText
    private lateinit var sendButton: Button
    private lateinit var responseTextView: TextView

    private lateinit var trustedKeyStore: KeyStore
    private lateinit var serverHost: String

    private lateinit var client: SecureTcpCertificateStoreClient

    private lateinit var tcpClient : TcpClient
    private var serverPort: Int = 0;

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main) // Make sure you have a layout with these elements
        tcpClient = TcpClient("31.10.82.229", 80)
        tcpClient.connect();
        hostEditText = findViewById(R.id.hostEditText)
        portEditText = findViewById(R.id.portEditText)
        messageEditText = findViewById(R.id.messageEditText)
        sendButton = findViewById(R.id.sendButton)
        responseTextView = findViewById(R.id.responseTextView)
        set();


        //    val secureTcpClient = SecureTcpClient(this)

        sendButton.setOnClickListener()
        {
            run()
            return@setOnClickListener
            val host = hostEditText.text.toString()
            val portString = portEditText.text.toString()
            val message = messageEditText.text.toString()
            if (host.isBlank() || portString.isBlank() || message.isBlank()) {
                Toast.makeText(this, "Please fill in all fields", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }

            val port = try {
                portString.toInt()
            } catch (e: NumberFormatException) {
                Toast.makeText(this, "Invalid port number", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }

            // Use lifecycleScope for coroutines tied to the Activity's lifecycle

            responseTextView.text = "Connecting..."
           // run()
            var m = ClientSocketManager()
            m.connect("localhost", 8888)


        }
    }

    override fun onDestroy() {
        super.onDestroy()
        // Ensure the connection is closed when the Activity is destroyed
        // In a real app, you might manage the client's lifecycle more robustly
        // (e.g., using a ViewModel)
        // For this simple example, we'll rely on closeConnection() being called
        // within connectAndCommunicate's finally block.
        // If the client might be reused, you might want an explicit close here.
    }

    fun set() {
        System.setProperty("systemProp.https.proxyHost", "localhost")
        System.setProperty("systemProp.https.proxyPort", "8888")
        System.setProperty("javax.net.ssl.trustStorePassword", "J0hnksM0nster")
         // Replace these with your actual server details and truststore path/password.
        serverHost = System.getProperty("systemProp.https.proxyHost")
        // val  serverHost = System.getenv("systemProp.https.proxyHost")// Or your server's IP/hostname
        serverPort = System.getProperty("systemProp.https.proxyPort").toInt()

        // Path to your truststore file (e.g., cacerts, or a custom JKS/PKCS12 file)
        // For local testing with self-signed certificates, you might need to create one.
        // You can often find the default Java truststore at JAVA_HOME/lib/security/cacerts
        val truststorePath =
            System.getProperty("javax.net.ssl.trustStore") ?: "path/to/your/client.truststore"

        val truststorePassword =
            System.getProperty("javax.net.ssl.trustStorePassword").toCharArray();

        trustedKeyStore = getKeyStore(this, R.raw.androids, truststorePassword);
        //  trustedKeyStore = (ks != null) ks : null;
        client = SecureTcpCertificateStoreClient(serverHost, serverPort, trustedKeyStore)
    }

    fun readRawResource(context: Context, resourceId: Int): InputStream? {
        try {
            // 1. Get the InputStream using the resource ID
            return context.resources.openRawResource(resourceId)

            // 2. Read the stream into a String (same logic as assets)
        } catch (ex: IOException) {
            ex.printStackTrace()

        } finally {
            return null;
        }
    }

    fun getKeyStore(context: Context, p12RawId: Int, p12Password: CharArray): KeyStore {

        val keyStoreType = "PKCS12"
        val keyStore = KeyStore.getInstance(keyStoreType)
        try {
            val p12InputStream = context.resources.openRawResource(p12RawId)
            keyStore.load(p12InputStream, p12Password)
            p12InputStream.close()
            return keyStore
        } catch (e: Exception) {
            e.printStackTrace()
            return keyStore;
        }
    }

     fun  run() {
         tcpClient.sendMessage("Hello server")
         if (true) return
        client.connectAndSend("Hello server")
        if (true) return
         var t = Thread(Runnable {
            client.connectAndSend("Hallo server")
        })
        t.start();
        /*
   "c:\Program Files\Java\jdk-24\bin\
   keytool -importcert -file "c:\AUsers\1MySoft\CSharp\src\Web\ConsoleAppSocket\ConsoleAppSocket\bin\Debug\net9.0\androids.pfx" -keystore "c:\AUsers\1MySoft\CSharp\src\Web\ConsoleAppSocket\ConsoleAppSocket\bin\Debug\net9.0\androids.jks" -alias "<anything>"
   keytool -importcert -file "c:\temp\androids.pfx" -keystore "c:\temp\androids.jks" -alias "<anything>"
    keytool -importcert -file "c:\temp\androids.pfx" -keystore "c:\temp\androids.jks" -alias "<anything>"

keytool -importkeystore -srckeystore androids.pfx -srcstoretype pkcs12 -destkeystore androids.jks -deststoretype JKS
keytool -importkeystore -srckeystore androids.pfx -srcstoretype pkcs12 -destkeystore c:\temp\androids.jks -deststoretype JKS
keytool -importkeystore -srckeystore c:\temp\androids.jks -destkeystore c:\temp\androids.jks -deststoretype pkcs12
keytool -importkeystore -srckeystore "c:\temp\androids.pfx" -srcstoretype PKCS12 -destkeystore "c:\temp\androids.jks -deststoretype JKS -deststorepass changeit -trustcacerts

         */
        if (true) return
        lifecycleScope.launch {
            client.connectAndSend("Hallo server")
        }
        if (true) return;
        // !!! IMPORTANT !!!


        val client = SecureTcpCertificateStoreClient(
            serverHost,
            serverPort,
            trustedKeyStore
        )

        try {

            client.connect()
            var socket = client.getSocket()

            if (socket?.isConnected == true) {
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
        } catch (e: Exception) {
            val i = 0
        }
    }
}