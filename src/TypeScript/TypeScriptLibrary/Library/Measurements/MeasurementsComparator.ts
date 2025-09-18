import type { IComparator } from "../Interfaces/IComparator";
import { Performer } from "../Performer";
import { IDataConsumer } from "./Interfaces/IDataConsumer";
import type { IMeasurements } from "./Interfaces/IMeasurements";

export class MeasurementsComparator implements IComparator<IMeasurements> {
    constructor(performer: Performer) {
        this.performer = performer;

    }
    compare(x: IMeasurements, y: IMeasurements): number {
        if (x == y) {
            return 0;
        }
        if (this.performer.implementsType(x, "IDataConsumer")) {
            var dcx = x as unknown as IDataConsumer;
            if (this.isSource(dcx, y)) {
                return 1;
            }
        }
        if (this.performer.implementsType(y, "IDataConsumer")) {
            var dcy = y as unknown as IDataConsumer;
            if (this.isSource(dcy, x)) {
                return -1;
            }
        }
        return 0;
    }

    protected isSource(dc : IDataConsumer, m : IMeasurements): boolean {
        var measurements = dc.getAllMeasurements();
        var  count = measurements.length;
        for (var i = 0; i < count; i++)
        {
            var x = measurements[i];
            if (m == x)
            {
                return true;
            }
            if (this.performer.implementsType(x, "IDataConsumer"))
            {
                var dataConsumer = x as unknown as IDataConsumer;
                if (this.isSource(dataConsumer, m))
                {
                    return true;
                }
            }
        }
        return false;
    }

    performer !: Performer;
}