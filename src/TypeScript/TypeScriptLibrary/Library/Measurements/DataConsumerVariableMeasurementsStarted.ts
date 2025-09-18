/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { AliasInitialValueCollection } from "../AliasInitialValueCollection.";
import { FeedbackAliasCollection } from "../FeedbackAliasCollection";
import type { IAlias } from "../Interfaces/IAlias";
import type { IDesktop } from "../Interfaces/IDesktop";
import type { IFeedbackCollection } from "../Interfaces/IFeedbackCollection";
import type { IInitialValueCollection } from "../Interfaces/IInitialValueCollection";
import { DataConsumerVariableMeasurements } from "./DataConsumerVariableMeasurements";
import type { IFeedbackHolder } from "./Interfaces/IFeedbackHolder";
import type { IStarted } from "./Interfaces/IStarted";

export class DataConsumerVariableMeasurementsStarted extends DataConsumerVariableMeasurements implements IStarted, IFeedbackHolder
{
    protected initial !: IInitialValueCollection;


    protected alias !: IAlias;

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
        this.initial.resetInitialValues();
    }



    setInitial(): void {
        this.initial = new AliasInitialValueCollection(this, this);
    }

    setFeedback(): void {
        let map = new Map<string, string>();
        this.feedback = new FeedbackAliasCollection(map, this, this);
    }

    feedback !: IFeedbackCollection;

}