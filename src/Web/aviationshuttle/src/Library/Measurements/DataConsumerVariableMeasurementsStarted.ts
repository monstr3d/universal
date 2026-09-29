/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { AliasInitialValueCollection } from "../AliasInitialValueCollection.";
import type { IDesktop } from "../Interfaces/IDesktop";
import type { IFeedbackCollection } from "../Interfaces/IFeedbackCollection";
import type { IInitialValueCollection } from "../Interfaces/IInitialValueCollection";
import { DataConsumerVariableMeasurements } from "./DataConsumerVariableMeasurements";
import { FeedbackAliasCollection } from "./FeedBack/FeedbackAliasCollection";
import type { IFeedbackHolder } from "./Interfaces/IFeedbackHolder";
import type { IStarted } from "./Interfaces/IStarted";

export class DataConsumerVariableMeasurementsStarted extends DataConsumerVariableMeasurements implements IStarted, IFeedbackHolder
{
    protected initial !: IInitialValueCollection;


    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name);
        this.typeName = "DataConsumerVariadbleMeasurementsStarted";
        this.types.push("IStarted");
        this.types.push("DataConsumerVariadbleMeasurementsStarted");
        this.alias = this;
    }
    getFeedbackCollection(): IFeedbackCollection {
        return this.feedback;
    }


    startedStart(start: number): void {
        this.fictiveStart = start
        this.initial.resetInitialValues();
    }

    protected fictiveStart: number = 0



    setInitial(): void {
        this.initial = new AliasInitialValueCollection(this, this);
    }

    setFeedback(): void {
        let map = new Map<string, string>();
        this.feedback = new FeedbackAliasCollection(map, this, this);
    }

    feedback !: IFeedbackCollection;

}