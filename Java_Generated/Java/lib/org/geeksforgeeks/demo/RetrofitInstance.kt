package org.geeksforgeeks.demo

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetrofitInstance {
    private val retrofit by lazy {
   /*     Retrofit.Builder().baseUrl("https://jsonplaceholder.typicode.com//")
            .addConverterFactory(GsonConverterFactory.create())
            .build()*/
        Retrofit.Builder().baseUrl("https://jsonplaceholder.typicode.com//")
            .addConverterFactory(GsonConverterFactory.create())
            .build()

    }

    val apiInterface by lazy {
        retrofit.create(ApiInterface::class.java)
    }
}