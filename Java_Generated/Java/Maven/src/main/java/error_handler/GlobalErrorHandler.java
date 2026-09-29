package error_handler;

import error_handler.interfaces.IErrorHandler;

public class GlobalErrorHandler {

    static IErrorHandler errorHandler;

    static public IErrorHandler get() {
        return errorHandler;
    }

    static public void set(IErrorHandler errorHandler) {
        GlobalErrorHandler.errorHandler = errorHandler;
    }
}
