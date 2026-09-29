package tests;

import general_service.interfaces.IAction;
import general_service.interfaces.IFuncT;
import generated.ODE_Feed;

import measurements.Performer;
import measurements.differential_equations.processors.RungeProcessor;
import measurements.interfaces.IDataConsumer;
import measurements.interfaces.IMeasurements;
import runtime.DataRuntimeConsumerODE;

public class ODE_FeedAct extends ODE_Feed implements IAction, IFuncT<boolean[]> {

    IDataConsumer consumer;

    IMeasurements measurements;

    public ODE_FeedAct() {
        super();
        consumer = performer.get(this, "Chart");
        measurements = consumer.getAllMeasurements()[0];
    }

    @Override
    public void action()
    {
        general_service.Performer.print(consumer);
    }

    public void test() {
        var pr = new RungeProcessor(null);
        var r = new DataRuntimeConsumerODE(consumer, pr);
        var p = new Performer();
        p.performFixedStepCalculation(r, 0, 0.1, 30,  this, this, cond);

    }

    @Override
    public boolean[] funcT() {
        return b;
    }

    boolean[] b = new boolean[]{true};

    Cond cond = new Cond();


    class Cond implements IFuncT<boolean[]> {

        @Override
        public boolean[] funcT() {
            return b;
        }

        boolean[] b = new boolean[]{false};


    }
}
