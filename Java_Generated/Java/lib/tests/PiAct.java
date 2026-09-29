package tests;

import android.util.Log;

import general_service.interfaces.IAction;
import generated.PI;
import measurements.Performer;
import measurements.interfaces.IDataConsumer;
import measurements.interfaces.IMeasurements;
import runtime.DataRuntimeConsumer;


public class PiAct extends PI implements IAction {
    public PiAct()
    {
        super();
        var c = getCategoryObjects();
        consumer =  performer.get(this, "Chart");
        measurements = consumer.getAllMeasurements();
    }

    @Override
    public void action() {
        for (var m : measurements) {
            var n = m.getMeasurementsCount();
            for (var i = 0; i < n; i++) {
                var o = m.getMeasurement(i);
                Log.d("", o + "\n");
            }
        }
    }

    IDataConsumer consumer;

    IMeasurements[] measurements;

    public void test()
    {
        var r = new DataRuntimeConsumer(consumer);
        var p = new Performer();
        p.performFixedStepCalculation(r, 0, 1, 1000, this);
    }

}
