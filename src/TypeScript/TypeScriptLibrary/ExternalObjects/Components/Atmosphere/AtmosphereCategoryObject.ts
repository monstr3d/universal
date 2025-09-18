/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { types } from "node:util";
import { OwnNotImplemented } from "../../../Library/ErrorHandler/OwnNotImplemented";
import type { ICategoryObject } from "../../../Library/Interfaces/ICategoryObject";
import type { IDesktop } from "../../../Library/Interfaces/IDesktop";
import type { IObject } from "../../../Library/Interfaces/IObject";
import { AtmospherePure } from "./AtmospherePure";
import type { IObjectTransformer } from "../../../Library/Measurements/Interfaces/IObjectTransformer";
import type { ICheck } from "../../../Library/Interfaces/ICheck";
import { Performer } from "../../../Library/Performer";


export class AtmosphereCategoryObject extends AtmospherePure implements ICategoryObject, IObject,
    IObjectTransformer {

    constructor(desktop: IDesktop, name: string) {
        super();
        this.desktop = desktop;
        this.name = name;
        desktop.addCategoryObject(this);
        desktop.addObject(this);
        this.checker = desktop.getCheck();
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
    calculate(input: any[], output: any[]): void {
        var t = this.performer.convertFromAny<number>(input[0])
        this.x[0] = this.performer.convertFromAny<number>(input[1])
        this.x[1] = this.performer.convertFromAny<number>(input[2])
        this.x[2] = this.performer.convertFromAny<number>(input[3])
        var r = this.atmosphere(t, this.x);
        output[0] = r;
    }

    getClassName(): string {
        throw "AtmosphereCategoryObject";
    }
    imlplementsType(type: string): boolean {
        return this.types.indexOf(type) > 0;
    }
    getName(): string {
        return this.name;
    }
    getObject(): Object {
        throw new OwnNotImplemented();
    }
    setObject(obj: Object): void {
        throw new OwnNotImplemented();
    }
    getCategoryObjectName(): string {
        return this.name;
    }
    getDesktop(): IDesktop {
        return this.desktop;
    }

    name: string = "";

    protected types: string[] = ["IObject", "ICategoryObject", "IObjectTransformer", "AtmospherePure", "AtmosphereCategoryObject"];


    desktop !: IDesktop;

    protected checker !: ICheck;

    inp: string[] = ["t", "x", "y", "z"];
    ooutp: string[] = ["Density"];

    a: number = 0;

    x: number[] = [ 0, 0, 0 ];

    performer: Performer = new Performer();
}


