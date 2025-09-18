"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ODE_FeedbackAct = void 0;
const OwnNotImplemented_1 = require("../../Library/ErrorHandler/OwnNotImplemented");
const RungeProcessor_1 = require("../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor");
const PefrormerMeasuremets_1 = require("../../Library/Measurements/PefrormerMeasuremets");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
const ODE_Feedback_1 = require("../ODE_Feedback");
class ODE_FeedbackAct extends ODE_Feedback_1.ODE_Feedback {
    constructor() {
        super();
        var o = this.getCategoryObjects();
        this.dc = o[2];
    }
    action() {
        var k = this.dc.getAllMeasurements()[0];
        var a = k.getMeasurement(0).getMeasurementValue();
        var b = k.getMeasurement(1).getMeasurementValue();
        console.log(a, b);
    }
    func() {
        return false;
    }
    test() {
        try {
            let processor = new RungeProcessor_1.RungeProcessor();
            var runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, processor);
            var p = new PefrormerMeasuremets_1.PefrormerMeasuremets();
            p.performFixedStepCalculation(runtime, 0, 0.4, 45, this, this);
        }
        catch (e) {
            throw new OwnNotImplemented_1.OwnNotImplemented();
        }
    }
}
exports.ODE_FeedbackAct = ODE_FeedbackAct;
//# sourceMappingURL=ODE_FeedbackAct.js.map