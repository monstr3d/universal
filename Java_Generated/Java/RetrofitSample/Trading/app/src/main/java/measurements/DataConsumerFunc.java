package measurements;

import general_service.interfaces.IFunc;
import measurements.interfaces.IDataConsumer;
import measurements.interfaces.IMeasurement;

public class DataConsumerFunc implements IFunc {

    Performer mPerformer = new Performer();
    IDataConsumer dataConsumer;

    String name;

    IMeasurement measurement;

    public DataConsumerFunc(IDataConsumer consumer, String name)
    {
        dataConsumer = consumer;
        this.name = name;
        measurement = mPerformer.getMeasurement(consumer, name);
    }

    @Override
    public Object func() {
        return measurement.getMeasurementValue();
    }
}
