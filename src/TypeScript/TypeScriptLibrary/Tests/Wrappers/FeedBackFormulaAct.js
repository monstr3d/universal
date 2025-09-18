"use strict";
// FeedBackFormulaAct.ts
// Wrapper for FeedBackFormulaAct logic
Object.defineProperty(exports, "__esModule", { value: true });
exports.FeedBackFormulaAct = void 0;
const PefrormerMeasuremets_1 = require("../../Library/Measurements/PefrormerMeasuremets");
const Performer_1 = require("../../Library/Performer");
const DataRuntimeConsumer_1 = require("../../Library/Runtime/DataRuntimeConsumer");
const FeedBackFormula_1 = require("../FeedBackFormula");
class FeedBackFormulaAct extends FeedBackFormula_1.FeedBackFormula {
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
exports.FeedBackFormulaAct = FeedBackFormulaAct;
//# sourceMappingURL=FeedBackFormulaAct.js.map