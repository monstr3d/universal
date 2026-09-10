import { MaterialGroup } from "./MaterialGroup";

export class PhongMaterial extends MaterialGroup {
    constructor(name: string) {
        super(name)
        this.types.push("PhongMategial")
        this.typeName = "PhongMategial"
    }
}