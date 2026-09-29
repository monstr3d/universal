package external.trading.library.objects;

import cancellation.interfaces.ICancellation;
import cancellation.interfaces.IInitializeTask;
import category_theory.CategoryObject;
import diagram.interfaces.IDesktop;

import java.util.concurrent.CompletableFuture;

public class Fiction extends CategoryObject implements IInitializeTask {

    public Fiction(String name, IDesktop desktop)
    {
        super(name, desktop);
    }

    @Override
    public CompletableFuture InitializeFutureAsync(ICancellation cancellation) {
           return CompletableFuture.supplyAsync(() -> {
                getSymbols(cancellation);
                return null;
            });
        }


    void getSymbols(ICancellation cancellation) {

    }
}
