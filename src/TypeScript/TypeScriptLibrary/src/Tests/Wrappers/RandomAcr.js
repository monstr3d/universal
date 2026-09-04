"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RandomAct = void 0;
const PerformerMeasuremets_1 = require("../../Library/Measurements/PerformerMeasuremets");
const Motion6DFactory_1 = require("../../Library/Motion6D/Motion6DFactory");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
const Random_1 = require("../Random");
class RandomAct extends Random_1.Random {
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
        console.log(a);
    }
    func() {
        return false;
    }
    test() {
        var runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, this.factory);
        var p = new PerformerMeasuremets_1.PerformerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 1, 1000, this, this);
    }
}
exports.RandomAct = RandomAct;
