"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DonchianSequenceFilter = void 0;
const QueueFilter_1 = require("./QueueFilter");
class DonchianSequenceFilter extends QueueFilter_1.QueueFilter {
    getOwnValue() {
        var p = this.performer;
        var x = this.arr;
        var y = this.max ? p.findMaxWithReduce(x) : p.findMinWithReduce(x);
        return y;
    }
    constructor(count, max) {
        super(count);
        this.max = max;
    }
    max = true;
}
exports.DonchianSequenceFilter = DonchianSequenceFilter;
