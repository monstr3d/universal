package error_handler;
import error_handler.interfaces.IErrorHandler;

public class ConsoleErrorHandler  implements IErrorHandler {
    @Override
    public void handle(Throwable exception) {
        System.err.println((exception.getMessage()));
    }

    @Override
    public void show(String message) {
        System.out.println(message);
    }
}
