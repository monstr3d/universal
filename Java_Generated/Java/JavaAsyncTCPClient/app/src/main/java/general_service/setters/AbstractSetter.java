package general_service.setters;

import general_service.interfaces.IValueSetter;

public abstract class AbstractSetter implements IValueSetter {

    protected Object value;

    protected Object def;

    @Override
    public Object getDefaultValue() {
        return def;
    }

    @Override
    public Object getValue() {
        return value;
    }

    @Override
    public Object getType() {
        return type;
    }

   protected Object type;

}
