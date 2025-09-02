"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EulerProcessor = void 0;
const DifferentialEquationProcessor_1 = require("./DifferentialEquationProcessor");
class EulerProcessor extends DifferentialEquationProcessor_1.DifferentialEquationProcessor {
    constructor() {
        super(...arguments);
        this.w = [];
    }
    stepDifferentialEquations(start, finish) {
        let dt = finish - start;
        let i = 0;
        for (let m of this.measurements) {
            m.updateMeasurements();
            for (let j = 0; j < m.getMeasurementsCount(); j++) {
                var mea = m.getMeasurement(j);
                var x = mea.getMeasurementValue();
                this.w[i] = this.performer.convertFromAny(x);
                ++i;
            }
        }
        i = 0;
        for (let s of this.equations) {
            s.calculateDerivations();
            let m = s;
            let count = m.getMeasurementsCount();
            for (var j = 0; j < count; j++) {
                var mea = m.getMeasurement(j);
                var v = this.performer.getDerivationMeasurement(mea);
                var y = this.performer.convertFromAny(v);
                this.w[i] += y * dt;
                ++i;
            }
            s.copyVariablesToSolver(i - count, this.w);
        }
    }
    updateDimension() {
        super.updateDimension();
        this.w = new Array(this.dimension);
    }
    newDifferentialEquations() {
        return new EulerProcessor();
    }
}
exports.EulerProcessor = EulerProcessor;
//# sourceMappingURL=EulerProcessor.js.map