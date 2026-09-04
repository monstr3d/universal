import { Performer } from "../../Performer";
import type { ISequenceFilter } from "./Interfaces/ISequenceFilter";



export abstract class QueueFilter implements ISequenceFilter {


    protected arr: number[] = []

    protected count: number = 2;

    protected a: number = 0;

    protected b: number | undefined = undefined;

    protected performer: Performer = new Performer()

    constructor(count: number) {
        this.count = count;
    }

    getFilterCount(): number {
        return this.count;
    }

    setFilterCount(count: number): void {
        this.count = count;
    }

    protected abstract getOwnValue(): number | undefined

    getFilterValue(a: number): number | undefined {
        this.arr.push(a)
        var c = this.arr.length
        var l = c >= this.count;
        if (!l) return undefined;
        this.b = this.getOwnValue();
        this.arr.shift()
        return this.b
    }

    resetFilter(): void {
        this.arr = []
    }

}