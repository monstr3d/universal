import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IFeedback } from "../Interfaces/IFeedback";
import { IFeedbackCollection } from "../Interfaces/IFeedbackCollection";

export class FictiveFeedbackCollection implements IFeedbackCollection
{
    getFeedbacksMap(): Map<string, string>
    {
        throw new OwnNotImplemented();
     }
    addFeedback(feedback: IFeedback): void
    {
        throw new OwnNotImplemented();
     }
    getFeedbacks(): IFeedback[]
    {
        throw new OwnNotImplemented();
    }

    setFeedbacks(): void
    {

    }

}