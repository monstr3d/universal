package measurements.variables;
import general_service.interfaces.IValue;
import general_service.interfaces.IValueSetter;
import general_service.interfaces.IValueSetterFactory;
import measurements.interfaces.IDerivation;
import measurements.interfaces.IMeasurement;

import java.lang.reflect.Array;

public class Variable implements IMeasurement,  IValue, IDerivation {
    public Variable(Object type, String name,  IValueSetterFactory factory) {
        this.type = type;
        this.name = name;
        setter = factory.getValueSetter(type);
        value = setter.getDefaultValue();
    }



    @Override
    public Object getIValue() {
        return setter.getValue();
    }

    @Override
    public void setIValue(Object value) {

        setter.setValue(value);
    }

    @Override
    public IMeasurement getDerivation() {
        return derivation;
    }

    @Override
    public void setDerivation(IMeasurement measurement) {
        derivation = measurement;
    }

    @Override
    public String getMeasurementName() {
        return name;
    }

    @Override
    public Object getMeasurementType() {
        return type;
    }

    @Override
    public Object getMeasurementValue() {
        return setter.getValue();
    }

    Object value;

    Object type;

    Array array;

    String name;

    IMeasurement derivation;

    @Override
    public String toString() {
        return setter.toString();
    }

    IValueSetter setter;
    measurements.Performer mPerformer = new measurements.Performer();
}

