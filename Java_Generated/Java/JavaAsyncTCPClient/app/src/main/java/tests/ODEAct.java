package tests;

import general_service.interfaces.IAction;
import generated.ODE;
import measurements.Performer;
import measurements.differential_equations.processors.RungeProcessor;
import measurements.interfaces.IDataConsumer;
import measurements.interfaces.IMeasurements;
import runtime.DataRuntimeConsumerODE;

public class ODEAct extends ODE implements IAction {

    IDataConsumer consumer;

    IMeasurements measurements;

    public ODEAct() {
        consumer = performer.get(this, "Chart");
        measurements = consumer.getAllMeasurements()[0];
    }

    @Override
    public void action()
    {
        var n = measurements.getMeasurementsCount();
        for (var i = 0; i < n; i++) {
            System.out.print(measurements.getMeasurement(i) + " ");
        }
        System.out.println();
    }

    public void test() {
        var pr = new RungeProcessor(null);
        var r = new DataRuntimeConsumerODE(consumer, pr);
        var p = new Performer();
        p.performFixedStepCalculation(r, 0, 0.4, 45, this);

    }
}
