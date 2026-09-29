import communication.GreetClient;
import communication.SimpleClient;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        try {
            GreetClient client = new GreetClient();
            client.startConnection("127.0.0.1", 6666);
            while (true) {
                String response = client.sendMessage("hello server");
                System.out.println(response);
            }
      //      client.stopConnection();
        }
        catch (Throwable e)
        {
int i = 0;
        }

        //assertEquals("hello client", response);
    }
}