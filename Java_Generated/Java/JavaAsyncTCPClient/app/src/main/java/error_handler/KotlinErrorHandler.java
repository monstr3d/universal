package error_handler;

import error_handler.interfaces.IErrorHandler;

public class KotlinErrorHandler  implements IErrorHandler {


    @Override
    public void handle(Throwable exception) {
        ke.print(exception.getMessage());
    }

    @Override
    public void show(String message) {
ke.print(message);
    }

    KotlinError ke = new KotlinError();
}
