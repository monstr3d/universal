package general_service.interfaces;

public interface IValueSetter {
    Object getDefaultValue();

    Object getValue();

    void  setValue(Object o);

    Object getType();

}
