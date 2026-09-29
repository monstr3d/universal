package general_service;

import general_service.interfaces.IFeedback;
import general_service.interfaces.IFeedbackCollection;
import measurements.interfaces.IMeasurements;

import java.util.*;

public class FeedbackCollection implements IFeedbackCollection {

    public FeedbackCollection(Map<String, String> map)
    {
       performer.copyMap(map, this.map);
    }

    public FeedbackCollection(IMeasurements measurements, List<Entry<int[], String>> list)
    {
        for (var l : list)
        {
            var k = l.getKey();
            var f = new FeedbackAlias(measurements, k[0], k[1], l.getValue());
            addFeedback(f);
        }
    }

    @Override
    public Map<String, String> getFeedbacksMap() {
        return map;
    }

    @Override
    public void addFeedback(IFeedback feedback) {
        feedbacks = performer.extend(feedbacks, feedback);
    }

    @Override
    public IFeedback[] getFeedbacks() {
        return feedbacks;
    }

    @Override
    public void setFeedbacks() {
        for (var feedback : feedbacks) {
            feedback.setFeedback();
        }
    }

    @Override
    public boolean isEmpty() {
        return feedbacks.length == 0;
    }

    protected IFeedback[] feedbacks = new IFeedback[0];

    protected Performer performer = new Performer();

    protected Map<String, String> map = new HashMap<>();


}
