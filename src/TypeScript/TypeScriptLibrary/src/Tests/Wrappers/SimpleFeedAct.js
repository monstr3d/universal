"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SimpleFeedAct = void 0;
const PerformerMeasuremets_1 = require("../../Library/Measurements/PerformerMeasuremets");
const Motion6DFactory_1 = require("../../Library/Motion6D/Motion6DFactory");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
const SimpleFeed_1 = require("../SimpleFeed");
class SimpleFeedAct extends SimpleFeed_1.SimpleFeed {
    dc;
    factory = new Motion6DFactory_1.Motion6DFactory;
    constructor() {
        super();
        var co = this.getCategoryObject("Chart");
        this.dc = co;
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
        var runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, this.factory);
        var p = new PerformerMeasuremets_1.PerformerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 0.001, 1000, this, this);
    }
}
exports.SimpleFeedAct = SimpleFeedAct;
