package tests;

import general_service.interfaces.IAction;
import general_service.interfaces.IFuncT;
import generated.RecursiveFeedbackSimple;
import measurements.Performer;
import measurements.interfaces.IDataConsumer;
import measurements.interfaces.IMeasurements;
import runtime.DataRuntimeConsumer;

public class RecursiveFeedbackSimpleAct extends RecursiveFeedbackSimple implements IAction, IFuncT<boolean[]> {

    public RecursiveFeedbackSimpleAct() {
        super();
        var c = getCategoryObjects();
        consumer = performer.get(this, "Chart");
        measurements = consumer.getAllMeasurements();
    }

    @Override
    public void action() {
        general_service.Performer.print(consumer);
     }


    public void test() {
        var r = new DataRuntimeConsumer(consumer);
        var p = new Performer();
        p.performFixedStepCalculation(r, 0, 0.1, 30, this, this, cond);
    }

    IDataConsumer consumer;

    IMeasurements[] measurements;

    @Override
    public boolean[] funcT() {
        return b;
    }

    Cond cond = new Cond();

    boolean[] b = new boolean[]{true};

    class Cond implements IFuncT<boolean[]> {

        @Override
        public boolean[] funcT() {
            return b;
        }

        boolean[] b = new boolean[]{false};


    }
}