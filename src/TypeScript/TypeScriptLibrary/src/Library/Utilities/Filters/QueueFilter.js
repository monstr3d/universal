"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.QueueFilter = void 0;
const Performer_1 = require("../../Performer");
class QueueFilter {
    arr = [];
    count = 2;
    a = 0;
    b = undefined;
    performer = new Performer_1.Performer();
    constructor(count) {
        this.count = count;
    }
    getFilterCount() {
        return this.count;
    }
    setFilterCount(count) {
        this.count = count;
    }
    getFilterValue(a) {
        this.arr.push(a);
        var c = this.arr.length;
        var l = c >= this.count;
        if (!l)
            return undefined;
        this.b = this.getOwnValue();
        this.arr.shift();
        return this.b;
    }
    resetFilter() {
        this.arr = [];
    }
}
exports.QueueFilter = QueueFilter;
