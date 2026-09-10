import type { IGameLoaderFactory } from "../../Game/Interfaces/IGameLoaderFactory";
import type { ILoader } from "../../Interfaces/ILoader";
import type { IObject } from "../../Interfaces/IObject";
export declare abstract class AbstractGameLoaderFactory implements IObject, IGameLoaderFactory {
    abstract getLoader(object: any): ILoader;
    getName(): string;
    getClassName(): string;
    imlplementsType(type: string): boolean;
    protected typeName: string;
    protected types: string[];
    protected name: string;
}
//# sourceMappingURL=AbstractGameLoaderFactory.d.ts.map