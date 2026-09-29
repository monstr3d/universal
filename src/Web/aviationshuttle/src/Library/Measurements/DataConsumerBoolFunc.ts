/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IFunc } from "../Interfaces/IFunc";
import { Performer } from "../Performer";
import type { IDataConsumer } from "./Interfaces/IDataConsumer";
import type { IMeasurement } from "./Interfaces/IMeasurement";

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


    measurement !: IMeasurement;

    performer: Performer = new Performer();

}