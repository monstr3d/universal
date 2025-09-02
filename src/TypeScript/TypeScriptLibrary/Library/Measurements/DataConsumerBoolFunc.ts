import { FictiveMeasurement } from "../Fiction/FictiveMeasurement";
import { IFunc } from "../Interfaces/IFunc";
import { Performer } from "../Performer";
import { IDataConsumer } from "./Interfaces/IDataConsumer";
import { IMeasurement } from "./Interfaces/IMeasurement";

export class DataConsumerBoolFunc implements IFunc<boolean>
{

    constructor(dataConsumer: IDataConsumer, name: string)
    {
        this.measurement = this.performer.getMeasurementDC(dataConsumer, name);
    }

    func(): boolean
    {
        var res = this.measurement.getMeasurementValue();
        if (res != undefined)
        {
            return this.performer.convertFromAny<boolean>(res);
        }
        return false;
    }


    measurement: IMeasurement = new FictiveMeasurement();

    performer: Performer = new Performer();

}