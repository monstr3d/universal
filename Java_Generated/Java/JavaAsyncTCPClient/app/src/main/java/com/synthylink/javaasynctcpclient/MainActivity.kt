package com.synthylink.javaasynctcpclient

import android.os.Bundle
import android.widget.Button
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import communication.AsyncTcpClient
import communication.ConsoleByteReceiver
import tests.Actor

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        try {

            btn = findViewById(R.id.button)
             btn.setOnClickListener { start() }
        } catch (e: Exception) {
        }

       // AsyncWhenAllExample.run();
    }

    fun start() {
       // AsyncWhenAllExample.run()
        /*
        fech = FetchDataTask("31.10.82.229", 7168, ConsoleByteReceiver())
        val string = "Hello world"
        val b = string.toByteArray()
        fech.execute(b)*/
        var act = Actor()
        act.testSymbolsTrading()
    }

    fun whenAll()
    {

    }

    lateinit var btn : Button
    lateinit var client : AsyncTcpClient;//("31.10.82.229",7168)
}

