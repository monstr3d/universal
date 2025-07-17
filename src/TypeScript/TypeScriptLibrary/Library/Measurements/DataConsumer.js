"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataConsumer = void 0;
const CategoryObject_1 = require("../CategoryObject");
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
class DataConsumer extends CategoryObject_1.CategoryObject {
    constructor() {
        super(...arguments);
        this.measurements = [];
    }
    PostSetArrow() {
        try {
            throw new OwnNotImplemented_1.OwnNotImplemented();
        }
        catch (e) { }
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