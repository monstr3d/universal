"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataConsumer = void 0;
const CategoryObject_1 = require("../CategoryObject");
class DataConsumer extends CategoryObject_1.CategoryObject {
    constructor(desktop, name) {
        super(desktop, name);
        this.success = true;
        this.mapOperations = new Map;
        this.measurements = [];
        this.typeName = "DataConsumer";
        this.types.push("DataConsumer");
        this.types.push("IDataConsumer");
        this.types.push("IPostSetArrow");
        this.types.push("ITimeMeasurementConsumer");
        this.tms = this;
        this.dataConsumer = this;
    }
    getInternalTime() {
        var tm = this.timeMeasurement;
        return tm.getTime();
    }
    getTimeMeasutement() {
        return this.timeMeasurement;
    }
    setTimeMeasurement(measurement) {
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