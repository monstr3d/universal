package cancellation.interfaces;

import java.util.concurrent.CompletableFuture;

public interface IStartTask {
    CompletableFuture StartFutureAsync(ICancellation cancellation);
}
