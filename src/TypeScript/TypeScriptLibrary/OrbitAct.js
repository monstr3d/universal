"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.OrbitAct = void 0;
const PefrormerMeasuremets_1 = require("./Library/Measurements/PefrormerMeasuremets");
const DetaRuntimeConsumer_1 = require("./Library/Measurements/Runtime/DetaRuntimeConsumer");
const Orbital_1 = require("./src/Orbital");
class OrbitAct extends Orbital_1.Orbital {
    constructor() {
        super();
        this.dc = this.getCategoryObjects()[1];
    }
    act() {
        var k = this.dc.getAllMeasurements();
        var a = k[0].getMeasurement(0).getMeasurementValue();
        var b = k[1].getMeasurement(0).getMeasurementValue();
    }
    test() {
        var runtime = new DetaRuntimeConsumer_1.DetaRuntimeConsumer(this.dc);
        var p = new PefrormerMeasuremets_1.PefrormerMeasuremets();
        p.peformCalculation(runtime, 0, 1, 3, this.act);
    }
}
exports.OrbitAct = OrbitAct;
//# sourceMappingURL=OrbitAct.js.map