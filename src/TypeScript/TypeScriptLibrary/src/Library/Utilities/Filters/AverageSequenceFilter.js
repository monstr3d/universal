"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AverageSequenceFilter = void 0;
const QueueFilter_1 = require("./QueueFilter");
class AverageSequenceFilter extends QueueFilter_1.QueueFilter {
    constructor(count) {
        super(count);
    }
    getOwnValue() {
        return this.performer.calculateAverage(this.arr);
    }
}
exports.AverageSequenceFilter = AverageSequenceFilter;
