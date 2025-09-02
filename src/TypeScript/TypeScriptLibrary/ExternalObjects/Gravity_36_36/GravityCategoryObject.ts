import { FictiveDesktop } from "../../Library/Fiction/FictiveDesktop";
import { ICategoryObject } from "../../Library/Interfaces/ICategoryObject";
import { IDesktop } from "../../Library/Interfaces/IDesktop";
import { IObject } from "../../Library/Interfaces/IObject";
import { IObjectTransformer } from "../../Library/Measurements/Interfaces/IObjectTransformer";
import { Performer } from "../../Library/Performer";
import { Gravity } from "./Gravity.";

export class GravityCategoryObject extends Gravity implements ICategoryObject, IObject, IObjectTransformer
{
    constructor(desktop: IDesktop, name: string) {
        super();
        this.desktop = desktop;
        this.name = name;
        desktop.addCategoryObject(this);
        desktop.addObject(this);
        this.n0 = 36;
        this.nk = 36;
    }
    getInput(): string[] {
        return this.inp;
    }
    getOutput(): string[] {
        return this.ooutp;
    }
    getInputType(i: number) {
        return this.a;
    }
    getOutputType(i: number) {
       return this.a;
    }
    calculate(input: any[], output: any[]): void
    {
        var x = this.convert(input[0]);
        var y = this.convert(input[1]);
        var z = this.convert(input[2]);
        this.Forces(x, y, z, this.fx, this.fy, this.fz);
        output[0] = this.fx[0];
        output[1] = this.fy[0];
        output[2] = this.fz[0];
    }

    getClassName(): string {
        return this.typeName;
    }
    imlplementsType(type: string): boolean {
        return this.types.indexOf(type) >= 0;
    }
    getName(): string {
        return this.name;
    }
    getObject(): Object {
        return this.obj;
    }
    setObject(obj: Object): void {
        this.obj = obj;
    }
    getCategoryObjectName(): string {
        return this.name;
    }
    getDesktop(): IDesktop {
        return this.desktop;
    }

    convert(x: any): number {
        return this.performer.convertFromAny<number>(x);
    }

    performer: Performer = new Performer();

    obj: Object = new Object();

    name: string = "";

    desktop: IDesktop = new FictiveDesktop();

    protected types: string[] = ["IObject", "ICategoryObject", "IObjectTransformer", "GravityCategoryObject"];

    protected typeName: string = "GravityCategoryObject";

    a: number = 0;

    inp: string[] = ["x", "y", "z"];

    ooutp: string[] = ["Gx", "Gy", "Gz"];

    fx: number[] = new Array(1);
    fy: number[] = new Array(1);
    fz: number[] = new Array(1);


}