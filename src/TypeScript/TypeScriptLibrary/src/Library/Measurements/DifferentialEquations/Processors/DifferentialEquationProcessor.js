"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DifferentialEquationProcessor = void 0;
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
const OwnNotImplemented_1 = require("../../../ErrorHandler/OwnNotImplemented");
const Performer_1 = require("../../../Performer");
class DifferentialEquationProcessor {
    actionT2(t1, t2) {
        this.stepDifferentialEquations(t1, t2);
    }
    isEmptyActionT2() {
        return false;
    }
    getName() {
        return this.name;
    }
    getClassName() {
        return this.typeName;
    }
    imlplementsType(type) {
        return this.types.includes(type);
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
        this.fstart = start;
        this.ffinish = finish;
        throw new OwnNotImplemented_1.OwnNotImplemented("DifferentialEquationProcessor");
    }
    fstart = 0;
    ffinish = 0;
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
        throw new OwnNotImplemented_1.OwnNotImplemented("DifferentialEquationProcessor");
    }
    getDifferentialEquationsDimention() {
        return 0;
    }
    performer = new Performer_1.Performer();
    dimension = 0;
    equations = [];
    norm = [];
    measurements = [];
    timeProvider;
    typeName = "DifferentialEquationProcessor";
    types = ["IObject", "IDifferentialEquationProcessor", "DifferentialEquationProcessor"];
    name = "";
}
exports.DifferentialEquationProcessor = DifferentialEquationProcessor;
