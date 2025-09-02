import { AliasInitialValueCollection } from "../AliasInitialValueCollection.";
import { FictionInitialValueCollection } from "../Fiction/FictionInitialValueCollection";
import { FictiveAlias } from "../Fiction/FictiveAlias";
import { IAlias } from "../Interfaces/IAlias";
import { IDesktop } from "../Interfaces/IDesktop";
import { IInitialValueCollection } from "../Interfaces/IInitialValueCollection";
import { DataConsumerVariableMeasurements } from "./DataConsumerVariableMeasurements";
import { IStarted } from "./Interfaces/IStarted";

export class DataConsumerVariableMeasurementsStarted extends DataConsumerVariableMeasurements implements IStarted
{
    protected initial: IInitialValueCollection = new FictionInitialValueCollection();


    protected alias: IAlias = new FictiveAlias();

    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name);
        this.typeName = "DataConsumerVariadbleMeasurementsStarted";
        this.types.push("IStarted");
        this.types.push("DataConsumerVariadbleMeasurementsStarted");
        this.alias = this;
    }


    startedStart(start: number): void {
        this.initial.resetInitialValues();
    }



    setInitial(): void {
        this.initial = new AliasInitialValueCollection(this, this);
    }

}