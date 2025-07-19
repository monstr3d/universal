"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataConsumer = void 0;
const CategoryObject_1 = require("../CategoryObject");
class DataConsumer extends CategoryObject_1.CategoryObject {
    constructor(desktop, name) {
        super(desktop, name);
        this.measurements = [];
        this.tms = this;
        this.timeOperation = this.performer.GetNumberTimeOperation(this);
    }
    getInternalTime() {
        return this.timeOperation();
    }
    getTimeMeasutement() {
        return this.timeMeasurement;
    }
    setTimeMeasutement(measurement) {
        this.timeMeasurement = measurement;
        ;
    }
    postSetArrow() {
    }
    getAllMeasurements() {
        return this.measurements;
    }
    addMeasurements(item) {
        this.measurements.push(item);
    }
}
exports.DataConsumer = DataConsumer;
//# sourceMappingURL=DataConsumer.js.map