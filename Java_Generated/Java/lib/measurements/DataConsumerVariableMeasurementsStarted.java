package measurements;

import diagram.interfaces.IDesktop;
import general_service.AliasInitialValueCollection;
import general_service.Entry;
import general_service.FeedbackCollection;
import general_service.interfaces.IFeedbackCollection;
import general_service.interfaces.IInitialValueCollection;
import measurements.interfaces.IFeedbackHolder;
import measurements.interfaces.IStarted;

import java.util.List;

public class DataConsumerVariableMeasurementsStarted extends DataConsumerVariableMeasurements implements IStarted,
        IFeedbackHolder {
    public DataConsumerVariableMeasurementsStarted(String name, IDesktop desktop) {
        super(name, desktop);
    }

    @Override
    protected void setFeedback(List<Entry<int[], String>> list) {
        feedback = new FeedbackCollection(this, list);
    }

    @Override
    public void startedStart(double startTime) {
        initial.resetInitialValues();
    }

    protected void createInitial()
    {
        initial = new AliasInitialValueCollection(this, this);
    }

    protected void setInitial()
    {
        initial = new AliasInitialValueCollection(this, this);
    }

    protected IInitialValueCollection initial;

    protected IFeedbackCollection feedback;

    @Override
    public IFeedbackCollection getFeedbackCollection() {
        return feedback;
    }
}
