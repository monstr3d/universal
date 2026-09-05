import type { IObject } from "../Interfaces/IObject";
import { Game3DPerformer } from "./Game3DPerformer";
export declare class EmptyGame3DObject implements IObject {
    protected performer: Game3DPerformer;
    constructor(name: string);
    getName(): string;
    getClassName(): string;
    imlplementsType(type: string): boolean;
    protected typeName: string;
    protected types: string[];
    protected name: string;
}
//# sourceMappingURL=EmptyGame3DObject.d.ts.map