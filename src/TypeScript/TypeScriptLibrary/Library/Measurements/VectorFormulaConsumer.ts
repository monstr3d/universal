import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IDesktop } from "../IDesktop";
import { IPostSetArrow } from "../IPostSetArrow";
import { DataConsumerMeasurements } from "./DataConsumerMeasurements";

export class VectorFormulaConsumer extends DataConsumerMeasurements implements IPostSetArrow
{
    protected feedback: Map<number, string> = new Map();

    protected arguments: string[] = [];

    protected operationNames: Map<number, string> = new Map();

    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name);
        this.typeName = "VectorFormulaConsumer";
        this.types.push("VectorFormulaConsumer");
        this.types.push("IPostSetArrow");
    }

    updateMeasurements(): void {
        this.calculateTree();
    }

    calculateTree(): void {
    }



    postSetArrow(): void {
        try {
            throw new OwnNotImplemented();
        }
        catch (e: any) { }
    }


}

//export default VectorFormulaConsumer;