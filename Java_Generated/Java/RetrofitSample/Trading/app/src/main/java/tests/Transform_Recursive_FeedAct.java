package tests;

import general_service.interfaces.IAction;
import generated.Transform_Recursive_Feed;
import measurements.Performer;
import measurements.interfaces.IDataConsumer;
import measurements.interfaces.IMeasurement;
import measurements.interfaces.IMeasurements;
import runtime.DataRuntimeConsumer;

public class Transform_Recursive_FeedAct extends Transform_Recursive_Feed implements IAction {
   public  Transform_Recursive_FeedAct()
   {
       super();
       consumer = performer.get(this, "Chart");
       IMeasurements m = performer.get(this, "Transformer");
       measurements = mperformer.get(m);

   }

    @Override
    public void action()
    {
        System.out.println();
        for (var m : measurements) {
            System.out.print(m + " ");
        }
    }

    public void test()
    {
        var r = new DataRuntimeConsumer(consumer);
        mperformer.performFixedStepCalculation(r, 0, 1, 60, this);
    }

    IDataConsumer consumer;

    IMeasurement[] measurements;

    Performer mperformer = new Performer();

}
