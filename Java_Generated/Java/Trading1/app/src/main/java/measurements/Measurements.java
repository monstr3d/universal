package measurements;

import category_theory.CategoryObject;
import diagram.interfaces.IDesktop;
import measurements.interfaces.IMeasurement;
import measurements.interfaces.IMeasurements;

import java.util.ArrayList;
import java.util.List;

public class Measurements extends CategoryObject implements IMeasurements {
    public Measurements(String name, IDesktop desktop) {
        super(name, desktop);
    }

    List<IMeasurement> measurements = new ArrayList<>();

    @Override
    public int getMeasurementsCount() {
        return measurements.size();
    }

    @Override
    public IMeasurement getMeasurement(int i) {
        return measurements.get(i);
    }

    @Override
    public void updateMeasurements() {

    }

    @Override
    public void addMeasurement(IMeasurement measurement) {
        measurements.add(measurement);
    }
}
