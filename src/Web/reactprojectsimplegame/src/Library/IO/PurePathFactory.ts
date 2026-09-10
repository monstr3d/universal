import type { IPathFactory } from "./Interfaces/IPathFactory";
import type { IObject } from "../Interfaces/IObject";
import type { IPath } from "./Interfaces/IPath";
import { PurePath } from "./PurePath";

export class PurePathFactory implements IPathFactory, IObject {
    createPath(obj: any): IPath {
        this.any = obj
        return new PurePath();
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

    protected typeName: string = "PurePathFactory";

    protected types: string[] = ["IObject", "IPathFactory", "PurePathFactory"];

    protected name: string = "";

    protected any !: any

}