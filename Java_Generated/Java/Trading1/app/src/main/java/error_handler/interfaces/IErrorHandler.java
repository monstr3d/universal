package error_handler.interfaces;

public interface IErrorHandler {
    void handle(Throwable exception);
    void show(String message);
}
