package measurements;

import diagram.interfaces.IDesktop;
import measurements.interfaces.IMeasurement;

import java.util.Random;

public class RandomGenerator  extends  Measurements implements IMeasurement {
    public RandomGenerator(String name, IDesktop desktop) {
        super(name, desktop);
        addMeasurement(this);
    }

    @Override
    public String getMeasurementName() {
        return "Random";
    }

    @Override
    public Object getMeasurementType() {
        return type;
    }

    @Override
    public Object getMeasurementValue() {
        return value;
    }

    @Override
    public String toString()
    {
        return value[0] + "";
    }

    @Override
    public void updateMeasurements() {
        value[0] = random.nextDouble();
    }
    double[] type = new double[0];
    double[] value = new double[]{0};

    Random random = new Random();

}
