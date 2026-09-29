package trading.database.classes;

import cancellation.interfaces.ICancellation;
import cancellation.interfaces.ICancelledObject;
import communication.AsyncTcpClient;
import communication.interfaces.IByteReceiver;
import org.jetbrains.annotations.NotNull;
import org.jetbrains.annotations.Nullable;
import trading.database.interfaces.ITradingDatabaseHistoryInterface;

import java.util.*;
import java.util.concurrent.CompletableFuture;

import static com.sun.management.HotSpotDiagnosticMXBean.ThreadDumpFormat.JSON;



public class TcpTradingDatabaseHistoryInterface implements ITradingDatabaseHistoryInterface, IByteReceiver, ICancelledObject
{

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
        // JsonObject jsonObject = JsonParser.parseString(json)
        //        .getAsJsonObject();   }
    }
    void change(ICancellation cancellation)
    {
    }

    @Override
    public CompletableFuture<Void>  cancelObject() {
        return null;
    }
}
