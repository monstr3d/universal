"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ODEAct = void 0;
const RungeProcessor_1 = require("../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor");
const PerformerMeasuremets_1 = require("../../Library/Measurements/PerformerMeasuremets");
const Motion6DFactory_1 = require("../../Library/Motion6D/Motion6DFactory");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
const ODE_1 = require("../ODE");
class ODEAct extends ODE_1.ODE {
    dc;
    constructor() {
        super();
        var o = this.getCategoryObjects();
        this.dc = o[2];
    }
    isEmptyAction() {
        return false;
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
            var runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, new Motion6DFactory_1.Motion6DFactory());
            var p = new PerformerMeasuremets_1.PerformerMeasuremets();
            p.performFixedStepCalculation(runtime, 0, 0.4, 45, this, this);
        }
        catch (e) {
            let i = 0;
        }
    }
}
exports.ODEAct = ODEAct;
