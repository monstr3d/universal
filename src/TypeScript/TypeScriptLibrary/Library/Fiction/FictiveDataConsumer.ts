import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IDataConsumer } from "../Measurements/Interfaces/IDataConsumer";
import { IMeasurements } from "../Measurements/Interfaces/IMeasurements";

export class FictiveDataConsumer implements IDataConsumer{
    getAllMeasurements(): IMeasurements[] {
        throw new OwnNotImplemented();
    }
    addMeasurements(item: IMeasurements): void {
        throw new OwnNotImplemented();
    }

}