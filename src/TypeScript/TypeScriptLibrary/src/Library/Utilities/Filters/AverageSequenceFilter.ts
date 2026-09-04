import { QueueFilter } from "./QueueFilter";

export class AverageSequenceFilter extends QueueFilter {

    constructor(count: number) {
        super(count);
    }

    protected getOwnValue(): number | undefined {
        return this.performer.calculateAverage(this.arr)
    }
}