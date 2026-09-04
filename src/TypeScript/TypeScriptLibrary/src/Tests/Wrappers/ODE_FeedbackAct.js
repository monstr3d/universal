"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ODE_FeedbackAct = void 0;
const OwnNotImplemented_1 = require("../../Library/ErrorHandler/OwnNotImplemented");
const RungeProcessor_1 = require("../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor");
const PerformerMeasuremets_1 = require("../../Library/Measurements/PerformerMeasuremets");
const Motion6DFactory_1 = require("../../Library/Motion6D/Motion6DFactory");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
const ODE_Feedback_1 = require("../ODE_Feedback");
class ODE_FeedbackAct extends ODE_Feedback_1.ODE_Feedback {
    dc;
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
    isEmptyAction() {
        return false;
    }
    func() {
        return false;
    }
    test() {
        try {
            let processor = new RungeProcessor_1.RungeProcessor();
            var runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, new Motion6DFactory_1.Motion6DFactory());
            var p = new PerformerMeasuremets_1.PerformerMeasuremets();
            p.performFixedStepCalculation(runtime, 0, 0.4, 45, this, this);
        }
        catch (e) {
            throw new OwnNotImplemented_1.OwnNotImplemented();
        }
    }
}
exports.ODE_FeedbackAct = ODE_FeedbackAct;
