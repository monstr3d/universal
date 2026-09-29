package communication.interfaces;

public interface IByteClient {

    void send(byte[] bytes);

    byte[] receive();
}
