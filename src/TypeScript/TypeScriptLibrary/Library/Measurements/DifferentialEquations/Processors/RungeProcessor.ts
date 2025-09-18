/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IMeasurements } from "../../Interfaces/IMeasurements";
import type { IDifferentialEquationProcessor } from "../Interfaces/IDifferentialEquationProcessor ";
import type { IDifferentialEquationSolver } from "../Interfaces/IDifferentialEquationSolver";
import { DifferentialEquationProcessor } from "./DifferentialEquationProcessor";

export class RungeProcessor extends DifferentialEquationProcessor
{

    w: number[] = [];
    z: number[] = [];
    f: number[] = [];
    k : number[][] = [];
    a: number[] = [0.5, 0.5, 1.0, 1.0, 0.5];



    stepDifferentialEquations(t0: number, t1: number): void
    {
        let dt = t1 - t0;
        let i = 0;
        for (let m of this.measurements)
        {
            let count = m.getMeasurementsCount();
            m.updateMeasurements();
            for (let j = 0; j < count; j++)
            {
                var mea = m.getMeasurement(j);
                var x = mea.getMeasurementValue();
                let v = this.performer.convertFromAny<number>(x);
                this.w[i] = v;
                this.f[i] = v;
                ++i;
            }
            var s = m as unknown as IDifferentialEquationSolver;
            s.copyVariablesToSolver(i - count, this.w);
        }
        let t = t0;
        this.timeProvider.setTime(t);
        i = 0;
        for (let s of this.equations)
        {
            s.calculateDerivations();
            let m = s as unknown as IMeasurements;
            let count = m.getMeasurementsCount();
            for (var j = 0; j < count; j++) {
                var mea = m.getMeasurement(j);
                this.z[i] = this.performer.getDerivationMeasurement(mea);
                this.k[0][i] = this.z[i] * dt;
                this.w[i] = this.f[i] + 0.5 * this.k[0][i];
                ++i;
            }
            s.copyVariablesToSolver(i - count, this.w);
        }
        t = t0 + 0.5 * dt;
        this.timeProvider.setTime(t);
        i = 0;
        for (let s of this.equations)
        {
            s.calculateDerivations();
            let m = s as unknown as IMeasurements;
            let count = m.getMeasurementsCount();
            for (var j = 0; j < count; j++)
            {
                var mea = m.getMeasurement(j);
                this.z[i] = this.performer.getDerivationMeasurement(mea);
                this.k[1][i] = this.z[i] * dt;
                this.w[i] = this.f[i] + 0.5 * this.k[1][i];
                ++i;
            }
            s.copyVariablesToSolver(i - count, this.w);
        }
        t = t0 + 0.5 * dt;
        this.timeProvider.setTime(t);
        i = 0;
        for (let s of this.equations)
        {
            s.calculateDerivations();
            let m = s as unknown as IMeasurements;
            let count = m.getMeasurementsCount();
            for (var j = 0; j < count; j++)
            {
                var mea = m.getMeasurement(j);
                this.z[i] = this.performer.getDerivationMeasurement(mea);
                this.k[2][i] = this.z[i] * dt;
                this.w[i] = this.f[i] + this.k[2][i];
                ++i;
            }
            s.copyVariablesToSolver(i - count, this.w);
        }
        t = t0 + dt;
        this.timeProvider.setTime(t);
        i = 0;
        for (let s of this.equations)
        {
            s.calculateDerivations();
            let m = s as unknown as IMeasurements;
            let count = m.getMeasurementsCount();
            for (var j = 0; j < count; j++)
            {
                var mea = m.getMeasurement(j);
                this.z[i] = this.performer.getDerivationMeasurement(mea);
                this.k[3][i] = this.z[i] * dt;
                ++i;
            }
            s.copyVariablesToSolver(i - count, this.w);

        }
        i = 0;
        for (let s of this.equations)
        {
            let m = s as unknown as IMeasurements;
            var count = m.getMeasurementsCount();
            for (var j = 0; j < count; j++)
            {
                let c = (this.k[0][i] + 2 * this.k[1][i] + 2 * this.k[2][i] + this.k[3][i]) / 6;
                this.f[i] += c;
                ++i;
            }
            s.copyVariablesToSolver(i - count, this.f);
        }
    }




   



    updateDimension(): void
    {
        super.updateDimension()
        let n = this.dimension;
        this.z = new Array(n);
        this.f = new Array(n);
        this.w = new Array(n);
        for (let i = 0; i < 4; i++)
        {
            let x: number[] = new Array(n);
            this.k.push(x);
        }
    }

    newDifferentialEquations(): IDifferentialEquationProcessor {
        return new RungeProcessor();
    }

}