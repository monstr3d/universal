package general_service.interfaces;

public interface IInitialValueCollection {
    IInitialValue[] getInitialValues();

    void resetInitialValues();

    void addInitialValue(IInitialValue value);

}
