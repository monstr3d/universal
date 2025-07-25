"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataLink = void 0;
const CategoryArrow_1 = require("../CategoryArrow");
class DataLink extends CategoryArrow_1.CategoryArrow {
    constructor(desktop, name) {
        super(desktop, name);
        this.typeName = "DataLink";
        this.types.push("DataLink");
    }
    getSource() {
        return this.consumer;
    }
    getTagret() {
        return this.measurements;
    }
    setSource(source) {
        this.consumer = source;
    }
    setTarget(target) {
        this.measurements = target;
        this.consumer.addMeasurements(this.measurements);
    }
    getName() {
        return this.name;
    }
}
exports.DataLink = DataLink;
//# sourceMappingURL=DataLink.js.map