"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DonchianSequenceFilter = void 0;
const QueueFilter_1 = require("./QueueFilter");
class DonchianSequenceFilter extends QueueFilter_1.QueueFilter {
    getOwnValue(l) {
        if (!l)
            return undefined;
        var p = this.performer;
        var x = this.queue.toArray();
        var y = this.max ? p.findMaxWithReduce(x) : p.findMinWithReduce(x);
        return y;
    }
    constructor(count, max) {
        super(count);
        this.max = true;
        this.max = max;
    }
}
exports.DonchianSequenceFilter = DonchianSequenceFilter;
//# sourceMappingURL=DonchianSequenceFilter.js.map