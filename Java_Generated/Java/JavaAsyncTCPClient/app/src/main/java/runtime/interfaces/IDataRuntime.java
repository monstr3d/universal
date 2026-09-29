package runtime.interfaces;

import category_theory.interfaces.ICategoryArrow;
import category_theory.interfaces.ICategoryObject;
import diagram.interfaces.IDesktop;
import measurements.interfaces.IStarted;
import measurements.time.interfaces.ITimeMeasurementProvider;

public interface IDataRuntime {

    void updateRuntime();

    /// <summary>
    /// Refreshes itself
    /// </summary>
    void refreshRuntime();

    /// <summary>
    /// Starts all components
    /// </summary>
    /// <param name="time">Start time</param>
    void startRuntime(double time);

    void stepRuntime(double begin, double end);


    void addCategoryObjectToRuntime(ICategoryObject object);


    ICategoryObject getRuntimeObject(String name);


    void setTimeProvider(ITimeMeasurementProvider provider);

    ITimeMeasurementProvider getTimeProvider();

    ICategoryObject[] getRuntimeObjects();


    ICategoryArrow[] getRuntimeArrows();

    IStarted[] getStarted();

    IDesktop getDesktop();

}
