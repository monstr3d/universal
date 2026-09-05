import type { IGameLoaderFactory } from "../../Game/Interfaces/IGameLoaderFactory";
import type { ILoader } from "../../Interfaces/ILoader";
import type { IObject } from "../../Interfaces/IObject";

export abstract class AbstractGameLoaderFactory implements IObject, IGameLoaderFactory {
    abstract getLoader(object: any): ILoader

    getName(): string {
        return this.name;
    }


    getClassName(): string {
        return this.typeName;
    }

    imlplementsType(type: string): boolean {
        return this.types.includes(type);
    }

    protected typeName: string = "AbstracGameLoaderFactory";

    protected types: string[] = ["IObject", "IGameLoaderFactory", "AbstracGameLoaderFactory"];

    protected name: string = "";

}