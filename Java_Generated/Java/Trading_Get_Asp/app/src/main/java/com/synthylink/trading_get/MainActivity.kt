package com.synthylink.trading_get

import com.synthylink.trading_get.R
import android.app.ProgressDialog
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import communication.ResponseData
import communication.RetrofitInstance
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class MainActivity : AppCompatActivity() {

    private lateinit var titleTextView: TextView
    private lateinit var bodyTextView: TextView
    private lateinit var getDataButton: Button

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        titleTextView = findViewById(R.id.title_textView)
        bodyTextView = findViewById(R.id.body_textView)
        getDataButton = findViewById(R.id.getData_button)

        getDataButton.setOnClickListener {
            getData()
        }
    }

    private fun getData() {

        val progressDialog = ProgressDialog(this)
        progressDialog.setMessage("Please wait")
        progressDialog.show()

        RetrofitInstance.getApiInterface().getData().enqueue(object : Callback<ResponseData?> {
            override fun onResponse(call: Call<ResponseData?>, response: Response<ResponseData?>) {
                val responseData = response.body()
     //           titleTextView.text = responseData?.title
                bodyTextView.text = responseData?.body
                progressDialog.dismiss()
            }

            override fun onFailure(call: Call<ResponseData?>, t: Throwable) {
                Toast.makeText(this@MainActivity, t.localizedMessage, Toast.LENGTH_SHORT).show()
                progressDialog.dismiss()
            }
        })
    }
}