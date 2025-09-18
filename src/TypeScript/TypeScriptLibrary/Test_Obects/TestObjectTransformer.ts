import { CategoryObject } from "../Library/CategoryObject";
import type  { IDesktop } from "../Library/Interfaces/IDesktop";
import type { IObjectTransformer } from "../Library/Measurements/Interfaces/IObjectTransformer";

export class TestObjectTransformer extends CategoryObject implements IObjectTransformer
{
    /// Fieelds

    protected coefficient: number = 0;

    inp: string[] = ["a", "b", "c", "d"];
    ooutp: string[] = ["a", "b", "c", "d"];
    a: number = 0;

    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name);
        this.typeName = "TestObjectTransformer";
        this.types.push("IObjectTransformer");
        this.types.push("TestObjectTransformer");
    }


    getInput(): string[] {
        return this.inp;
    }

    getOutput(): string[] {
        return this.ooutp;
    }

    getInputType(i: number): any {
       return this.a;
    }

    getOutputType(i: number): any {
        return this.a;
    }

    calculate(input: any [], output: any []): void {
        var a = this.convert<number>(input[0]);
        var b = this.convert < number >(input[1]);
        var c = this.convert < number >(input[2]);
        var d = this.convert < number >(input[3]);
        output[0] = this.coefficient * (a + b);
        output[1] = this.coefficient * b * c;
        output[2] = this.coefficient * (c + Math.sin(d));
     }
}