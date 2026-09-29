package measurements;

import category_theory.CategoryObject;
import category_theory.interfaces.ICategoryObject;
import diagram.interfaces.IDesktop;
import error_handler.interfaces.ICheck;
import error_handler.interfaces.ICheckHolder;
import general_service.Entry;
import general_service.Performer;
import general_service.interfaces.*;
import measurements.interfaces.IDataConsumer;
import measurements.interfaces.IMeasurements;
import measurements.time.interfaces.ITimeMeasurementConsumer;
import measurements.time.interfaces.ITimeMeasurementProvider;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class DataConsumer extends CategoryObject implements IDataConsumer, IPostSetArrow,
        ITimeMeasurementConsumer, IPrintedObject, ICheckHolder {

    protected Performer performer = new Performer();
    protected measurements.Performer mPerformer = new measurements.Performer();

    ITimeMeasurementConsumer tms;

    ITimeMeasurementProvider timeMeasurement;

    protected boolean success = true;

    protected IDataConsumer dataConsumer;

    protected IValueSetterFactory valueSetterFactory;

    protected List<IMeasurements> measurements = new ArrayList<>();

    protected List<IMeasurements> dependent = new ArrayList<>();

    protected List<Object> list = new ArrayList<>();

    protected Object variable;

    public DataConsumer(String name, IDesktop desktop) {
        super(name, desktop);
        valueSetterFactory = desktop.getValueSetterFactory();
    }

    protected void init() {

    }


    @Override
    public IMeasurements[] getAllMeasurements() {
        var size = measurements.size();
        IMeasurements[] m = new IMeasurements[size];
        measurements.toArray(m);
        return m;
    }

    @Override
    public void addMeasurements(IMeasurements item)
    {
        measurements.add(item);
        mPefrformer.GetDependent(measurements, list, dependent);
    }

    @Override
    public void postSetArrow() {

    }

    @Override
    public ITimeMeasurementProvider getTimeMeasutement() {
        return timeMeasurement;
    }

    @Override
    public void setTimeMeasurement(ITimeMeasurementProvider provider) {
        timeMeasurement = provider;
    }

    @Override
    public double getInternalTime() {
        return 0;
    }

    protected String[] copyMap(Map<String, Entry<Object, Object>> input, Map<String, IValueSetter> output) {
        return mPefrformer.copyMap(input, output, valueSetterFactory);
    }


    protected measurements.Performer mPefrformer = new measurements.Performer();

    @Override
    public void print(IPrinter printer) {
        var m = getAllMeasurements();
        for (var mea : m) {
            ICategoryObject co = (ICategoryObject) mea;
            var s = co.getCategoryObjectName() + " ";
            int n = mea.getMeasurementsCount();
            for (int i = 0; i < n; i++) {
                s += mea.getMeasurement(i) + " ";
            }
            printer.print(s + "\n");
        }
    }

    @Override
    public ICheck getChecker() {
        return checker;
    }

    @Override
    public void setChecker(ICheck check) {
        checker = check;

    }
}