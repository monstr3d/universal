package external.trading.database.classes;

import cancellation.interfaces.ICancellation;
import cancellation.interfaces.ICancelledObject;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.internal.LinkedTreeMap;
import com.google.gson.reflect.TypeToken;
import communication.AsyncTcpClient;
import communication.interfaces.IByteReceiver;
import external.utilities.date_time.OADateConverter;
import general_service.Performer;
import external.trading.database.interfaces.ITradingDatabaseHistoryInterface;

import java.util.*;
import java.util.concurrent.CompletableFuture;




public class TcpTradingDatabaseHistoryInterface implements ITradingDatabaseHistoryInterface, IByteReceiver, ICancelledObject
{

    Performer performer = new Performer();

    OADateConverter oaDateConverter = new OADateConverter();

    int port;

    String host;

    ICancellation cancellation;


    AsyncTcpClient client;

    Map<String, Object> map = new HashMap<>();

   // AutoResetEvent event = new AutoResetEvent(false);

    HistoricalDataMessageDateTime[] messages;


    public  TcpTradingDatabaseHistoryInterface(String host, int port)
    {
        this.host = host;


        this.port = port;
    }

    Gson getGson()
    {
        Gson gson = new GsonBuilder()
                .setPrettyPrinting()
                .create();
        return  gson;
    }

    @Override
    public CompletableFuture<Map<String, Object>> getSymbolsAsync(ICancellation cancellation) {
        return CompletableFuture.supplyAsync(() ->
        {
           set(cancellation);
            try
            {
                client = new AsyncTcpClient(host, port, this);
                var gson = getGson();
                String sym = gson.toJson("Symbols");
                var bt = sym.getBytes();
                client.start(bt);
            }
            catch (Throwable e)
            {
            int i = 0;
            }
            return map;
        });
    }


    void set(ICancellation cancellation)
    {
        if (this.cancellation != null)
        {
            cancellation.removeCancelledObject(this);
        }
        cancellation.addCancelledObject(this);
        this.cancellation = cancellation;
    }

    @Override
    public CompletableFuture<HistoricalDataMessageDateTime[]> getHistoricalDataMessageDateTimesAsync(Object id, double begin, double end, ICancellation cancellation) {
        var data = new Data();
        data.id = id.toString();
        data.begin = begin;
        data.end = end;
        return CompletableFuture.supplyAsync(() ->
        {
    //        event.set();
            set(cancellation);
            try
            {
                client = new AsyncTcpClient(host, port, this);
               // var d =
                var gson = getGson();
                var sym = gson.toJson(data);
                var bt = sym.getBytes();
                client.start(bt);
     //           event.waitOne();
            }
            catch (Throwable e)
            {
                int i = 0;
            }
            return messages;
        });

    }

    @Override
    public void receiveBytes(byte[] bytes, int length) {
        try {
            String s = new String(bytes);
            //   JsonObject jsonObject = JsonParser.parseString(s).getAsJsonObject();
            Gson gson = getGson();
            var o = gson.fromJson(s, new TypeToken<Object>() {
            }.getType());
            //    var ob =  (Map<String, Object>)gson.fromJson(s, new TypeToken<Map<String, Object>>(){}.getType());
            //     performer.copyMap(ob, map);
            if (o instanceof ArrayList<?>) {
                var list = (ArrayList<?>) o;
                messages = new HistoricalDataMessageDateTime[list.size()];
                int i = 0;

                for (var x : list) {
                    var mess = new HistoricalDataMessageDateTime();
                    var map  = (LinkedTreeMap)x;
                    double dt = (double) map.get("date");
                    var date = OADateConverter.fromOADate(dt);
                    mess.date = date;
                    mess.open = (double) map.get("date");
                    mess.high = (double) map.get("high");
                    mess.low = (double) map.get("low");
                    mess.close = (double) map.get("close");
                    mess.volume = (double) map.get("volume");
                    //var ct = map.get("count");
                   // mess.count = (int) map.get("count");
                    mess.wap = (double) map.get("wap");
                    mess.hasGaps = (boolean) map.get("hasGaps");
                    messages[i] = mess;
                    ++i;
                }
                client.close();
                // event.reset();
            }
        } catch (Exception e) {
            throw new RuntimeException(e);
        }

    }
    void change(ICancellation cancellation)
    {
    }

    @Override
    public CompletableFuture<Void>  cancelObject() {
        return null;
    }

    class Data
    {
        public  String id;

        public  double begin;

        public  double end;
    }
}
