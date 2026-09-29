package trading.database.classes;

import trading.database.interfaces.ITradingDatabaseHistoryInterface;

public class TradingDatabaseHistoryInterface {

    static  ITradingDatabaseHistoryInterface inter;

    static public ITradingDatabaseHistoryInterface get()
    {
        return  inter;
    }

    static public void   set(ITradingDatabaseHistoryInterface inter)
    {
        TradingDatabaseHistoryInterface.inter = inter;
    }


}
