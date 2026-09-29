package runtime;


import measurements.differential_equations.interfaces.IDifferentialEquationProcessor;
import measurements.differential_equations.interfaces.IDifferentialEquationSolver;
import measurements.interfaces.IDataConsumer;
import measurements.time.interfaces.ITimeMeasurementProvider;

public class DataRuntimeConsumerODE extends DataRuntimeConsumer{
    public DataRuntimeConsumerODE(IDataConsumer dataConsumer, IDifferentialEquationProcessor processor) {
        super(dataConsumer);

        this.processor = processor.newDifferentialEquations(desktop);
        var equations = new IDifferentialEquationSolver[0];
        for (var m : this.measurements)
        {
            if (m instanceof  IDifferentialEquationSolver)
            {
                equations = performer.extend(equations, (IDifferentialEquationSolver)m);
            }
         }
        this.processor.addRangeDifferentialEquations(equations);
        this.processor.updateDimension();
    }

    @Override
    public void stepRuntime(double begin, double end) {
        processor.stepDifferentialEquations(begin, end);
    }

    @Override
    public void setTimeProvider(ITimeMeasurementProvider provider) {
        if (processor != null)
        {
            processor.setDifferentialEquationsTimeProvider(provider);
        }
        super.setTimeProvider(provider);
     }


    IDifferentialEquationProcessor processor;

}
