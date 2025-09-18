/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IDesktop } from "../../../Interfaces/IDesktop";
import type { IPostSetArrow } from "../../../Interfaces/IPostSetArrow";
import type { IValue } from "../../../Interfaces/IValue";
import { DataConsumerVariableMeasurementsStarted } from "../../DataConsumerVariableMeasurementsStarted";
import type { ITimeMeasurementProvider } from "../../Interfaces/ITimeMeasurementProvider";
import { Variable } from "../../Variables/Variable";
import type { IDifferentialEquationSolver } from "../Interfaces/IDifferentialEquationSolver";

export class DifferentialEquationSolverFormula extends DataConsumerVariableMeasurementsStarted
    implements IDifferentialEquationSolver, IPostSetArrow {

    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name);
        this.typeName = "DifferentialEquationSolverFormula";
        this.types.push("IDifferentialEquationSolver");
        this.types.push("IPostSetArrow");
        this.types.push("DifferentrialEquationSolverFormula");
    }
    setDifferentialEquationSolverTimeProvider(time: ITimeMeasurementProvider): void {
        this.time = time;
    }
    getDifferentialEquationSolverTimeProvider(): ITimeMeasurementProvider {
        return this.time;
    }

    startedStart(start: number): void
    {
        this.initial.resetInitialValues();
        this.feedback.setFeedbacks();
    }


    calculateDerivations(): void
    {
        this.feedback.setFeedbacks();
        this.performer.updateChildrenData(this);
        this.calculateTree();
        this.save();
    }

    copyVariablesToSolver(offset: number, variables: number[]): void
    {
        let n = this.output.length;
        for (var i = 0; i < n; i++)
        {
            this.output[i].setIValue(variables[i + offset]);
        }
    }

    calculateTree(): void
    {

    }

    save(): void
    {

    }

    init(): void
    {

    }

    protected addVariableValue(name: string, type: any, value: any): void
    {
        let variable = new Variable(name, type, value);
        let derivation = new Variable("D" + name, 0, 0);
        variable.setDerivation(derivation);
        this.derivations.set(name, derivation);
        this.addVariable(variable);
        this.deri.push(derivation);
    }



    postSetArrow(): void
    {
        this.init();
        this.setInitial();
        this.setFeedback();
    }

    protected derivations: Map<string, IValue> = new Map();

    protected deri: IValue[] = [];

    time !: ITimeMeasurementProvider;


   
}