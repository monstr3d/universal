package communication.interfaces;

import java.util.concurrent.CancellationException;

public interface ICancellationToken {
    boolean isCancellationRequested();
    void cancel();
    void throwIfCancellationRequested() throws CancellationException; // Helper method

}
