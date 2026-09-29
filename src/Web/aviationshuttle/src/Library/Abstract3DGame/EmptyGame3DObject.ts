import type { IObject } from "../Interfaces/IObject";
import { Game3DPerformer } from "./Game3DPerformer";

export class EmptyGame3DObject implements IObject {

    protected performer: Game3DPerformer = new Game3DPerformer()
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

    protected typeName: string = "EmptyGameObject"

    protected types: string[] = ["IObject", "EmptyGame3DObject"]

    protected name: string = ""


}