package tests;

import general_service.interfaces.IAction;
import generated.RandomTwo;
import measurements.Performer;
import measurements.interfaces.IDataConsumer;
import measurements.interfaces.IMeasurements;
import runtime.DataRuntimeConsumer;

import java.io.Console;

public class RandomTwoAct extends RandomTwo implements IAction {

    public RandomTwoAct()
    {
        super();
        var c = getCategoryObjects();
        consumer = (IDataConsumer) getCategoryObjects().get(2);
        measurements = consumer.getAllMeasurements();
    }

    @Override
    public void action() {
    for (var m : measurements)
    {
        System.out.println("+++++");
        var n  = m.getMeasurementsCount();
        for (var i = 0; i < n; i++)
        {
            var o = m.getMeasurement(i);
            System.out.print(o);
        }
    }
   }


    public void test()
    {
var r = new DataRuntimeConsumer(consumer);
var p = new Performer();
p.performFixedStepCalculation(r, 0, 1, 10, this);
    }

    IDataConsumer consumer;

    IMeasurements[] measurements;

}
