package general_service;

import general_service.interfaces.IInitialValue;
import general_service.interfaces.IInitialValueCollection;

public class InitialValueCollection implements IInitialValueCollection {
    @Override
    public IInitialValue[] getInitialValues() {
        return values;
    }

    @Override
    public void resetInitialValues() {
        for (var iv : values) {
            iv.resetInitValue();
        }
    }

    @Override
    public void addInitialValue(IInitialValue value) {
        values = performer.extend(values, value);
    }

    Performer performer = new Performer();

    IInitialValue[] values = new IInitialValue[0];

}
