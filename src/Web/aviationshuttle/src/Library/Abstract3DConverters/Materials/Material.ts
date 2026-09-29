import type { IObject } from "../../Interfaces/IObject";
import type { INamed } from "../../NamedTree/Interfaces/INamed";
import { Performer } from "../../Performer";

export class Material implements INamed, IObject {

    constructor(name: string) {
        this.namedName = name;
    }

    getNamedName(): string {
        return this.namedName
    }
    setNamedName(name: string): void {
        this.namedName = name
    }

    getName(): string {
        return this.namedName
    }


    getClassName(): string {
        return this.typeName;
    }

    imlplementsType(type: string): boolean {
        return this.types.includes(type);
    }

    protected typeName: string = "Material";

    protected types: string[] = ["IObject", "INamed", "Material"];

    performer: Performer = new Performer()


    namedName: string = ""

}