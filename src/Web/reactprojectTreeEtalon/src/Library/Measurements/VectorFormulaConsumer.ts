/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IDesktop } from "../Interfaces/IDesktop";
import type { IFeedbackCollection } from "../Interfaces/IFeedbackCollection";
import type { IPostSetArrow } from "../Interfaces/IPostSetArrow";
import type { IPrintedObject } from "../Interfaces/IPrintedObject";
import type { IRunning } from "../Interfaces/IRunning";
import { DataConsumerVariableMeasurements } from "./DataConsumerVariableMeasurements";

export class VectorFormulaConsumer extends DataConsumerVariableMeasurements implements IPostSetArrow, IRunning
{

    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name);
        this.typeName = "VectorFormulaConsumer";
        this.types.push("VectorFormulaConsumer");
        this.types.push("IPostSetArrow");
        this.types.push("IRunning");
        this.types.push("IPrintedObject");

    }

    setRunning(running: boolean): void {
        this.isRunning = running
        this.reset()
    }

    getRunning(): boolean {
        return this.isRunning
    }

    updateMeasurements(): void {
        this.calculateTree();
        this.save();
        this.feedback?.setFeedbacks()
    }

    calculateTree(): void
    {
    }

    init(): void {

    }

    save(): void {

    }

    protected reset(): void {

    }

    setFeedback(): void {

    }


    postSetArrow(): void
    {
        this.init();
        this.setFeedback()
    }

    feedback !: IFeedbackCollection;

    isRunning: boolean = false

}

