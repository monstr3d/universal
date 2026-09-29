package measurements;

import diagram.interfaces.IDesktop;
import general_service.Entry;
import measurements.interfaces.IStarted;
import measurements.variables.Variable;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class VectorFormulaConsumer extends  DataConsumerMeasurements {
    public VectorFormulaConsumer(String name, IDesktop desktop) {
        super(name, desktop);
    }

    @Override
    public void updateMeasurements() {
      //  mPefrformer.updateChildrenData(this, feedback);
        calculateTree();
        save();
    }

    @Override
    protected void setFeedback(List<Entry<int[], String>> list) {

    }

    @Override
    public void postSetArrow() {
        init();
        createFeedback();
    }

    protected void addVariableValue(String name, Object type)
    {
        var variable = new Variable(type, name, valueSetterFactory);
        addVariable(variable);
    }

    protected void addVariable(Variable variable)
    {
        variables.put(variable.getMeasurementName(), variable);
        addMeasurement(variable);
    }

    protected void save()
    {

    }



    protected void calculateTree() {
    }

protected Map<String, Variable>  variables = new HashMap<>();

}
