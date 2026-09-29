package com.synthylink.empty;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

public interface ApiInterface {
    @GET("getweatherforecast")
    Call<List<String>> getWeatherConditions();
}
