"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.OrbitAct = void 0;
const PefrormerMeasuremets_1 = require("./Library/Measurements/PefrormerMeasuremets");
const DetaRuntimeConsumer_1 = require("./Library/Runtime/DetaRuntimeConsumer");
const Orbital_1 = require("./src/Orbital");
class OrbitAct extends Orbital_1.Orbital {
    constructor() {
        super();
        this.dc = this.getCategoryObjects()[1];
    }
    action() {
        var k = this.dc.getAllMeasurements()[0];
        var a = k.getMeasurement(0).getMeasurementValue();
        var b = k.getMeasurement(1).getMeasurementValue();
        console.log(a, b);
    }
    test() {
        var runtime = new DetaRuntimeConsumer_1.DetaRuntimeConsumer(this.dc);
        var p = new PefrormerMeasuremets_1.PefrormerMeasuremets();
        p.peformFixedStepCalculation(runtime, 0, 1, 10, this);
    }
}
exports.OrbitAct = OrbitAct;
//# sourceMappingURL=OrbitAct.js.map