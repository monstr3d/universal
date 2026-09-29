package external.trading.library.objects;

import cancellation.interfaces.ICancellation;
import cancellation.interfaces.ICancelledObject;
import cancellation.interfaces.IInitializeTask;
import cancellation.interfaces.IStartTask;
import category_theory.CategoryObject;
import diagram.interfaces.IDesktop;
import general_service.Performer;
import measurements.interfaces.IIterator;
import measurements.interfaces.IMeasurement;
import measurements.interfaces.IMeasurements;
import external.trading.database.classes.HistoricalDataMessageDateTime;
import external.trading.database.interfaces.ITradingDatabaseHistoryInterface;
import external.trading.database.classes.TradingDatabaseHistoryInterface;

import java.util.HashMap;
import java.util.Map;
import java.util.concurrent.CompletableFuture;


public class DataQuery extends CategoryObject implements IInitializeTask, IStartTask, ICancelledObject, IIterator, IMeasurements {

    Performer performer = new Performer();

    protected Object id;

    protected  double begin;

    protected double end;

    protected String period;

    HistoricalDataMessageDateTime[] data;


    ITradingDatabaseHistoryInterface inter = TradingDatabaseHistoryInterface.get();

    public DataQuery(String name, IDesktop desktop)
    {
        super(name, desktop);
    }
    void getSymbols(ICancellation cancellation) {
        try {
            var smb = inter.getSymbolsAsync(cancellation);
            var mp = smb.get();
            performer.copyMap(mp, symbols);
        }
        catch (Throwable e)
        {

        }
    }

    void startTask(ICancellation cancellation)
    {
        try
        {
            var smb = inter.getHistoricalDataMessageDateTimesAsync(id, begin, end, cancellation);
            data = smb.get();
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

    @Override
    public CompletableFuture StartFutureAsync(ICancellation cancellation) {
        return null;
    }

    @Override
    public void nextIterator() {

    }

    @Override
    public void resetIterator() {

    }

    @Override
    public int getMeasurementsCount() {
        return 0;
    }

    @Override
    public IMeasurement getMeasurement(int i) {
        return null;
    }

    @Override
    public void updateMeasurements() {

    }

    @Override
    public void addMeasurement(IMeasurement measurement) {

    }
}

