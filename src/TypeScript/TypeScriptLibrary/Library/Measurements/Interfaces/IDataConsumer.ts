import { IMeasurements } from "./IMeasurements";

export interface IDataConsumer
{

    getAllMeasurements(): IMeasurements[];
    addMeasurements(item: IMeasurements) : void;
}
