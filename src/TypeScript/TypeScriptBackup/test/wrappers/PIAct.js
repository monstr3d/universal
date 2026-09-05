"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PIAct = void 0;
const PerformerMeasuremets_1 = require("../../src/Library/Measurements/PerformerMeasuremets");
const DataRuntimeConsumer_1 = require("../../src/Library/Runtime/DataRuntimeConsumer");
const UniversalFactory_1 = require("../../src/Library/UniversalFactory");
const PI_1 = require("../tests/PI");
class PIAct extends PI_1.PI {
    constructor() {
        super();
        var co = this.getCategoryObject("Chart");
        this.dc = co;
    }
    action() {
        var k = this.dc.getAllMeasurements()[0];
        var a = k.getMeasurement(0).getMeasurementValue();
        console.log(a);
    }
    isEmptyAction() { return false; }
    func() {
        return false;
    }
    test() {
        var runtime = new DataRuntimeConsumer_1.DataRuntimeConsumer(this.dc, new UniversalFactory_1.UniversalFactory());
        var p = new PerformerMeasuremets_1.PerformerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 0.001, 1000, this, this);
    }
}
exports.PIAct = PIAct;
//# sourceMappingURL=PIAct.js.map