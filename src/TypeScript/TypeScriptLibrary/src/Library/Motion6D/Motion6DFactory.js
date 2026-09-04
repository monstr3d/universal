"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Motion6DFactory = void 0;
const RungeProcessor_1 = require("../Measurements/DifferentialEquations/Processors/RungeProcessor");
const UniversalFactory_1 = require("../UniversalFactory");
const Motion6DRealtimeFactory_1 = require("./Runtime/Event/Motion6DRealtimeFactory");
class Motion6DFactory extends UniversalFactory_1.UniversalFactory {
    constructor() {
        super();
        this.types.push("Motion6DFactory");
        this.typeName = "Motion6DFactory";
        let processor = new RungeProcessor_1.RungeProcessor();
        this.addFactory(processor, "IDifferentialEquationProcessor");
        let f = new Motion6DRealtimeFactory_1.Motion6DRealtimeFactory(this);
        this.addFactory(f, "IRealtimeCollectionFactory");
    }
}
exports.Motion6DFactory = Motion6DFactory;
