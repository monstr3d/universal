import type { IChildrenT } from "../../NamedTree/Interfaces/IChildrenT";
import { Material } from "./Material";
export declare class MaterialGroup extends Material implements IChildrenT<Material> {
    constructor(name: string);
    getChildernT(): Material[];
    addChildT(child: Material): void;
    removeChildT(child: Material): void;
    materials: Material[];
}
//# sourceMappingURL=MaterialGroup.d.ts.map