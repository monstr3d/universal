package measurements;

import diagram.interfaces.IDesktop;
import general_service.Entry;
import general_service.FeedbackCollection;
import general_service.interfaces.IAlias;
import general_service.interfaces.IFeedbackCollection;
import general_service.interfaces.IValueSetter;
import measurements.interfaces.IMeasurement;
import measurements.interfaces.IMeasurements;
import measurements.variables.Variable;

import java.util.*;

public abstract class DataConsumerMeasurements  extends  DataConsumer implements IMeasurements, IAlias {



    public DataConsumerMeasurements(String name, IDesktop desktop) {

        super(name, desktop);
    }


    @Override
    public int getMeasurementsCount() {
        return iMeasurements.size();
    }

    @Override
    public IMeasurement getMeasurement(int i) {
        return iMeasurements.get(i);
    }

    @Override
    public void updateMeasurements() {

    }

    @Override
    public void addMeasurement(IMeasurement measurement) {
        iMeasurements.add(measurement);
    }



    public double getInternalTime() {

        return timeMeasurement.getTime();
    }

    List<IMeasurement> iMeasurements = new ArrayList<>();

    @Override
    public String[] getAliasNames() {
        return aliasNames;
    }

    @Override
    public Object getAliasType(String name)
    {
        return map.get(name).getType();
    }

    @Override
    public Object getAliasValue(String name)
    {
        var setter =  map.get(name);
        return setter.getValue();
    }

    @Override
    public void setAliasValue(String name, Object obj) {
       var setter =  map.get(name);
       setter.setValue(obj);
    }

    protected void setMap(java.util.Map<String, Entry<Object, Object>> map)
    {
       aliasNames =  copyMap(map, this.map);
    }



    protected void createFeedback() {
        List<Entry<int[], String>> list = new ArrayList<>();
        setFeedback(list);
    }

    protected abstract void setFeedback(List<Entry<int[], String>> list);

    protected void addVariableValue(String name, Object type)
    {
    }

    protected void addVariable(Variable variable)
    {
    }


    java.util.Map<String, IValueSetter> map = new HashMap<>();



    protected String[] aliasNames = new String[0];

}
