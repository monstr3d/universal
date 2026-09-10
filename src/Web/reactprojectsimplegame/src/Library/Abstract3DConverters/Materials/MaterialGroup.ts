import type { IChildrenT } from "../../NamedTree/Interfaces/IChildrenT";
import { Material } from "./Material";

export class MaterialGroup extends Material implements IChildrenT<Material>
{
    constructor(name: string) {
        super(name)
        this.types.push("IChildrenT<Material>")
        this.types.push("MaterialGroup")
        this.typeName = "MaterialGroup"
    }
    getChildernT(): Material[] {
        return this.materials;
    }
    addChildT(child: Material): void {
        this.materials.push(child)
    }
    removeChildT(child: Material): void {
        this.performer.remove<Material>(this.materials, child)
    }

    


    materials: Material[] = []
}