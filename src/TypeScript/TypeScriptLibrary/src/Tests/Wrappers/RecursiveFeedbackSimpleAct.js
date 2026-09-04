"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RecursiveFeedbackSimpleAct = void 0;
const PerformerMeasuremets_1 = require("../../Library/Measurements/PerformerMeasuremets");
const Motion6DFactory_1 = require("../../Library/Motion6D/Motion6DFactory");
const Performer_1 = require("../../Library/Performer");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
const RecursiveFeedbackSimple_1 = require("../RecursiveFeedbackSimple");
class RecursiveFeedbackSimpleAct extends RecursiveFeedbackSimple_1.RecursiveFeedbackSimple {
    dc;
    factory = new Motion6DFactory_1.Motion6DFactory;
    constructor() {
        super();
        this.dc = this.performer.getByType(this, "DataConsumer")[0];
    }
    isEmptyAction() {
        return false;
    }
    func() {
        return false;
    }
    action() {
        this.performer.print(this.dc);
    }
    performer = new Performer_1.Performer();
    test() {
        var runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, this.factory);
        var p = new PerformerMeasuremets_1.PerformerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 0.1, 30, this, this);
    }
}
exports.RecursiveFeedbackSimpleAct = RecursiveFeedbackSimpleAct;
