package cancellation.interfaces;

import java.util.concurrent.CompletableFuture;

public interface ICancelledObject {
    CompletableFuture<Void> cancelObject();

}
