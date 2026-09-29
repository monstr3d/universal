package diagram.interfaces;

import category_theory.interfaces.ICategoryArrow;
import category_theory.interfaces.ICategoryObject;
import error_handler.interfaces.ICheck;
import error_handler.interfaces.IErrorHandler;
import general_service.interfaces.IValueSetter;
import general_service.interfaces.IValueSetterFactory;

import java.util.List;

public interface IDesktop {
    List<ICategoryObject> getCategoryObjects();

    List<ICategoryArrow> getCategoryArrows();

    void addCategoryObject(ICategoryObject obj);

    void addCategoryArrow(ICategoryArrow arrow);

    ICategoryObject getCategoryObject(String name);

    ICategoryArrow getCategoryArrow(String name);

    void setCheck(ICheck check);

    ICheck getCheck();

    void setErrorHandler(IErrorHandler errorHandler);

    IErrorHandler getErrorHandler();

    void init();

    IValueSetterFactory getValueSetterFactory();
}
