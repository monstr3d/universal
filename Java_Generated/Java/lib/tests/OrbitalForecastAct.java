package tests;

import error_handler.interfaces.ICheck;
import general_service.android.AndroidPrinter;
import general_service.interfaces.IAction;
import general_service.interfaces.IAlias;
import generated.OrbitalForecast;
import measurements.Performer;
import measurements.differential_equations.processors.RungeProcessor;
import measurements.interfaces.IDataConsumer;
import measurements.interfaces.IMeasurements;
import runtime.DataRuntimeConsumerODE;

public class OrbitalForecastAct extends OrbitalForecast implements IAction {
    IDataConsumer consumer;

    IMeasurements measurements;

    IAlias alias;

    public OrbitalForecastAct() {
        var check = new Check();
        general_service.Performer.setCheker(this, check);
        consumer = performer.get(this, "Chart");
        alias = performer.get(this, "Motion equations");
        var printer = new AndroidPrinter();
        general_service.Performer.setPrinter(printer);
    }

    @Override
    public void action()
    {
      general_service.Performer.print(consumer);
    }

    public void test() {
        setAlias();
        var pr = new RungeProcessor(null);
        var r = new DataRuntimeConsumerODE(consumer, pr);
        var p = new Performer();
       // p.performFixedStepCalculation(r, 0, 1, 18000, this);
        p.performFixedStepCalculation(r, 1770457504, 1, 18000, this, "Recursive.y");

    }

    public void test1() {
        setAlias();
        var pr = new RungeProcessor(null);
        var r = new DataRuntimeConsumerODE(consumer, pr);
        var p = new Performer();
        // p.performFixedStepCalculation(r, 0, 1, 18000, this);
        p.performFixedStepCalculation(r, 1770457504, 1, 18000, this);

    }

    void setAlias()
    {
        double[] x = new double[]
                {
                   -5448.34815324,  -4463.93698421, 0,  -0.98539477743, 1.21681893834,  7.45047785592

                };
        //             Begin: 1770457504, End: 18000, X: -5448.34815324, Y: -4463.93698421, Z: 0, Vx: 0.98539477743, Vy: 1.21681893834, Vz: 7.45047785592
        alias.setAliasValue("x", get(x[0]));
        alias.setAliasValue("y", get(x[1]));
        alias.setAliasValue("z", get(x[2]));
        alias.setAliasValue("v", get(x[3]));
        alias.setAliasValue("u", get(x[4]));
        alias.setAliasValue("w", get(x[5]));

    }

    double[] get(double x)
    {
        return  new double[]{x};
    }


    class  Check implements ICheck
    {


        @Override
        public boolean check(Object obj) {
            return false;
        }
    }

}


