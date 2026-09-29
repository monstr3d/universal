package measurements.differential_equations.processors;

import diagram.interfaces.IDesktop;
import general_service.Performer;
import measurements.differential_equations.interfaces.IDifferentialEquationProcessor;
import measurements.differential_equations.interfaces.IDifferentialEquationSolver;
import measurements.interfaces.IMeasurements;
import measurements.time.interfaces.ITimeMeasurementProvider;

public class DifferentialEquationProcessor implements IDifferentialEquationProcessor {

    public DifferentialEquationProcessor(IDesktop desktop)
    {
        this.desktop = desktop;
    }

    protected Performer performer = new Performer();

    protected int dimension;


    protected IDifferentialEquationSolver[] equations = new IDifferentialEquationSolver[0];


    protected ITimeMeasurementProvider timeProvider;

    @Override
    public IDifferentialEquationSolver[] getDifferentialEquations() {
       return equations;
    }


    @Override
    public void addRangeDifferentialEquations(IDifferentialEquationSolver[] equations) {
        this.equations = performer.extend(this.equations, equations);
    }

    @Override
    public void stepDifferentialEquations(double start, double finish) {

    }

    @Override
    public void updateDimension() {
        dimension = 0;
        for (IDifferentialEquationSolver s : equations)
        {
            dimension += ((IMeasurements)s).getMeasurementsCount();
        }

    }

    @Override
    public ITimeMeasurementProvider getDifferentialEquationsTimeProvider() {
        return timeProvider;
    }

    @Override
    public void setDifferentialEquationsTimeProvider(ITimeMeasurementProvider timeProvider) {
        this.timeProvider = timeProvider;
    }

    @Override
    public void clearDifferentialEquations() {
        equations = new IDifferentialEquationSolver[0];
    }

    @Override
    public IDifferentialEquationProcessor newDifferentialEquations(IDesktop desktop) {
        return null;
    }

    protected IDesktop desktop;
}
