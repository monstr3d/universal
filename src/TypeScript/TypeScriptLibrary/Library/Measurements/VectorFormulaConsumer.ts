import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IDesktop } from "../IDesktop";
import { IPostSetArrow } from "../IPostSetArrow";
import { DataConsumerMeasurements } from "./DataConsumerMeasurements";

export class VectorFormulaConsumer extends DataConsumerMeasurements implements IPostSetArrow
{

    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name);

    }

    PostSetArrow(): void {
        try {
            throw new OwnNotImplemented();
        }
        catch (e: any) { }
    }


}

//export default VectorFormulaConsumer;