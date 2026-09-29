package communication;

import java.io.IOException;

import okhttp3.Interceptor;
import okhttp3.Request;
import okhttp3.Response;

class CancellationInterceptor implements Interceptor {
    @Override
    public Response intercept(Chain chain) throws IOException {
        Request request = chain.request();

        // How to associate a CancellationToken with the request?
        // Option 1: Use request tags (if your network calls support it)
        // Option 2: Pass it through a custom header (less common for cancellation itself)
        // Option 3: Manage tokens at a higher level (e.g., in your Activity/Fragment)
        //
        // For this example, let's assume we're managing tokens externally.
        // The interceptor can't directly access an arbitrary CancellationToken
        // unless it's explicitly passed. A more common approach is to cancel the OkHttp Call directly.

        // The most straightforward way with OkHttp is to call `call.cancel()`
        // on the OkHttp Call object when you need to cancel.
        // The `CancellationInterceptor` is more about detecting if the
        // underlying connection/request is already being aborted due to
        // a network issue or external cancellation signal.

        // Let's focus on how you'd trigger cancellation from your Android code.

        return chain.proceed(request);
    }
}