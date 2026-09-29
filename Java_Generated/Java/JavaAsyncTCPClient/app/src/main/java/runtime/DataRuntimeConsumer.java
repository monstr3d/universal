package runtime;

import category_theory.interfaces.ICategoryArrow;
import category_theory.interfaces.ICategoryObject;
import diagram.interfaces.IDesktop;
import general_service.Performer;
import general_service.interfaces.IActionT;
import measurements.interfaces.*;
import measurements.service.MeasurementsComparator;
import measurements.time.interfaces.ITimeMeasurementConsumer;
import measurements.time.interfaces.ITimeMeasurementProvider;
import runtime.interfaces.IDataRuntime;

import java.util.*;

public class DataRuntimeConsumer implements IDataRuntime, IActionT<IStarted> {

    public DataRuntimeConsumer(IDataConsumer dataConsumer) {
        List<IMeasurements> list = new ArrayList<>();
        this.addDataConsumer(dataConsumer, list);
        var count = list.size();
        ICategoryObject cc = (ICategoryObject) dataConsumer;
        desktop = cc.getDesktop();
        for (int i = count - 1; i >= 0; i--)
        {
            var n = list.get(i);
            measurements = performer.extend(measurements, n);
            if (n instanceof ICategoryObject) {
                addCategoryObjectToRuntime((ICategoryObject) n);
            }
            if (n instanceof IStarted ) {
                started = performer.extend(started, (IStarted) n);
            }

        }
        if (dataConsumer instanceof IMeasurements) {
            measurements = performer.extend(measurements, (IMeasurements) dataConsumer);
        }
        sortMeasurements();
    }

    @Override
    public void updateRuntime()
    {
        for (var m : measurements)
        {
            m.updateMeasurements();
        }
    }


    @Override
    public IDesktop getDesktop()
    {
        return  desktop;
    }


    /// <summary>
    /// Refreshes itself
    /// </summary>
    @Override
    public void refreshRuntime() {

    }

    /// <summary>
    /// Starts all components
    /// </summary>
    /// <param name="time">Start time</param>
    @Override
    public void startRuntime(double time) {
       /* for (var s : started) {
            s.startedStart(time);
        }*/
        timeStart = time;
        var co = desktop.getCategoryObjects();
        for (var obj : co)
        {
            Class<?> interfaceClass = IStarted.class;
            if (interfaceClass.isInstance(obj)) {
                var started  = (IStarted)obj;
                started.startedStart(time);
            }
        }

    }

    @Override
    public void stepRuntime(double begin, double end) {

    }

    @Override
    public   void addCategoryObjectToRuntime(ICategoryObject object){
        categoryObjects = performer.extend(categoryObjects, object);
        var n = object.getCategoryObjectName();
        categoryObjectsMap.put(n, object);
    }

    @Override
    public ICategoryObject getRuntimeObject(String name) {
        return categoryObjectsMap.get(name);
    }

    @Override
    public void setTimeProvider(ITimeMeasurementProvider provider) {
        timeProvider = provider;
        for (var c : categoryObjects)
        {
            if (c instanceof ITimeMeasurementConsumer)
            {
                var co = (ITimeMeasurementConsumer)c;
                 co.setTimeMeasurement(provider);
            }
        }
    }

    @Override
    public ITimeMeasurementProvider getTimeProvider() {
        return timeProvider;
    }

    @Override
    public ICategoryObject[] getRuntimeObjects() {
        return categoryObjects;
    }

    @Override
    public ICategoryArrow[] getRuntimeArrows() {
        return categoryArrows;
    }

    @Override
    public IStarted[] getStarted() {
        return  started;
    }


    protected  void  addDataConsumer(IDataConsumer dc, List<IMeasurements> list) {
        var m = dc.getAllMeasurements();
        var n = m.length;
        if (n != 0) {
            for (var i = 0; i < n; i++) {
                var mea = m[i];
                if (list.lastIndexOf(mea) >= 0) {
                    continue;
                }
                list.add(mea);
                if (mea instanceof IDataConsumer) {
                    addDataConsumer((IDataConsumer) mea, list);
                }

            }
        } else {

        }
    }

    protected void sortMeasurements()
    {
        List<IMeasurements> measurementsList = new ArrayList<>();
        Collections.addAll(measurementsList, measurements);
        Collections.sort(measurementsList, comparator);
        var n = measurements.length;
        measurements = measurementsList.toArray(new IMeasurements[n]);
    }





    protected IDesktop desktop;

    protected  Comparator<IMeasurements> comparator = new MeasurementsComparator();

    ICategoryArrow[] categoryArrows = new ICategoryArrow[0];

    IStarted[] started  = new IStarted[0];


    ICategoryObject[] categoryObjects = new ICategoryObject[0];

    ITimeMeasurementProvider timeProvider;

    protected  IMeasurements[] measurements = new IMeasurements[0];

    protected Performer performer = new Performer();

    protected Map<String, ICategoryObject> categoryObjectsMap = new HashMap<>();

    protected double timeStart;

    @Override
    public void actionT(IStarted iStarted) {
        if (iStarted != null) {
            iStarted.startedStart(timeStart);
        }
    }
}
