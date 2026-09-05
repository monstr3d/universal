import { QueueFilter } from "./QueueFilter";

export class AverageSequenceFilter extends QueueFilter {

    constructor(count: number) {
        super(count);
    }

    protected getOwnValue(l: boolean): number | undefined {
        if (!l) return undefined
        let a = this.queue.toArray()
        return this.performer.calculateAverage(a)
    }
}