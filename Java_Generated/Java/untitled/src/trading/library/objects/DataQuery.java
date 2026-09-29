package trading.library.objects;

import cancellation.interfaces.ICancellation;
import cancellation.interfaces.ICancelledObject;
import cancellation.interfaces.IInitializeTask;
import general_service.Performer;
import trading.database.interfaces.ITradingDatabaseHistoryInterface;
import trading.database.classes.TradingDatabaseHistoryInterface;

import java.util.HashMap;
import java.util.Map;
import java.util.concurrent.CompletableFuture;


public class DataQuery implements IInitializeTask, ICancelledObject {

    Performer performer = new Performer();
    ITradingDatabaseHistoryInterface inter = TradingDatabaseHistoryInterface.get();
    void getSymbols(ICancellation cancellation) {
        try {
            var smb = inter.getSymbols(cancellation);
            var mp = smb.get();
            performer.copyMap(mp, symbols);
        }
        catch (Throwable e)
        {

        }
    }

    @Override
    public CompletableFuture<Void> InitializeFutureAsync(ICancellation cancellation)
    {

            return CompletableFuture.supplyAsync(() -> {
                getSymbols(cancellation); return null;
            });
    }

Map<String, Object> symbols = new HashMap<>();


    @Override
    public CompletableFuture<Void> cancelObject() {
        return null;
    }
}

