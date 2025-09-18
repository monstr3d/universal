"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RecursvieFeedbackAct = void 0;
const PefrormerMeasuremets_1 = require("../../Library/Measurements/PefrormerMeasuremets");
const Performer_1 = require("../../Library/Performer");
const DataRuntimeConsumer_1 = require("../../Library/Runtime/DataRuntimeConsumer");
const RecursiveFeedback_1 = require("../RecursiveFeedback");
class RecursvieFeedbackAct extends RecursiveFeedback_1.RecursiveFeedback {
    constructor() {
        super();
        this.performer = new Performer_1.Performer();
        this.dc = this.performer.getByType(this, "DataConsumer")[0];
    }
    func() {
        return false;
    }
    action() {
        this.performer.print(this.dc);
    }
    test() {
        var runtime = new DataRuntimeConsumer_1.DataRuntimeConsumer(this.dc);
        var p = new PefrormerMeasuremets_1.PefrormerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 0.1, 30, this, this);
    }
}
exports.RecursvieFeedbackAct = RecursvieFeedbackAct;
//# sourceMappingURL=RecursvieFeedbackAct.js.map