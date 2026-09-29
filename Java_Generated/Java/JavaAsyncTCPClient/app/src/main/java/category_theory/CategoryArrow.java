package category_theory;

import category_theory.interfaces.ICategoryArrow;
import category_theory.interfaces.ICategoryObject;
import diagram.interfaces.IDesktop;
import error_handler.interfaces.ICheck;
import error_handler.interfaces.IErrorHandler;

public class CategoryArrow implements ICategoryArrow {

    protected  ICategoryObject source;

    protected  ICategoryObject target;

    protected String name;

    protected  IDesktop desktop;
    protected IErrorHandler errorHandler;


    protected ICheck checker;

    public CategoryArrow(String name, IDesktop desktop)
    {
        this.name = name;
        this.desktop = desktop;
        if (desktop != null)
        {
            desktop.addCategoryArrow(this);
            checker = desktop.getCheck();
            errorHandler = desktop.getErrorHandler();
        }

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


    /**
     * @return
     */
    @Override
    public ICategoryObject getSource() {
        return source;
    }

    /**
     * @return
     */
    @Override
    public ICategoryObject getTarget() {
        return target;
    }

    /**
     * @param source
     */
    @Override
    public void setSource(ICategoryObject source) {
        this.source = source;
    }

    /**
     * @param target
     */
    @Override
    public void setTarget(ICategoryObject target) {
        this.target = target;
    }

    /**
     * @return
     */
    @Override
    public String getArrowName() {
        return name;
    }

    /**
     * @return
     */
    @Override
    public IDesktop getDesktop() {
        return desktop;
    }
}

