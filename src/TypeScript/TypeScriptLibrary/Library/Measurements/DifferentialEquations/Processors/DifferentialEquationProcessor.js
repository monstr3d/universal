"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DifferentialEquationProcessor = void 0;
const OwnNotImplemented_1 = require("../../../ErrorHandler/OwnNotImplemented");
const FictiveTimeMeasurementProvider_1 = require("../../../Fiction/FictiveTimeMeasurementProvider");
const Performer_1 = require("../../../Performer");
class DifferentialEquationProcessor {
    constructor() {
        this.performer = new Performer_1.Performer();
        this.dimension = 0;
        this.equations = [];
        this.norm = [];
        this.measurements = [];
        this.timeProvider = new FictiveTimeMeasurementProvider_1.FictiveTimeMeasurementProvider();
    }
    getDifferentialEquations() {
        return this.equations;
    }
    addRangeDifferentialEquations(equations) {
        for (let e of equations) {
            this.equations.push(e);
            let m = e;
            this.measurements.push(m);
        }
    }
    stepDifferentialEquations(start, finish) {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    updateDimension() {
        this.dimension = 0;
        for (var m of this.measurements) {
            this.dimension += m.getMeasurementsCount();
        }
    }
    getDifferentialEquationsTimeProvider() {
        return this.timeProvider;
    }
    setDifferentialEquationsTimeProvider(time) {
        this.timeProvider = time;
    }
    clearDifferentialEquations() {
        this.measurements.length = 0;
        this.norm.length = 0;
        this.equations.length = 0;
    }
    newDifferentialEquations() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    getDifferentialEquationsDimention() {
        return 0;
    }
}
exports.DifferentialEquationProcessor = DifferentialEquationProcessor;
//# sourceMappingURL=DifferentialEquationProcessor.js.map