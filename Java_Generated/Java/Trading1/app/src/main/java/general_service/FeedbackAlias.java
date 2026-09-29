package general_service;

import category_theory.interfaces.ICategoryObject;
import general_service.interfaces.*;
import measurements.interfaces.IMeasurement;
import measurements.interfaces.IMeasurements;

import java.util.SplittableRandom;

public class FeedbackAlias implements IFeedback, IFeedbackAlias {
    @Override
    public void setFeedback() {
        var value = measurement.getMeasurementValue();
        aliasName.setAliasNameValue(value);
    }

    @Override
    public IAliasName getFeedBackAlias() {
        return null;
    }

    public  FeedbackAlias(IMeasurements measurements, int n, int m, String name) {
        measurement = measurements.getMeasurement(m);
        ICategoryObject co = (ICategoryObject) measurements;
        Object o = measurements;
        this.name = name;
        aliasName = new AliasName(co, n, name);
    }

    protected IAliasName aliasName;

   protected String name;

   protected  general_service.Performer performer = new general_service.Performer();

    protected IMeasurement measurement;
}
