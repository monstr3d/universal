import type { IFeedbackCollection } from "../../Interfaces/IFeedbackCollection";

export interface IFeedbackHolder {
    getFeedbackCollection(): IFeedbackCollection;
}