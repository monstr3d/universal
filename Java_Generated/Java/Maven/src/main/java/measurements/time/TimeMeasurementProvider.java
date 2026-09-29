package measurements.time;

import measurements.interfaces.IMeasurement;
import measurements.time.interfaces.ITimeMeasurementProvider;

public class TimeMeasurementProvider implements ITimeMeasurementProvider, IMeasurement {
    @Override
    public IMeasurement getTimeMeasurement() {
        return null;
    }

    @Override
    public double getTime() {
        return time[0];
    }

    @Override
    public void setTime(double time) {
        this.time[0] = time;
    }




    @Override
    public String getMeasurementName() {
        return "Time";
    }

    @Override
    public Object getMeasurementType() {
        return type;
    }

    @Override
    public Object getMeasurementValue() {
        return type;
    }

    double[] time = new double[1];

    double[]  type = new double[0];

}
