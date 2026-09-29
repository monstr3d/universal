package general_service.setters;

import error_handler.interfaces.IErrorHandler;
import general_service.interfaces.IValueSetter;

import java.lang.reflect.Array;

public class DoubleSetter extends AbstractSetter {

    IErrorHandler handler;

    public DoubleSetter(IErrorHandler handler) {
        value = array;
        def = new double[]{0};
        type = new double[0];
        this.handler = handler;
    }


    @Override
    public void setValue(Object o) {
        if (o == null)
        {
            value = null;
            return;
        }
        var d = (double[]) o;
        array[0] = d[0];
        value = array;
    }

    @Override
    public String toString() {
        return value == null ? "null" : array[0] + "";
    }

    private final double[] array = new double[]{0};
}