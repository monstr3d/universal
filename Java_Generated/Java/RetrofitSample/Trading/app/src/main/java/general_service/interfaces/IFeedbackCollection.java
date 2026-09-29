package general_service.interfaces;

import java.util.Map;

public interface IFeedbackCollection {
   Map<String, String > getFeedbacksMap();

    void addFeedback(IFeedback feedback);

    IFeedback[]  getFeedbacks();

    void setFeedbacks();

    boolean isEmpty();

}
