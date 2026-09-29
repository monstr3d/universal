package tests;

import general_service.interfaces.IAction;
import generated.Condition;
import measurements.Performer;
import measurements.interfaces.IDataConsumer;
import measurements.interfaces.IMeasurements;
import runtime.DataRuntimeConsumer;

public class ConditionAct extends Condition implements IAction {

    public ConditionAct()
    {
        super();
        var c = getCategoryObjects();
        consumer =  performer.get(this, "Chart");
        measurements = consumer.getAllMeasurements();
    }

    @Override
    public void action() {
        System.out.println("\n+++++");
        for (var m : measurements) {
             var n = m.getMeasurementsCount();
            for (var i = 0; i < n; i++) {
                var o = m.getMeasurement(i);
                System.out.print(o + " ");
            }
        }
    }


    public void test()
    {
        var r = new DataRuntimeConsumer(consumer);
        var p = new Performer();
        p.performFixedStepCalculation(r, 0, 0.01, 300, this, "Condition.Formula_1");
    }

    IDataConsumer consumer;

    IMeasurements[] measurements;

}
