package measurements.differential_equations;

import diagram.interfaces.IDesktop;
import general_service.interfaces.IValue;
import measurements.DataConsumerVariableMeasurementsStarted;
import measurements.Performer;
import measurements.differential_equations.interfaces.IDifferentialEquationSolver;
import measurements.interfaces.IMeasurements;
import measurements.interfaces.IStarted;
import measurements.time.interfaces.ITimeMeasurementProvider;
import measurements.variables.Variable;

import java.util.HashMap;
import java.util.Map;

public class DifferentialEquationSolverFormula extends DataConsumerVariableMeasurementsStarted implements IDifferentialEquationSolver, IStarted, IMeasurements
{
    public DifferentialEquationSolverFormula(String name, IDesktop desktop) {
        super(name, desktop);
    }

    /// <summary>
    /// Calculates derivations
    /// </summary>
    @Override
    public void calculateDerivations() {
        feedback.setFeedbacks();
       // mPerformer.updateChildrenData(this);
        for (var d : dependent)
        {
            d.updateMeasurements();
        }
        this.calculateTree();
        this.save();
    }

    @Override
    public void startedStart(double startTime) {
        initial.resetInitialValues();
        feedback.setFeedbacks();
    }


    @Override
    public void postSetArrow()
    {
        init();
        this.setInitial();
        createFeedback();

    }

    /// <summary>
    /// Copies variables from processor to solver
    /// </summary>
    /// <param name="offset">Offset</param>
    /// <param name="variables">Vector of all desktop differential equations variables</param>
    @Override
    public void copyVariablesToSolver(int offset, double[] variables) {
        var n = this.output.length;
        for (var i = 0; i < n; i++)
        {
            val[0] = variables[i + offset];
            output[i].setIValue(val);
        }
   }

   @Override
    protected void addVariableValue(String name,Object type)
    {
        var variable = new Variable(type, name, valueSetterFactory);
        var derivation = new Variable(type, "D" + name, valueSetterFactory);
        variable.setDerivation(derivation);
        derivations.put(name, derivation);
        deri = performer.extend(deri, derivation);
        addVariable(variable);
    }


    ///
    /// Sets time provider
    ///
    @Override
    public void setDifferentialEquationSolverTimeProvider(ITimeMeasurementProvider time) {
this.time = time;
    }

    @Override
    public ITimeMeasurementProvider getDifferentialEquationSolverTimeProvider() {
        return time;
    }

    protected void calculateTree()
    {

    }

    protected void save()
    {

    }

    double[] val = new double[1];


    protected ITimeMeasurementProvider time;

    protected measurements.Performer mPerformer = new Performer();

    protected Map<String, Variable> derivations = new HashMap<>();

    IValue[] deri = new IValue[0];
}