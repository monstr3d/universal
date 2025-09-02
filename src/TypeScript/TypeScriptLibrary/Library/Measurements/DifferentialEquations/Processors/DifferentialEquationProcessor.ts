import { OwnNotImplemented } from "../../../ErrorHandler/OwnNotImplemented";
import { FictiveTimeMeasurementProvider } from "../../../Fiction/FictiveTimeMeasurementProvider";
import { Performer } from "../../../Performer";
import { IMeasurements } from "../../Interfaces/IMeasurements";
import { INormalizable } from "../../Interfaces/INormalizable";
import { ITimeMeasurementProvider } from "../../Interfaces/ITimeMeasurementProvider";
import { IDifferentialEquationProcessor } from "../Interfaces/IDifferentialEquationProcessor ";
import { IDifferentialEquationSolver } from "../Interfaces/IDifferentialEquationSolver";


export class DifferentialEquationProcessor implements IDifferentialEquationProcessor
{
     
   
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
        throw new OwnNotImplemented();
    }

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
        throw new OwnNotImplemented();
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

    protected timeProvider: ITimeMeasurementProvider = new FictiveTimeMeasurementProvider();

}
