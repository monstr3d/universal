import { IDataConsumer } from "./IDataConsumer";
import { IMeasurements } from "./IMeasurements";

export class PefrormerMeasuremets {

    getDependentPrivate(dataConsumer: IDataConsumer, measurements: IMeasurements[]) : void {

        let m = dataConsumer.getAllMeasurements();
        for (let i = o; i < m.length; i++) {
            let mea = m[i];
            if (measurements.find(mea => true) === undefined) {

            }
            else
            {
                measurements.push(mea);
                if (mea instanceof IDataConsumer) {

                }

            }
        }
    }
}