import type { IFactory } from "../Interfaces/IFactory";
import type { IDifferentialEquationProcessor } from "./DifferentialEquations/Interfaces/IDifferentialEquationProcessor";
import { UniversalFactory } from "../UniversalFactory";
import { RungeProcessor } from "./DifferentialEquations/Processors/RungeProcessor";

export const getRungeFactory = () : IFactory => {
    let f = new UniversalFactory();
    let processor = new RungeProcessor();
    f.addFactory<IDifferentialEquationProcessor>(processor, "IDifferentialEquationProcessor")
    return f
}