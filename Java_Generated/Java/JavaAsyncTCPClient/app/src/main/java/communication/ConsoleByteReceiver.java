package communication;

import communication.interfaces.IByteReceiver;

public class ConsoleByteReceiver implements IByteReceiver {
    public ConsoleByteReceiver()
    {

    }
    @Override
    public void Receive(byte[] bytes, int length) {
        var s = new String(bytes);
        System.out.println(s);

    }
}
