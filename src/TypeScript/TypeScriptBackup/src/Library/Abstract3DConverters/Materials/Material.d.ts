import type { IObject } from "../../Interfaces/IObject";
import type { INamed } from "../../NamedTree/Interfaces/INamed";
import { Performer } from "../../Performer";
export declare class Material implements INamed, IObject {
    constructor(name: string);
    getNamedName(): string;
    setNamedName(name: string): void;
    getName(): string;
    getClassName(): string;
    imlplementsType(type: string): boolean;
    protected typeName: string;
    protected types: string[];
    performer: Performer;
    namedName: string;
}
//# sourceMappingURL=Material.d.ts.map