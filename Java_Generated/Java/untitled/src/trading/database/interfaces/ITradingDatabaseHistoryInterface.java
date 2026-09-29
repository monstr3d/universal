package trading.database.interfaces;

import cancellation.interfaces.ICancellation;

import java.util.Map;
import java.util.Objects;
import java.util.concurrent.CompletableFuture;

public interface ITradingDatabaseHistoryInterface {

    CompletableFuture<Map<String, Object>> getSymbols(ICancellation cancellation);
}
