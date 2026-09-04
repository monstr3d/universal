import { QueueFilter } from "./QueueFilter";

export class DonchianSequenceFilter extends QueueFilter {
    protected getOwnValue(): number | undefined {
        var p = this.performer
        var x = this.arr
        var y = this.max ? p.findMaxWithReduce(x) : p.findMinWithReduce(x)
        return y
    }


    constructor(count: number, max: boolean) {
        super(count)
        this.max = max
    }

    protected max: boolean = true



}