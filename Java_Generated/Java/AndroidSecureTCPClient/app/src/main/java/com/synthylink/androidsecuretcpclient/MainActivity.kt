package com.synthylink.androidsecuretcpclient


import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.lifecycle.lifecycleScope
import communication.SecureTcpClient
import kotlinx.coroutines.launch

class MainActivity : AppCompatActivity() {

    private lateinit var hostEditText: EditText
    private lateinit var portEditText: EditText
    private lateinit var messageEditText: EditText
    private lateinit var sendButton: Button
    private lateinit var responseTextView: TextView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main) // Make sure you have a layout with these elements

        hostEditText = findViewById(R.id.hostEditText)
        portEditText = findViewById(R.id.portEditText)
        messageEditText = findViewById(R.id.messageEditText)
        sendButton = findViewById(R.id.sendButton)
        responseTextView = findViewById(R.id.responseTextView)

        val secureTcpClient = SecureTcpClient(this)

        sendButton.setOnClickListener {
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
            lifecycleScope.launch {
                responseTextView.text = "Connecting..."

                val response = secureTcpClient.connectAndCommunicate(host, port, "", message)
                if (response != null) {
                    responseTextView.text = "Response: $response"
                } else {
                    responseTextView.text = "Connection failed or error occurred."
                }
            }
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
}