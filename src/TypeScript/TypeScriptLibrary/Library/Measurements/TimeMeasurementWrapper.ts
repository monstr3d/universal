import { Operation } from "../Types/Operation";
import { IMeasurement } from "./IMeasurement";
import { ITimeMeasurementConsumer } from "./ITimeMeasurementConsumer";

export class TimeMeasurementWrapper implements IMeasurement
{

    constructor(consumer: ITimeMeasurementConsumer)
    {
        this.consumer = consumer;
    }
    getName(): string {
        return "Time";
    }
    getType() {
        return 0;
    }
    getOperation(): Operation<any> {
        return this.getValue;
    }

    consumer!: ITimeMeasurementConsumer;

    getValue(): any {
        let tm = this.consumer.getTimeMeasutement();
        return tm.getOperation()();

    }


}

