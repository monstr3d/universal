package diagram;

import cancellation.interfaces.ICancellation;
import cancellation.interfaces.IInitializeTask;
import category_theory.interfaces.ICategoryArrow;
import category_theory.interfaces.ICategoryObject;
import diagram.interfaces.IDesktop;
import error_handler.interfaces.ICheck;
import error_handler.interfaces.IErrorHandler;
import general_service.Performer;
import general_service.interfaces.IPostSetArrow;
import general_service.interfaces.IValueSetterFactory;
import general_service.setters.factory.ValueSetterFactory;


import java.util.*;
import java.util.concurrent.CompletableFuture;

public class Desktop  implements IDesktop, ICheck, IErrorHandler
{
    protected List<ICategoryObject> objects = new ArrayList<>();

    protected List<ICategoryArrow> arrows = new ArrayList<>();

    protected Map<String, ICategoryObject> objectMap = new TreeMap<>();
    protected Map<String, ICategoryArrow> arrowMap = new TreeMap<>();

    public Desktop(ICheck check, IErrorHandler errorHandler)
    {
        this.check = check;
        this.errorHandler = errorHandler;
        valueSetterFactory = new ValueSetterFactory(errorHandler);
        init();
    }

    public  Desktop()
    {
        this.check = this;
        this.errorHandler = this;
        valueSetterFactory = new ValueSetterFactory(this);
        init();
    }


    /**
     * @return
     */
    @Override
    public List<ICategoryObject> getCategoryObjects() {
        return objects;
    }

    /**
     * @return
     */
    @Override
    public List<ICategoryArrow> getCategoryArrows() {
        return arrows;
    }

    /**
     * @param obj
     */
    @Override
    public void addCategoryObject(ICategoryObject obj) {
        objects.add(obj);
        objectMap.put(obj.getCategoryObjectName(), obj);
    }

    /**
     * @param arrow
     */
    @Override
    public void addCategoryArrow(ICategoryArrow arrow) {
arrows.add(arrow);
arrowMap.put(arrow.getArrowName(), arrow);
    }

    /**
     * @param name
     * @return
     */
    @Override
    public ICategoryObject getCategoryObject(String name) {
        ICategoryObject o = objectMap.get(name);
        return  o;
    }

    /**
     * @param name
     * @return
     */
    @Override
    public ICategoryArrow getCategoryArrow(String name) {
       ICategoryArrow a = arrowMap.get(name);
       return a;
    }

    @Override
    public void setCheck(ICheck check) {
        this.check = check;

    }

    @Override
    public ICheck getCheck() {
        return check;
    }

    @Override
    public void setErrorHandler(IErrorHandler errorHandler) {
        this.errorHandler = errorHandler;
    }

    @Override
    public IErrorHandler getErrorHandler() {
        return errorHandler;
    }

    @Override
    public void init() {

    }

    @Override
    public IValueSetterFactory getValueSetterFactory()
    {
        return valueSetterFactory;
    }

    protected IValueSetterFactory valueSetterFactory;

    protected void postSet() {
        for (var a : arrows) {
            if (a instanceof IPostSetArrow) {
                var  p = (IPostSetArrow)a;
                p.postSetArrow();
            }
        }
        for (var o : objects) {
            if (o instanceof IPostSetArrow) {
                var  p = (IPostSetArrow)o;
                p.postSetArrow();
            }
        }
    }

    protected void postSetArrow()
    {

    }

    protected  List< CompletableFuture<Void> > GetFutures(ICancellation cancellation)
    {
        List< CompletableFuture<Void> > futures = new ArrayList<>();
        for (var o : objects)
        {
            if (o instanceof IInitializeTask)
            {
                var init = (IInitializeTask)o;
                futures.add(init.InitializeFutureAsync(cancellation));
            }
        }
        for (var a : arrows) {
            if (a instanceof IInitializeTask) {
                var init = (IInitializeTask) a;
                futures.add(init.InitializeFutureAsync(cancellation));
            }
        }

        return  futures;
    }


/*
      protected async Task FinalAsync(CancellationToken token)
      {
          var tasks = new List<Task>();
          foreach (var item in CategoryObjects)
          {
              if (item is IInitializeTask task)
              {
                  tasks.Add(task.Initialize(token));
              }
          }
          foreach (var item in CategoryArrows)
          {
              if (item is IInitializeTask task)
              {
                  tasks.Add(task.Initialize(token));
              }
          }
          await Task.WhenAll(tasks);
      }


 */




    @Override
    public boolean check(Object obj) {
        return false;
    }

    @Override
    public void handle(Throwable exception)
    {

    }

    @Override
    public void show(String message) {

    }

    protected ICheck check;

    protected IErrorHandler errorHandler;

    protected Performer performer = new Performer();
}

