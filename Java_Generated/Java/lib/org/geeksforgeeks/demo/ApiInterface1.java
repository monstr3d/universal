package org.geeksforgeeks.demo;

import retrofit2.Call;
import retrofit2.http.GET;

public interface ApiInterface1 {
    @GET("/posts/1")
    Call<ResponseData> getData();
}