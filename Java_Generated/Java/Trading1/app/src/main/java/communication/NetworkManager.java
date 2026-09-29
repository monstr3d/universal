package communication;

import communication.interfaces.SimpleCancellationToken;
import okhttp3.Call;
import okhttp3.OkHttpClient;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

// ... (SimpleCancellationToken and SimpleCancellationTokenSource as defined above)

public class NetworkManager {

    private Retrofit retrofit;
    private OkHttpClient okHttpClient;

    public NetworkManager() {
        okHttpClient = new OkHttpClient.Builder()
                .addInterceptor(new CancellationInterceptor()) // Interceptor to check cancellation
                .build();

        retrofit = new Retrofit.Builder()
                .baseUrl("YOUR_API_BASE_URL")
                .client(okHttpClient)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
    }

    // You'll have your API service interfaces here
    public interface ApiService {
        // Example: Define your API calls
        // @GET("data")
        // Call<MyData> getData(@Query("param") String param);
    }

    public ApiService getApiService() {
        return retrofit.create(ApiService.class);
    }

    // Helper method to create a Call with cancellation support
    public <T> Call createCancellableCall(okhttp3.Call originalCall, SimpleCancellationToken token) {
        // This is a simplified approach. OkHttp's Call already supports cancellation.
        // The real integration is in how you pass the token and check it.
        return originalCall; // OkHttp's Call has .cancel() method
    }
}