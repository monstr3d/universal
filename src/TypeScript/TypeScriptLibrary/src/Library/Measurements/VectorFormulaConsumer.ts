/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IDesktop } from "../Interfaces/IDesktop";
import type { IFeedbackCollection } from "../Interfaces/IFeedbackCollection";
import type { IPostSetArrow } from "../Interfaces/IPostSetArrow";
import { DataConsumerVariableMeasurements } from "./DataConsumerVariableMeasurements";

export class VectorFormulaConsumer extends DataConsumerVariableMeasurements implements IPostSetArrow
{

    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name);
        this.typeName = "VectorFormulaConsumer";
        this.types.push("VectorFormulaConsumer");
        this.types.push("IPostSetArrow");
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

    setFeedback(): void {

    }


    postSetArrow(): void
    {
        this.init();
        this.setFeedback()
    }

    feedback !: IFeedbackCollection;

}

