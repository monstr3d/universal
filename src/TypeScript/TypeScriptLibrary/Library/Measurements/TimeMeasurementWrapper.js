"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TimeMeasurementWrapper = void 0;
class TimeMeasurementWrapper {
    constructor(consumer) {
        this.consumer = consumer;
    }
    getName() {
        return "Time";
    }
    getType() {
        return 0;
    }
    getOperation() {
        return this.getValue;
    }
    getValue() {
        let tm = this.consumer.getTimeMeasutement();
        return tm.getOperation()();
    }
}
exports.TimeMeasurementWrapper = TimeMeasurementWrapper;
//# sourceMappingURL=TimeMeasurementWrapper.js.map