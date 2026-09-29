package measurements;

import general_service.interfaces.IFuncT;
import measurements.interfaces.IDataConsumer;

public class DataConsumerFuncT<T> extends DataConsumerFunc implements IFuncT<T> {
    public DataConsumerFuncT(IDataConsumer consumer, String name) {
        super(consumer, name);
    }

    @Override
    public T funcT() {
        return  null;
    }
}
