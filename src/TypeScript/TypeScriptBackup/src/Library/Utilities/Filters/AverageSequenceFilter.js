"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AverageSequenceFilter = void 0;
const QueueFilter_1 = require("./QueueFilter");
class AverageSequenceFilter extends QueueFilter_1.QueueFilter {
    constructor(count) {
        super(count);
    }
    getOwnValue(l) {
        if (!l)
            return undefined;
        let a = this.queue.toArray();
        return this.performer.calculateAverage(a);
    }
}
exports.AverageSequenceFilter = AverageSequenceFilter;
//# sourceMappingURL=AverageSequenceFilter.js.map