/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IFeedback } from "./IFeedback";

export interface IFeedbackCollection
{

    getFeedbacksMap(): Map<string, string>;

    addFeedback(feedback: IFeedback): void;

    getFeedbacks(): IFeedback[];

    setFeedbacks(): void;

    isEmpty(): boolean;
}