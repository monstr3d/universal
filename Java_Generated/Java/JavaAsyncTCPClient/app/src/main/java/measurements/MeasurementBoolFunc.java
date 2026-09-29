package measurements;

import general_service.interfaces.IFuncT;
import measurements.interfaces.IMeasurement;

public class MeasurementBoolFunc implements IFuncT<boolean[]> {
    public MeasurementBoolFunc(IMeasurement measurement)
    {
        this.measurement = measurement;
    }
    IMeasurement measurement;

    @Override
    public boolean[] funcT() {
        var value = measurement.getMeasurementValue();
        return (boolean[])value;
    }
}
