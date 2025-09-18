/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IMeasurements } from "./IMeasurements";

export interface IDataConsumer
{
    getAllMeasurements(): IMeasurements[];
    addMeasurements(item: IMeasurements) : void;
}
