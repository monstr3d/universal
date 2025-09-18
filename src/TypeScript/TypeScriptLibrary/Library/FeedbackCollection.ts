/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

import type { IFeedback } from "./Interfaces/IFeedback";
import type { IFeedbackCollection } from "./Interfaces/IFeedbackCollection";
import { Performer } from "./Performer";

export class FeedbackCollection implements IFeedbackCollection
{
    constructor(map: Map<string, string>)
    {
        this.performer.copyMap(map, this.map);
    }

    getFeedbacks(): IFeedback[]
    {
        return this.feedbacks;
    }


    setFeedbacks(): void
    {
        for (let feedback of this.feedbacks)
        {
            feedback.setFeedback();
        }
    }


    getFeedbacksMap(): Map<string, string> {
        return this.map;
    }

    addFeedback(feedback: IFeedback): void {
        this.feedbacks.push(feedback);
    }

    isEmpty(): boolean
    {
        return this.feedbacks.length === 0;
    }

    protected performer: Performer = new Performer();


    protected feedbacks: IFeedback[] = [];

    protected map: Map<string, string> = new Map();



}