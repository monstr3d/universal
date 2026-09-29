package cancellation.interfaces;

import java.util.concurrent.CompletableFuture;

public interface IInitializeTask {
    CompletableFuture InitializeFutureAsync(ICancellation cancellation);
}
