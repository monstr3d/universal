/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

import type { IDesktop } from "../Interfaces/IDesktop";
import type { IMeasurements } from "./Interfaces/IMeasurements";
import type { IPostSetArrow } from "../Interfaces/IPostSetArrow";
import { DataConsumerVariableMeasurementsStarted } from "./DataConsumerVariableMeasurementsStarted";
import { FeedbackAliasCollection } from "../FeedbackAliasCollection";
import { Performer } from "../Performer";


export class RecursiveFormula extends DataConsumerVariableMeasurementsStarted implements  IPostSetArrow
{
    protected inputs: IMeasurements[] = [];


    protected arguments: string[] = [];

  //  protected initial: Map<string, any> = new Map();

    protected operationNames: Map<number, string> = new Map();

    protected performer: Performer = new Performer();


    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name);
        this.typeName = "RecursiveFormula";
        this.types.push("IPostSetArrow");
        this.types.push("RecursiveFormula");

    }

 
    init(): void
    {

    }

    setFeedback(): void {
        let map = new Map<string, string>();
        this.feedback = new FeedbackAliasCollection(map, this, this);
    }

   
    postSetArrow(): void
    {
        this.init();
        this.setInitial();
        this.setFeedback();
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

    startedStart(start: number)
    {
        this.initial.resetInitialValues();
        this.feedback.setFeedbacks();
    }


    updateMeasurements(): void {
        //this.performer.updateFeedbackData(this, this.feedback)
        this.calculateTree();
        this.save();
        this.feedback.setFeedbacks();
    }
}
