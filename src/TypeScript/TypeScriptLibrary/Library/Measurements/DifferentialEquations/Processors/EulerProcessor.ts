import { IMeasurements } from "../../Interfaces/IMeasurements";
import { IDifferentialEquationProcessor } from "../Interfaces/IDifferentialEquationProcessor ";
import { DifferentialEquationProcessor } from "./DifferentialEquationProcessor";

export class EulerProcessor extends DifferentialEquationProcessor
{

    w: number[] = [];

 

    stepDifferentialEquations(start: number, finish: number): void
    {
        let dt = finish - start;
        let i = 0;
        for (let m of this.measurements)
        {
            m.updateMeasurements();
            for (let j = 0; j < m.getMeasurementsCount(); j++)
            {
                var mea = m.getMeasurement(j);
                var x = mea.getMeasurementValue();
                this.w[i] = this.performer.convertFromAny<number>(x);
                ++i;
            }
        }
        i = 0;
        for (let s of this.equations)
        {
            s.calculateDerivations();
            let m = s as unknown as IMeasurements;
            let count = m.getMeasurementsCount();
            for (var j = 0; j < count; j++)
            {
                var mea = m.getMeasurement(j);
                var v = this.performer.getDerivationMeasurement(mea);
                var y = this.performer.convertFromAny<number>(v);
                this.w[i] +=  y * dt;
                ++i;
            }
            s.copyVariablesToSolver(i - count, this.w);
        }

    }

    updateDimension(): void
    {
        super.updateDimension();
        this.w = new Array(this.dimension);
    }

    newDifferentialEquations(): IDifferentialEquationProcessor
    {
        return new EulerProcessor();
    }

}