package cancellation.interfaces;

import java.util.concurrent.CompletableFuture;

public interface ICancellation {

    void  addCancelledObject(ICancelledObject object);
    void  removeCancelledObject(ICancelledObject object);

    CompletableFuture<Void> cancelConcellation();

}
