"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataRuntimeConsumerODE = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
const DataRuntimeConsumer_1 = require("./DataRuntimeConsumer");
class DataRuntimeConsumerODE extends DataRuntimeConsumer_1.DataRuntimeConsumer {
    constructor(consumer, factory) {
        super(consumer, factory);
        this.differentialEquations = [];
        this.typeName = "DataRuntimeConsumerODE";
        this.types.push("IStepActionHolder");
        this.types.push("DataRuntimeConsumerODE");
        let processor = factory.getFactory("IDifferentialEquationProcessor");
        if (processor === undefined) {
            throw new OwnNotImplemented_1.OwnNotImplemented("DataRuntimeConsumerODE");
        }
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
    getStepAction() {
        return this.processor;
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