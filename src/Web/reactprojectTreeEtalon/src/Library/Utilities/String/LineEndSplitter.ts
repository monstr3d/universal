import type { IObject } from "../../Interfaces/IObject";
import type { IStringSplitter } from "./Interfaces/IStringSplitter";

export class LineEndSplitter implements IObject, IStringSplitter {

    splitStrings(object: any, str: string): string[] {
        this.object = object
        return str.split('\n')
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

    protected typeName: string = "LineEndSplitter";

    protected types: string[] = ["IObject", "IStringSplitter", "LineEndSplitter"];

    protected name: string = "";

    protected object: any

}