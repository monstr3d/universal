package trading.database.classes;

import cancellation.interfaces.ICancellation;
import cancellation.interfaces.ICancelledObject;
import com.google.gson.Gson;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import com.google.gson.reflect.TypeToken;
import communication.AsyncTcpClient;
import communication.interfaces.IByteReceiver;
import general_service.Performer;
import trading.database.interfaces.ITradingDatabaseHistoryInterface;

import java.util.*;
import java.util.concurrent.CompletableFuture;




public class TcpTradingDatabaseHistoryInterface implements ITradingDatabaseHistoryInterface, IByteReceiver, ICancelledObject
{

    Performer performer = new Performer();

    int port;

    String host;

    ICancellation cancellation;


    AsyncTcpClient client;

    Map<String, Object> map = new HashMap<>();


    public  TcpTradingDatabaseHistoryInterface(String host, int port)
    {
        this.host = host;
        this.port = port;
    }

    @Override
    public CompletableFuture<Map<String, Object>> getSymbols(ICancellation cancellation) {
        return CompletableFuture.supplyAsync(() ->
        {
            cancellation.addCancelledObject(this);
            this.cancellation = cancellation;
            try
            {
                client = new AsyncTcpClient(host, port, this);
                String sym = "Symbols";
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

    @Override
    public void Receive(byte[] bytes, int length) {
        String s = new String(bytes);
         JsonObject jsonObject = JsonParser.parseString(s).getAsJsonObject();
        Gson gson = new Gson();
        var ob =  (Map<String, Object>)gson.fromJson(s, new TypeToken<Map<String, Object>>(){}.getType());
        performer.copyMap(ob, map);

    }
    void change(ICancellation cancellation)
    {
    }

    @Override
    public CompletableFuture<Void>  cancelObject() {
        return null;
    }
}
