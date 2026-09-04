/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { OwnNotImplemented } from "../../../ErrorHandler/OwnNotImplemented";

import { Performer } from "../../../Performer";
import type { IMeasurements } from "../../Interfaces/IMeasurements";
import type { INormalizable } from "../../Interfaces/INormalizable";
import type { ITimeMeasurementProvider } from "../../Interfaces/ITimeMeasurementProvider";
import type { IDifferentialEquationProcessor } from "../Interfaces/IDifferentialEquationProcessor ";
import type { IDifferentialEquationSolver } from "../Interfaces/IDifferentialEquationSolver";


export class DifferentialEquationProcessor implements IDifferentialEquationProcessor
{
    actionT2(t1: number, t2: number): void {
        this.stepDifferentialEquations(t1, t2)
    }
    isEmptyActionT2(): boolean {
        return false
    }
     
    getName(): string {
        return this.name;
    }


    getClassName(): string {
        return this.typeName;
    }

    imlplementsType(type: string): boolean {
        return this.types.includes(type);
    }

  
    getDifferentialEquations(): IDifferentialEquationSolver[] {
        return this.equations;
    }

    addRangeDifferentialEquations(equations: IDifferentialEquationSolver[]): void
    {
        for (let e of equations)
        {
            this.equations.push(e);
            let m = e as unknown as IMeasurements;
            this.measurements.push(m);
        }
    }

    stepDifferentialEquations(start: number, finish: number): void
    {
        this.fstart = start
        this.ffinish = finish
        throw new OwnNotImplemented("DifferentialEquationProcessor");
    }

    fstart: number = 0
    ffinish: number = 0
    updateDimension(): void
    {
        this.dimension = 0;
        for (var m of this.measurements)
        {
            this.dimension += m.getMeasurementsCount();
        }
    }

 

    getDifferentialEquationsTimeProvider(): ITimeMeasurementProvider {
        return this.timeProvider;
    }

    setDifferentialEquationsTimeProvider(time: ITimeMeasurementProvider): void
    {
        this.timeProvider = time;
    }

    clearDifferentialEquations(): void
    {
        this.measurements.length = 0;
        this.norm.length = 0;
        this.equations.length = 0;
    }

    newDifferentialEquations(): IDifferentialEquationProcessor
    {
        throw new OwnNotImplemented("DifferentialEquationProcessor");
    }

    getDifferentialEquationsDimention(): number
    {
        return 0;
        
    }

    protected performer: Performer = new Performer();

    protected dimension: number = 0;


    protected equations: IDifferentialEquationSolver[] = [];

    protected norm: INormalizable[] = [];

    protected measurements: IMeasurements[] = [];

    protected timeProvider !: ITimeMeasurementProvider;

    protected typeName: string = "DifferentialEquationProcessor";

    protected types: string[] = ["IObject", "IDifferentialEquationProcessor", "DifferentialEquationProcessor"];

    protected name: string = ""


}
