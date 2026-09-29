package general_service.setters.factory;

import error_handler.interfaces.IErrorHandler;
import general_service.interfaces.IValueSetter;
import general_service.interfaces.IValueSetterFactory;
import general_service.setters.BooleanSetter;
import general_service.setters.DoubleSetter;

public class ValueSetterFactory implements IValueSetterFactory {

    public  ValueSetterFactory(IErrorHandler errorHandler)
    {
        this.errorHandler = errorHandler;
    }
    @Override
    public IValueSetter getValueSetter(Object type) {
        if (type instanceof double[]) {
            return new DoubleSetter(errorHandler);
        }
        if (type instanceof boolean[]) {
            return new BooleanSetter();
        }
        return null;
    }

    protected IErrorHandler errorHandler;
}
