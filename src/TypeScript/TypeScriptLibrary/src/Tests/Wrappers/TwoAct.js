"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TwoAct = void 0;
const PerformerMeasuremets_1 = require("../../Library/Measurements/PerformerMeasuremets");
const Motion6DFactory_1 = require("../../Library/Motion6D/Motion6DFactory");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
const Two_1 = require("../Two");
class TwoAct extends Two_1.Two {
    dc;
    constructor() {
        super();
        this.dc = this.getCategoryObjects()[1];
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
    factory = new Motion6DFactory_1.Motion6DFactory;
    test() {
        var runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, this.factory);
        var p = new PerformerMeasuremets_1.PerformerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 1, 10, this, this);
    }
}
exports.TwoAct = TwoAct;
