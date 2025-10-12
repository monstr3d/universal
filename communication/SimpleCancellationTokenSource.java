package communication;

import java.util.concurrent.CancellationException;

import communication.interfaces.SimpleCancellationToken;

public class SimpleCancellationTokenSource {
    private volatile boolean cancelled = false;

    public SimpleCancellationToken getToken() {
        return new SimpleCancellationToken() {
            @Override
            public boolean isCancellationRequested() {
                return cancelled;
            }

            @Override
            public void cancel() {
                cancelled = true;
            }

            @Override
            public void throwIfCancellationRequested() throws CancellationException {
                if (cancelled) {
                    throw new CancellationException("Operation cancelled");
                }
            }
        };
    }

    public void cancel() {
        cancelled = true;
    }
}
