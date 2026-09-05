import type { IRealtimeCollectionFactory } from "../Interfaces/IRealtimeCollectionFactory";
import type { IDifferentialEquationProcessor } from "../Measurements/DifferentialEquations/Interfaces/IDifferentialEquationProcessor ";
import { RungeProcessor } from "../Measurements/DifferentialEquations/Processors/RungeProcessor";
import { UniversalFactory } from "../UniversalFactory";
import { Motion6DRealtimeFactory } from "./Runtime/Event/Motion6DRealtimeFactory";

export class Motion6DFactory extends UniversalFactory {
    constructor() {
        super()
        this.types.push("Motion6DFactory")
        this.typeName = "Motion6DFactory"
        let processor = new RungeProcessor();
        this.addFactory<IDifferentialEquationProcessor>(processor, "IDifferentialEquationProcessor")
        let f = new Motion6DRealtimeFactory(this)
        this.addFactory<IRealtimeCollectionFactory>(f, "IRealtimeCollectionFactory")
    }
}
