
import { Performer } from "../../Performer";
import type { ISequenceFilter } from "./Interfaces/ISequenceFilter";

import { Queue } from 'queue-typescript';


export abstract class QueueFilter implements ISequenceFilter {


   // protected arr: number[] = []

  //  protected copy: number[] = []

    protected count: number = 2;


    protected queue !: Queue<number> 

   protected x : number[] = []


    protected performer: Performer = new Performer()


    constructor(count: number) {
        this.count = count;
        this.queue = new Queue<number>()
    }
    getFilterData() {
        return this.queue
    }

    getFilterCount(): number {
        return this.count;
    }

    setFilterCount(count: number): void {
        this.count = count;
    }

    protected abstract getOwnValue(b: boolean): number | undefined

    getFilterValue(a: number): number | undefined {
        this.queue.enqueue(a)
        let k = this.queue.length - this.count
        if (k > 0) this.queue.dequeue()
        let b = this.getOwnValue(k >= 0);
        return b
    }

    resetFilter(): void {
        this.queue = new Queue<number>()
    }

}