package communication.interfaces;

import java.util.concurrent.CancellationException;


public interface SimpleCancellationToken {

    boolean isCancellationRequested();
    void cancel();
    void throwIfCancellationRequested() throws CancellationException; // Helper method

}
