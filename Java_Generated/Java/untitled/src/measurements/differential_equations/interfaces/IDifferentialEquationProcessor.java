package measurements.differential_equations.interfaces;

import diagram.interfaces.IDesktop;
import measurements.time.interfaces.ITimeMeasurementProvider;

public interface IDifferentialEquationProcessor {

    IDifferentialEquationSolver[] getDifferentialEquations();

    void addRangeDifferentialEquations(IDifferentialEquationSolver[] equations);

    void stepDifferentialEquations(double start, double finish);

    void updateDimension();

    ITimeMeasurementProvider getDifferentialEquationsTimeProvider();

    void setDifferentialEquationsTimeProvider(ITimeMeasurementProvider timeProvider);

    void clearDifferentialEquations();

    IDifferentialEquationProcessor newDifferentialEquations(IDesktop desktop);
}