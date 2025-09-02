
import { IDesktop } from "../Interfaces/IDesktop";
import { IMeasurements } from "./Interfaces/IMeasurements";
import { IPostSetArrow } from "../Interfaces/IPostSetArrow";
import { IStarted } from "./Interfaces/IStarted";
import { IAlias } from "../Interfaces/IAlias";
import { IFeedbackAliasCollectionHolder } from "../Interfaces/IFeedbackAliasCollectionHolder";
import { FictiveAlias } from "../Fiction/FictiveAlias";
import { FictionInitialValueCollection } from "../Fiction/FictionInitialValueCollection";
import { IInitialValueCollection } from "../Interfaces/IInitialValueCollection";
import { AliasInitialValueCollection } from "../AliasInitialValueCollection.";
import { IFeedbackAliasCollection } from "../Interfaces/IFeedbackAliasCollection";
import { DataConsumerVariableMeasurements } from "./DataConsumerVariableMeasurements";


export class Recursive extends DataConsumerVariableMeasurements implements IStarted,
    IFeedbackAliasCollectionHolder, IPostSetArrow
{
    protected inputs: IMeasurements[] = [];


    protected arguments: string[] = [];

  //  protected initial: Map<string, any> = new Map();

    protected operationNames: Map<number, string> = new Map();

    protected alias: IAlias = new FictiveAlias();

    protected initial: IInitialValueCollection = new FictionInitialValueCollection();

    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);
        this.typeName = "Recursive";
        this.types.push("IStarted");
        this.types.push("IPostSetArrow");
        this.types.push("IFeedbackAliasCollectionHolder");
        this.types.push("Recursive");
        this.alias = this;

    }
    getFeedbackAliasCollection(): IFeedbackAliasCollection {
        throw new Error("Method not implemented.");
    }

    startedStart(start: number): void
    {
        this.initial.resetInitialValues();
    }

    setIniitial(): void
    {
        this.initial = new AliasInitialValueCollection(this, this);
    }

    init(): void
    {

    }

   
    postSetArrow(): void
    {
        this.init();
        this.setFeedback();
        this.setIniitial();
    }

    getAllMeasurements(): IMeasurements[] {
        return this.inputs;
    }

    addMeasurements(item: IMeasurements): void {
        this.inputs.push(item);
    }

    calculateTree(): void
    {

    }

    save(): void
    {

    }


    updateMeasurements(): void
    {
        this.feedback.setFeedbacks();
//        this.performer.updateChildrenData(this);
        this.calculateTree();
        this.save();
    }
}
