package general_service;

import java.lang.reflect.Array;
import java.util.Map;

import category_theory.interfaces.ICategoryArrow;
import category_theory.interfaces.ICategoryObject;
import diagram.interfaces.IDesktop;
import error_handler.interfaces.ICheck;
import error_handler.interfaces.ICheckHolder;
import error_handler.interfaces.IErrorHandler;
import general_service.interfaces.IPrintedObject;
import general_service.interfaces.IPrinter;




public class Performer
{
    static public void setCheker(IDesktop desktop, ICheck check) {
        var objects = desktop.getCategoryObjects();
        for (var co : objects)
        {
            if (co instanceof ICheckHolder)
            {
                var checkHolder = (ICheckHolder)co;
                checkHolder.setChecker(check);
            }
        }
    }


    static IErrorHandler errorHandler;

    static void set(IErrorHandler errorHandler) {
        Performer.errorHandler = errorHandler;
    }

    public void handle(Throwable exception) {
        errorHandler.handle(exception);
    }

    static IPrinter printer = new ConsolePrinter();

    static public void print(Object object)
    {
        if (object instanceof IPrintedObject)
        {
            var po = (IPrintedObject)object;
            po.print(printer);
            return;
        }
        printer.print(object);
    }

    static public IPrinter getPrinter()
    {
        return printer;
    }

    static  public void setPrinter(IPrinter printer)
    {
        Performer.printer = printer;
    }

    public void show(String message) {
        errorHandler.show(message);
    }

    public <T, S> void copyMap(Map<T, S> from, Map<T, S> to) {
        var e = from.entrySet();
        for (var item : e) {
            to.put(item.getKey(), item.getValue());
        }
    }

    public <T> T[] extend(T[] t, T s) {
        var n = t.length;
        var type = t.getClass();
        var ct = type.getComponentType();
        var r = (T[]) Array.newInstance(ct, n + 1);
        System.arraycopy(t, 0, r, 0, t.length);
        r[n] = s;
        return r;
    }

    public <T> T[] extend(T[] t, T[] s) {
        var n = t.length + s.length;
        var type = s.getClass();
        var ct = type.getComponentType();
        var r = (T[]) Array.newInstance(ct, n);
        System.arraycopy(t, 0, r, 0, t.length);
        System.arraycopy(s, 0, r, t.length, s.length);
        return r;
    }

    public <T> T get(IDesktop desktop, String name) {
        var o = desktop.getCategoryObject(name);
        if (o != null) {
            return (T) o;
        }
        T categoryArrow = (T) desktop.getCategoryArrow(name);
        return categoryArrow;
    }

    public <T> T get(ICategoryObject object, String name) {
        var desktop = object.getDesktop();
        return get(desktop, name);
    }

    public <T> T get(ICategoryArrow arrow, String name) {
        var desktop = arrow.getDesktop();
        return get(desktop, name);
    }


    public <T> T get(Object object, String name)
    {
        if (object instanceof  IDesktop)
        {
            return get((IDesktop)object, name);
        }
        if (object instanceof  ICategoryObject)
        {
            return get((ICategoryObject)object, name);
        }
        if (object instanceof  ICategoryArrow)
        {
            return get((ICategoryArrow)object, name);
        }
       return  null;
    }

    public static  ICategoryObject getCategoryObject(IDesktop desktop, int n)
    {
        return desktop.getCategoryObjects().get(n);
    }

    public static  ICategoryObject getCategoryObject(ICategoryObject object, int n)
    {
        var desktop = object.getDesktop();
        return getCategoryObject(desktop, n);
    }


    public static  ICategoryObject getCategoryObject(ICategoryArrow arrow, int n)
    {
        var desktop = arrow.getDesktop();
        return getCategoryObject(desktop, n);
    }


    public <T>  T getCategoryObject(Object object, int name) {
        if (object instanceof  IDesktop)
        {
            return (T)getCategoryObject((IDesktop)object, name);
        }
        if (object instanceof  ICategoryObject)
        {
            return (T)getCategoryObject((ICategoryObject) object, name);
        }
        if (object instanceof  ICategoryArrow)
        {
            return (T)getCategoryObject((ICategoryArrow) object, name);
        }
        return  null;

        }
    }

