package external.trading.database.interfaces;

import cancellation.interfaces.ICancellation;
import external.trading.database.classes.HistoricalDataMessageDateTime;

import java.util.Map;
import java.util.concurrent.CompletableFuture;

public interface ITradingDatabaseHistoryInterface {

    CompletableFuture<Map<String, Object>> getSymbolsAsync(ICancellation cancellation);
    CompletableFuture<HistoricalDataMessageDateTime[]> getHistoricalDataMessageDateTimesAsync(Object id, double begin, double end, ICancellation cancellation);

}
