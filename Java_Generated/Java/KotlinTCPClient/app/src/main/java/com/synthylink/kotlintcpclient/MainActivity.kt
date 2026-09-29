package com.synthylink.kotlintcpclient

import com.synthylink.kotlintcpclient.R
import android.os.Bundle
import android.util.Log
import android.widget.Button
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import communication.TcpClientManager
import kotlinx.coroutines.launch
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import kotlinx.coroutines.cancelChildren
import java.nio.charset.Charset

class MainActivity : AppCompatActivity() {

    private val TAG = "MainActivity"
    private lateinit var tcpClientManager: TcpClientManager

    // Replace with your server's IP address and port
    private val SERVER_ADDRESS = "192.168.1.100" // Example IP
    private val SERVER_PORT = 12345

    lateinit var   textViewReceivedData : TextView;


    // Example Port

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        // If using view binding:
        setContentView(R.layout.activity_main)

        //btnComnect = R.layout.
        // If not using view binding, set your layout: setContentView(R.layout.activity_main)

        // Initialize the client manager
        tcpClientManager = TcpClientManager(SERVER_ADDRESS, SERVER_PORT)

        var btnConnect = findViewById(R.id.btnConnect) as Button
        var btnDisconnect = findViewById(R.id.btnDisconnect) as Button
        var btnData = findViewById(R.id.btnGetData) as Button

        textViewReceivedData = findViewById(R.id.textViewReceivedData)


        btnConnect.setOnClickListener {
            startTcpClient()
        }

        btnDisconnect.setOnClickListener {
            stopTcpClient()
        }

        btnData.setOnClickListener {
            getAndDisplayData()
        }
    }

    private fun startTcpClient() {
        // Launch a coroutine in the activity's lifecycle scope
        // This scope will be cancelled when the activity is destroyed
        lifecycleScope.launch {
            try {
                // Ensure no other child coroutines for TCP are running
              //  this.coroutineContext.cancelChildren(filter = { it.context.key == TCP_CLIENT_JOB_KEY })

                tcpClientManager.startAndReceiveData()
            } catch (e: Exception) {
                Log.e(TAG, "Error starting TCP client: ${e.message}")
            }
        }
    }

    private fun stopTcpClient() {
        lifecycleScope.launch {
            // Cancel any ongoing TCP client operations
       //     this.coroutineContext.cancelChildren(filter = { it.context.key == TCP_CLIENT_JOB_KEY })
            tcpClientManager.stopClient()
            Log.i(TAG, "TCP client stopped.")
        }
    }

    private fun getAndDisplayData() {
        lifecycleScope.launch {
            val receivedBytes = tcpClientManager.getAccumulatedData()
            if (receivedBytes != null && receivedBytes.isNotEmpty()) {
                // Convert bytes to a string (assuming UTF-8 encoding)
                val dataString = String(receivedBytes, Charset.forName("UTF-8"))
                Log.i(TAG, "--- Accumulated Data ---")
                Log.i(TAG, dataString)
                Log.i(TAG, "----------------------")
                // Update UI with dataString
                textViewReceivedData.text = dataString // Assuming you have a TextView with this ID
            } else {
                Log.i(TAG, "No data received yet or stream is empty.")
                textViewReceivedData.text = "No data received yet."
            }
        }
    }

    override fun onDestroy() {
        super.onDestroy()
        // Ensure the client is stopped when the activity is destroyed
        stopTcpClient()
    }

    // Define a custom CoroutineContext.Key for filtering child jobs
  //  companion object {
//        val TCP_CLIENT_JOB_KEY = object : kotlin.coroutines.CoroutineContext.Key<kotlin.coroutines.Job> {}
//    }
}