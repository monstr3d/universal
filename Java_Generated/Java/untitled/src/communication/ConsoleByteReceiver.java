package communication;

import communication.interfaces.IByteReceiver;

public class ConsoleByteReceiver implements IByteReceiver {
    @Override
    public void Receive(byte[] bytes, int length) {
        var s = new String(bytes);
        System.out.println(s);

    }
}
