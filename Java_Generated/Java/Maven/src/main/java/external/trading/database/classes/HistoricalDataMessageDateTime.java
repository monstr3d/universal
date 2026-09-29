package external.trading.database.classes;

import java.time.LocalDateTime;

public class HistoricalDataMessageDateTime {
    public LocalDateTime date;
    public double open;
    public double high;
    public double low;
    public double close;
    public double volume;
    public int count;
    public double wap;
    public boolean hasGaps;

}
