"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataConsumerBoolFunc = void 0;
const Performer_1 = require("../Performer");
class DataConsumerBoolFunc {
    constructor(dataConsumer, name) {
        this.performer = new Performer_1.Performer();
        this.measurement = this.performer.getMeasurementDC(dataConsumer, name);
    }
    func() {
        var res = this.measurement.getMeasurementValue();
        if (res != undefined) {
            return this.performer.convertFromAny(res);
        }
        return false;
    }
}
exports.DataConsumerBoolFunc = DataConsumerBoolFunc;
//# sourceMappingURL=DataConsumerBoolFunc.js.map