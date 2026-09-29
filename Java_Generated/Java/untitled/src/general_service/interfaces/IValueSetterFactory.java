package general_service.interfaces;

public interface IValueSetterFactory {
    IValueSetter getValueSetter(Object type);
}
