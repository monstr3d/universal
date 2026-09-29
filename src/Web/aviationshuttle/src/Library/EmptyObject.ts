import type { IObject } from "./Interfaces/IObject";
import { Performer } from "./Performer";

export class EmptyObject implements IObject {

    protected performer : Performer = new Performer()
    constructor(name: string) {
        this.name = name
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

    protected typeName: string = "EmptyObject"

    protected types: string[] = ["IObject",  "EmptyObject"]

    protected name: string = ""

}