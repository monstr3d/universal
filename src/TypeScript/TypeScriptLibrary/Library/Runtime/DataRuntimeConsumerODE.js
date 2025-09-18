"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataRuntimeConsumerODE = void 0;
const DataRuntimeConsumer_1 = require("./DataRuntimeConsumer");
class DataRuntimeConsumerODE extends DataRuntimeConsumer_1.DataRuntimeConsumer {
    constructor(consumer, processor) {
        super(consumer);
        this.differentialEquations = [];
        this.processor = processor.newDifferentialEquations();
        let equations = [];
        for (let measurements of this.measurements) {
            if (this.performer.implementsType(measurements, "IDifferentialEquationSolver")) {
                let solver = measurements;
                equations.push(solver);
            }
        }
        this.processor.addRangeDifferentialEquations(equations);
        this.processor.updateDimension();
    }
    setTimeProvider(timeProvider) {
        super.setTimeProvider(timeProvider);
        this.processor.setDifferentialEquationsTimeProvider(timeProvider);
    }
    stepRuntime(begin, end) {
        this.processor.stepDifferentialEquations(begin, end);
    }
}
exports.DataRuntimeConsumerODE = DataRuntimeConsumerODE;
//# sourceMappingURL=DataRuntimeConsumerODE.js.map