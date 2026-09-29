package category_theory;

import category_theory.interfaces.ICategoryObject;
import diagram.interfaces.IDesktop;
import error_handler.interfaces.ICheck;
import error_handler.interfaces.IErrorHandler;
import general_service.Performer;

/**
 *
 */
public class CategoryObject implements ICategoryObject {

    protected  String name;

    public IDesktop desktop;



    public CategoryObject(String name, IDesktop desktop)
    {
        this.name = name;
        this.desktop = desktop;
        if (desktop != null)
        {
            desktop.addCategoryObject(this);
            checker = desktop.getCheck();
            errorHandler = desktop.getErrorHandler();
        }

    }

    /**
     * @return
     */
    @Override
    public String getCategoryObjectName() {
        return name;
    }

    /**
     * @return
     */
    @Override
    public IDesktop getDesktop() {
        return desktop;
    }


    protected boolean check(Object o)
    {
        return checker.check(o);
    }
    protected void show(String message)
    {
        errorHandler.show(message);
    }

    protected void handle(Throwable throwable)
    {
        errorHandler.handle(throwable);
    }

    IErrorHandler errorHandler;

    protected ICheck checker;

    protected Performer performer = new Performer();


}
