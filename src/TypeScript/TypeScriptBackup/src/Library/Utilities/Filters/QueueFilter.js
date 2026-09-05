"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.QueueFilter = void 0;
const Performer_1 = require("../../Performer");
const queue_typescript_1 = require("queue-typescript");
class QueueFilter {
    constructor(count) {
        // protected arr: number[] = []
        //  protected copy: number[] = []
        this.count = 2;
        this.x = [];
        this.performer = new Performer_1.Performer();
        this.count = count;
        this.queue = new queue_typescript_1.Queue();
    }
    getFilterData() {
        return this.queue;
    }
    getFilterCount() {
        return this.count;
    }
    setFilterCount(count) {
        this.count = count;
    }
    getFilterValue(a) {
        this.queue.enqueue(a);
        let k = this.queue.length - this.count;
        if (k > 0)
            this.queue.dequeue();
        let b = this.getOwnValue(k >= 0);
        return b;
    }
    resetFilter() {
        this.queue = new queue_typescript_1.Queue();
    }
}
exports.QueueFilter = QueueFilter;
//# sourceMappingURL=QueueFilter.js.map