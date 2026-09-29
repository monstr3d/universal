import { QueueFilter } from "./QueueFilter";

export class DonchianSequenceFilter extends QueueFilter {
    protected getOwnValue(l: boolean): number | undefined {
        if (!l) return undefined
        var p = this.performer
        var x = this.queue.toArray()
        var y = this.max ? p.findMaxWithReduce(x) : p.findMinWithReduce(x)
        return y
    }


    constructor(count: number, max: boolean) {
        super(count)
        this.max = max
    }

    protected max: boolean = true

    any : any



}